using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RegeditCE
{
    public partial class NewKey : Form
    {
        public NewKey()
        {
            InitializeComponent();
        }

        private string strMessage;

        public string Message
        {
            get { return strMessage; }
            set
            {
                strMessage = value;
                textboxMessage.Text = strMessage;
            }
        }

        private void buttonPositive_Click(object sender, EventArgs e)
        {
            strMessage = textboxMessage.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}