using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Controls;

namespace DSLauncherV2
{
    // I just straight up ripped this from https://stackoverflow.com/questions/4681936/a-scrollable-messagebox-in-c-sharp
    // Turns out it works a lot better than my own implementation
    // That being said, I've made quite a few changes and additions.
    public sealed class ScrollMessageBox : MetroFramework.Forms.MetroForm
    {
        public ScrollMessageBox()
        {
            InitializeComponent();
        }

        private ScrollMessageBox(string text)
        {
            InitializeComponent();
            box.Text = text;
        }

        private ScrollMessageBox(string title, string text)
        {
            InitializeComponent();
            Text = $@"Terms of Service Update: {title}";
            box.Text = text.Replace("\n", "\n\r\n");
            this.Show();
            this.Focus();
            this.box.SelectionLength = 0;
        }

        public static void Show(string title, string text)
        {
            new ScrollMessageBox(title, text).Show();
        }

        public static void Show(string title, string text, Primary owner)
        {
            new ScrollMessageBox(title, text).Show(owner);
        }

        public static void ShowDialog(string title, string text, Primary owner)
        {
            ScrollMessageBox scr = new ScrollMessageBox(title, text);
            scr.Visible = false;
            scr.tos = text;
            scr.ShowDialog(owner);
        }

        public static void Show(string text)
        {
            new ScrollMessageBox(text).Show();
        }

        public static void Show(string text, Primary owner)
        {
            new ScrollMessageBox(text).Show(owner);
        }

        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.box = new MetroFramework.Controls.MetroTextBox();
            this.reject = new MetroFramework.Controls.MetroButton();
            this.accept = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // box
            // 
            this.box.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.box.CustomButton.Image = null;
            this.box.CustomButton.Location = new System.Drawing.Point(2, 2);
            this.box.CustomButton.Name = "";
            this.box.CustomButton.Size = new System.Drawing.Size(595, 595);
            this.box.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.box.CustomButton.TabIndex = 1;
            this.box.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.box.CustomButton.UseSelectable = true;
            this.box.CustomButton.Visible = false;
            this.box.Lines = new string[0];
            this.box.Location = new System.Drawing.Point(100, 100);
            this.box.MaxLength = 32767;
            this.box.Multiline = true;
            this.box.Name = "box";
            this.box.PasswordChar = '\0';
            this.box.ReadOnly = true;
            this.box.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.box.SelectedText = "";
            this.box.SelectionLength = 0;
            this.box.SelectionStart = 0;
            this.box.ShortcutsEnabled = true;
            this.box.Size = new System.Drawing.Size(600, 600);
            this.box.TabIndex = 0;
            this.box.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.box.UseSelectable = true;
            this.box.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.box.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // reject
            // 
            this.reject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.reject.Location = new System.Drawing.Point(700, 740);
            this.reject.Name = "reject";
            this.reject.Size = new System.Drawing.Size(80, 20);
            this.reject.Style = MetroFramework.MetroColorStyle.Red;
            this.reject.TabIndex = 1;
            this.reject.Text = "Reject ToS?";
            this.reject.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.reject.UseSelectable = true;
            this.reject.UseStyleColors = true;
            this.reject.Click += new System.EventHandler(this.RejectToS);
            // 
            // accept
            // 
            this.accept.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.accept.Location = new System.Drawing.Point(600, 740);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(80, 20);
            this.accept.Style = MetroFramework.MetroColorStyle.Blue;
            this.accept.TabIndex = 2;
            this.accept.Text = "Accept ToS?";
            this.accept.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.accept.UseSelectable = true;
            this.accept.UseStyleColors = true;
            this.accept.Click += new System.EventHandler(this.AcceptToS);
            // 
            // ScrollMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.box);
            this.Controls.Add(this.reject);
            this.Controls.Add(this.accept);
            this.Icon = global::DSLauncherV2.Properties.Resources.Freelancer1;
            this.Name = "ScrollMessageBox";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScrollMessageBox_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroTextBox box;
        private MetroButton reject;
        private MetroButton accept;
        private string tos;
        private bool readyToClose = false;

        private void RejectToS(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void AcceptToS(object sender, EventArgs e)
        {
            // Save all text to file
            File.WriteAllText(Directory.GetCurrentDirectory() + @"\ToS.txt", tos);
            readyToClose = true;
            this.Close();
        }

        private void ScrollMessageBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (readyToClose)
                return;

            e.Cancel = true;
        }
    }
}
