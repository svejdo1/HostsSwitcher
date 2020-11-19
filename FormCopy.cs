using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Barbar.HostsSwitcher {
  public partial class FormCopy : Form {
    public string FileName {
      get { return txtFileName.Text; }
    }

    public FormCopy(string inputText) {
      InitializeComponent();
      lblText.Text = inputText;
      txtFileName.Text = "NewProfile";
    }

        public FormCopy(string inputText,string startingFileName)
        {
            InitializeComponent();
            lblText.Text = inputText;
            txtFileName.Text = startingFileName;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            txtFileName.Text=txtFileName.Text.Replace(" ", "_");
            txtFileName.Text = txtFileName.Text.Replace("(", "");
            txtFileName.Text = txtFileName.Text.Replace(")", "");
            if (txtFileName.Text.Length==0)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
