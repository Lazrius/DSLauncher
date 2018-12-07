using System;
using System.Windows.Forms;
using System.ComponentModel;

namespace DSLauncherV2
{
    sealed partial class Primary
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Primary));
            this.actionsLabel = new MetroFramework.Controls.MetroLabel();
            this.hrLabel1 = new System.Windows.Forms.Label();
            this.currentAccountLabel = new MetroFramework.Controls.MetroLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.MTC = new MetroFramework.Controls.MetroTabControl();
            this.CNS = new MetroFramework.Controls.MetroTabPage();
            this.CNSImport = new System.Windows.Forms.WebBrowser();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.ExternalSettings = new MetroFramework.Controls.MetroTabPage();
            this.metroLabel20 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.ThemeSelector = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.DiscordRPCCheckBox = new MetroFramework.Controls.MetroToggle();
            this.metroLabel7 = new MetroFramework.Controls.MetroLabel();
            this.ToggleLocalTime = new MetroFramework.Controls.MetroToggle();
            this.metroLabel6 = new MetroFramework.Controls.MetroLabel();
            this.ToggleLogTime = new MetroFramework.Controls.MetroToggle();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.ToggleChatAppend = new MetroFramework.Controls.MetroToggle();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.ToggleChatLog = new MetroFramework.Controls.MetroToggle();
            this.GameSettings = new MetroFramework.Controls.MetroTabPage();
            this.IncreaseDrawDistanceLabel = new MetroFramework.Controls.MetroLabel();
            this.IncreaseDrawDistance = new MetroFramework.Controls.MetroToggle();
            this.ChatWarning = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.DisableChat = new MetroFramework.Controls.MetroToggle();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.ToggleWindowedMode = new MetroFramework.Controls.MetroToggle();
            this.WidthLabel = new MetroFramework.Controls.MetroLabel();
            this.HeightLabel = new MetroFramework.Controls.MetroLabel();
            this.WidthBox = new MetroFramework.Controls.MetroTextBox();
            this.HeightBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel14 = new MetroFramework.Controls.MetroLabel();
            this.ToggleDesktopRes = new MetroFramework.Controls.MetroToggle();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel12 = new MetroFramework.Controls.MetroLabel();
            this.metroTextBox1 = new MetroFramework.Controls.MetroTextBox();
            this.forcedArguments = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel8 = new MetroFramework.Controls.MetroLabel();
            this.ToggleDepartingPlayer = new MetroFramework.Controls.MetroToggle();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.ToggleArrivingPlayer = new MetroFramework.Controls.MetroToggle();
            this.metroLabel10 = new MetroFramework.Controls.MetroLabel();
            this.ToggleLagIcon = new MetroFramework.Controls.MetroToggle();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.ToggleFlightText = new MetroFramework.Controls.MetroToggle();
            this.Accounts = new MetroFramework.Controls.MetroTabPage();
            this.AccountsGrid = new MetroFramework.Controls.MetroGrid();
            this.AccName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccIsFav = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccSignature = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccountContextMenu = new MetroFramework.Controls.MetroContextMenu(this.components);
            this.CreateNewAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectedAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.ExportAccounts = new System.Windows.Forms.ToolStripMenuItem();
            this.EditAccount = new System.Windows.Forms.ToolStripMenuItem();
            this.MarkFavorite = new System.Windows.Forms.ToolStripMenuItem();
            this.importLauncherAccountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.About = new MetroFramework.Controls.MetroTabPage();
            this.metroTile4 = new MetroFramework.Controls.MetroTile();
            this.metroTile3 = new MetroFramework.Controls.MetroTile();
            this.metroTile2 = new MetroFramework.Controls.MetroTile();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.aboutInfo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.LoadingBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.launchGame = new MetroFramework.Controls.MetroLink();
            this.patchGame = new MetroFramework.Controls.MetroLink();
            this.patchLauncher = new MetroFramework.Controls.MetroLink();
            this.ExportAccountSaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.CurrentSelectedAccountLabel = new MetroFramework.Controls.MetroLabel();
            this.FavAccount1 = new MetroFramework.Controls.MetroLink();
            this.FavAccount2 = new MetroFramework.Controls.MetroLink();
            this.FavAccount3 = new MetroFramework.Controls.MetroLink();
            this.FavAccount4 = new MetroFramework.Controls.MetroLink();
            this.RecentAccounts4 = new MetroFramework.Controls.MetroLink();
            this.RecentAccounts3 = new MetroFramework.Controls.MetroLink();
            this.RecentAccounts2 = new MetroFramework.Controls.MetroLink();
            this.RecentAccounts1 = new MetroFramework.Controls.MetroLink();
            this.SortCategory = new MetroFramework.Controls.MetroComboBox();
            this.metroLabel16 = new MetroFramework.Controls.MetroLabel();
            this.ImportLauncherFile = new System.Windows.Forms.OpenFileDialog();
            this.downloadProgress = new MetroFramework.Controls.MetroLabel();
            this.patchDownload = new MetroFramework.Controls.MetroProgressBar();
            this.launcherCheckerLabel = new MetroFramework.Controls.MetroLabel();
            this.launcherPatchSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.MTC.SuspendLayout();
            this.CNS.SuspendLayout();
            this.ExternalSettings.SuspendLayout();
            this.GameSettings.SuspendLayout();
            this.Accounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGrid)).BeginInit();
            this.AccountContextMenu.SuspendLayout();
            this.About.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // actionsLabel
            // 
            this.actionsLabel.AutoSize = true;
            this.actionsLabel.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.actionsLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.actionsLabel.Location = new System.Drawing.Point(536, 11);
            this.actionsLabel.Name = "actionsLabel";
            this.actionsLabel.Size = new System.Drawing.Size(67, 25);
            this.actionsLabel.TabIndex = 4;
            this.actionsLabel.Text = "Actions";
            this.actionsLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // hrLabel1
            // 
            this.hrLabel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.hrLabel1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.hrLabel1.Location = new System.Drawing.Point(536, 39);
            this.hrLabel1.Name = "hrLabel1";
            this.hrLabel1.Size = new System.Drawing.Size(243, 1);
            this.hrLabel1.TabIndex = 5;
            this.hrLabel1.Text = "                 ";
            // 
            // currentAccountLabel
            // 
            this.currentAccountLabel.AutoSize = true;
            this.currentAccountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.currentAccountLabel.Location = new System.Drawing.Point(7, 364);
            this.currentAccountLabel.Name = "currentAccountLabel";
            this.currentAccountLabel.Size = new System.Drawing.Size(111, 19);
            this.currentAccountLabel.TabIndex = 6;
            this.currentAccountLabel.Text = "Current Account: ";
            this.currentAccountLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label1.Location = new System.Drawing.Point(536, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 1);
            this.label1.TabIndex = 8;
            this.label1.Text = "                 ";
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.ForeColor = System.Drawing.SystemColors.Control;
            this.metroLabel1.Location = new System.Drawing.Point(536, 124);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(137, 25);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Recent Accounts";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.label2.Location = new System.Drawing.Point(536, 275);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(243, 1);
            this.label2.TabIndex = 10;
            this.label2.Text = "                 ";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel2.ForeColor = System.Drawing.SystemColors.Control;
            this.metroLabel2.Location = new System.Drawing.Point(536, 247);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(154, 25);
            this.metroLabel2.TabIndex = 9;
            this.metroLabel2.Text = "Favourite Accounts";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MTC
            // 
            this.MTC.Controls.Add(this.CNS);
            this.MTC.Controls.Add(this.ExternalSettings);
            this.MTC.Controls.Add(this.GameSettings);
            this.MTC.Controls.Add(this.Accounts);
            this.MTC.Controls.Add(this.About);
            this.MTC.Enabled = false;
            this.MTC.HotTrack = true;
            this.MTC.Location = new System.Drawing.Point(7, 5);
            this.MTC.Name = "MTC";
            this.MTC.SelectedIndex = 0;
            this.MTC.Size = new System.Drawing.Size(526, 347);
            this.MTC.TabIndex = 11;
            this.MTC.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.MTC.UseSelectable = true;
            this.MTC.SelectedIndexChanged += new System.EventHandler(this.MTC_SelectedIndexChanged);
            // 
            // CNS
            // 
            this.CNS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.CNS.Controls.Add(this.CNSImport);
            this.CNS.Controls.Add(this.metroLabel18);
            this.CNS.Controls.Add(this.metroProgressSpinner1);
            this.CNS.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.CNS.HorizontalScrollbarBarColor = true;
            this.CNS.HorizontalScrollbarHighlightOnWheel = false;
            this.CNS.HorizontalScrollbarSize = 10;
            this.CNS.Location = new System.Drawing.Point(4, 38);
            this.CNS.Name = "CNS";
            this.CNS.Size = new System.Drawing.Size(518, 305);
            this.CNS.TabIndex = 0;
            this.CNS.Text = "News";
            this.CNS.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CNS.UseCustomBackColor = true;
            this.CNS.VerticalScrollbarBarColor = true;
            this.CNS.VerticalScrollbarHighlightOnWheel = false;
            this.CNS.VerticalScrollbarSize = 10;
            // 
            // CNSImport
            // 
            this.CNSImport.AllowWebBrowserDrop = false;
            this.CNSImport.Location = new System.Drawing.Point(3, 3);
            this.CNSImport.MinimumSize = new System.Drawing.Size(20, 20);
            this.CNSImport.Name = "CNSImport";
            this.CNSImport.ScrollBarsEnabled = false;
            this.CNSImport.Size = new System.Drawing.Size(512, 299);
            this.CNSImport.TabIndex = 23;
            this.CNSImport.TabStop = false;
            this.CNSImport.WebBrowserShortcutsEnabled = false;
            this.CNSImport.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.CNSImport_Navigating);
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel18.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel18.ForeColor = System.Drawing.SystemColors.Control;
            this.metroLabel18.Location = new System.Drawing.Point(197, 116);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(165, 25);
            this.metroLabel18.TabIndex = 20;
            this.metroLabel18.Text = "Connecting To Kitty";
            this.metroLabel18.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel18.UseCustomBackColor = true;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(140, 110);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Minimum = 30;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(41, 31);
            this.metroProgressSpinner1.Speed = 3F;
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressSpinner1.TabIndex = 19;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.UseCustomBackColor = true;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Value = 40;
            // 
            // ExternalSettings
            // 
            this.ExternalSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.ExternalSettings.Controls.Add(this.metroLabel20);
            this.ExternalSettings.Controls.Add(this.metroLabel23);
            this.ExternalSettings.Controls.Add(this.ThemeSelector);
            this.ExternalSettings.Controls.Add(this.metroLabel19);
            this.ExternalSettings.Controls.Add(this.DiscordRPCCheckBox);
            this.ExternalSettings.Controls.Add(this.metroLabel7);
            this.ExternalSettings.Controls.Add(this.ToggleLocalTime);
            this.ExternalSettings.Controls.Add(this.metroLabel6);
            this.ExternalSettings.Controls.Add(this.ToggleLogTime);
            this.ExternalSettings.Controls.Add(this.metroLabel5);
            this.ExternalSettings.Controls.Add(this.ToggleChatAppend);
            this.ExternalSettings.Controls.Add(this.metroLabel4);
            this.ExternalSettings.Controls.Add(this.ToggleChatLog);
            this.ExternalSettings.HorizontalScrollbarBarColor = true;
            this.ExternalSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.ExternalSettings.HorizontalScrollbarSize = 10;
            this.ExternalSettings.Location = new System.Drawing.Point(4, 38);
            this.ExternalSettings.Name = "ExternalSettings";
            this.ExternalSettings.Size = new System.Drawing.Size(518, 305);
            this.ExternalSettings.TabIndex = 2;
            this.ExternalSettings.Text = "External Settings";
            this.ExternalSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ExternalSettings.UseCustomBackColor = true;
            this.ExternalSettings.VerticalScrollbarBarColor = true;
            this.ExternalSettings.VerticalScrollbarHighlightOnWheel = false;
            this.ExternalSettings.VerticalScrollbarSize = 10;
            // 
            // metroLabel20
            // 
            this.metroLabel20.AutoSize = true;
            this.metroLabel20.Location = new System.Drawing.Point(329, 12);
            this.metroLabel20.Name = "metroLabel20";
            this.metroLabel20.Size = new System.Drawing.Size(134, 19);
            this.metroLabel20.TabIndex = 20;
            this.metroLabel20.Text = "Experimental Settings";
            this.metroLabel20.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel20.UseCustomBackColor = true;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(61, 235);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(92, 19);
            this.metroLabel23.TabIndex = 19;
            this.metroLabel23.Text = "Launcher Style";
            this.metroLabel23.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel23.UseCustomBackColor = true;
            // 
            // ThemeSelector
            // 
            this.ThemeSelector.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ThemeSelector.FormattingEnabled = true;
            this.ThemeSelector.ItemHeight = 23;
            this.ThemeSelector.Items.AddRange(new object[] {
            "Default",
            "Black",
            "White",
            "Silver",
            "Blue",
            "Green",
            "Lime",
            "Teal",
            "Orange",
            "Brown",
            "Pink",
            "Magenta",
            "Purple",
            "Red",
            "Yellow"});
            this.ThemeSelector.Location = new System.Drawing.Point(32, 257);
            this.ThemeSelector.Name = "ThemeSelector";
            this.ThemeSelector.Size = new System.Drawing.Size(142, 29);
            this.ThemeSelector.TabIndex = 18;
            this.ThemeSelector.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ThemeSelector.UseCustomBackColor = true;
            this.ThemeSelector.UseSelectable = true;
            this.ThemeSelector.UseStyleColors = true;
            this.ThemeSelector.SelectedIndexChanged += new System.EventHandler(this.ThemeSelector_SelectedIndexChanged);
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(359, 45);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(109, 19);
            this.metroLabel19.TabIndex = 11;
            this.metroLabel19.Text = "Discord Presence";
            this.metroLabel19.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel19.UseCustomBackColor = true;
            // 
            // DiscordRPCCheckBox
            // 
            this.DiscordRPCCheckBox.AutoSize = true;
            this.DiscordRPCCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.DiscordRPCCheckBox.Enabled = false;
            this.DiscordRPCCheckBox.Location = new System.Drawing.Point(279, 46);
            this.DiscordRPCCheckBox.Name = "DiscordRPCCheckBox";
            this.DiscordRPCCheckBox.Size = new System.Drawing.Size(80, 17);
            this.DiscordRPCCheckBox.TabIndex = 10;
            this.DiscordRPCCheckBox.Text = "Off";
            this.DiscordRPCCheckBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DiscordRPCCheckBox.UseCustomBackColor = true;
            this.DiscordRPCCheckBox.UseSelectable = true;
            this.DiscordRPCCheckBox.CheckedChanged += new System.EventHandler(this.DiscordRPCCheckBox_CheckedChanged);
            // 
            // metroLabel7
            // 
            this.metroLabel7.AutoSize = true;
            this.metroLabel7.Location = new System.Drawing.Point(98, 109);
            this.metroLabel7.Name = "metroLabel7";
            this.metroLabel7.Size = new System.Drawing.Size(98, 19);
            this.metroLabel7.TabIndex = 9;
            this.metroLabel7.Text = "Log Local Time";
            this.metroLabel7.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel7.UseCustomBackColor = true;
            // 
            // ToggleLocalTime
            // 
            this.ToggleLocalTime.AutoSize = true;
            this.ToggleLocalTime.Checked = true;
            this.ToggleLocalTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleLocalTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleLocalTime.Location = new System.Drawing.Point(18, 110);
            this.ToggleLocalTime.Name = "ToggleLocalTime";
            this.ToggleLocalTime.Size = new System.Drawing.Size(80, 17);
            this.ToggleLocalTime.TabIndex = 8;
            this.ToggleLocalTime.Text = "On";
            this.ToggleLocalTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleLocalTime.UseCustomBackColor = true;
            this.ToggleLocalTime.UseSelectable = true;
            this.ToggleLocalTime.CheckedChanged += new System.EventHandler(this.ToggleLocalTime_CheckedChanged);
            // 
            // metroLabel6
            // 
            this.metroLabel6.AutoSize = true;
            this.metroLabel6.Location = new System.Drawing.Point(98, 77);
            this.metroLabel6.Name = "metroLabel6";
            this.metroLabel6.Size = new System.Drawing.Size(64, 19);
            this.metroLabel6.TabIndex = 7;
            this.metroLabel6.Text = "Log Time";
            this.metroLabel6.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel6.UseCustomBackColor = true;
            // 
            // ToggleLogTime
            // 
            this.ToggleLogTime.AutoSize = true;
            this.ToggleLogTime.Checked = true;
            this.ToggleLogTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleLogTime.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleLogTime.Location = new System.Drawing.Point(18, 78);
            this.ToggleLogTime.Name = "ToggleLogTime";
            this.ToggleLogTime.Size = new System.Drawing.Size(80, 17);
            this.ToggleLogTime.TabIndex = 6;
            this.ToggleLogTime.Text = "On";
            this.ToggleLogTime.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleLogTime.UseCustomBackColor = true;
            this.ToggleLogTime.UseSelectable = true;
            this.ToggleLogTime.CheckedChanged += new System.EventHandler(this.ToggleLogTime_CheckedChanged);
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(98, 45);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(87, 19);
            this.metroLabel5.TabIndex = 5;
            this.metroLabel5.Text = "Append Logs";
            this.metroLabel5.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel5.UseCustomBackColor = true;
            // 
            // ToggleChatAppend
            // 
            this.ToggleChatAppend.AutoSize = true;
            this.ToggleChatAppend.Checked = true;
            this.ToggleChatAppend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleChatAppend.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleChatAppend.Location = new System.Drawing.Point(18, 46);
            this.ToggleChatAppend.Name = "ToggleChatAppend";
            this.ToggleChatAppend.Size = new System.Drawing.Size(80, 17);
            this.ToggleChatAppend.TabIndex = 4;
            this.ToggleChatAppend.Text = "On";
            this.ToggleChatAppend.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleChatAppend.UseCustomBackColor = true;
            this.ToggleChatAppend.UseSelectable = true;
            this.ToggleChatAppend.CheckedChanged += new System.EventHandler(this.ToggleChatAppend_CheckedChanged);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(98, 13);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(62, 19);
            this.metroLabel4.TabIndex = 3;
            this.metroLabel4.Text = "Chat Log";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel4.UseCustomBackColor = true;
            // 
            // ToggleChatLog
            // 
            this.ToggleChatLog.AutoSize = true;
            this.ToggleChatLog.Checked = true;
            this.ToggleChatLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleChatLog.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleChatLog.Location = new System.Drawing.Point(18, 14);
            this.ToggleChatLog.Name = "ToggleChatLog";
            this.ToggleChatLog.Size = new System.Drawing.Size(80, 17);
            this.ToggleChatLog.TabIndex = 2;
            this.ToggleChatLog.Text = "On";
            this.ToggleChatLog.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleChatLog.UseCustomBackColor = true;
            this.ToggleChatLog.UseSelectable = true;
            this.ToggleChatLog.CheckedChanged += new System.EventHandler(this.ToggleChatLog_CheckedChanged);
            // 
            // GameSettings
            // 
            this.GameSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.GameSettings.Controls.Add(this.IncreaseDrawDistanceLabel);
            this.GameSettings.Controls.Add(this.IncreaseDrawDistance);
            this.GameSettings.Controls.Add(this.ChatWarning);
            this.GameSettings.Controls.Add(this.metroLabel15);
            this.GameSettings.Controls.Add(this.DisableChat);
            this.GameSettings.Controls.Add(this.metroLabel17);
            this.GameSettings.Controls.Add(this.ToggleWindowedMode);
            this.GameSettings.Controls.Add(this.WidthLabel);
            this.GameSettings.Controls.Add(this.HeightLabel);
            this.GameSettings.Controls.Add(this.WidthBox);
            this.GameSettings.Controls.Add(this.HeightBox);
            this.GameSettings.Controls.Add(this.metroLabel14);
            this.GameSettings.Controls.Add(this.ToggleDesktopRes);
            this.GameSettings.Controls.Add(this.metroLabel13);
            this.GameSettings.Controls.Add(this.metroLabel12);
            this.GameSettings.Controls.Add(this.metroTextBox1);
            this.GameSettings.Controls.Add(this.forcedArguments);
            this.GameSettings.Controls.Add(this.metroLabel8);
            this.GameSettings.Controls.Add(this.ToggleDepartingPlayer);
            this.GameSettings.Controls.Add(this.metroLabel9);
            this.GameSettings.Controls.Add(this.ToggleArrivingPlayer);
            this.GameSettings.Controls.Add(this.metroLabel10);
            this.GameSettings.Controls.Add(this.ToggleLagIcon);
            this.GameSettings.Controls.Add(this.metroLabel11);
            this.GameSettings.Controls.Add(this.ToggleFlightText);
            this.GameSettings.HorizontalScrollbarBarColor = true;
            this.GameSettings.HorizontalScrollbarHighlightOnWheel = false;
            this.GameSettings.HorizontalScrollbarSize = 10;
            this.GameSettings.Location = new System.Drawing.Point(4, 38);
            this.GameSettings.Name = "GameSettings";
            this.GameSettings.Size = new System.Drawing.Size(518, 305);
            this.GameSettings.TabIndex = 5;
            this.GameSettings.Text = "Game Settings";
            this.GameSettings.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.GameSettings.UseCustomBackColor = true;
            this.GameSettings.UseStyleColors = true;
            this.GameSettings.VerticalScrollbarBarColor = true;
            this.GameSettings.VerticalScrollbarHighlightOnWheel = false;
            this.GameSettings.VerticalScrollbarSize = 10;
            // 
            // IncreaseDrawDistanceLabel
            // 
            this.IncreaseDrawDistanceLabel.AutoSize = true;
            this.IncreaseDrawDistanceLabel.Location = new System.Drawing.Point(98, 205);
            this.IncreaseDrawDistanceLabel.Name = "IncreaseDrawDistanceLabel";
            this.IncreaseDrawDistanceLabel.Size = new System.Drawing.Size(142, 19);
            this.IncreaseDrawDistanceLabel.TabIndex = 56;
            this.IncreaseDrawDistanceLabel.Text = "Increase Draw Distance";
            this.IncreaseDrawDistanceLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.IncreaseDrawDistanceLabel.UseCustomBackColor = true;
            // 
            // IncreaseDrawDistance
            // 
            this.IncreaseDrawDistance.AutoSize = true;
            this.IncreaseDrawDistance.Checked = true;
            this.IncreaseDrawDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IncreaseDrawDistance.Cursor = System.Windows.Forms.Cursors.Default;
            this.IncreaseDrawDistance.Location = new System.Drawing.Point(18, 206);
            this.IncreaseDrawDistance.Name = "IncreaseDrawDistance";
            this.IncreaseDrawDistance.Size = new System.Drawing.Size(80, 17);
            this.IncreaseDrawDistance.TabIndex = 55;
            this.IncreaseDrawDistance.Text = "On";
            this.IncreaseDrawDistance.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.IncreaseDrawDistance.UseCustomBackColor = true;
            this.IncreaseDrawDistance.UseSelectable = true;
            this.IncreaseDrawDistance.CheckedChanged += new System.EventHandler(this.IncreaseDrawDistance_CheckedChanged);
            // 
            // ChatWarning
            // 
            this.ChatWarning.AutoSize = true;
            this.ChatWarning.Location = new System.Drawing.Point(312, 45);
            this.ChatWarning.Name = "ChatWarning";
            this.ChatWarning.Size = new System.Drawing.Size(203, 76);
            this.ChatWarning.TabIndex = 54;
            this.ChatWarning.Text = "Disabling the chat for multiplayer\r\nis highly unadvised and can cause\r\nissues. It" +
    " is largly for recording\r\npurposes.";
            this.ChatWarning.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChatWarning.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ChatWarning.UseCustomBackColor = true;
            this.ChatWarning.Visible = false;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(410, 12);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(82, 19);
            this.metroLabel15.TabIndex = 53;
            this.metroLabel15.Text = "Disable Chat";
            this.metroLabel15.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel15.UseCustomBackColor = true;
            // 
            // DisableChat
            // 
            this.DisableChat.AutoSize = true;
            this.DisableChat.Cursor = System.Windows.Forms.Cursors.Default;
            this.DisableChat.Location = new System.Drawing.Point(330, 14);
            this.DisableChat.Name = "DisableChat";
            this.DisableChat.Size = new System.Drawing.Size(80, 17);
            this.DisableChat.TabIndex = 52;
            this.DisableChat.Text = "Off";
            this.DisableChat.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DisableChat.UseCustomBackColor = true;
            this.DisableChat.UseSelectable = true;
            this.DisableChat.CheckedChanged += new System.EventHandler(this.DisableChat_CheckedChanged);
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(98, 173);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(111, 19);
            this.metroLabel17.TabIndex = 49;
            this.metroLabel17.Text = "Windowed Mode";
            this.metroLabel17.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel17.UseCustomBackColor = true;
            // 
            // ToggleWindowedMode
            // 
            this.ToggleWindowedMode.AutoSize = true;
            this.ToggleWindowedMode.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleWindowedMode.Location = new System.Drawing.Point(18, 174);
            this.ToggleWindowedMode.Name = "ToggleWindowedMode";
            this.ToggleWindowedMode.Size = new System.Drawing.Size(80, 17);
            this.ToggleWindowedMode.TabIndex = 48;
            this.ToggleWindowedMode.Text = "Off";
            this.ToggleWindowedMode.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleWindowedMode.UseCustomBackColor = true;
            this.ToggleWindowedMode.UseSelectable = true;
            this.ToggleWindowedMode.CheckedChanged += new System.EventHandler(this.ToggleWindowedMode_CheckedChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Enabled = false;
            this.WidthLabel.ForeColor = System.Drawing.Color.Black;
            this.WidthLabel.Location = new System.Drawing.Point(418, 142);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(15, 19);
            this.WidthLabel.TabIndex = 47;
            this.WidthLabel.Text = "x";
            this.WidthLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WidthLabel.UseCustomBackColor = true;
            this.WidthLabel.Visible = false;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Enabled = false;
            this.HeightLabel.Location = new System.Drawing.Point(275, 141);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(72, 19);
            this.HeightLabel.TabIndex = 46;
            this.HeightLabel.Text = "Resolution:";
            this.HeightLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.HeightLabel.UseCustomBackColor = true;
            this.HeightLabel.Visible = false;
            // 
            // WidthBox
            // 
            // 
            // 
            // 
            this.WidthBox.CustomButton.Image = null;
            this.WidthBox.CustomButton.Location = new System.Drawing.Point(42, 1);
            this.WidthBox.CustomButton.Name = "";
            this.WidthBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.WidthBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.WidthBox.CustomButton.TabIndex = 1;
            this.WidthBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.WidthBox.CustomButton.UseSelectable = true;
            this.WidthBox.CustomButton.Visible = false;
            this.WidthBox.Enabled = false;
            this.WidthBox.Lines = new string[0];
            this.WidthBox.Location = new System.Drawing.Point(435, 140);
            this.WidthBox.Margin = new System.Windows.Forms.Padding(0);
            this.WidthBox.MaxLength = 32767;
            this.WidthBox.Name = "WidthBox";
            this.WidthBox.PasswordChar = '\0';
            this.WidthBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.WidthBox.SelectedText = "";
            this.WidthBox.SelectionLength = 0;
            this.WidthBox.SelectionStart = 0;
            this.WidthBox.ShortcutsEnabled = true;
            this.WidthBox.Size = new System.Drawing.Size(64, 23);
            this.WidthBox.TabIndex = 45;
            this.WidthBox.TabStop = false;
            this.WidthBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.WidthBox.UseCustomBackColor = true;
            this.WidthBox.UseSelectable = true;
            this.WidthBox.Visible = false;
            this.WidthBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.WidthBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.WidthBox.TextChanged += new System.EventHandler(this.WidthBox_TextChanged);
            // 
            // HeightBox
            // 
            // 
            // 
            // 
            this.HeightBox.CustomButton.Image = null;
            this.HeightBox.CustomButton.Location = new System.Drawing.Point(42, 1);
            this.HeightBox.CustomButton.Name = "";
            this.HeightBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.HeightBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.HeightBox.CustomButton.TabIndex = 1;
            this.HeightBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.HeightBox.CustomButton.UseSelectable = true;
            this.HeightBox.CustomButton.Visible = false;
            this.HeightBox.Lines = new string[0];
            this.HeightBox.Location = new System.Drawing.Point(352, 140);
            this.HeightBox.Margin = new System.Windows.Forms.Padding(0);
            this.HeightBox.MaxLength = 32767;
            this.HeightBox.Name = "HeightBox";
            this.HeightBox.PasswordChar = '\0';
            this.HeightBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.HeightBox.SelectedText = "";
            this.HeightBox.SelectionLength = 0;
            this.HeightBox.SelectionStart = 0;
            this.HeightBox.ShortcutsEnabled = true;
            this.HeightBox.Size = new System.Drawing.Size(64, 23);
            this.HeightBox.TabIndex = 44;
            this.HeightBox.TabStop = false;
            this.HeightBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.HeightBox.UseCustomBackColor = true;
            this.HeightBox.UseSelectable = true;
            this.HeightBox.Visible = false;
            this.HeightBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.HeightBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.HeightBox.TextChanged += new System.EventHandler(this.HeightBox_TextChanged);
            // 
            // metroLabel14
            // 
            this.metroLabel14.AutoSize = true;
            this.metroLabel14.Location = new System.Drawing.Point(98, 141);
            this.metroLabel14.Name = "metroLabel14";
            this.metroLabel14.Size = new System.Drawing.Size(145, 19);
            this.metroLabel14.TabIndex = 43;
            this.metroLabel14.Text = "Use Desktop Resolution";
            this.metroLabel14.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel14.UseCustomBackColor = true;
            // 
            // ToggleDesktopRes
            // 
            this.ToggleDesktopRes.AutoSize = true;
            this.ToggleDesktopRes.Checked = true;
            this.ToggleDesktopRes.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleDesktopRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleDesktopRes.Location = new System.Drawing.Point(18, 142);
            this.ToggleDesktopRes.Name = "ToggleDesktopRes";
            this.ToggleDesktopRes.Size = new System.Drawing.Size(80, 17);
            this.ToggleDesktopRes.TabIndex = 42;
            this.ToggleDesktopRes.Text = "On";
            this.ToggleDesktopRes.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleDesktopRes.UseCustomBackColor = true;
            this.ToggleDesktopRes.UseSelectable = true;
            this.ToggleDesktopRes.CheckedChanged += new System.EventHandler(this.ToggleDesktopRes_CheckedChanged);
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(17, 240);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(131, 19);
            this.metroLabel13.TabIndex = 41;
            this.metroLabel13.Text = "Optional Arguments:";
            this.metroLabel13.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel13.UseCustomBackColor = true;
            // 
            // metroLabel12
            // 
            this.metroLabel12.AutoSize = true;
            this.metroLabel12.Location = new System.Drawing.Point(18, 271);
            this.metroLabel12.Name = "metroLabel12";
            this.metroLabel12.Size = new System.Drawing.Size(121, 19);
            this.metroLabel12.TabIndex = 40;
            this.metroLabel12.Text = "Forced Arguments:";
            this.metroLabel12.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel12.UseCustomBackColor = true;
            // 
            // metroTextBox1
            // 
            // 
            // 
            // 
            this.metroTextBox1.CustomButton.Image = null;
            this.metroTextBox1.CustomButton.Location = new System.Drawing.Point(310, 1);
            this.metroTextBox1.CustomButton.Name = "";
            this.metroTextBox1.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.metroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroTextBox1.CustomButton.TabIndex = 1;
            this.metroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.metroTextBox1.CustomButton.UseSelectable = true;
            this.metroTextBox1.CustomButton.Visible = false;
            this.metroTextBox1.Lines = new string[0];
            this.metroTextBox1.Location = new System.Drawing.Point(167, 238);
            this.metroTextBox1.Margin = new System.Windows.Forms.Padding(0);
            this.metroTextBox1.MaxLength = 32767;
            this.metroTextBox1.Name = "metroTextBox1";
            this.metroTextBox1.PasswordChar = '\0';
            this.metroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.metroTextBox1.SelectedText = "";
            this.metroTextBox1.SelectionLength = 0;
            this.metroTextBox1.SelectionStart = 0;
            this.metroTextBox1.ShortcutsEnabled = true;
            this.metroTextBox1.Size = new System.Drawing.Size(332, 23);
            this.metroTextBox1.TabIndex = 39;
            this.metroTextBox1.TabStop = false;
            this.metroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTextBox1.UseCustomBackColor = true;
            this.metroTextBox1.UseSelectable = true;
            this.metroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.metroTextBox1.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.metroTextBox1.TextChanged += new System.EventHandler(this.metroTextBox1_TextChanged);
            // 
            // forcedArguments
            // 
            // 
            // 
            // 
            this.forcedArguments.CustomButton.Image = null;
            this.forcedArguments.CustomButton.Location = new System.Drawing.Point(310, 1);
            this.forcedArguments.CustomButton.Name = "";
            this.forcedArguments.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.forcedArguments.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.forcedArguments.CustomButton.TabIndex = 1;
            this.forcedArguments.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.forcedArguments.CustomButton.UseSelectable = true;
            this.forcedArguments.CustomButton.Visible = false;
            this.forcedArguments.Lines = new string[0];
            this.forcedArguments.Location = new System.Drawing.Point(167, 269);
            this.forcedArguments.Margin = new System.Windows.Forms.Padding(0);
            this.forcedArguments.MaxLength = 32767;
            this.forcedArguments.Name = "forcedArguments";
            this.forcedArguments.PasswordChar = '\0';
            this.forcedArguments.ReadOnly = true;
            this.forcedArguments.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.forcedArguments.SelectedText = "";
            this.forcedArguments.SelectionLength = 0;
            this.forcedArguments.SelectionStart = 0;
            this.forcedArguments.ShortcutsEnabled = true;
            this.forcedArguments.Size = new System.Drawing.Size(332, 23);
            this.forcedArguments.TabIndex = 38;
            this.forcedArguments.TabStop = false;
            this.forcedArguments.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.forcedArguments.UseCustomBackColor = true;
            this.forcedArguments.UseSelectable = true;
            this.forcedArguments.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.forcedArguments.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel8
            // 
            this.metroLabel8.AutoSize = true;
            this.metroLabel8.Location = new System.Drawing.Point(98, 109);
            this.metroLabel8.Name = "metroLabel8";
            this.metroLabel8.Size = new System.Drawing.Size(153, 19);
            this.metroLabel8.TabIndex = 37;
            this.metroLabel8.Text = "Show \"Departing Player\"";
            this.metroLabel8.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel8.UseCustomBackColor = true;
            // 
            // ToggleDepartingPlayer
            // 
            this.ToggleDepartingPlayer.AutoSize = true;
            this.ToggleDepartingPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleDepartingPlayer.Location = new System.Drawing.Point(18, 110);
            this.ToggleDepartingPlayer.Name = "ToggleDepartingPlayer";
            this.ToggleDepartingPlayer.Size = new System.Drawing.Size(80, 17);
            this.ToggleDepartingPlayer.TabIndex = 36;
            this.ToggleDepartingPlayer.Text = "Off";
            this.ToggleDepartingPlayer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleDepartingPlayer.UseCustomBackColor = true;
            this.ToggleDepartingPlayer.UseSelectable = true;
            this.ToggleDepartingPlayer.CheckedChanged += new System.EventHandler(this.ToggleDepartingPlayer_CheckedChanged);
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(98, 77);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(140, 19);
            this.metroLabel9.TabIndex = 35;
            this.metroLabel9.Text = "Show \"Arriving Player\"";
            this.metroLabel9.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel9.UseCustomBackColor = true;
            // 
            // ToggleArrivingPlayer
            // 
            this.ToggleArrivingPlayer.AutoSize = true;
            this.ToggleArrivingPlayer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleArrivingPlayer.Location = new System.Drawing.Point(18, 78);
            this.ToggleArrivingPlayer.Name = "ToggleArrivingPlayer";
            this.ToggleArrivingPlayer.Size = new System.Drawing.Size(80, 17);
            this.ToggleArrivingPlayer.TabIndex = 34;
            this.ToggleArrivingPlayer.Text = "Off";
            this.ToggleArrivingPlayer.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleArrivingPlayer.UseCustomBackColor = true;
            this.ToggleArrivingPlayer.UseSelectable = true;
            this.ToggleArrivingPlayer.CheckedChanged += new System.EventHandler(this.ToggleArrivingPlayer_CheckedChanged);
            // 
            // metroLabel10
            // 
            this.metroLabel10.AutoSize = true;
            this.metroLabel10.Location = new System.Drawing.Point(98, 45);
            this.metroLabel10.Name = "metroLabel10";
            this.metroLabel10.Size = new System.Drawing.Size(93, 19);
            this.metroLabel10.TabIndex = 33;
            this.metroLabel10.Text = "Show Lag Icon";
            this.metroLabel10.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel10.UseCustomBackColor = true;
            // 
            // ToggleLagIcon
            // 
            this.ToggleLagIcon.AutoSize = true;
            this.ToggleLagIcon.Checked = true;
            this.ToggleLagIcon.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleLagIcon.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleLagIcon.Location = new System.Drawing.Point(18, 46);
            this.ToggleLagIcon.Name = "ToggleLagIcon";
            this.ToggleLagIcon.Size = new System.Drawing.Size(80, 17);
            this.ToggleLagIcon.TabIndex = 32;
            this.ToggleLagIcon.Text = "On";
            this.ToggleLagIcon.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleLagIcon.UseCustomBackColor = true;
            this.ToggleLagIcon.UseSelectable = true;
            this.ToggleLagIcon.CheckedChanged += new System.EventHandler(this.ToggleLagIcon_CheckedChanged);
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(98, 13);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(102, 19);
            this.metroLabel11.TabIndex = 31;
            this.metroLabel11.Text = "Show Flight Text";
            this.metroLabel11.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel11.UseCustomBackColor = true;
            // 
            // ToggleFlightText
            // 
            this.ToggleFlightText.AutoSize = true;
            this.ToggleFlightText.Checked = true;
            this.ToggleFlightText.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ToggleFlightText.Cursor = System.Windows.Forms.Cursors.Default;
            this.ToggleFlightText.Location = new System.Drawing.Point(18, 14);
            this.ToggleFlightText.Name = "ToggleFlightText";
            this.ToggleFlightText.Size = new System.Drawing.Size(80, 17);
            this.ToggleFlightText.TabIndex = 30;
            this.ToggleFlightText.Text = "On";
            this.ToggleFlightText.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ToggleFlightText.UseCustomBackColor = true;
            this.ToggleFlightText.UseSelectable = true;
            this.ToggleFlightText.CheckedChanged += new System.EventHandler(this.ToggleFlightText_CheckedChanged);
            // 
            // Accounts
            // 
            this.Accounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.Accounts.Controls.Add(this.AccountsGrid);
            this.Accounts.HorizontalScrollbarBarColor = true;
            this.Accounts.HorizontalScrollbarHighlightOnWheel = false;
            this.Accounts.HorizontalScrollbarSize = 10;
            this.Accounts.Location = new System.Drawing.Point(4, 38);
            this.Accounts.Name = "Accounts";
            this.Accounts.Size = new System.Drawing.Size(518, 305);
            this.Accounts.TabIndex = 1;
            this.Accounts.Text = "Accounts";
            this.Accounts.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Accounts.UseCustomBackColor = true;
            this.Accounts.VerticalScrollbarBarColor = true;
            this.Accounts.VerticalScrollbarHighlightOnWheel = false;
            this.Accounts.VerticalScrollbarSize = 10;
            // 
            // AccountsGrid
            // 
            this.AccountsGrid.AllowUserToAddRows = false;
            this.AccountsGrid.AllowUserToDeleteRows = false;
            this.AccountsGrid.AllowUserToOrderColumns = true;
            this.AccountsGrid.AllowUserToResizeColumns = false;
            this.AccountsGrid.AllowUserToResizeRows = false;
            this.AccountsGrid.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AccountsGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AccountsGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.AccountsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.AccountsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AccountsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AccName,
            this.AccDescription,
            this.AccCategory,
            this.AccIsFav,
            this.AccCode,
            this.AccSignature});
            this.AccountsGrid.ContextMenuStrip = this.AccountContextMenu;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.AccountsGrid.DefaultCellStyle = dataGridViewCellStyle2;
            this.AccountsGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.AccountsGrid.EnableHeadersVisualStyles = false;
            this.AccountsGrid.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.AccountsGrid.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AccountsGrid.Location = new System.Drawing.Point(3, 3);
            this.AccountsGrid.Name = "AccountsGrid";
            this.AccountsGrid.ReadOnly = true;
            this.AccountsGrid.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(198)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.AccountsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.AccountsGrid.RowHeadersVisible = false;
            this.AccountsGrid.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.AccountsGrid.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AccountsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.AccountsGrid.Size = new System.Drawing.Size(512, 299);
            this.AccountsGrid.StandardTab = true;
            this.AccountsGrid.TabIndex = 7;
            this.AccountsGrid.UseStyleColors = true;
            this.AccountsGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.AccountsGrid_MouseDoubleClick);
            // 
            // AccName
            // 
            this.AccName.HeaderText = "Name";
            this.AccName.Name = "AccName";
            this.AccName.ReadOnly = true;
            this.AccName.Width = 140;
            // 
            // AccDescription
            // 
            this.AccDescription.HeaderText = "Description";
            this.AccDescription.Name = "AccDescription";
            this.AccDescription.ReadOnly = true;
            this.AccDescription.Width = 140;
            // 
            // AccCategory
            // 
            this.AccCategory.HeaderText = "Category";
            this.AccCategory.Name = "AccCategory";
            this.AccCategory.ReadOnly = true;
            this.AccCategory.Width = 120;
            // 
            // AccIsFav
            // 
            this.AccIsFav.HeaderText = "Favourite";
            this.AccIsFav.Name = "AccIsFav";
            this.AccIsFav.ReadOnly = true;
            // 
            // AccCode
            // 
            this.AccCode.HeaderText = "AccCode";
            this.AccCode.Name = "AccCode";
            this.AccCode.ReadOnly = true;
            this.AccCode.Visible = false;
            // 
            // AccSignature
            // 
            this.AccSignature.HeaderText = "AccSignature";
            this.AccSignature.Name = "AccSignature";
            this.AccSignature.ReadOnly = true;
            this.AccSignature.Visible = false;
            // 
            // AccountContextMenu
            // 
            this.AccountContextMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.AccountContextMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.AccountContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateNewAccount,
            this.DeleteSelectedAccounts,
            this.ExportAccounts,
            this.EditAccount,
            this.MarkFavorite,
            this.importLauncherAccountsToolStripMenuItem});
            this.AccountContextMenu.Name = "metroContextMenu1";
            this.AccountContextMenu.Size = new System.Drawing.Size(216, 136);
            this.AccountContextMenu.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.AccountContextMenu.UseStyleColors = true;
            // 
            // CreateNewAccount
            // 
            this.CreateNewAccount.Name = "CreateNewAccount";
            this.CreateNewAccount.Size = new System.Drawing.Size(215, 22);
            this.CreateNewAccount.Text = "Create New Account";
            this.CreateNewAccount.Click += new System.EventHandler(this.CreateNewAccount_Click);
            // 
            // DeleteSelectedAccounts
            // 
            this.DeleteSelectedAccounts.Name = "DeleteSelectedAccounts";
            this.DeleteSelectedAccounts.Size = new System.Drawing.Size(215, 22);
            this.DeleteSelectedAccounts.Text = "Delete Selected Accounts";
            this.DeleteSelectedAccounts.Click += new System.EventHandler(this.DeleteSelectedAccounts_Click);
            // 
            // ExportAccounts
            // 
            this.ExportAccounts.Name = "ExportAccounts";
            this.ExportAccounts.Size = new System.Drawing.Size(215, 22);
            this.ExportAccounts.Text = "Export Selected Accounts";
            this.ExportAccounts.Click += new System.EventHandler(this.ExportAccounts_Click);
            // 
            // EditAccount
            // 
            this.EditAccount.Name = "EditAccount";
            this.EditAccount.Size = new System.Drawing.Size(215, 22);
            this.EditAccount.Text = "Edit Selected Account";
            this.EditAccount.Click += new System.EventHandler(this.EditAccount_Click);
            // 
            // MarkFavorite
            // 
            this.MarkFavorite.Name = "MarkFavorite";
            this.MarkFavorite.Size = new System.Drawing.Size(215, 22);
            this.MarkFavorite.Text = "Mark/Unmark Favorite";
            this.MarkFavorite.Click += new System.EventHandler(this.MarkFavorite_Click);
            // 
            // importLauncherAccountsToolStripMenuItem
            // 
            this.importLauncherAccountsToolStripMenuItem.Name = "importLauncherAccountsToolStripMenuItem";
            this.importLauncherAccountsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.importLauncherAccountsToolStripMenuItem.Text = "Import Launcher Accounts";
            this.importLauncherAccountsToolStripMenuItem.Click += new System.EventHandler(this.importLauncherAccountsToolStripMenuItem_Click);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.About.Controls.Add(this.metroTile4);
            this.About.Controls.Add(this.metroTile3);
            this.About.Controls.Add(this.metroTile2);
            this.About.Controls.Add(this.metroTile1);
            this.About.Controls.Add(this.aboutInfo);
            this.About.Controls.Add(this.metroLabel3);
            this.About.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.About.HorizontalScrollbarBarColor = true;
            this.About.HorizontalScrollbarHighlightOnWheel = false;
            this.About.HorizontalScrollbarSize = 10;
            this.About.Location = new System.Drawing.Point(4, 38);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(518, 305);
            this.About.Style = MetroFramework.MetroColorStyle.Pink;
            this.About.TabIndex = 3;
            this.About.Text = "About";
            this.About.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.About.UseCustomBackColor = true;
            this.About.VerticalScrollbarBarColor = true;
            this.About.VerticalScrollbarHighlightOnWheel = false;
            this.About.VerticalScrollbarSize = 10;
            // 
            // metroTile4
            // 
            this.metroTile4.ActiveControl = null;
            this.metroTile4.Enabled = false;
            this.metroTile4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.metroTile4.Location = new System.Drawing.Point(30, 52);
            this.metroTile4.Name = "metroTile4";
            this.metroTile4.Size = new System.Drawing.Size(458, 10);
            this.metroTile4.TabIndex = 21;
            this.metroTile4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile4.UseCustomBackColor = true;
            this.metroTile4.UseCustomForeColor = true;
            this.metroTile4.UseSelectable = true;
            // 
            // metroTile3
            // 
            this.metroTile3.ActiveControl = null;
            this.metroTile3.Enabled = false;
            this.metroTile3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.metroTile3.Location = new System.Drawing.Point(485, 35);
            this.metroTile3.Name = "metroTile3";
            this.metroTile3.Size = new System.Drawing.Size(24, 251);
            this.metroTile3.TabIndex = 20;
            this.metroTile3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile3.UseCustomBackColor = true;
            this.metroTile3.UseCustomForeColor = true;
            this.metroTile3.UseSelectable = true;
            // 
            // metroTile2
            // 
            this.metroTile2.ActiveControl = null;
            this.metroTile2.Enabled = false;
            this.metroTile2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.metroTile2.Location = new System.Drawing.Point(29, 276);
            this.metroTile2.Name = "metroTile2";
            this.metroTile2.Size = new System.Drawing.Size(458, 10);
            this.metroTile2.TabIndex = 19;
            this.metroTile2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile2.UseCustomBackColor = true;
            this.metroTile2.UseCustomForeColor = true;
            this.metroTile2.UseSelectable = true;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Enabled = false;
            this.metroTile1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.metroTile1.Location = new System.Drawing.Point(6, 35);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(24, 251);
            this.metroTile1.TabIndex = 18;
            this.metroTile1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroTile1.UseCustomBackColor = true;
            this.metroTile1.UseCustomForeColor = true;
            this.metroTile1.UseSelectable = true;
            // 
            // aboutInfo
            // 
            // 
            // 
            // 
            this.aboutInfo.CustomButton.Image = null;
            this.aboutInfo.CustomButton.Location = new System.Drawing.Point(242, 1);
            this.aboutInfo.CustomButton.Name = "";
            this.aboutInfo.CustomButton.Size = new System.Drawing.Size(215, 215);
            this.aboutInfo.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.aboutInfo.CustomButton.TabIndex = 1;
            this.aboutInfo.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.aboutInfo.CustomButton.UseSelectable = true;
            this.aboutInfo.CustomButton.Visible = false;
            this.aboutInfo.Enabled = false;
            this.aboutInfo.Lines = new string[0];
            this.aboutInfo.Location = new System.Drawing.Point(29, 61);
            this.aboutInfo.Margin = new System.Windows.Forms.Padding(0);
            this.aboutInfo.MaxLength = 32767;
            this.aboutInfo.Multiline = true;
            this.aboutInfo.Name = "aboutInfo";
            this.aboutInfo.PasswordChar = '\0';
            this.aboutInfo.PromptText = "Thank you for being part of this community <3";
            this.aboutInfo.ReadOnly = true;
            this.aboutInfo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.aboutInfo.SelectedText = "";
            this.aboutInfo.SelectionLength = 0;
            this.aboutInfo.SelectionStart = 0;
            this.aboutInfo.ShortcutsEnabled = true;
            this.aboutInfo.Size = new System.Drawing.Size(458, 217);
            this.aboutInfo.Style = MetroFramework.MetroColorStyle.Blue;
            this.aboutInfo.TabIndex = 17;
            this.aboutInfo.TabStop = false;
            this.aboutInfo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.aboutInfo.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.aboutInfo.UseCustomBackColor = true;
            this.aboutInfo.UseSelectable = true;
            this.aboutInfo.WaterMark = "Thank you for being part of this community <3";
            this.aboutInfo.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.aboutInfo.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Enabled = false;
            this.metroLabel3.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel3.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.metroLabel3.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.metroLabel3.Location = new System.Drawing.Point(165, 8);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(186, 25);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 16;
            this.metroLabel3.Text = "About DSLauncher V2";
            this.metroLabel3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel3.UseCustomBackColor = true;
            this.metroLabel3.UseCustomForeColor = true;
            this.metroLabel3.UseStyleColors = true;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            this.metroStyleManager1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // LoadingBackgroundWorker
            // 
            this.LoadingBackgroundWorker.WorkerReportsProgress = true;
            this.LoadingBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.LoadingBackgroundWorker_DoWork);
            this.LoadingBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.LoadingBackgroundWorker_ProgressChanged);
            this.LoadingBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.LoadingBackgroundWorker_RunWorkerCompleted);
            // 
            // launchGame
            // 
            this.launchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.launchGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.launchGame.Enabled = false;
            this.launchGame.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.launchGame.Location = new System.Drawing.Point(536, 44);
            this.launchGame.Name = "launchGame";
            this.launchGame.Size = new System.Drawing.Size(203, 29);
            this.launchGame.Style = MetroFramework.MetroColorStyle.Blue;
            this.launchGame.TabIndex = 12;
            this.launchGame.Text = "&Launch Game";
            this.launchGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.launchGame.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.launchGame.UseSelectable = true;
            this.launchGame.Click += new System.EventHandler(this.launchGame_Click);
            this.launchGame.MouseEnter += new System.EventHandler(this.launchGame_MouseEnter);
            this.launchGame.MouseLeave += new System.EventHandler(this.launchGame_MouseLeave);
            // 
            // patchGame
            // 
            this.patchGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.patchGame.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patchGame.Enabled = false;
            this.patchGame.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.patchGame.Location = new System.Drawing.Point(536, 68);
            this.patchGame.Name = "patchGame";
            this.patchGame.Size = new System.Drawing.Size(203, 29);
            this.patchGame.Style = MetroFramework.MetroColorStyle.Blue;
            this.patchGame.TabIndex = 13;
            this.patchGame.Text = "&Patch Game";
            this.patchGame.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patchGame.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.patchGame.UseSelectable = true;
            this.patchGame.Click += new System.EventHandler(this.patchGame_Click);
            this.patchGame.MouseEnter += new System.EventHandler(this.patchGame_MouseEnter);
            this.patchGame.MouseLeave += new System.EventHandler(this.patchGame_MouseLeave);
            // 
            // patchLauncher
            // 
            this.patchLauncher.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.patchLauncher.Cursor = System.Windows.Forms.Cursors.Hand;
            this.patchLauncher.Enabled = false;
            this.patchLauncher.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.patchLauncher.Location = new System.Drawing.Point(536, 91);
            this.patchLauncher.Name = "patchLauncher";
            this.patchLauncher.Size = new System.Drawing.Size(203, 29);
            this.patchLauncher.Style = MetroFramework.MetroColorStyle.Blue;
            this.patchLauncher.TabIndex = 16;
            this.patchLauncher.Text = "Patch Launcher";
            this.patchLauncher.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patchLauncher.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.patchLauncher.UseSelectable = true;
            this.patchLauncher.Click += new System.EventHandler(this.patchLauncher_Click);
            this.patchLauncher.MouseEnter += new System.EventHandler(this.patchLauncher_MouseEnter);
            this.patchLauncher.MouseLeave += new System.EventHandler(this.patchLauncher_MouseLeave);
            // 
            // ExportAccountSaveFileDialog
            // 
            this.ExportAccountSaveFileDialog.CreatePrompt = true;
            this.ExportAccountSaveFileDialog.DefaultExt = "xml";
            this.ExportAccountSaveFileDialog.FileName = "Launcher Accounts";
            this.ExportAccountSaveFileDialog.Filter = "XML File|*.xml";
            this.ExportAccountSaveFileDialog.Title = "Save File As...";
            this.ExportAccountSaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.ExportAccountSaveFileDialog_FileOk);
            // 
            // CurrentSelectedAccountLabel
            // 
            this.CurrentSelectedAccountLabel.AutoSize = true;
            this.CurrentSelectedAccountLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.CurrentSelectedAccountLabel.Location = new System.Drawing.Point(117, 364);
            this.CurrentSelectedAccountLabel.Name = "CurrentSelectedAccountLabel";
            this.CurrentSelectedAccountLabel.Size = new System.Drawing.Size(181, 19);
            this.CurrentSelectedAccountLabel.TabIndex = 19;
            this.CurrentSelectedAccountLabel.Text = "No account currently selected";
            this.CurrentSelectedAccountLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.CurrentSelectedAccountLabel.UseCustomForeColor = true;
            // 
            // FavAccount1
            // 
            this.FavAccount1.Location = new System.Drawing.Point(536, 280);
            this.FavAccount1.Name = "FavAccount1";
            this.FavAccount1.Size = new System.Drawing.Size(240, 23);
            this.FavAccount1.TabIndex = 20;
            this.FavAccount1.Text = "%placeholder%";
            this.FavAccount1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FavAccount1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FavAccount1.UseSelectable = true;
            this.FavAccount1.UseStyleColors = true;
            this.FavAccount1.Visible = false;
            this.FavAccount1.Click += new System.EventHandler(this.FavAccount1_Click);
            // 
            // FavAccount2
            // 
            this.FavAccount2.Location = new System.Drawing.Point(536, 300);
            this.FavAccount2.Name = "FavAccount2";
            this.FavAccount2.Size = new System.Drawing.Size(240, 23);
            this.FavAccount2.TabIndex = 21;
            this.FavAccount2.Text = "%placeholder%";
            this.FavAccount2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FavAccount2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FavAccount2.UseSelectable = true;
            this.FavAccount2.UseStyleColors = true;
            this.FavAccount2.Visible = false;
            this.FavAccount2.Click += new System.EventHandler(this.FavAccount2_Click);
            // 
            // FavAccount3
            // 
            this.FavAccount3.Location = new System.Drawing.Point(536, 320);
            this.FavAccount3.Name = "FavAccount3";
            this.FavAccount3.Size = new System.Drawing.Size(240, 23);
            this.FavAccount3.TabIndex = 22;
            this.FavAccount3.Text = "%placeholder%";
            this.FavAccount3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FavAccount3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FavAccount3.UseSelectable = true;
            this.FavAccount3.UseStyleColors = true;
            this.FavAccount3.Visible = false;
            this.FavAccount3.Click += new System.EventHandler(this.FavAccount3_Click);
            // 
            // FavAccount4
            // 
            this.FavAccount4.Location = new System.Drawing.Point(536, 340);
            this.FavAccount4.Name = "FavAccount4";
            this.FavAccount4.Size = new System.Drawing.Size(240, 23);
            this.FavAccount4.TabIndex = 23;
            this.FavAccount4.Text = "%placeholder%";
            this.FavAccount4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.FavAccount4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FavAccount4.UseSelectable = true;
            this.FavAccount4.UseStyleColors = true;
            this.FavAccount4.Visible = false;
            this.FavAccount4.Click += new System.EventHandler(this.FavAccount4_Click);
            // 
            // RecentAccounts4
            // 
            this.RecentAccounts4.Location = new System.Drawing.Point(536, 218);
            this.RecentAccounts4.Name = "RecentAccounts4";
            this.RecentAccounts4.Size = new System.Drawing.Size(240, 23);
            this.RecentAccounts4.TabIndex = 27;
            this.RecentAccounts4.Text = "%placeholder%";
            this.RecentAccounts4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentAccounts4.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RecentAccounts4.UseSelectable = true;
            this.RecentAccounts4.UseStyleColors = true;
            this.RecentAccounts4.Visible = false;
            this.RecentAccounts4.Click += new System.EventHandler(this.RecentAccounts4_Click);
            // 
            // RecentAccounts3
            // 
            this.RecentAccounts3.Location = new System.Drawing.Point(536, 198);
            this.RecentAccounts3.Name = "RecentAccounts3";
            this.RecentAccounts3.Size = new System.Drawing.Size(240, 23);
            this.RecentAccounts3.TabIndex = 26;
            this.RecentAccounts3.Text = "%placeholder%";
            this.RecentAccounts3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentAccounts3.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RecentAccounts3.UseSelectable = true;
            this.RecentAccounts3.UseStyleColors = true;
            this.RecentAccounts3.Visible = false;
            this.RecentAccounts3.Click += new System.EventHandler(this.RecentAccounts3_Click);
            // 
            // RecentAccounts2
            // 
            this.RecentAccounts2.Location = new System.Drawing.Point(536, 178);
            this.RecentAccounts2.Name = "RecentAccounts2";
            this.RecentAccounts2.Size = new System.Drawing.Size(240, 23);
            this.RecentAccounts2.TabIndex = 25;
            this.RecentAccounts2.Text = "%placeholder%";
            this.RecentAccounts2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentAccounts2.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RecentAccounts2.UseSelectable = true;
            this.RecentAccounts2.UseStyleColors = true;
            this.RecentAccounts2.Visible = false;
            this.RecentAccounts2.Click += new System.EventHandler(this.RecentAccounts2_Click);
            // 
            // RecentAccounts1
            // 
            this.RecentAccounts1.Location = new System.Drawing.Point(536, 158);
            this.RecentAccounts1.Name = "RecentAccounts1";
            this.RecentAccounts1.Size = new System.Drawing.Size(240, 23);
            this.RecentAccounts1.TabIndex = 24;
            this.RecentAccounts1.Text = "%placeholder%";
            this.RecentAccounts1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.RecentAccounts1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RecentAccounts1.UseSelectable = true;
            this.RecentAccounts1.UseStyleColors = true;
            this.RecentAccounts1.Visible = false;
            this.RecentAccounts1.Click += new System.EventHandler(this.RecentAccounts1_Click);
            // 
            // SortCategory
            // 
            this.SortCategory.FormattingEnabled = true;
            this.SortCategory.ItemHeight = 23;
            this.SortCategory.Items.AddRange(new object[] {
            "Show All Accounts"});
            this.SortCategory.Location = new System.Drawing.Point(409, 358);
            this.SortCategory.Name = "SortCategory";
            this.SortCategory.Size = new System.Drawing.Size(121, 29);
            this.SortCategory.TabIndex = 28;
            this.SortCategory.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SortCategory.UseSelectable = true;
            this.SortCategory.UseStyleColors = true;
            this.SortCategory.SelectedIndexChanged += new System.EventHandler(this.SortCategory_SelectedIndexChanged);
            // 
            // metroLabel16
            // 
            this.metroLabel16.AutoSize = true;
            this.metroLabel16.ForeColor = System.Drawing.SystemColors.Control;
            this.metroLabel16.Location = new System.Drawing.Point(536, 364);
            this.metroLabel16.Name = "metroLabel16";
            this.metroLabel16.Size = new System.Drawing.Size(171, 19);
            this.metroLabel16.TabIndex = 29;
            this.metroLabel16.Text = "Sort Accounts Via Category";
            this.metroLabel16.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // ImportLauncherFile
            // 
            this.ImportLauncherFile.FileName = "LauncherFile";
            this.ImportLauncherFile.FileOk += new System.ComponentModel.CancelEventHandler(this.ImportLauncherFile_FileOk);
            // 
            // downloadProgress
            // 
            this.downloadProgress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.downloadProgress.ForeColor = System.Drawing.SystemColors.Control;
            this.downloadProgress.Location = new System.Drawing.Point(11, 422);
            this.downloadProgress.Name = "downloadProgress";
            this.downloadProgress.Size = new System.Drawing.Size(522, 19);
            this.downloadProgress.TabIndex = 33;
            this.downloadProgress.Text = "%DownloadProgress%";
            this.downloadProgress.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.downloadProgress.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.downloadProgress.Visible = false;
            this.downloadProgress.TextChanged += new System.EventHandler(this.downloadProgress_TextChanged);
            // 
            // patchDownload
            // 
            this.patchDownload.Location = new System.Drawing.Point(11, 396);
            this.patchDownload.Name = "patchDownload";
            this.patchDownload.Size = new System.Drawing.Size(522, 23);
            this.patchDownload.Style = MetroFramework.MetroColorStyle.Blue;
            this.patchDownload.TabIndex = 32;
            this.patchDownload.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.patchDownload.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // launcherCheckerLabel
            // 
            this.launcherCheckerLabel.AutoSize = true;
            this.launcherCheckerLabel.ForeColor = System.Drawing.SystemColors.Control;
            this.launcherCheckerLabel.Location = new System.Drawing.Point(581, 410);
            this.launcherCheckerLabel.Name = "launcherCheckerLabel";
            this.launcherCheckerLabel.Size = new System.Drawing.Size(140, 19);
            this.launcherCheckerLabel.TabIndex = 31;
            this.launcherCheckerLabel.Text = "Checking for patches...";
            this.launcherCheckerLabel.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // launcherPatchSpinner
            // 
            this.launcherPatchSpinner.Location = new System.Drawing.Point(544, 405);
            this.launcherPatchSpinner.Maximum = 100;
            this.launcherPatchSpinner.Minimum = 30;
            this.launcherPatchSpinner.Name = "launcherPatchSpinner";
            this.launcherPatchSpinner.Size = new System.Drawing.Size(27, 27);
            this.launcherPatchSpinner.Speed = 2F;
            this.launcherPatchSpinner.Style = MetroFramework.MetroColorStyle.Blue;
            this.launcherPatchSpinner.TabIndex = 30;
            this.launcherPatchSpinner.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.launcherPatchSpinner.UseSelectable = true;
            this.launcherPatchSpinner.Value = 60;
            // 
            // Primary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.downloadProgress);
            this.Controls.Add(this.patchDownload);
            this.Controls.Add(this.launcherCheckerLabel);
            this.Controls.Add(this.launcherPatchSpinner);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hrLabel1);
            this.Controls.Add(this.metroLabel16);
            this.Controls.Add(this.SortCategory);
            this.Controls.Add(this.RecentAccounts4);
            this.Controls.Add(this.RecentAccounts3);
            this.Controls.Add(this.RecentAccounts2);
            this.Controls.Add(this.RecentAccounts1);
            this.Controls.Add(this.FavAccount4);
            this.Controls.Add(this.FavAccount3);
            this.Controls.Add(this.FavAccount2);
            this.Controls.Add(this.FavAccount1);
            this.Controls.Add(this.CurrentSelectedAccountLabel);
            this.Controls.Add(this.patchLauncher);
            this.Controls.Add(this.patchGame);
            this.Controls.Add(this.launchGame);
            this.Controls.Add(this.MTC);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.currentAccountLabel);
            this.Controls.Add(this.actionsLabel);
            this.DisplayHeader = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 450);
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "Primary";
            this.Padding = new System.Windows.Forms.Padding(18, 30, 18, 19);
            this.Resizable = false;
            this.Text = "Discovery Launcher";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TransparencyKey = System.Drawing.Color.SkyBlue;
            this.Load += new System.EventHandler(this.Primary_Load);
            this.Shown += new System.EventHandler(this.Primary_Shown);
            this.MTC.ResumeLayout(false);
            this.CNS.ResumeLayout(false);
            this.CNS.PerformLayout();
            this.ExternalSettings.ResumeLayout(false);
            this.ExternalSettings.PerformLayout();
            this.GameSettings.ResumeLayout(false);
            this.GameSettings.PerformLayout();
            this.Accounts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AccountsGrid)).EndInit();
            this.AccountContextMenu.ResumeLayout(false);
            this.About.ResumeLayout(false);
            this.About.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MetroFramework.Controls.MetroLabel actionsLabel;
        private System.Windows.Forms.Label hrLabel1;
        private MetroFramework.Controls.MetroLabel currentAccountLabel;
        private System.Windows.Forms.Label label1;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.Label label2;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroTabControl MTC;
        private MetroFramework.Controls.MetroTabPage CNS;
        private MetroFramework.Controls.MetroTabPage Accounts;
        private MetroFramework.Controls.MetroTabPage ExternalSettings;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Controls.MetroLink launchGame;
        private MetroFramework.Controls.MetroLink patchGame;
        private MetroFramework.Controls.MetroTabPage About;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private MetroFramework.Controls.MetroTextBox aboutInfo;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        private MetroFramework.Controls.MetroToggle ToggleChatLog;
        private MetroFramework.Controls.MetroLabel metroLabel7;
        private MetroFramework.Controls.MetroToggle ToggleLocalTime;
        private MetroFramework.Controls.MetroLabel metroLabel6;
        private MetroFramework.Controls.MetroToggle ToggleLogTime;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroToggle ToggleChatAppend;
        private MetroFramework.Controls.MetroLink patchLauncher;
        private MetroFramework.Controls.MetroTile metroTile4;
        private MetroFramework.Controls.MetroTile metroTile3;
        private MetroFramework.Controls.MetroTile metroTile2;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroTabPage GameSettings;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroToggle ToggleWindowedMode;
        private MetroFramework.Controls.MetroLabel WidthLabel;
        private MetroFramework.Controls.MetroLabel HeightLabel;
        private MetroFramework.Controls.MetroTextBox WidthBox;
        private MetroFramework.Controls.MetroTextBox HeightBox;
        private MetroFramework.Controls.MetroLabel metroLabel14;
        private MetroFramework.Controls.MetroToggle ToggleDesktopRes;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel metroLabel12;
        private MetroFramework.Controls.MetroTextBox metroTextBox1;
        private MetroFramework.Controls.MetroTextBox forcedArguments;
        private MetroFramework.Controls.MetroLabel metroLabel8;
        private MetroFramework.Controls.MetroToggle ToggleDepartingPlayer;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroToggle ToggleArrivingPlayer;
        private MetroFramework.Controls.MetroLabel metroLabel10;
        private MetroFramework.Controls.MetroToggle ToggleLagIcon;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroToggle ToggleFlightText;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroComboBox ThemeSelector;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroToggle DiscordRPCCheckBox;
        private MetroFramework.Controls.MetroLabel ChatWarning;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroToggle DisableChat;
        private MetroFramework.Controls.MetroGrid AccountsGrid;
        private MetroFramework.Controls.MetroContextMenu AccountContextMenu;
        private ToolStripMenuItem CreateNewAccount;
        private ToolStripMenuItem DeleteSelectedAccounts;
        private ToolStripMenuItem ExportAccounts;
        private SaveFileDialog ExportAccountSaveFileDialog;
        private ToolStripMenuItem EditAccount;
        private ToolStripMenuItem MarkFavorite;
        private MetroFramework.Controls.MetroLabel CurrentSelectedAccountLabel;
        private MetroFramework.Controls.MetroLink FavAccount1;
        private MetroFramework.Controls.MetroLink FavAccount4;
        private MetroFramework.Controls.MetroLink FavAccount3;
        private MetroFramework.Controls.MetroLink FavAccount2;
        private MetroFramework.Controls.MetroLink RecentAccounts4;
        private MetroFramework.Controls.MetroLink RecentAccounts3;
        private MetroFramework.Controls.MetroLink RecentAccounts2;
        private MetroFramework.Controls.MetroLink RecentAccounts1;
        private MetroFramework.Controls.MetroComboBox SortCategory;
        private MetroFramework.Controls.MetroLabel metroLabel16;
        private ToolStripMenuItem importLauncherAccountsToolStripMenuItem;
        private OpenFileDialog ImportLauncherFile;
        private WebBrowser CNSImport;
        private MetroFramework.Controls.MetroLabel IncreaseDrawDistanceLabel;
        private MetroFramework.Controls.MetroToggle IncreaseDrawDistance;
        private MetroFramework.Controls.MetroLabel metroLabel20;
        private DataGridViewTextBoxColumn AccName;
        private DataGridViewTextBoxColumn AccDescription;
        private DataGridViewTextBoxColumn AccCategory;
        private DataGridViewTextBoxColumn AccIsFav;
        private DataGridViewTextBoxColumn AccCode;
        private DataGridViewTextBoxColumn AccSignature;
        private MetroFramework.Controls.MetroLabel downloadProgress;
        private MetroFramework.Controls.MetroProgressBar patchDownload;
        private MetroFramework.Controls.MetroLabel launcherCheckerLabel;
        private MetroFramework.Controls.MetroProgressSpinner launcherPatchSpinner;
    }
}

