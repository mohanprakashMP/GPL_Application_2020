using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;    

namespace GPL_Application_2020
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void eXITToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lOADToolStripMenuItem_Click(object sender, EventArgs e)
        {


            try
            {
                Stream stream = null;
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Browse File from Specific Folder";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if ((stream = openFileDialog.OpenFile()) != null)
                    {
                        using (stream)
                        {
                            textBox1.Text =File.ReadAllText(openFileDialog.FileName);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Error", "File not Found");
            }
            catch (IOException)
            {
                MessageBox.Show("Error", "IO exception");
            }
        }

        private void sAVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "TXT files(*.txt)|*.txt|All files(*.*)|*.*";
                if (save.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter write = new StreamWriter(File.Create(save.FileName));
                    write.WriteLine(textBox1.Text);
                    write.Close();
                    MessageBox.Show("File Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}


