using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegeditCE
{
    public partial class NewValue : Form
    {
        public NewValue()
        {
            InitializeComponent();

            cbType.Items.Add(RegistryValueKind.Binary.ToString());
            cbType.Items.Add(RegistryValueKind.DWord.ToString());
            cbType.Items.Add(RegistryValueKind.ExpandString.ToString());
            cbType.Items.Add(RegistryValueKind.MultiString.ToString());
            cbType.Items.Add(RegistryValueKind.QWord.ToString());
            cbType.Items.Add(RegistryValueKind.String.ToString());
        }

        private string strName;
        private string strValue;
        private RegistryValueKind keyType;

        public string VName
        {
            get { return strName; }
            set
            {
                strName = value;
                tbName.Text = strName;
            }
        }

        public string Value
        {
            get { return strValue; }
            set
            {
                strValue = value;
                tbValue.Text = strValue;
            }
        }

        public RegistryValueKind Type
        {
            get { return keyType; }
            set
            {
                keyType = value;

                int i=-1;
                do {
                    i++;
                }while(!strName.Equals(((RegistryValueKind)i).ToString()));

                cbType.SelectedIndex = i;
            }
        }

        private void buttonNegative_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void buttonPositive_Click(object sender, EventArgs e)
        {
            strName = tbName.Text;
            strValue = tbValue.Text;
            //keyType = IndexToType(cbType.SelectedIndex);

            this.DialogResult = DialogResult.OK;
        }
    }
}