using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIProject
{
    public partial class MainForm : Form
    {
        // strings for the saving written data and display about info

        public string WhatToSave;
        public string aboutMe = "This application was created by Abiey Lema" + "\n" +
                                "         For Prog 1815 Spring 2019";

        

        public MainForm()
        {
            InitializeComponent();
        }

        private void textDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextDocumentForm textDocumentForm = new TextDocumentForm(WhatToSave);
            textDocumentForm.MdiParent = this;
            toolStripStatusLabel1.Text = "Text Document Open";



            textDocumentForm.Show();
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {

            TextDocumentForm textDocumentForm = new TextDocumentForm(WhatToSave);
            textDocumentForm.MdiParent = this;
            textDocumentForm.Show();
            toolStripStatusLabel1.Text = "Text Document Open";
            saveAsToolStripMenuItem.Enabled = true;
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextDocumentForm)

            {
                WhatToSave = ActiveMdiChild.ActiveControl.Text;
                


                // the type of files we allow
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

                //we will add the extension to file name if user doesn't provide it
                saveFileDialog1.AddExtension = true;

                // set our initial directory to our working directory
                saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    // save the text we entered to the selected

                   
                    File.WriteAllText(saveFileDialog1.FileName, WhatToSave);
                    
                }
            }

            else
            {

                MessageBox.Show("Only Text Documents Can be saved!");
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "FileTypes (*.txt*txt*.bmp;*.jpg;*.jpeg)|*.txt;*.bmp;*.jpg;*.jpeg|All Files (*.*)|*.*";
            
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string fileType = "";
                fileType = openFileDialog1.FileName;
                fileType = fileType.Substring(fileType.Length - 3);



                

                if(fileType == "txt")
                {
                     StringBuilder stringToDisplay = new StringBuilder();

                    // iterate through files displaying content to screen
                    // with divider and file name displayed
                    foreach (string fileName in openFileDialog1.FileNames)
                    {
                        TextDocumentForm textDocumentForm = new TextDocumentForm(WhatToSave);
                        textDocumentForm.MdiParent = this;
                        textDocumentForm.Show();
                        saveAsToolStripMenuItem.Enabled = true;

                        stringToDisplay.AppendLine(File.ReadAllText(fileName));
                        ActiveMdiChild.ActiveControl.Text = stringToDisplay.ToString();
                        toolStripStatusLabel1.Text = "Text Document Open";
                    }


                }

                

                else
                {


                    

                  
                        ImageDocumentForm imageDocumentForm = new ImageDocumentForm();
                        imageDocumentForm.MdiParent = this;
                        imageDocumentForm.picBox1.ImageLocation = openFileDialog1.FileName;
                        imageDocumentForm.Show();
                        toolStripStatusLabel1.Text = "Image Document Open";



                }


            }
        }

        private void textDocumentToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Text File (*.txt)|*.txt|All Files (*.*)|*.*";
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {



                StringBuilder stringToDisplay = new StringBuilder();

                
                // get file to open for each loop is used but multiselect is set to false
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    TextDocumentForm textDocumentForm = new TextDocumentForm(WhatToSave);
                    textDocumentForm.MdiParent = this;
                    textDocumentForm.Show();

                    stringToDisplay.AppendLine(File.ReadAllText(fileName));
                    ActiveMdiChild.ActiveControl.Text = stringToDisplay.ToString();
                    toolStripStatusLabel1.Text = "Text Document Open";
                }


            }

        }

        private void imageDocumentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = @"C:\";
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg)|*.bmp;*.jpg;*.jpeg";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                ImageDocumentForm imageDocumentForm = new ImageDocumentForm();
                imageDocumentForm.MdiParent = this;
                imageDocumentForm.picBox1.ImageLocation = openFileDialog.FileName; 
                imageDocumentForm.Show();
                toolStripStatusLabel1.Text = "Image Document Open";


            }

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild is TextDocumentForm)

            {
                WhatToSave = ActiveMdiChild.ActiveControl.Text;



                // the type of files we allow
                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

                //we will add the extension to file name if user doesn't provide it
                saveFileDialog1.AddExtension = true;

                // set our initial directory to our working directory
                saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {


                    // save the text we entered to the selected


                    File.WriteAllText(saveFileDialog1.FileName, WhatToSave);

                }
            }

            else
            {

                MessageBox.Show("Only Text Documents Can be saved!");
            }
        }

        private void cascadeWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form frm in this.MdiChildren)
            {
                if (ActiveMdiChild is TextDocumentForm)
                {
                    switch (MessageBox.Show("Do you want to save this document?", "Save", MessageBoxButtons.YesNoCancel))
                    {
                        case DialogResult.Yes:
                            
                                WhatToSave = ActiveMdiChild.ActiveControl.Text;



                                // the type of files we allow
                                saveFileDialog1.Filter = "Text Files (*.txt)|*.txt";

                                //we will add the extension to file name if user doesn't provide it
                                saveFileDialog1.AddExtension = true;

                                // set our initial directory to our working directory
                                saveFileDialog1.InitialDirectory = Environment.CurrentDirectory;

                                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                                {


                                    // save the text we entered to the selected


                                    File.WriteAllText(saveFileDialog1.FileName, WhatToSave);
                                    ActiveMdiChild.Close();


                            }



                            


                            break;
                        case DialogResult.No:

                            ActiveMdiChild.Close();

                            break;

                       
                            

                        
                            
                    }   

                }

                else
                {
                    if (ActiveMdiChild is ImageDocumentForm)

                        ActiveMdiChild.Close();



                }

                







            }
           
                
            



                this.Close();
            
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            
            aboutForm.pictureBox1.Image = Properties.Resources.IMG_3196;
            aboutForm.lblAbout.Text = aboutMe;

            aboutForm.ShowDialog();
            toolStripStatusLabel1.Text = "About Document Open";

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            
            aboutForm.pictureBox1.Image = Properties.Resources.IMG_3196;
            aboutForm.lblAbout.Text = aboutMe;

            aboutForm.ShowDialog();
            toolStripStatusLabel1.Text = "About Document Open";

        }
    }
}
