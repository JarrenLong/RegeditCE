namespace RegeditCE
{
    partial class NewKey
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
            this.buttonPositive = new System.Windows.Forms.Button();
            this.buttonNegative = new System.Windows.Forms.Button();
            this.labelName = new System.Windows.Forms.Label();
            this.textboxMessage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonPositive
            // 
            this.buttonPositive.Location = new System.Drawing.Point(3, 60);
            this.buttonPositive.Name = "buttonPositive";
            this.buttonPositive.Size = new System.Drawing.Size(103, 24);
            this.buttonPositive.TabIndex = 0;
            this.buttonPositive.Text = "OK";
            this.buttonPositive.Click += new System.EventHandler(this.buttonPositive_Click);
            // 
            // buttonNegative
            // 
            this.buttonNegative.Location = new System.Drawing.Point(3, 90);
            this.buttonNegative.Name = "buttonNegative";
            this.buttonNegative.Size = new System.Drawing.Size(103, 24);
            this.buttonNegative.TabIndex = 1;
            this.buttonNegative.Text = "Cancel";
            this.buttonNegative.Click += new System.EventHandler(this.buttonNegative_Click);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.labelName.Location = new System.Drawing.Point(3, 10);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(103, 20);
            this.labelName.Text = "New Key Name:";
            // 
            // textboxMessage
            // 
            this.textboxMessage.Location = new System.Drawing.Point(3, 33);
            this.textboxMessage.Name = "textboxMessage";
            this.textboxMessage.Size = new System.Drawing.Size(103, 21);
            this.textboxMessage.TabIndex = 3;
            // 
            // NewKey
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(110, 120);
            this.ControlBox = false;
            this.Controls.Add(this.textboxMessage);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.buttonNegative);
            this.Controls.Add(this.buttonPositive);
            this.MinimizeBox = false;
            this.Name = "NewKey";
            this.Text = "Save Key";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPositive;
        private System.Windows.Forms.Button buttonNegative;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textboxMessage;
    }
}