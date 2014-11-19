namespace RegeditCE
{
    partial class wndRegedit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.cbRootKey = new System.Windows.Forms.ComboBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.listSubkeys = new System.Windows.Forms.ListBox();
            this.labelCurPath = new System.Windows.Forms.Label();
            this.btnDown = new System.Windows.Forms.Button();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.labelType = new System.Windows.Forms.Label();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.labelValue = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.labelSearch = new System.Windows.Forms.Label();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.listSubvalues = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chData = new System.Windows.Forms.ColumnHeader();
            this.cbKey = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbRootKey
            // 
            this.cbRootKey.Location = new System.Drawing.Point(8, 15);
            this.cbRootKey.Name = "cbRootKey";
            this.cbRootKey.Size = new System.Drawing.Size(160, 22);
            this.cbRootKey.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Location = new System.Drawing.Point(205, 15);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(22, 22);
            this.btnUp.TabIndex = 1;
            this.btnUp.Text = "U";
            this.btnUp.Click += new System.EventHandler(this.btnUp_OnClick);
            // 
            // listSubkeys
            // 
            this.listSubkeys.Location = new System.Drawing.Point(8, 76);
            this.listSubkeys.Name = "listSubkeys";
            this.listSubkeys.Size = new System.Drawing.Size(160, 58);
            this.listSubkeys.TabIndex = 2;
            this.listSubkeys.SelectedIndexChanged += new System.EventHandler(this.listSubkeys_SelectedIndexChanged);
            // 
            // labelCurPath
            // 
            this.labelCurPath.Font = new System.Drawing.Font("Tahoma", 7F, System.Drawing.FontStyle.Regular);
            this.labelCurPath.Location = new System.Drawing.Point(8, 40);
            this.labelCurPath.Name = "labelCurPath";
            this.labelCurPath.Size = new System.Drawing.Size(219, 32);
            // 
            // btnDown
            // 
            this.btnDown.Location = new System.Drawing.Point(174, 15);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(25, 22);
            this.btnDown.TabIndex = 4;
            this.btnDown.Text = "D";
            this.btnDown.Click += new System.EventHandler(this.btnDown_OnClick);
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(153, 209);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(46, 22);
            this.cbType.TabIndex = 5;
            // 
            // labelName
            // 
            this.labelName.Location = new System.Drawing.Point(8, 210);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(44, 18);
            this.labelName.Text = "Name:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(46, 210);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(66, 21);
            this.tbName.TabIndex = 7;
            // 
            // labelType
            // 
            this.labelType.Location = new System.Drawing.Point(118, 213);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(44, 18);
            this.labelType.Text = "Type:";
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(46, 237);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(66, 21);
            this.tbValue.TabIndex = 11;
            // 
            // labelValue
            // 
            this.labelValue.Location = new System.Drawing.Point(8, 239);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(44, 18);
            this.labelValue.Text = "Value:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 239);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(50, 19);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_OnClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(174, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(53, 19);
            this.btnDelete.TabIndex = 14;
            this.btnDelete.Text = "Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_OnClick);
            // 
            // labelSearch
            // 
            this.labelSearch.Location = new System.Drawing.Point(174, 76);
            this.labelSearch.Name = "labelSearch";
            this.labelSearch.Size = new System.Drawing.Size(53, 17);
            this.labelSearch.Text = "Search:";
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(174, 96);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(53, 21);
            this.tbSearch.TabIndex = 16;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // listSubvalues
            // 
            this.listSubvalues.Columns.Add(this.chName);
            this.listSubvalues.Columns.Add(this.chType);
            this.listSubvalues.Columns.Add(this.chData);
            this.listSubvalues.Location = new System.Drawing.Point(8, 139);
            this.listSubvalues.Name = "listSubvalues";
            this.listSubvalues.Size = new System.Drawing.Size(219, 65);
            this.listSubvalues.TabIndex = 17;
            this.listSubvalues.View = System.Windows.Forms.View.Details;
            this.listSubvalues.SelectedIndexChanged += new System.EventHandler(this.listSubvalues_SelectedIndexChanged);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 100;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 30;
            // 
            // chData
            // 
            this.chData.Text = "Data";
            this.chData.Width = 80;
            // 
            // cbKey
            // 
            this.cbKey.Location = new System.Drawing.Point(205, 209);
            this.cbKey.Name = "cbKey";
            this.cbKey.Size = new System.Drawing.Size(35, 23);
            this.cbKey.TabIndex = 23;
            this.cbKey.Text = "K";
            this.cbKey.Click += new System.EventHandler(this.cbKey_OnClick);
            // 
            // wndRegedit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 290);
            this.Controls.Add(this.cbKey);
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.listSubvalues);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.labelSearch);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.labelCurPath);
            this.Controls.Add(this.listSubkeys);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.cbRootKey);
            this.Controls.Add(this.labelType);
            this.Name = "wndRegedit";
            this.Text = "RegeditCE";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbRootKey;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.ListBox listSubkeys;
        private System.Windows.Forms.Label labelCurPath;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label labelSearch;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListView listSubvalues;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chData;
        private System.Windows.Forms.CheckBox cbKey;
    }
}

