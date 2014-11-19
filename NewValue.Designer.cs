namespace RegeditCE
{
    partial class NewValue
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
            this.tbName = new System.Windows.Forms.TextBox();
            this.mainMenu2 = new System.Windows.Forms.MainMenu();
            this.buttonNegative = new System.Windows.Forms.Button();
            this.buttonPositive = new System.Windows.Forms.Button();
            this.tbValue = new System.Windows.Forms.TextBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(3, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(103, 21);
            this.tbName.TabIndex = 7;
            this.tbName.Text = "Name";
            // 
            // buttonNegative
            // 
            this.buttonNegative.Location = new System.Drawing.Point(3, 115);
            this.buttonNegative.Name = "buttonNegative";
            this.buttonNegative.Size = new System.Drawing.Size(103, 24);
            this.buttonNegative.TabIndex = 6;
            this.buttonNegative.Text = "Cancel";
            this.buttonNegative.Click += new System.EventHandler(this.buttonNegative_Click);
            // 
            // buttonPositive
            // 
            this.buttonPositive.Location = new System.Drawing.Point(3, 85);
            this.buttonPositive.Name = "buttonPositive";
            this.buttonPositive.Size = new System.Drawing.Size(103, 24);
            this.buttonPositive.TabIndex = 5;
            this.buttonPositive.Text = "OK";
            this.buttonPositive.Click += new System.EventHandler(this.buttonPositive_Click);
            // 
            // tbValue
            // 
            this.tbValue.Location = new System.Drawing.Point(3, 58);
            this.tbValue.Name = "tbValue";
            this.tbValue.Size = new System.Drawing.Size(103, 21);
            this.tbValue.TabIndex = 8;
            this.tbValue.Text = "Value";
            // 
            // cbType
            // 
            this.cbType.Location = new System.Drawing.Point(3, 30);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(103, 22);
            this.cbType.TabIndex = 9;
            // 
            // NewValue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(110, 145);
            this.ControlBox = false;
            this.Controls.Add(this.cbType);
            this.Controls.Add(this.tbValue);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.buttonNegative);
            this.Controls.Add(this.buttonPositive);
            this.MinimizeBox = false;
            this.Name = "NewValue";
            this.Text = "Save Value";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.MainMenu mainMenu2;
        private System.Windows.Forms.Button buttonNegative;
        private System.Windows.Forms.Button buttonPositive;
        private System.Windows.Forms.TextBox tbValue;
        private System.Windows.Forms.ComboBox cbType;
    }
}