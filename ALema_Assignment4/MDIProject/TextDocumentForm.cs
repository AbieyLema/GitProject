using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDIProject
{
    public partial class TextDocumentForm : Form
    {
        public static string WhatToSave;
        public TextDocumentForm()
        {
            InitializeComponent();

            
            
            
        }

        //Contructor for instance with a string to save text

        public TextDocumentForm(string WhatToSave)
        {
            InitializeComponent();
            




        }

        // closing event for updating the status bar

        public void TextDocumentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((MainForm)this.MdiParent).toolStripStatusLabel1.Text = "No Document Open";
        }
    }
}
