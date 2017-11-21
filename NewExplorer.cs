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
  public partial class NewExplorer : Form
  {
    private RegistryHandler reg = null;

    public NewExplorer()
    {
      InitializeComponent();

      reg = new RegistryHandler();

      UpdateWnd();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
      bool bDeleteKey = true;
      string selectedItem = "test";

      string msg = "Delete " + (bDeleteKey ? "key " : "value ") + selectedItem + "?";
      DialogResult ret = MessageBox.Show(
          msg, "Are you Sure?",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Exclamation,
          MessageBoxDefaultButton.Button2);

      if (ret == DialogResult.Yes)
      {
        if (bDeleteKey)
        {
          //Delete the selected key
          MessageBox.Show("Deleting key \"" + selectedItem + "\"");
        }
        else
        {
          //Delete the selected key's value
          MessageBox.Show("Deleting value \"" + selectedItem + "\"");
        }

        reg.Delete(bDeleteKey, selectedItem);

        UpdateWnd();
      }
    }

    private void tbSearch_TextChanged(object sender, EventArgs e)
    {
      UpdateWnd();
    }

    private void lvKeys_ItemActivate(object sender, EventArgs e)
    {
      //Move up if node == "..", down if lower
      ListViewItem li = ((ListView)sender).FocusedItem;
      if (li != null)
      {
        string key = li.Text;
        if (key != null)
        {
          if (key.Equals(".."))
          {
            reg.MoveUp();
          }
          else if (key.Equals("<new key>"))
          {
            NewKey myForm = new NewKey();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
              reg.Create(myForm.Message);

              UpdateWnd();
            }
          }
          else
          {
            reg.MoveDown(key);
          }
        }

        UpdateWnd();
      }
    }

    private void UpdateWnd()
    {
      lvKeys.Items.Clear();
      lvValues.Items.Clear();

      //Filter keys if we have search text
      string find = tbSearch.Text;
      if (find != null)
      {
        foreach (string s in reg.Keys)
        {
          if (s != null)
          {
            string buf = s.ToLower();
            if (buf.StartsWith(find))
            {
              lvKeys.Items.Add(new ListViewItem(s));
            }
          }
        }
      }
      else //Just display the keys
      {
        foreach (string s in reg.Keys)
        {
          if (s != null)
          {
            lvKeys.Items.Add(new ListViewItem(s));
          }
        }
      }

      //Always show all values
      foreach (RegValue s in reg.Values)
      {
        lvValues.Items.Add(new ListViewItem(new string[] { s.Name, s.Type.ToString(), s.ValueToString() }));
      }
    }

    private void lvValues_ItemActivate(object sender, EventArgs e)
    {
      ListViewItem li = ((ListView)sender).FocusedItem;
      if (li != null)
      {
        string key = li.Text;
        if (key != null)
        {
          if (key.Equals("<new value>"))
          {
            NewValue myForm = new NewValue();
            if (myForm.ShowDialog() == DialogResult.OK)
            {
              reg.Create(new RegValue(myForm.VName, myForm.Value, myForm.Type));

              UpdateWnd();
            }
          }
        }

        UpdateWnd();
      }
    }
  }
}
