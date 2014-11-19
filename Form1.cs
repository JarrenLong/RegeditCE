using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace RegeditCE
{
    public partial class wndRegedit : Form
    {
        private static List<string> subKeyList = null;
        private static List<RegValue> subKeyValues = null;
        private static string sCurrentKey = null;
        private static string[] sRootKeys = new string[] {
            //PC\CE Root Keys
            "HKEY_CLASSES_ROOT","HKEY_CURRENT_USER","HKEY_LOCAL_MACHINE","HKEY_USERS",
            //PC only
            //"HKEY_PERFORMANCE_DATA", "HKEY_CURRENT_CONFIG", "HKEY_DYN_DATA"
        };

        public wndRegedit()
        {
            subKeyList = new List<string>();
            subKeyValues = new List<RegValue>();
            sCurrentKey = "";

            InitializeComponent();

            foreach (string s in sRootKeys)
                cbRootKey.Items.Add(s);

            cbRootKey.SelectedIndex = 0;

            cbType.Items.Add(RegistryValueKind.Binary.ToString());
            cbType.Items.Add(RegistryValueKind.DWord.ToString());
            cbType.Items.Add(RegistryValueKind.ExpandString.ToString());
            cbType.Items.Add(RegistryValueKind.MultiString.ToString());
            cbType.Items.Add(RegistryValueKind.QWord.ToString());
            cbType.Items.Add(RegistryValueKind.String.ToString());

            // Show new Dialog
            NewExplorer myForm = new NewExplorer();
            myForm.ShowDialog();
            
        }

        private void UpdateKeyList(string[] keys, bool bUpdateList)
        {
            //Reset list view and key list
            if (bUpdateList)
            {
                subKeyList.Clear();
            }
            listSubkeys.Items.Clear();
            listSubkeys.SelectedIndex = -1;

            if (keys == null || keys.Length < 1)
            {
                listSubkeys.Items.Add("No children");
            }
            else
            {
                foreach (string s in keys)
                {
                    if (bUpdateList)
                    {
                        subKeyList.Add(s);
                    }
                    listSubkeys.Items.Add(s);
                }
            }
        }

        private void UpdateValueList(RegValue[] values)
        {
            listSubvalues.Items.Clear();

            if (values == null || values.Length < 1)
            {
                listSubvalues.Items.Add(new ListViewItem(new string[] { "None", "", "" }));
            }
            else
            {
                foreach (RegValue s in values)
                {
                    listSubvalues.Items.Add(new ListViewItem(new string[] { s.Name, s.Type.ToString(), s.ValueToString() }));
                }
            }
        }

        private RegistryKey OpenKey(string sFullPath)
        {
            RegistryKey ret = null;
            int sfpMinLength = 0;
            string[] sTok = sFullPath.Split(new char[] { '\\' });

            if (sTok[0].Equals(sRootKeys[0]))
            {
                ret = Registry.ClassesRoot;
                sfpMinLength = 16;
            }
            else if (sTok[0].Equals(sRootKeys[1]))
            {
                ret = Registry.CurrentUser;
                sfpMinLength = 16;
            }
            else if (sTok[0].Equals(sRootKeys[2]))
            {
                ret = Registry.LocalMachine;
                sfpMinLength = 17;
            }
            else if (sTok[0].Equals(sRootKeys[3]))
            {
                ret = Registry.Users;
                sfpMinLength = 10;
            }
            else
            {
                //Don't try to open any keys
                sfpMinLength = 65535;
                ret = null;
            }

            try
            {
                if (sFullPath.Length > sfpMinLength)
                    ret = ret.OpenSubKey(sFullPath.Substring(sfpMinLength + 1), true);
            }
            catch (System.Security.SecurityException sx)
            {
                MessageBox.Show("Unauthorized: " + sx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                ret = null;
            }

            return ret;
        }

        private void CheckForValues(RegistryKey key)
        {
            //Check for child values and display if found
            if (key != null)
            {
                string[] valuesName = key.GetValueNames();
                List<RegValue> val = new List<RegValue>();

                if (valuesName.Length > 0)
                {
                    foreach (string s in valuesName)
                    {
                        object rv = null;
                        RegistryValueKind rt = RegistryValueKind.Unknown;

                        try
                        {
                            rv = key.GetValue(s);
                        }
                        catch
                        {
                            rv = new object();
                        }

                        try
                        {
                            rt = key.GetValueKind(s);
                        }
                        catch
                        {
                            rt = RegistryValueKind.Unknown;
                        }

                        val.Add(new RegValue(s, rv, rt));
                    }
                }

                UpdateValueList(val.ToArray());
            }
        }

        private void UpdateFullPath()
        {
            labelCurPath.Text = sCurrentKey;
            labelCurPath.Invalidate();
        }

        private int VarTypeToIndex(string type)
        {
            if (RegistryValueKind.Binary.ToString() == type)
                return 0;
            if (RegistryValueKind.DWord.ToString() == type)
                return 1;
            if (RegistryValueKind.ExpandString.ToString() == type)
                return 2;
            if (RegistryValueKind.MultiString.ToString() == type)
                return 3;
            if (RegistryValueKind.QWord.ToString() == type)
                return 4;
            if (RegistryValueKind.String.ToString() == type)
                return 5;

            return -1;
        }

        private RegistryValueKind IndexToVarType(int idx)
        {
            RegistryValueKind ret = RegistryValueKind.Unknown;
            switch (idx)
            {
                case 0:
                    ret = RegistryValueKind.Binary;
                    break;
                case 1:
                    ret = RegistryValueKind.DWord;
                    break;
                case 2:
                    ret = RegistryValueKind.ExpandString;
                    break;
                case 3:
                    ret = RegistryValueKind.MultiString;
                    break;
                case 4:
                    ret = RegistryValueKind.QWord;
                    break;
                case 5:
                    ret = RegistryValueKind.String;
                    break;
                default:
                    ret = RegistryValueKind.Unknown;
                    break;
            }
            return ret;
        }

        #region Window Action Handlers
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            List<string> found = new List<string>();

            string searchStr = '^' + Regex.Escape(tbSearch.Text) + '.';
            foreach (string s in subKeyList)
            {
                if (Regex.IsMatch(s, searchStr, RegexOptions.IgnoreCase))
                {
                    found.Add(s);
                }
            }

            UpdateKeyList(found.ToArray(), false);
        }

        private void btnDown_OnClick(object sender, EventArgs e)
        {
            if (listSubkeys.SelectedIndex < 0)
            {
                sCurrentKey = sRootKeys[cbRootKey.SelectedIndex];
            }
            else
            {
                sCurrentKey += '\\' + (string)listSubkeys.SelectedItem;
            }

            RegistryKey key = OpenKey(sCurrentKey);
            if (key != null)
            {
                try
                {
                    UpdateKeyList(key.GetSubKeyNames(), true);
                }
                catch
                {
                    UpdateKeyList(null, true);
                }

                CheckForValues(key);
            }
            else
            {
                UpdateKeyList(null, true);
            }

            key.Close();

            UpdateFullPath();
        }

        private void btnUp_OnClick(object sender, EventArgs e)
        {
            int lastIndex = sCurrentKey.LastIndexOf('\\');
            if (sCurrentKey.IndexOf('\\') != lastIndex)
            {
                sCurrentKey = sCurrentKey.Substring(0, lastIndex);
            }
            else
            {
                sCurrentKey = sRootKeys[cbRootKey.SelectedIndex];
            }

            RegistryKey key = OpenKey(sCurrentKey);
            if (key != null)
            {
                try
                {
                    UpdateKeyList(key.GetSubKeyNames(), true);
                }
                catch
                {
                    UpdateKeyList(null, true);
                }

                CheckForValues(key);
            }
            else
            {
                UpdateKeyList(null, true);
            }

            key.Close();

            UpdateFullPath();
        }

        private void btnSave_OnClick(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure?", "Save Value",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                RegistryKey curKey = OpenKey(sCurrentKey);
                if (cbKey.Checked)
                {
                    try
                    {
                        curKey.CreateSubKey(tbName.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
                else
                {
                    if (curKey != null)
                    {
                        RegistryValueKind vType = IndexToVarType(cbType.SelectedIndex);

                        try
                        {
                            switch (vType)
                            {
                                case RegistryValueKind.Binary:
                                    {
                                        string buf = tbValue.Text;
                                        int len = buf.Length;
                                        byte[] vals = new byte[len];

                                        for (int i = 0; i < len; i++)
                                            vals[i] = (byte)buf[i];

                                        curKey.SetValue(tbName.Text, vals, vType);
                                    }
                                    break;
                                case RegistryValueKind.DWord:
                                    {
                                        int val = Convert.ToInt32(tbValue.Text);
                                        curKey.SetValue(tbName.Text, val, vType);
                                    }
                                    break;
                                case RegistryValueKind.ExpandString:
                                    throw new Exception("Not Implemented");
                                    //break;
                                case RegistryValueKind.MultiString:
                                    {
                                        string[] vals = tbValue.Text.Split(new char[] { ',' });
                                        curKey.SetValue(tbName.Text, vals, vType);
                                    }
                                    break;
                                case RegistryValueKind.QWord:
                                    {
                                        long val = Convert.ToInt64(tbValue.Text);
                                        curKey.SetValue(tbName.Text, val, vType);
                                    }
                                    break;
                                case RegistryValueKind.String:
                                case RegistryValueKind.Unknown:
                                default:
                                    curKey.SetValue(tbName.Text, tbValue.Text, vType);
                                    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                curKey.Close();
            }
        }

        private void btnDelete_OnClick(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure?", "Delete Value",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);
            if (res == DialogResult.Yes)
            {
                RegistryKey curKey = OpenKey(sCurrentKey);
                if (curKey != null)
                {
                    if (cbKey.Checked)
                    {
                        try
                        {
                            curKey.DeleteSubKey(tbName.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                    else
                    {
                        try
                        {
                            curKey.DeleteValue(tbName.Text);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                    }
                }
                curKey.Close();
            }
        }

        private void listSubvalues_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem it = listSubvalues.FocusedItem;
            if (it != null)
            {
                ListViewItem.ListViewSubItemCollection sca = it.SubItems;

                if (sca != null && sca.Count == 3)
                {
                    tbName.Text = sca[0].Text.ToString();
                    cbType.SelectedIndex = VarTypeToIndex(sca[1].Text);
                    tbValue.Text = sca[2].Text.ToString();
                    cbKey.Checked = false;
                    cbType.Enabled = true;
                    tbValue.Enabled = true;
                }
            }
        }

        private void listSubkeys_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSubkeys.SelectedItem != null)
            {
                tbName.Text = listSubkeys.SelectedItem.ToString();
                cbKey.Checked = true;
                cbType.Enabled = false;
                tbValue.Enabled = false;
            }
        }

        private void cbKey_OnClick(object sender, EventArgs e)
        {
            if (cbKey.Checked)
            {
                cbType.Enabled = false;
                tbValue.Enabled = false;
            }
            else
            {
                cbType.Enabled = true;
                tbValue.Enabled = true;
            }
        }
        #endregion
    }
}