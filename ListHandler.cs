using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;

namespace RegeditCE
{
  class RegistryHandler
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

    public RegistryHandler()
    {
      subKeyList = new List<string>();
      foreach (string s in sRootKeys)
      {
        subKeyList.Add(s);
      }

      subKeyValues = new List<RegValue>();
      sCurrentKey = "";
    }

    public string[] Keys
    {
      get
      {
        if (sCurrentKey == "")
        {
          return sRootKeys;
        }

        int count = subKeyList.Count;
        string[] ret = new string[count + 2];
        ret[0] = "..";
        ret[1] = "<new key>";

        for (int i = 2; i < count; i++)
        {
          ret[i] = subKeyList[i];
        }

        return ret;
      }
      set
      {
      }
    }

    public RegValue[] Values
    {
      get
      {
        return subKeyValues.ToArray();
      }
      set
      {
      }
    }

    public string CurrentPath
    {
      get
      {
        return sCurrentKey;
      }
      set { }
    }

    public RegistryKey OpenKey(string sFullPath)
    {
      RegistryKey ret = null;
      string[] sTok = sFullPath.Split(new char[] { '\\' });

      if (sTok[0].Equals(sRootKeys[0]))
      {
        ret = Registry.ClassesRoot;
      }
      else if (sTok[0].Equals(sRootKeys[1]))
      {
        ret = Registry.CurrentUser;
      }
      else if (sTok[0].Equals(sRootKeys[2]))
      {
        ret = Registry.LocalMachine;
      }
      else if (sTok[0].Equals(sRootKeys[3]))
      {
        ret = Registry.Users;
      }
      else
      {
        ret = null;
      }

      if (ret != null)
      {
        try
        {
          if (sTok.Length > 0)
          {
            string subkey = "";

            for (int i = 1; i < sTok.Length; i++)
            {
              subkey += sTok[i] + "\\";
            }
            subkey = subkey.TrimEnd(new char[] { '\\' });

            ret = ret.OpenSubKey(subkey, true);
          }

          subKeyList.Clear();
          string[] sk = new string[1];

          if (ret != null)
          {
            sk = ret.GetSubKeyNames();
          }
          else
          {
            sk = sRootKeys;
          }

          foreach (string s in sk)
          {
            subKeyList.Add(s);
          }
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
      }
      else
      {
        subKeyList.Clear();
        string[] sk = sRootKeys;
        foreach (string s in sk)
        {
          subKeyList.Add(s);
        }
      }

      return ret;
    }

    public int VarTypeToIndex(string type)
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

    public RegistryValueKind IndexToVarType(int idx)
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

    public void Create(string keyName)
    {
      RegistryKey curKey = OpenKey(sCurrentKey);
      curKey.CreateSubKey(keyName);
      curKey.Close();
    }

    public void Create(RegValue info)
    {
      //Save value
      RegistryKey curKey = OpenKey(sCurrentKey);
      if (curKey != null)
      {
        try
        {
          switch (info.Type)
          {
            case RegistryValueKind.Binary:
              {
                string buf = (string)info.Value;
                int len = buf.Length;
                byte[] vals = new byte[len];

                for (int i = 0; i < len; i++)
                  vals[i] = (byte)buf[i];

                curKey.SetValue(info.Name, vals, info.Type);
              }
              break;
            case RegistryValueKind.DWord:
              {
                int val = Convert.ToInt32(info.Value);
                curKey.SetValue(info.Name, val, info.Type);
              }
              break;
            case RegistryValueKind.ExpandString:
              throw new Exception("Not Implemented");
            case RegistryValueKind.MultiString:
              {
                string[] vals = ((string)info.Value).Split(new char[] { ',' });
                curKey.SetValue(info.Name, vals, info.Type);
              }
              break;
            case RegistryValueKind.QWord:
              {
                long val = Convert.ToInt64(info.Value);
                curKey.SetValue(info.Name, val, info.Type);
              }
              break;
            case RegistryValueKind.String:
            case RegistryValueKind.Unknown:
            default:
              curKey.SetValue(info.Name, info.Value, info.Type);
              break;
          }
        }
        catch (Exception ex)
        {
          MessageBox.Show(ex.ToString());
        }
      }
      curKey.Close();
    }

    public void Delete(bool key, string name)
    {
      RegistryKey curKey = OpenKey(sCurrentKey);
      if (curKey != null)
      {
        if (key)
        {
          try
          {
            curKey.DeleteSubKey(name);
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
            curKey.DeleteValue(name);
          }
          catch (Exception ex)
          {
            MessageBox.Show(ex.ToString());
          }
        }

        curKey.Close();
      }
    }

    public void MoveUp()
    {
      int lastIndex = sCurrentKey.LastIndexOf('\\');
      if (lastIndex > 0)
      {
        sCurrentKey = sCurrentKey.Substring(0, lastIndex);
      }
      else
      {
        sCurrentKey = "";
      }

      RegistryKey key = OpenKey(sCurrentKey);
      if (key != null)
      {
        CheckForValues(key);
        key.Close();
      }
    }

    public void MoveDown(string keyName)
    {
      if (sCurrentKey == "")
      {
        sCurrentKey = keyName;
      }
      else
      {
        sCurrentKey += '\\' + keyName;
      }

      RegistryKey key = OpenKey(sCurrentKey);
      if (key != null)
      {
        CheckForValues(key);
        key.Close();
      }
    }

    private void CheckForValues(RegistryKey key)
    {
      //Check for child values and display if found
      if (key != null)
      {
        string[] valuesName = key.GetValueNames();
        subKeyValues.Clear();
        subKeyValues.Add(new RegValue("<new value>", 0, RegistryValueKind.Unknown));

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

            subKeyValues.Add(new RegValue(s, rv, rt));
          }
        }
      }
    }
  }

  #region Registry helper class
  class RegValue
  {
    private string _name;
    private object _value;
    private RegistryValueKind _type;

    public RegValue(string name, object value, RegistryValueKind type)
    {
      _name = name;
      _value = value;
      _type = type;
    }

    public string Name
    {
      get
      {
        return _name;
      }
    }

    public object Value
    {
      get
      {
        return _value;
      }
    }

    public RegistryValueKind Type
    {
      get
      {
        return _type;
      }
    }

    public string ValueToString()
    {
      string ret = "";

      switch (_type)
      {
        case RegistryValueKind.Binary:
          {
            byte[] buf = (byte[])_value;
            foreach (byte b in buf)
              ret += (char)b;
          }
          break;
        case RegistryValueKind.MultiString:
          {
            string[] tok = (string[])_value;
            foreach (string s in tok)
              ret += (s + ',');
          }
          break;
        default:
          ret = _value.ToString();
          break;
      }

      return ret;
    }
  }
  #endregion
}
