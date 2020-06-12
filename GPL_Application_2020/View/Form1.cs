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
        Graphics g;

        public Form1()
        {
            InitializeComponent();
            g =panel1.CreateGraphics();
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != null && !textBox1.Text.Equals(""))
            {
                CommandValidations cmdval = new CommandValidations(textBox1);
            if (!cmdval.IsSomethingInvalid)
            {
                try
                {
                   
                    Command c = new Command();
                    c.Commandline(textBox1,g,panel1);
                    
                }
                catch (Exception exc)
                {
                    textBox2.Text += "\r\n" + exc.ToString();
                }
            }
            else if (!cmdval.IsSyntaxValid)
            {
                textBox2.Text += "\r\nCommand Syntax Error.";
            }
            else if (!cmdval.IsParameterValid)
            {
                textBox2.Text += "\r\nParamter Error.";
            }
            else
            {
                textBox2.Text += "\r\nSomething went wrong, try again.";

            }
        }
            else
            {
                textBox2.Text += ("CommandField Must not be Empty");
            }
}

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            panel1.Refresh();
            g.ResetTransform();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            panel1.Refresh();
        }

        private void oPENToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HelpSection hs = new HelpSection();
            hs.Show();
        }
    }
}


