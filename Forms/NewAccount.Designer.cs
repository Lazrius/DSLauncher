namespace DSLauncherV2
{
    partial class NewAccount
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.GenerateButton = new MetroFramework.Controls.MetroButton();
            this.OkButton = new MetroFramework.Controls.MetroButton();
            this.CancelButton = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.NameTextbox = new MetroFramework.Controls.MetroTextBox();
            this.DescriptionTextbox = new MetroFramework.Controls.MetroTextBox();
            this.CategoryTextbox = new MetroFramework.Controls.MetroTextBox();
            this.CodeTextbox = new MetroFramework.Controls.MetroTextBox();
            this.SigTextbox = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // GenerateButton
            // 
            this.GenerateButton.Location = new System.Drawing.Point(24, 186);
            this.GenerateButton.Name = "GenerateButton";
            this.GenerateButton.Size = new System.Drawing.Size(75, 23);
            this.GenerateButton.TabIndex = 0;
            this.GenerateButton.Text = "Generate";
            this.GenerateButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.GenerateButton.UseSelectable = true;
            this.GenerateButton.Click += new System.EventHandler(this.GenerateButton_Click);
            // 
            // OkButton
            // 
            this.OkButton.Location = new System.Drawing.Point(264, 186);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 23);
            this.OkButton.TabIndex = 1;
            this.OkButton.Text = "Ok";
            this.OkButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OkButton.UseSelectable = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(172, 186);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 2;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CancelButton.UseSelectable = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(3, 35);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(52, 19);
            this.metroLabel1.TabIndex = 3;
            this.metroLabel1.Text = "Name: ";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(3, 64);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(77, 19);
            this.metroLabel2.TabIndex = 4;
            this.metroLabel2.Text = "Description:";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(3, 94);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(67, 19);
            this.metroLabel3.TabIndex = 5;
            this.metroLabel3.Text = "Category:";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(3, 123);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(48, 19);
            this.metroLabel4.TabIndex = 6;
            this.metroLabel4.Text = "Code: ";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(3, 151);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(71, 19);
            this.metroLabel5.TabIndex = 7;
            this.metroLabel5.Text = "Signature: ";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // NameTextbox
            // 
            this.NameTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            // 
            // 
            // 
            this.NameTextbox.CustomButton.Image = null;
            this.NameTextbox.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.NameTextbox.CustomButton.Name = "";
            this.NameTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NameTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NameTextbox.CustomButton.TabIndex = 1;
            this.NameTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NameTextbox.CustomButton.UseSelectable = true;
            this.NameTextbox.CustomButton.Visible = false;
            this.NameTextbox.ForeColor = System.Drawing.SystemColors.Control;
            this.NameTextbox.Lines = new string[0];
            this.NameTextbox.Location = new System.Drawing.Point(83, 35);
            this.NameTextbox.MaxLength = 32767;
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.PasswordChar = '\0';
            this.NameTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NameTextbox.SelectedText = "";
            this.NameTextbox.SelectionLength = 0;
            this.NameTextbox.SelectionStart = 0;
            this.NameTextbox.ShortcutsEnabled = true;
            this.NameTextbox.Size = new System.Drawing.Size(256, 23);
            this.NameTextbox.TabIndex = 8;
            this.NameTextbox.UseCustomBackColor = true;
            this.NameTextbox.UseCustomForeColor = true;
            this.NameTextbox.UseSelectable = true;
            this.NameTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NameTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // DescriptionTextbox
            // 
            this.DescriptionTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            // 
            // 
            // 
            this.DescriptionTextbox.CustomButton.Image = null;
            this.DescriptionTextbox.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.DescriptionTextbox.CustomButton.Name = "";
            this.DescriptionTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.DescriptionTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DescriptionTextbox.CustomButton.TabIndex = 1;
            this.DescriptionTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.DescriptionTextbox.CustomButton.UseSelectable = true;
            this.DescriptionTextbox.CustomButton.Visible = false;
            this.DescriptionTextbox.ForeColor = System.Drawing.SystemColors.Control;
            this.DescriptionTextbox.Lines = new string[0];
            this.DescriptionTextbox.Location = new System.Drawing.Point(83, 64);
            this.DescriptionTextbox.MaxLength = 32767;
            this.DescriptionTextbox.Name = "DescriptionTextbox";
            this.DescriptionTextbox.PasswordChar = '\0';
            this.DescriptionTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DescriptionTextbox.SelectedText = "";
            this.DescriptionTextbox.SelectionLength = 0;
            this.DescriptionTextbox.SelectionStart = 0;
            this.DescriptionTextbox.ShortcutsEnabled = true;
            this.DescriptionTextbox.Size = new System.Drawing.Size(256, 23);
            this.DescriptionTextbox.TabIndex = 9;
            this.DescriptionTextbox.UseCustomBackColor = true;
            this.DescriptionTextbox.UseCustomForeColor = true;
            this.DescriptionTextbox.UseSelectable = true;
            this.DescriptionTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.DescriptionTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CategoryTextbox
            // 
            this.CategoryTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            // 
            // 
            // 
            this.CategoryTextbox.CustomButton.Image = null;
            this.CategoryTextbox.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.CategoryTextbox.CustomButton.Name = "";
            this.CategoryTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CategoryTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CategoryTextbox.CustomButton.TabIndex = 1;
            this.CategoryTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CategoryTextbox.CustomButton.UseSelectable = true;
            this.CategoryTextbox.CustomButton.Visible = false;
            this.CategoryTextbox.ForeColor = System.Drawing.SystemColors.Control;
            this.CategoryTextbox.Lines = new string[0];
            this.CategoryTextbox.Location = new System.Drawing.Point(83, 94);
            this.CategoryTextbox.MaxLength = 32767;
            this.CategoryTextbox.Name = "CategoryTextbox";
            this.CategoryTextbox.PasswordChar = '\0';
            this.CategoryTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CategoryTextbox.SelectedText = "";
            this.CategoryTextbox.SelectionLength = 0;
            this.CategoryTextbox.SelectionStart = 0;
            this.CategoryTextbox.ShortcutsEnabled = true;
            this.CategoryTextbox.Size = new System.Drawing.Size(256, 23);
            this.CategoryTextbox.TabIndex = 10;
            this.CategoryTextbox.UseCustomBackColor = true;
            this.CategoryTextbox.UseCustomForeColor = true;
            this.CategoryTextbox.UseSelectable = true;
            this.CategoryTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CategoryTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // CodeTextbox
            // 
            this.CodeTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            // 
            // 
            // 
            this.CodeTextbox.CustomButton.Image = null;
            this.CodeTextbox.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.CodeTextbox.CustomButton.Name = "";
            this.CodeTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.CodeTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.CodeTextbox.CustomButton.TabIndex = 1;
            this.CodeTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.CodeTextbox.CustomButton.UseSelectable = true;
            this.CodeTextbox.CustomButton.Visible = false;
            this.CodeTextbox.Enabled = false;
            this.CodeTextbox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CodeTextbox.Lines = new string[0];
            this.CodeTextbox.Location = new System.Drawing.Point(83, 123);
            this.CodeTextbox.MaxLength = 32767;
            this.CodeTextbox.Name = "CodeTextbox";
            this.CodeTextbox.PasswordChar = '\0';
            this.CodeTextbox.ReadOnly = true;
            this.CodeTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.CodeTextbox.SelectedText = "";
            this.CodeTextbox.SelectionLength = 0;
            this.CodeTextbox.SelectionStart = 0;
            this.CodeTextbox.ShortcutsEnabled = true;
            this.CodeTextbox.Size = new System.Drawing.Size(256, 23);
            this.CodeTextbox.TabIndex = 11;
            this.CodeTextbox.UseCustomBackColor = true;
            this.CodeTextbox.UseCustomForeColor = true;
            this.CodeTextbox.UseSelectable = true;
            this.CodeTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.CodeTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SigTextbox
            // 
            this.SigTextbox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            // 
            // 
            // 
            this.SigTextbox.CustomButton.Image = null;
            this.SigTextbox.CustomButton.Location = new System.Drawing.Point(234, 1);
            this.SigTextbox.CustomButton.Name = "";
            this.SigTextbox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SigTextbox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SigTextbox.CustomButton.TabIndex = 1;
            this.SigTextbox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SigTextbox.CustomButton.UseSelectable = true;
            this.SigTextbox.CustomButton.Visible = false;
            this.SigTextbox.Enabled = false;
            this.SigTextbox.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.SigTextbox.Lines = new string[0];
            this.SigTextbox.Location = new System.Drawing.Point(83, 151);
            this.SigTextbox.MaxLength = 32767;
            this.SigTextbox.Name = "SigTextbox";
            this.SigTextbox.PasswordChar = '\0';
            this.SigTextbox.ReadOnly = true;
            this.SigTextbox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SigTextbox.SelectedText = "";
            this.SigTextbox.SelectionLength = 0;
            this.SigTextbox.SelectionStart = 0;
            this.SigTextbox.ShortcutsEnabled = true;
            this.SigTextbox.Size = new System.Drawing.Size(256, 23);
            this.SigTextbox.TabIndex = 12;
            this.SigTextbox.UseCustomBackColor = true;
            this.SigTextbox.UseCustomForeColor = true;
            this.SigTextbox.UseSelectable = true;
            this.SigTextbox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SigTextbox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NewAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 232);
            this.ControlBox = false;
            this.Controls.Add(this.SigTextbox);
            this.Controls.Add(this.CodeTextbox);
            this.Controls.Add(this.CategoryTextbox);
            this.Controls.Add(this.DescriptionTextbox);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.metroLabel5);
            this.Controls.Add(this.metroLabel4);
            this.Controls.Add(this.metroLabel3);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.GenerateButton);
            this.DisplayHeader = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewAccount";
            this.Padding = new System.Windows.Forms.Padding(20, 30, 20, 20);
            this.Resizable = false;
            this.ShowIcon = false;
            this.Text = "Add/Edit Accounts";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton GenerateButton;
        private MetroFramework.Controls.MetroButton OkButton;
        private MetroFramework.Controls.MetroButton CancelButton;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroTextBox NameTextbox;
        private MetroFramework.Controls.MetroTextBox DescriptionTextbox;
        private MetroFramework.Controls.MetroTextBox CategoryTextbox;
        private MetroFramework.Controls.MetroTextBox CodeTextbox;
        private MetroFramework.Controls.MetroTextBox SigTextbox;
    }
}