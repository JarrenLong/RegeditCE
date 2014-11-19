namespace RegeditCE
{
    partial class NewExplorer
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem();
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lvValues = new System.Windows.Forms.ListView();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chType = new System.Windows.Forms.ColumnHeader();
            this.chData = new System.Windows.Forms.ColumnHeader();
            this.lvKeys = new System.Windows.Forms.ListView();
            this.tbSearch = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lvValues);
            this.panel1.Controls.Add(this.lvKeys);
            this.panel1.Location = new System.Drawing.Point(0, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 238);
            // 
            // lvValues
            // 
            this.lvValues.Columns.Add(this.chName);
            this.lvValues.Columns.Add(this.chType);
            this.lvValues.Columns.Add(this.chData);
            this.lvValues.FullRowSelect = true;
            this.lvValues.Location = new System.Drawing.Point(121, 3);
            this.lvValues.Name = "lvValues";
            this.lvValues.Size = new System.Drawing.Size(116, 232);
            this.lvValues.TabIndex = 5;
            this.lvValues.View = System.Windows.Forms.View.Details;
            this.lvValues.ItemActivate += new System.EventHandler(this.lvValues_ItemActivate);
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 40;
            // 
            // chType
            // 
            this.chType.Text = "Type";
            this.chType.Width = 20;
            // 
            // chData
            // 
            this.chData.Text = "Data";
            this.chData.Width = 50;
            // 
            // lvKeys
            // 
            this.lvKeys.FullRowSelect = true;
            listViewItem1.Tag = "Root";
            listViewItem1.Text = "";
            this.lvKeys.Items.Add(listViewItem1);
            this.lvKeys.Location = new System.Drawing.Point(3, 3);
            this.lvKeys.Name = "lvKeys";
            this.lvKeys.Size = new System.Drawing.Size(116, 232);
            this.lvKeys.TabIndex = 4;
            this.lvKeys.View = System.Windows.Forms.View.SmallIcon;
            this.lvKeys.ItemActivate += new System.EventHandler(this.lvKeys_ItemActivate);
            // 
            // tbSearch
            // 
            this.tbSearch.Location = new System.Drawing.Point(3, 2);
            this.tbSearch.Name = "tbSearch";
            this.tbSearch.Size = new System.Drawing.Size(234, 21);
            this.tbSearch.TabIndex = 3;
            this.tbSearch.TextChanged += new System.EventHandler(this.tbSearch_TextChanged);
            // 
            // NewExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 294);
            this.Controls.Add(this.tbSearch);
            this.Controls.Add(this.panel1);
            this.Name = "NewExplorer";
            this.Text = "RegeditCE";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbSearch;
        private System.Windows.Forms.ListView lvKeys;
        private System.Windows.Forms.ListView lvValues;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chType;
        private System.Windows.Forms.ColumnHeader chData;


    }
}