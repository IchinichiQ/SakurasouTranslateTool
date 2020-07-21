using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SakurasouTranslateTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string filename = "";

        private void buttonExtract_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();

            myDialog.Filter = "Ssb files (*.ssb)|*.ssb|All files (*.*)|*.*";
            myDialog.RestoreDirectory = true;

            if (myDialog.ShowDialog() == DialogResult.OK)
                filename = myDialog.FileName;
            else
                return;

            using (BinaryReader myReader = new BinaryReader(File.Open(filename, FileMode.Open)))
            {
                int textOffset = -1;
                for (int i = 0; i < myReader.BaseStream.Length; i += 4)
                {
                    myReader.BaseStream.Seek(i, SeekOrigin.Begin);
                    byte[] chunk = myReader.ReadBytes(35);
                    byte[] sample = { 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D, 0x2D };
                    if (chunk.SequenceEqual(sample))
                    {
                        textOffset = i;
                        break;
                    }                   
                }

                if (textOffset == -1)
                {
                    MessageBox.Show("Text not found!", "STT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                dataGridViewStrings.Rows.Clear();

                for (int i = 0; i < myReader.BaseStream.Length; i += 4)
                {
                    myReader.BaseStream.Seek(i, SeekOrigin.Begin);
                    byte[] chunk = myReader.ReadBytes(4);
                    int pointer = BitConverter.ToInt32(chunk, 0) * 4;

                    List<byte> stringBytes = new List<byte>();
                    if (pointer > textOffset)
                    {
                        for (int ii = pointer; ii < myReader.BaseStream.Length; ii++)
                        {
                            myReader.BaseStream.Seek(ii, SeekOrigin.Begin);
                            byte charByte = myReader.ReadByte();
                            if (charByte == 0x00)
                                break;
                            stringBytes.Add(charByte);
                        }

                        if (stringBytes.Count == 0)
                            continue;

                        string myString = Encoding.UTF8.GetString(stringBytes.ToArray());
                        if (myString.StartsWith(" START : ") | myString.StartsWith("V_"))
                            continue;
                        if (myString.StartsWith(" END   : ") | myString.StartsWith("\n★★★\n★★★"))
                            break;

                        dataGridViewStrings.Rows.Add(i.ToString(), myString.Replace("\n","__"));
                    }                 
                }
            }

            labelCurrentFile.Text = Path.GetFileName(filename);
            buttonPatch.Enabled = true;
        }

        private void buttonPatch_Click(object sender, EventArgs e)
        {
            if (filename == "")
                return;

            using (BinaryWriter myWriter = new BinaryWriter(File.Open(filename, FileMode.Open)))
            {
                for (int i = 0; i < dataGridViewStrings.Rows.Count; i++)
                {
                    int pointerOffset = Int32.Parse(dataGridViewStrings.Rows[i].Cells[0].Value?.ToString());
                    byte[] newPointer = BitConverter.GetBytes(Convert.ToUInt32(myWriter.BaseStream.Length / 4));
                    myWriter.Seek(pointerOffset, SeekOrigin.Begin);
                    myWriter.Write(newPointer, 0, newPointer.Length);

                    string newText = dataGridViewStrings.Rows[i].Cells[1].Value?.ToString().Replace("__", "\n");
                    myWriter.Seek(0, SeekOrigin.End);
                    myWriter.Write(Encoding.UTF8.GetBytes(newText));

                    int nullCount = 4 - (Convert.ToInt32(myWriter.BaseStream.Length) % 4);
                    byte[] nulls = new byte[] {0x00, 0x00, 0x00, 0x00 };
                    myWriter.Write(nulls, 0, nullCount);

                    myWriter.Flush();
                }
            }
            MessageBox.Show("Done", "STT", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void itemExport_Click(object sender, EventArgs e)
        {
            if (filename == "")
                return;

            using (SaveFileDialog mySaveFileDialog = new SaveFileDialog())
            {
                mySaveFileDialog.Filter = "Text file (*.txt) | *.txt";

                if (mySaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] myStrings = new string[dataGridViewStrings.Rows.Count];
                    for (int i = 0; i < myStrings.Length; i++)
                    {
                        myStrings[i] = dataGridViewStrings.Rows[i].Cells[1].Value?.ToString();
                    }
                    File.WriteAllLines(mySaveFileDialog.FileName, myStrings);
                }
            }
        }

        private void itemImport_Click(object sender, EventArgs e)
        {
            if (filename == "")
                return;

            using (OpenFileDialog myOpenFileDialog = new OpenFileDialog())
            {
                myOpenFileDialog.Filter = "Text file (*.txt) | *.txt";

                if (myOpenFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] myStrings = File.ReadAllLines(myOpenFileDialog.FileName);
                    for (int i = 0; i < myStrings.Length; i++)
                    {
                        dataGridViewStrings.Rows[i].Cells[1].Value = myStrings[i];
                    }
                }
            }
        }
    }
}
