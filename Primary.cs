using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Cache;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using DSLauncherV2.Properties;
using HtmlAgilityPack;
using MetroFramework;
using MetroFramework.Controls;
using Microsoft.Win32;
using SharpCompress.Readers;
using SharpCompress.Common;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using System.Reflection;

namespace DSLauncherV2
{
    public sealed partial class Primary : MetroFramework.Forms.MetroForm
    {
        public BackgroundWorker LoadingBackgroundWorker;
        private LauncherSettings LauncherSettings = DSLauncherV2.LauncherSettings.Instance;
        private List<MetroLink> lstFavoriteAccounts;
        private List<string> lstAccountCategories = new List<string>();
        private byte[] downloadedData;
        private string currentAnnouncement;

        public Primary()
        {
            InitializeComponent();
            this.ControlBox = true;
            this.Text = String.Empty;
            this.StyleManager = metroStyleManager1;
            this.metroStyleManager1.Theme = MetroThemeStyle.Dark;
            this.MTC.SelectedTab = CNS;
            this.FavAccount1.Font = new Font(FavAccount1.Font.Name, FavAccount1.Font.SizeInPoints, FontStyle.Underline);
            this.FavAccount2.Font = new Font(FavAccount1.Font.Name, FavAccount1.Font.SizeInPoints, FontStyle.Underline);
            this.FavAccount3.Font = new Font(FavAccount1.Font.Name, FavAccount1.Font.SizeInPoints, FontStyle.Underline);
            this.FavAccount4.Font = new Font(FavAccount1.Font.Name, FavAccount1.Font.SizeInPoints, FontStyle.Underline);
            this.CNSImport.Visible = false;
        }

        private void Primary_Load(object sender, EventArgs e)
        {
            launcherCheckerLabel.Text = "Reading launcher Settings...";
            this.Show(); // Without this and the line below, notifications will be behind the form and we can't see them.
            this.Focus();
        }

        private void Primary_Shown(object sender, EventArgs e)
        {
            this.LoadingBackgroundWorker.RunWorkerAsync();
        }

        private void CheckConnectivity()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                webClient.DownloadFile(this.LauncherSettings.UserSettings.RemotePatchLocation + "patchlist.xml",
                    this.LauncherSettings.UserSettings.PatchListTempFile);
                webClient.Dispose();
            }
            catch (Exception)
            {
                this.LauncherSettings.UserSettings.UseKitty = 1;
                this.LauncherSettings.UserSettings.RemotePatchLocation = Defaults.Settings.KittyURL;
                this.launcherCheckerLabel.Invoke((Action) (() =>
                {
                    this.launcherCheckerLabel.Text = "Contacting Discovery Patch Server...";
                    this.launcherCheckerLabel.Refresh();
                    Application.DoEvents();
                }));
                this.ContactKitty();
            }
        }

        private void ContactKitty()
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                webClient.DownloadFile(this.LauncherSettings.UserSettings.RemotePatchLocation + "patchlist.xml",
                    this.LauncherSettings.UserSettings.PatchListTempFile);
                webClient.Dispose();
                this.launcherCheckerLabel.Invoke((Action) (() =>
                {
                    this.launcherCheckerLabel.Text = "Checking for patches...";
                    this.launcherCheckerLabel.Refresh();
                    Application.DoEvents();
                }));
            }
            catch (Exception ex)
            {
                this.LauncherSettings.ExHandler.ExHandler("F01", ex.Message, this);
            }
        }

        private void ApplyLauncherConfig()
        {
            this.ToggleDesktopRes.Checked = this.LauncherSettings.UserSettings.DisplayDesktopRes;
            this.ToggleArrivingPlayer.Checked = this.LauncherSettings.UserSettings.ShowJoiningPlayers;
            this.ToggleChatAppend.Checked = this.LauncherSettings.UserSettings.ChatAppend;
            this.ToggleChatLog.Checked = this.LauncherSettings.UserSettings.ChatLogging;
            this.ToggleDepartingPlayer.Checked = this.LauncherSettings.UserSettings.ShowDepartingPlayers;
            this.ToggleFlightText.Checked = this.LauncherSettings.UserSettings.ShowFlightText;
            this.ToggleLagIcon.Checked = this.LauncherSettings.UserSettings.ShowLagIndicator;
            this.ToggleLocalTime.Checked = this.LauncherSettings.UserSettings.ChatLocalTime;
            this.ToggleWindowedMode.Checked = this.LauncherSettings.UserSettings.DisplayMode;
            this.HeightBox.Text = this.LauncherSettings.UserSettings.DisplayHeight;
            this.WidthBox.Text = this.LauncherSettings.UserSettings.DisplayWidth;
            this.DiscordRPCCheckBox.Checked = this.LauncherSettings.UserSettings.DiscordRPC;
            this.IncreaseDrawDistance.Checked = this.LauncherSettings.UserSettings.DrawDistance;
            this.DisableChat.Checked = this.LauncherSettings.UserSettings.DisableChat;
            this.ThemeSelector.SelectedIndex = this.LauncherSettings.UserSettings.Style;
            this.metroTextBox1.Text = this.LauncherSettings.UserSettings.ExtraArgs; // Optional Args

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.RecentAccount1))
            {
                this.RecentAccounts1.Text = this.LauncherSettings.UserSettings.RecentAccount1;
                this.RecentAccounts1.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.RecentAccount2))
            {
                this.RecentAccounts2.Text = this.LauncherSettings.UserSettings.RecentAccount2;
                this.RecentAccounts2.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.RecentAccount3))
            {
                this.RecentAccounts3.Text = this.LauncherSettings.UserSettings.RecentAccount3;
                this.RecentAccounts3.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.RecentAccount4))
            {
                this.RecentAccounts4.Text = this.LauncherSettings.UserSettings.RecentAccount4;
                this.RecentAccounts4.Visible = true;
            }
        }

        private bool ConvertYesNoBool(string value)
        {
            if (value.ToLower() == "yes")
                return true;
            else
                return false;
        }

        private void LoadingBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            this.LauncherSettings.ReadConfigFile(this);
            this.LoadingBackgroundWorker.ReportProgress(0);
            this.CheckConnectivity();
            this.LoadingBackgroundWorker.ReportProgress(1);
            this.LauncherSettings.ReadPatchListFile(this);
            this.LoadingBackgroundWorker.ReportProgress(2);
            this.LauncherSettings.LoadAccounts(this);
            this.LoadingBackgroundWorker.ReportProgress(3);
            this.GetDiscoveryAnnouncements();
            this.LauncherSettings.CheckForPatches(this);
            this.LoadingBackgroundWorker.ReportProgress(4);
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 0)
            {
                this.launcherCheckerLabel.Text = "Contacting Patch Server...";
                this.metroStyleManager1.Style = (MetroColorStyle) this.LauncherSettings.UserSettings.Style;
                this.ApplyLauncherConfig();
            }

            if (e.ProgressPercentage == 1)
            {
                this.launcherCheckerLabel.Text = "Reading Patchlist Data...";
            }

            if (e.ProgressPercentage == 2)
            {
                this.launcherCheckerLabel.Text = "Loading Accounts...";
            }

            if (e.ProgressPercentage == 3)
            {
                this.launcherCheckerLabel.Text = "Checking If Updates Are Required...";
                this.MTC.Enabled = true;
                SetAccountsTab();
                this.CheckAccountRegistry();
            }

            if (e.ProgressPercentage == 4)
            {
                CNSImport.Capture = false;
                CNSImport.DocumentText = currentAnnouncement;
                if(!string.IsNullOrEmpty(CNSImport.DocumentText))
                    CNSImport.Visible = true;
                if (this.LauncherSettings.UserSettings.RemoteLauncherVersion >
                    this.LauncherSettings.UserSettings.LocalLauncherVersion)
                {
                    this.patchLauncher.ForeColor = Color.FromKnownColor(KnownColor.CornflowerBlue);
                    this.patchLauncher.UseCustomForeColor = true;
                    this.patchLauncher.Enabled = true;
                    this.launcherPatchSpinner.Visible = false;
                    this.launcherCheckerLabel.Text = "The launcher requires a patch.";
                    this.patchGame.Enabled = false;
                    this.patchGame.ForeColor = Color.FromArgb(51, 51, 51);
                }
            }

            if (e.ProgressPercentage == 5)
            {
                ReadyToLaunch();
            }

            if (e.ProgressPercentage == 6)
            {
                this.patchGame.Enabled = true;
                this.patchGame.UseCustomForeColor = true;
                this.patchGame.ForeColor = Color.FromKnownColor(KnownColor.CornflowerBlue);
                this.launcherPatchSpinner.Visible = false;
                this.launcherCheckerLabel.Visible = false;
                this.downloadProgress.Visible = true;
                this.downloadProgress.Text = "Game updates required; press \"Patch Game\" to install.";
            }

            if (e.ProgressPercentage == 7)
            {
                ReadyToLaunch();
            }
        }

        private void GetDiscoveryAnnouncements()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc;
            
            try
            {
                doc = web.Load("https://discoverygc.com/patch/launcherimages/");
            }
            catch
            {
                return;
            }

            if ((web.StatusCode != HttpStatusCode.OK) |
                doc.DocumentNode.InnerHtml.Contains("The maximum server load limit has been reached"))
                return;

            /*string node = doc.DocumentNode.SelectSingleNode("//comment()[contains(., 'portal_announcement')]/following-sibling::table").OuterHtml;
            string HTML = "<html><body><div id=container> %style% %REPLACE% </div></body></html>";
            string style = "<style> #container,.wrapper,body{text-shadow:1px 1px 0 #0d0d0d}body,table{font-size:13px}.trow1,.trow2,body," +
                           "table{font-style:normal;font-family:Arial,Verdana,Sans-Serif}body{background:#090909;color:#FFF;text-align:center;" +
                           "line-height:1.4;margin:0;overflow-y:scroll}table{background:0 0;color:#828282}.tborder{background:#181818;margin:auto;" +
                           "-moz-background-clip:padding;-webkit-background-clip:padding-box;-webkit-box-shadow:inset 0 0 1px 1px #262626;" +
                           "-moz-box-shadow:inset 0 0 1px 1px #262626;box-shadow:inset 0 0 1px 1px #262626;border:1px solid #101010;padding:1px;" +
                           "width:100%}.tcat,.trow1,.trow2{border-top:#101010 1px solid;border-bottom:#262626 1px solid;" +
                           "font-size:13px}.tfixed{table-layout:fixed;word-wrap:break-word}.thead_left{background:url(https://discoverygc.com/forums/images/dark/ice/style/thead_main.jpg) no-repeat;" +
                           "height:39px}.thead_right{background:url(https://discoverygc.com/forums/images/dark/ice/style/thead_right.jpg) 100% 0 no-repeat;" +
                           "height:39px}.thead_wrap .expcolimage{padding:6px}.thead_wrap .float_left{padding:10px}.thead,.thead_main" +
                           "{background:url(https://discoverygc.com/forums/images/dark/ice/style/thead_main.jpg) 0 100% repeat-x #006dec;" +
                           "color:#fff;-webkit-border-top-left-radius:4px;-webkit-border-top-right-radius:4px;-moz-border-radius-topleft:4px;" +
                           "-moz-border-radius-topright:4px;border-top-left-radius:4px;border-top-right-radius:4px}.thead a,.thead_main " +
                           "a{color:#fff;text-decoration:none}.thead a:hover,.thead_main a:hover{color:#fff;text-decoration:underline}.tcat,.tcat " +
                           "a:active,.tcat a:hover,.tcat a:link,.tcat a:visited,.trow1,.trow2,.trow_selected a:active,.trow_selected a:hover," +
                           ".trow_selected a:link,.trow_selected a:visited,.wrapper{color:#969696}.tcat{background:#181818;padding:6px}.trow1," +
                           ".trow2{background:#090909;padding:10px}.smalltext{font-size:11px}.largetext{font-size:14px;font-weight:700}.trow_shaded" +
                           "{background:#1A1A1A;border:1px solid #101010}.post.deleted_post,.post.unapproved_post,.trow1.deleted_post,.trow1." +
                           "unapproved_post,.trow_deleted{background:#650000}.no_bottom_border{border-bottom:0}.post.unapproved_post .post_author" +
                           "{border-bottom-color:#ffb8be}.post.classic.unapproved_post .post_author{border-color:#ffb8be}.post.unapproved_post " +
                           ".post_controls{border-top-color:#ffb8be}.trow_selected,tr.trow_selected td{background:#201f1f;color:#969696}#container" +
                           "{margin:auto;text-align:left;width:95%;font-family:Arial,Verdana,Sans-Serif}.wrapper{margin:-20px auto auto;" +
                           "padding:20px;background:#060606;-moz-background-clip:padding;-webkit-background-clip:padding-box;-webkit-box-shadow:" +
                           "inset 0 0 1px 1px #262626;-moz-box-shadow:inset 0 0 1px 1px #262626;box-shadow:inset 0 0 1px 1px #262626;border:1px " +
                           "solid #101010;-moz-border-radius:3px;-webkit-border-radius:3px;border-radius:3px;overflow:hidden}a:link,a:visited" +
                           "{color:#00cffe;text-decoration:none}tr td.trow1:first-child,tr td.trow2:first-child,tr td.trow_shaded:first-child" +
                           "{border-left:0}tr td.trow1:last-child,tr td.trow2:last-child,tr td.trow_shaded:last-child{border-right:0}.tborder" +
                           "{-moz-border-radius:3px;-webkit-border-radius:3px;border-radius:3px}.tborder tbody tr:last-child td{border-bottom:0}" +
                           ".tborder tbody tr:last-child td:first-child{-moz-border-radius-bottom-left:3px;-webkit-border-bottom-left-radius:3px;" +
                           "border-bottom-left-radius:3px}.tborder tbody tr:last-child td:last-child{-moz-border-radius-bottomright:3px;-webkit-" +
                           "border-bottom-right-radius:3px;border-bottom-right-radius:3px}.thead{-moz-border-radius-top-left:3px;-moz-border-radius" +
                           "-top-right:3px;-webkit-border-top-left-radius:3px;-webkit-border-top-right-radius:3px;border-top-left-radius:3px;border" +
                           "-top-right-radius:3px}.thead_collapsed{-moz-border-radius-bottom-left:3px;-moz-border-radius-bottom-right:3px;-webkit-" +
                           "border-bottom-left-radius:3px;-webkit-border-bottom-right-radius:3px;border-bottom-left-radius:3px;border-bottom-right-" +
                           "radius:3px}.thead_left{-moz-border-radius-topright:0;-webkit-border-top-right-radius:0;border-top-right-radius:0}.thead" +
                           "_right{-moz-border-radius-top-left:0;-webkit-border-top-left-radius:0;border-top-left-radius:0} </style>";
            HTML = HTML.Replace("%REPLACE%", node);
            HTML = HTML.Replace("%style%", style);*/

            currentAnnouncement = doc.Text;
        }

        private bool CompareMD5(string file, string patchhash)
        {
            if (!File.Exists(file))
                return false;
            using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (MD5 md5 = new MD5CryptoServiceProvider())
                {
                    byte[] hash = md5.ComputeHash((Stream) fileStream);
                    fileStream.Close();
                    StringBuilder stringBuilder = new StringBuilder();
                    foreach (byte num in hash)
                        stringBuilder.Append(string.Format("{0:X2}", (object) num));
                    return patchhash == stringBuilder.ToString();
                }
            }
        }

        private static double ConvertBytesToMegabytes(long bytes)
        {
            return bytes / 1024.0 / 1024.0;
        }

        private void ReadyToLaunch()
        {
            this.patchDownload.Visible = true;
            this.downloadProgress.Visible = true;
            this.downloadProgress.Text = "Updates complete, good flying!";
            this.launchGame.Enabled = true;
            this.launchGame.UseCustomForeColor = true;
            this.launchGame.ForeColor = Color.FromKnownColor(KnownColor.CornflowerBlue);
            this.launcherPatchSpinner.Value = 100;
            this.launcherPatchSpinner.EnsureVisible = false;
            this.launcherPatchSpinner.Spinning = false;
            this.launcherPatchSpinner.Visible = false;
            this.launcherCheckerLabel.Text = "You're all set, good flying!";
            this.launcherCheckerLabel.Visible = false;
            this.patchLauncher.Enabled = false;
            this.patchGame.Enabled = false;
            this.patchLauncher.ForeColor = Color.FromArgb(51, 51, 51);
            this.patchGame.ForeColor = Color.FromArgb(51, 51, 51);
        }

        private void CheckProcesses()
        {
            try
            {
                foreach (Process process in Process.GetProcessesByName("Freelancer"))
                {
                    if (MessageBox.Show(
                            "A freelancer process was found running in background. Unless you absolutely know what you're doing, you should click Yes. Clicking no might prevent the launcher from updating your installation correctly and corrupt it.",
                            "WARNING", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        process.Kill();
                        process.WaitForExit();
                    }
                }

                foreach (Process process in Process.GetProcessesByName("FLCompanion"))
                {
                    process.Kill();
                    process.WaitForExit();
                }

                foreach (Process process in Process.GetProcessesByName("FLStat"))
                {
                    process.Kill();
                    process.WaitForExit();
                }

                foreach (Process process in Process.GetProcessesByName("FLServer"))
                {
                    process.Kill();
                    process.WaitForExit();
                }
            }
            catch (Exception)
            {
                MessageBox.Show(
                    "Found a Freelancer.exe / FLStat / FLCompanion / FLServer process running, but couldn't kill it. Aborting patching.");
                Environment.Exit(0);
            }
        }

        private void MTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((TabControl) sender).SelectedIndex)
            {
                case 2:
                    this.forcedArguments.Text = this.LauncherSettings.UserSettings.MainServer;
                    this.forcedArguments.ReadOnly = true;
                    this.forcedArguments.Enabled = false;
                    break;
                case 4:
                    StringBuilder sb = new StringBuilder();

                    sb.Append(
                        "Discovery Freelancer is brought to you by the Discovery Development team.\r\n\r\n");

                    sb.Append("- DSLauncher 2.x Credits -\r\n");
                    sb.Append("Cannon and Kazinsal for the account generator,\r\n");
                    sb.Append("Alley for the original launcher code,\r\n");
                    sb.Append("Alex. for the decompliation of the original launcher,\r\n");
                    sb.Append("Laz for progamming the V2 launcher,\r\n");
                    sb.Append("Kazinsal for aesthetic updates and continued development,\r\n");
                    sb.Append("thedoctor45 for the logo...\r\n");
                    sb.Append("...and you for being part of the community and keeping Discovery alive.\r\n\r\n");

                    sb.Append("Discovery Launcher ");
                    sb.Append(Assembly.GetEntryAssembly().GetName().Version.Major);
                    sb.Append(".");
                    sb.Append(Assembly.GetEntryAssembly().GetName().Version.Minor);
                    sb.Append(".");
                    sb.Append(Assembly.GetEntryAssembly().GetName().Version.Build);

                    this.aboutInfo.Text = sb.ToString();
                    break;
            }
        }

        ///////////////////////////////////////////////
        /// Accounts Manager
        ///////////////////////////////////////////////

        private void LoadInAccounts(string accountName, string accountDescription, string accountCategory, string isFav,
            string accountCode, string accountSig)
        {
            this.AccountsGrid.Rows.Add(accountName, accountDescription, accountCategory, isFav, accountCode,
                accountSig);
        }

        private void addAccountNode(string accountName, string accountDescription, string accountCategory, string isFav,
            string accountCode, string accountSig)
        {
            XmlTextReader xmlTextReader = new XmlTextReader(this.LauncherSettings.UserSettings.AccountsFile);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTextReader);
            xmlTextReader.Close();

            XmlElement element = xmlDocument.CreateElement("account");

            XmlAttribute favAttribute = xmlDocument.CreateAttribute("favorite");
            favAttribute.Value = isFav;

            XmlAttribute descriptionAttribute = xmlDocument.CreateAttribute("description");
            descriptionAttribute.Value = accountDescription;

            XmlAttribute codeAttribute = xmlDocument.CreateAttribute("code");
            codeAttribute.Value = accountCode;

            XmlAttribute sigAttribute = xmlDocument.CreateAttribute("signature");
            sigAttribute.Value = accountSig;

            XmlAttribute catAttribute = xmlDocument.CreateAttribute("category");
            catAttribute.Value = accountCategory;

            element.InnerText = accountName;
            element.Attributes.Append(codeAttribute);
            element.Attributes.Append(sigAttribute);
            element.Attributes.Append(descriptionAttribute);
            element.Attributes.Append(favAttribute);
            element.Attributes.Append(catAttribute);

            xmlDocument.DocumentElement.AppendChild(element);
            xmlDocument.Save(this.LauncherSettings.UserSettings.AccountsFile);

            isFav = isFav.ToLower() == "false" ? "No" : "Yes";
            this.AccountsGrid.Rows.Add(accountName, accountDescription, accountCategory, isFav, accountCode,
                accountSig);
        }

        private void deleteAccountNode(string accountCode)
        {
            XmlTextReader xmlTextReader = new XmlTextReader(this.LauncherSettings.UserSettings.AccountsFile);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(xmlTextReader);
            xmlTextReader.Close();

            XmlElement documentElement = xmlDocument.DocumentElement;
            string xpath = string.Format("/AccountsList/account[@code='{0}']", accountCode);
            XmlNode oldChild = documentElement.SelectSingleNode(xpath);
            documentElement.RemoveChild(oldChild);
            xmlDocument.Save(this.LauncherSettings.UserSettings.AccountsFile);
            foreach (DataGridViewRow row in this.AccountsGrid.Rows)
            {
                if (row.Cells[4].Value.ToString().Equals(accountCode))
                    this.AccountsGrid.Rows.Remove(row);
            }
        }

        private void editAccountNode(string accountName, string accountDescription, string accountCategory,
            string isFav, string accountCode, string accountSig)
        {
            this.deleteAccountNode(accountCode);
            this.addAccountNode(accountName, accountDescription, accountCategory, isFav, accountCode, accountSig);
        }

        private void SetAccountsTab()
        {
            int iNum = 0;
            List<MetroLink> lstMetroLinks = new List<MetroLink>();
            foreach (KeyValuePair<int, UserSettings.AccountsListDataStruct> keyValuePair in LauncherSettings
                .UserSettings.AccountListData)
            {
                string isFav = keyValuePair.Value.IsFavorite.ToLower() == "false" ? "No" : "Yes";
                this.LoadInAccounts(keyValuePair.Value.AccountName, keyValuePair.Value.AccountDescription,
                    keyValuePair.Value.AccountCategory, isFav,
                    keyValuePair.Value.AccountCode, keyValuePair.Value.AccountSignature);

                if (lstAccountCategories.All(category => category != keyValuePair.Value.AccountCategory) &&
                    keyValuePair.Value.AccountCategory != "None")
                    lstAccountCategories.Add(keyValuePair.Value.AccountCategory);

                if (iNum < 4 && keyValuePair.Value.IsFavorite.ToLower() == "true")
                {
                    iNum++;
                    switch (iNum)
                    {
                        case 1:
                            this.FavAccount1.Text = keyValuePair.Value.AccountName;
                            this.FavAccount1.Visible = true;
                            lstMetroLinks.Add(FavAccount1);
                            break;
                        case 2:
                            this.FavAccount2.Text = keyValuePair.Value.AccountName;
                            this.FavAccount2.Visible = true;
                            lstMetroLinks.Add(FavAccount2);
                            break;
                        case 3:
                            this.FavAccount3.Text = keyValuePair.Value.AccountName;
                            this.FavAccount3.Visible = true;
                            lstMetroLinks.Add(FavAccount3);
                            break;
                        case 4:
                            this.FavAccount4.Text = keyValuePair.Value.AccountName;
                            this.FavAccount4.Visible = true;
                            lstMetroLinks.Add(FavAccount4);
                            break;
                    }
                }
            }

            lstFavoriteAccounts = lstMetroLinks;
            foreach (string category in lstAccountCategories)
                SortCategory.Items.Add(category);
        }

        // Launch Game

        void LaunchFreelancer()
        {
            string FLExe = this.LauncherSettings.UserSettings.InstallPath + @"/EXE/Freelancer.exe";
            string DSAce = this.LauncherSettings.UserSettings.InstallPath + @"/EXE/DSAce.dll";
            foreach (Process p in Process.GetProcessesByName("Freelancer"))
            {
                if (MessageBox.Show(
                        @"A freelancer process was found running in background. Do you want to terminate it?",
                        @"WARNING",
                        MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        p.Kill(); // Try to kill all "Freelancer" processes
                        p.WaitForExit(); // Wait until they are removed before attempting to continue
                    }
                    catch (Exception ex)
                    {
                        LauncherSettings.ExHandler.ExHandler("L04", ex.Message, this);
                    }
                }
            }

            if (!File.Exists(FLExe)) // We cannot find Freelancer.exe
            {
                this.LauncherSettings.ExHandler.ExHandler("L01", "", this);
            }

            else
            {
                if (!File.Exists(DSAce))
                {
                    this.LauncherSettings.ExHandler.ExHandler("L03", "", this);
                }

                else
                {
                    // Clean the saves directory in case multiple Discovery versions or FL mods are being run simultaneously
                    if (System.IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games/Freelancer/Accts/SinglePlayer/Restart.fl")))
                        foreach (string file in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games/Freelancer/Accts/SinglePlayer/"), "*.fl"))
                            System.IO.File.Delete(file);

                    string launchSettings = this.LauncherSettings.UserSettings.MainServer;

                    if (this.LauncherSettings.UserSettings.DisplayMode)
                        launchSettings += " -windowed";

                    if (this.LauncherSettings.UserSettings.DisplayDesktopRes)
                        launchSettings += " -dx";

                    else
                    {
                        string width = "800";
                        string height = "600";
                        if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.DisplayHeight))
                            height = this.LauncherSettings.UserSettings.DisplayHeight;
                        if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.DisplayWidth))
                            width = this.LauncherSettings.UserSettings.DisplayWidth;

                        launchSettings += " -d" + width + "-x" + height;
                    }

                    if (this.LauncherSettings.UserSettings.ChatLogging)
                        launchSettings += " -logchat";

                    if (this.LauncherSettings.UserSettings.ChatAppend)
                        launchSettings += " -logappend";

                    if (this.LauncherSettings.UserSettings.ChatTime)
                        launchSettings += " -logtime";

                    if (this.LauncherSettings.UserSettings.ChatLocalTime)
                        launchSettings += " -localtime";

                    if (!this.LauncherSettings.UserSettings.ShowFlightText)
                        launchSettings += " -noflighttext";

                    if (this.LauncherSettings.UserSettings.ShowDepartingPlayers)
                        launchSettings += " -dptplayer";

                    if (this.LauncherSettings.UserSettings.ShowJoiningPlayers)
                        launchSettings += " -newplayer";

                    if (this.LauncherSettings.UserSettings.ShowLagIndicator)
                        launchSettings += " -lag";

                    if (this.LauncherSettings.UserSettings.DiscordRPC)
                        launchSettings += " -discordrpc";

                    if (this.LauncherSettings.UserSettings.DrawDistance)
                        launchSettings += " -hdfx";

                    if (this.LauncherSettings.UserSettings.DisableChat)
                        launchSettings += " -nochat";

                    try
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = this.LauncherSettings.UserSettings.InstallPath + "//EXE//Freelancer.exe",
                            WorkingDirectory = this.LauncherSettings.UserSettings.InstallPath + "//EXE//",
                            Arguments = launchSettings + this.LauncherSettings.UserSettings.ExtraArgs + " " +
                                        this.forcedArguments.Text
                        });
                    }
                    catch (Exception ex)
                    {
                        this.LauncherSettings.ExHandler.ExHandler("L02", ex.Message, this);
                    }
                }
            }
        }

        ///////////////////////////////////////////////
        /// Launch Game/Patch Game/Patch Launcher
        ///////////////////////////////////////////////

        private void launchGame_Click(object sender, EventArgs e)
        {
            LaunchFreelancer(); // We want to try and keep these functions clean.
        }

        private void launchGame_MouseEnter(object sender, EventArgs e)
        {
            if (this.launchGame.Enabled)
                this.launchGame.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void launchGame_MouseLeave(object sender, EventArgs e)
        {
            if (this.launchGame.ForeColor == Color.FromArgb(255, 255, 255))
                this.launchGame.ForeColor = Color.CornflowerBlue;
        }

        private void patchGame_Click(object sender, EventArgs e)
        {
            this.launchGame.Enabled = false;
            this.launchGame.ForeColor = Color.FromArgb(51, 51, 51);
            this.launcherPatchSpinner.Visible = true;
            this.launcherCheckerLabel.Visible = true;
            this.launcherCheckerLabel.Text = "Patching Game...";
            CheckProcesses();
            this.patchDownload.Visible = true;
            this.downloadProgress.Visible = true;
            foreach (KeyValuePair<int, UserSettings.PatchListDataStruct> keyValuePair in this.LauncherSettings
                .UserSettings.PatchListData)
            {
                string str = this.LauncherSettings.UserSettings.InstallPath + "\\" + keyValuePair.Value.PatchURL;
                if (!this.LauncherSettings.UserSettings.installedpatchlist.Contains(keyValuePair.Value.PatchMD5Hash))
                {
                    bool flag1 = System.IO.File.Exists(str) && this.CompareMD5(str, keyValuePair.Value.PatchMD5Hash);
                    if (!flag1)
                    {
                        try
                        {
                            this.downloadedData = new byte[0];
                            WebResponse response = WebRequest
                                .Create(this.LauncherSettings.UserSettings.RemotePatchLocation +
                                        keyValuePair.Value.PatchURL).GetResponse();
                            Stream responseStream = response.GetResponseStream();
                            byte[] buffer = new byte[1024];
                            int dataLength = (int) response.ContentLength;
                            string dataLengthMB = ConvertBytesToMegabytes(dataLength).ToString("0.00");
                            int ProgressValue = 0;
                            this.patchDownload.Invoke((Action) (() =>
                            {
                                this.patchDownload.Value = 0;
                                this.patchDownload.Maximum = dataLength;
                                Application.DoEvents();
                            }));
                            this.downloadProgress.Invoke((Action) (() =>
                            {
                                this.downloadProgress.Text = "0.00 MB / " + dataLengthMB + " MB";
                                this.downloadProgress.Refresh();
                                Application.DoEvents();
                            }));
                            FileStream fileStream = new FileStream(str, FileMode.Create);
                            while (true)
                            {
                                int count = responseStream.Read(buffer, 0, buffer.Length);
                                if (count != 0)
                                {
                                    fileStream.Write(buffer, 0, count);
                                    ProgressValue += count;
                                    var value = ProgressValue;
                                    this.patchDownload.Invoke(method: (Action) (() =>
                                    {
                                        this.patchDownload.Value = value;
                                        this.patchDownload.Refresh();
                                        Application.DoEvents();
                                    }));
                                    this.downloadProgress.Invoke((Action) (() =>
                                    {
                                        this.downloadProgress.Text =
                                            Primary.ConvertBytesToMegabytes((long) ProgressValue).ToString("0.00") +
                                            " MB / " + dataLengthMB + " MB";
                                        this.downloadProgress.Refresh();
                                        Application.DoEvents();
                                    }));
                                }
                                else
                                    break;
                            }

                            responseStream.Close();
                            fileStream.Close();
                            bool flag2 = this.CompareMD5(str, keyValuePair.Value.PatchMD5Hash);
                            if (!flag2)
                            {
                                MessageBox.Show(
                                    "An error has occured while downloading one of the files. Please try again.");
                                Environment.Exit(0);
                            }
                            else
                            {
                                int num1 = flag2 ? 1 : 0;
                            }
                        }
                        catch (Exception ex)
                        {
                            this.LauncherSettings.ExHandler.ExHandler("D01", ex.Message, this);
                        }
                    }
                    // I don't know why this is here, but I am keeping it in case I need it later
                    /*else
                    {
                        int num2 = flag1 ? 1 : 0;
                    }*/

                    try
                    {
                        this.downloadProgress.Invoke((Action) (() =>
                        {
                            this.downloadProgress.Text = "Unzipping...";
                            this.downloadProgress.Refresh();
                            Application.DoEvents();
                        }));
                        using (Stream stream = File.OpenRead(str))
                        {
                            IReader reader = ReaderFactory.Open(stream);
                            while (reader.MoveToNextEntry())
                            {
                                if (!reader.Entry.IsDirectory)
                                    reader.WriteEntryToDirectory(this.LauncherSettings.UserSettings.InstallPath,
                                        new ExtractionOptions() {Overwrite = true, ExtractFullPath = true});
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        this.LauncherSettings.ExHandler.ExHandler("D02", ex.Message, this);
                    }

                    try
                    {
                        if (System.IO.File.Exists(str))
                        {
                            System.IO.File.Delete(str);
                            XmlDocument xmlDocument = new XmlDocument();
                            xmlDocument.Load("launcherconfig.xml");
                            XmlNode element = xmlDocument.CreateElement("Patch");
                            element.InnerText = keyValuePair.Value.PatchMD5Hash;
                            xmlDocument.SelectSingleNode("/BadassRoot/PatchHistory").AppendChild(element);
                            xmlDocument.Save("launcherconfig.xml");
                            this.LauncherSettings.UserSettings.installedpatchlist.Add(keyValuePair.Value.PatchMD5Hash);
                        }
                    }
                    catch (Exception ex)
                    {
                        this.LauncherSettings.ExHandler.ExHandler("D02", ex.Message, this);
                    }
                }
            }

            /*this.patchDownload.Visible = true;
            this.downloadProgress.Visible = true;
            this.patchGame.Enabled = false;
            this.patchGame.ForeColor = Color.FromArgb(51, 51, 51);
            this.launchGame.Enabled = true;
            this.launchGame.UseCustomForeColor = true;
            this.launchGame.ForeColor = Color.FromKnownColor(KnownColor.CornflowerBlue);
            this.launcherPatchSpinner.Visible = true;
            this.launcherCheckerLabel.Text = "You're all set.";*/
            ReadyToLaunch();
        }

        private void patchGame_MouseEnter(object sender, EventArgs e)
        {
            if (this.patchGame.Enabled)
                this.patchGame.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void patchGame_MouseLeave(object sender, EventArgs e)
        {
            if (this.patchGame.ForeColor == Color.FromArgb(255, 255, 255))
                this.patchGame.ForeColor = Color.CornflowerBlue;
        }

        private void patchLauncher_Click(object sender, EventArgs e)
        {
            Process.Start(this.LauncherSettings.UserSettings.InstallPath + "\\DSSelfPatch.exe");
            Environment.Exit(0);
        }

        private void patchLauncher_MouseEnter(object sender, EventArgs e)
        {
            if (this.patchLauncher.Enabled)
                this.patchLauncher.ForeColor = Color.FromArgb(255, 255, 255);
        }

        private void patchLauncher_MouseLeave(object sender, EventArgs e)
        {
            if (this.patchLauncher.ForeColor == Color.FromArgb(255, 255, 255))
                this.patchLauncher.ForeColor = Color.CornflowerBlue;
        }

        ////////////////////////////////////////
        /// Launcher Settings Changed
        ////////////////////////////////////////

        private void ThemeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroStyleManager1.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            launcherPatchSpinner.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            metroProgressSpinner1.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            LauncherSettings.SetLauncherStyle(Convert.ToInt32(ThemeSelector.SelectedIndex)); // Save it in the config
        }

        private void DiscordRPCCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.DiscordRPC = DiscordRPCCheckBox.Checked;
            this.LauncherSettings.SetDiscordRPC();
        }

        private void ToggleChatLog_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ChatLogging = ToggleChatLog.Checked;
            this.LauncherSettings.SetConfigValue("ChatLogging", this.LauncherSettings.UserSettings.ChatLogging);
        }

        private void ToggleChatAppend_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ChatAppend = ToggleChatAppend.Checked;
            this.LauncherSettings.SetConfigValue("ChatAppend", this.LauncherSettings.UserSettings.ChatAppend);
        }

        private void ToggleLogTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ChatTime = ToggleLogTime.Checked;
            this.LauncherSettings.SetConfigValue("ChatTime", this.LauncherSettings.UserSettings.ChatTime);
        }

        private void ToggleLocalTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ChatLocalTime = ToggleLocalTime.Checked;
            this.LauncherSettings.SetConfigValue("ChatLocalTime", this.LauncherSettings.UserSettings.ChatLocalTime);
        }

        private void ToggleFlightText_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ShowFlightText = ToggleFlightText.Checked;
            this.LauncherSettings.SetConfigValue("ShowFlightText", this.LauncherSettings.UserSettings.ShowFlightText);
        }

        private void ToggleLagIcon_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ShowLagIndicator = ToggleLagIcon.Checked;
            this.LauncherSettings.SetConfigValue("ShowLagIndicator",
                this.LauncherSettings.UserSettings.ShowLagIndicator);
        }

        private void ToggleArrivingPlayer_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ShowJoiningPlayers = ToggleArrivingPlayer.Checked;
            this.LauncherSettings.SetConfigValue("ShowJoiningPlayers",
                this.LauncherSettings.UserSettings.ShowJoiningPlayers);
        }

        private void ToggleDepartingPlayer_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.ShowDepartingPlayers = ToggleDepartingPlayer.Checked;
            this.LauncherSettings.SetConfigValue("ShowDepartingPlayers",
                this.LauncherSettings.UserSettings.ShowDepartingPlayers);
        }

        private void ToggleDesktopRes_CheckedChanged(object sender, EventArgs e)
        {
            if (!this.ToggleDesktopRes.Checked)
            {
                this.HeightBox.Visible = true;
                this.HeightLabel.Visible = true;
                this.WidthBox.Visible = true;
                this.WidthLabel.Visible = true;
            }

            else
            {
                this.HeightBox.Visible = false;
                this.HeightLabel.Visible = false;
                this.WidthBox.Visible = false;
                this.WidthLabel.Visible = false;
            }

            this.LauncherSettings.UserSettings.DisplayDesktopRes = ToggleDesktopRes.Checked;
            this.LauncherSettings.SetConfigValue("DisplayDesktopRes",
                this.LauncherSettings.UserSettings.DisplayDesktopRes);
        }

        private void ToggleWindowedMode_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.DisplayMode = ToggleWindowedMode.Checked;
            this.LauncherSettings.SetConfigValue("DisplayMode", this.LauncherSettings.UserSettings.DisplayMode);
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e) // Optional Arguments
        {
            this.LauncherSettings.UserSettings.ExtraArgs = this.metroTextBox1.Text;
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("launcherconfig.xml");
            xmlDocument.SelectSingleNode("/BadassRoot/Config/ExtraArgs").InnerText =
                this.LauncherSettings.UserSettings.ExtraArgs;
            xmlDocument.Save("launcherconfig.xml");
        }

        private void HeightBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.HeightBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.HeightBox.Text = "";
            }
            else
            {
                this.LauncherSettings.UserSettings.DisplayHeight = this.HeightBox.Text;
                XmlDocument XML = new XmlDocument();
                XML.Load("launcherconfig.xml");
                XML.SelectSingleNode("/BadassRoot/Config/DisplayHeight").InnerText =
                    this.LauncherSettings.UserSettings.DisplayHeight;
                XML.Save("launcherconfig.xml");
            }
        }

        private void WidthBox_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(this.WidthBox.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers.");
                this.WidthBox.Text = "";
            }
            else
            {
                this.LauncherSettings.UserSettings.DisplayWidth = this.WidthBox.Text;
                XmlDocument XML = new XmlDocument();
                XML.Load("launcherconfig.xml");
                XML.SelectSingleNode("/BadassRoot/Config/DisplayWidth").InnerText =
                    this.LauncherSettings.UserSettings.DisplayWidth;
                XML.Save("launcherconfig.xml");
            }
        }

        private void DisableChat_CheckedChanged(object sender, EventArgs e)
        {
            this.ChatWarning.Visible = DisableChat.Checked;
            this.LauncherSettings.UserSettings.DisableChat = DisableChat.Checked;
            this.LauncherSettings.SetDisableChat();
        }

        private void CreateNewAccount_Click(object sender, EventArgs e)
        {

            NewAccount accountForm = new NewAccount();
            this.LauncherSettings.UserSettings.AFavorite = false;
            this.LauncherSettings.UserSettings.AName = "";
            this.LauncherSettings.UserSettings.ADescription = "";
            this.LauncherSettings.UserSettings.ACode = "";
            this.LauncherSettings.UserSettings.ASignature = "";
            this.LauncherSettings.UserSettings.AccountCategory = "";
            accountForm.ShowDialog();
            switch (accountForm.DialogResult)
            {
                case DialogResult.OK:
                    bool flag = false;
                    foreach (DataGridViewRow row in this.AccountsGrid.Rows)
                    {
                        if (row.Cells[5].Value.ToString().Equals(this.LauncherSettings.UserSettings.ASignature))
                        {
                            MetroMessageBox.Show(this, "This account already exist in the launcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        break;
                    this.addAccountNode(this.LauncherSettings.UserSettings.AName, this.LauncherSettings.UserSettings.ADescription,
                        this.LauncherSettings.UserSettings.AccountCategory, this.LauncherSettings.UserSettings.AFavorite.ToString(),
                        this.LauncherSettings.UserSettings.ACode, this.LauncherSettings.UserSettings.ASignature);
                    this.AccountsGrid.Visible = false;
                    this.AccountsGrid.Visible = true;
                    break;
            }
        }

        private void DeleteSelectedAccounts_Click(object sender, EventArgs e)
        {
            List<DataGridViewRow> lstSelectedRows = new List<DataGridViewRow>();
            foreach (DataGridViewRow row in AccountsGrid.Rows)
            {
                if(row.Selected) // Grab only selected accounts
                    lstSelectedRows.Add(row);
            }

            if (MetroMessageBox.Show(this, "Are you REALLY sure you want to remove the selected accounts?", "Are you sure about that?",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                foreach (var row in lstSelectedRows)
                {
                    this.deleteAccountNode(row.Cells[4].Value.ToString());
                }
            }
        }

        private void ExportAccounts_Click(object sender, EventArgs e)
        {
            this.ExportAccountSaveFileDialog.ShowDialog();
        }

        private void ExportAccountSaveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = this.ExportAccountSaveFileDialog.FileName;
            XmlDocument xmlDocument = new XmlDocument();
            XmlComment comment = xmlDocument.CreateComment(
                "Launcher Accounts File, do not edit unless you know what you're doing. This file is intended to be an import/export file.");
            xmlDocument.AppendChild(comment);
            XmlNode element1 = xmlDocument.CreateElement("AccountsList");
            xmlDocument.AppendChild(element1);
            if (this.AccountsGrid.SelectedCells.Count == 0)
            {
                MetroMessageBox.Show(this, "You didn't have any accounts selected.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            foreach (DataGridViewRow row in this.AccountsGrid.Rows)
            {
                if (row.Selected)
                {
                    XmlElement element2 = xmlDocument.CreateElement("account");
                    XmlAttribute descriptionAttribute = xmlDocument.CreateAttribute("description");
                    descriptionAttribute.Value = row.Cells[1].Value.ToString();

                    XmlAttribute categoryAttribute = xmlDocument.CreateAttribute("category");
                    categoryAttribute.Value = row.Cells[2].Value.ToString();

                    XmlAttribute favAttribute = xmlDocument.CreateAttribute("favorite");
                    favAttribute.Value = row.Cells[3].Value.ToString();

                    XmlAttribute codeAttribute = xmlDocument.CreateAttribute("code");
                    codeAttribute.Value = row.Cells[4].Value.ToString();

                    XmlAttribute sigAttribute = xmlDocument.CreateAttribute("signature");
                    sigAttribute.Value = row.Cells[5].Value.ToString();

                    element2.InnerText = row.Cells[1].Value.ToString();
                    element2.Attributes.Append(descriptionAttribute);
                    element2.Attributes.Append(categoryAttribute);
                    element2.Attributes.Append(favAttribute);
                    element2.Attributes.Append(codeAttribute);
                    element2.Attributes.Append(sigAttribute);
                    xmlDocument.DocumentElement.AppendChild(element2);
                }
            }

            xmlDocument.Save(fileName);
            Process.Start(Path.GetDirectoryName(fileName));
        }

        private void EditAccount_Click(object sender, EventArgs e)
        {
            int iNum = 0;
            string currentAccountName = "";
            foreach (DataGridViewRow r in AccountsGrid.Rows)
            {
                if (r.Selected)
                {
                    currentAccountName = r.Cells[0].Value.ToString();
                    iNum++;
                }
            }

            if (iNum == 0 || iNum > 1)
            {
                MetroMessageBox.Show(this, "You cannot select multiple accounts to edit. You must select only one at a time.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            NewAccount accountForm = new NewAccount();
            DataGridViewRow row = this.AccountsGrid.Rows[this.AccountsGrid.SelectedCells[0].RowIndex];

            this.LauncherSettings.UserSettings.AName = row.Cells[0].Value.ToString();
            this.LauncherSettings.UserSettings.ADescription = row.Cells[1].Value.ToString();
            this.LauncherSettings.UserSettings.AccountCategory = row.Cells[2].Value.ToString();
            this.LauncherSettings.UserSettings.AFavorite = ConvertYesNoBool(row.Cells[3].Value.ToString());
            this.LauncherSettings.UserSettings.ACode = row.Cells[4].Value.ToString();
            this.LauncherSettings.UserSettings.ASignature = row.Cells[5].Value.ToString();

            accountForm.ShowDialog();
            if (accountForm.DialogResult != DialogResult.OK) return;

            this.editAccountNode(this.LauncherSettings.UserSettings.AName, this.LauncherSettings.UserSettings.ADescription,
                this.LauncherSettings.UserSettings.AccountCategory, this.LauncherSettings.UserSettings.AFavorite.ToString(),
                this.LauncherSettings.UserSettings.ACode, this.LauncherSettings.UserSettings.ASignature);
            
            this.AccountsGrid.Visible = false;
            this.AccountsGrid.Visible = true;
            if (this.CurrentSelectedAccountLabel.Text == currentAccountName)
                this.CurrentSelectedAccountLabel.Text = this.LauncherSettings.UserSettings.AName;

            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < lstFavoriteAccounts.Count; i++) // Using Foreach will throw exception
            {
                if (lstFavoriteAccounts[i].Text == currentAccountName)
                    lstFavoriteAccounts[i].Text = this.LauncherSettings.UserSettings.AName;
            }
        }

        private void MarkFavorite_Click(object sender, EventArgs e)
        {
            int iNum = 0;
            foreach (DataGridViewRow r in AccountsGrid.Rows)
            {
                if (r.Selected)
                {
                    iNum++;
                }
            }

            if (iNum == 0 || iNum > 1)
            {
                MetroMessageBox.Show(this, "You cannot select multiple accounts to favorite. You must select only one at a time.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            DataGridViewRow row = this.AccountsGrid.Rows[this.AccountsGrid.SelectedCells[0].RowIndex];

            this.LauncherSettings.UserSettings.AName = row.Cells[0].Value.ToString();
            this.LauncherSettings.UserSettings.ADescription = row.Cells[1].Value.ToString();
            this.LauncherSettings.UserSettings.AccountCategory = row.Cells[2].Value.ToString();
            this.LauncherSettings.UserSettings.AFavorite = !ConvertYesNoBool(row.Cells[3].Value.ToString()); // Invert whatever it already is
            this.LauncherSettings.UserSettings.ACode = row.Cells[4].Value.ToString();
            this.LauncherSettings.UserSettings.ASignature = row.Cells[5].Value.ToString();

            if (lstFavoriteAccounts.Count == 4 && this.LauncherSettings.UserSettings.AFavorite)
            {
                MetroMessageBox.Show(this, "You already have four accounts favorited. You can not add more.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            this.editAccountNode(this.LauncherSettings.UserSettings.AName, this.LauncherSettings.UserSettings.ADescription,
                this.LauncherSettings.UserSettings.AccountCategory, this.LauncherSettings.UserSettings.AFavorite.ToString(),
                this.LauncherSettings.UserSettings.ACode, this.LauncherSettings.UserSettings.ASignature);
        }

        private void UpdateRecentAccounts()
        {
            this.RecentAccounts1.Text = this.LauncherSettings.UserSettings.RecentAccount1;
            this.RecentAccounts2.Text = this.LauncherSettings.UserSettings.RecentAccount2;
            this.RecentAccounts3.Text = this.LauncherSettings.UserSettings.RecentAccount3;
            this.RecentAccounts4.Text = this.LauncherSettings.UserSettings.RecentAccount4;
            this.LauncherSettings.SetRecentAccount(1);
            this.LauncherSettings.SetRecentAccount(2);
            this.LauncherSettings.SetRecentAccount(3);
            this.LauncherSettings.SetRecentAccount(4);
        }

        private void SelectNewAccount(DataGridViewRow row)
        {
            string accName = row.Cells[0].Value.ToString();
            string accCode = row.Cells[4].Value.ToString();
            string accSig = row.Cells[5].Value.ToString();

            try
            {
                RegistryKey subKey = Registry.CurrentUser.CreateSubKey("Software\\Microsoft\\Microsoft Games\\Freelancer\\1.0", RegistryKeyPermissionCheck.ReadWriteSubTree);
                if (subKey != null)
                {
                    subKey.SetValue("MPAccountName", accCode);
                    subKey.SetValue("MPAccountNameSig", accSig);
                    this.CurrentSelectedAccountLabel.Text = accName;
                }

                if (this.LauncherSettings.UserSettings.RecentAccount1 == accName ||
                    this.LauncherSettings.UserSettings.RecentAccount2 == accName ||
                    this.LauncherSettings.UserSettings.RecentAccount3 == accName ||
                    this.LauncherSettings.UserSettings.RecentAccount4 == accName)
                        return;

                this.LauncherSettings.UserSettings.RecentAccount4 = this.LauncherSettings.UserSettings.RecentAccount3;
                this.LauncherSettings.UserSettings.RecentAccount3 = this.LauncherSettings.UserSettings.RecentAccount2;
                this.LauncherSettings.UserSettings.RecentAccount2 = this.LauncherSettings.UserSettings.RecentAccount1;
                this.LauncherSettings.UserSettings.RecentAccount1 = accName;
                UpdateRecentAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetRowIndex(string accName)
        {
            int index = -1;
            foreach (DataGridViewRow r in AccountsGrid.Rows)
            {
                if (r.Cells[0].Value.ToString() == accName)
                {
                    index = r.Index;
                    break;
                }
            }

            if (index == -1)
            {
                MetroMessageBox.Show(this, "Unable to load account. Account no longer exists or is corrpted.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            return index;
        }

        private void FavAccount1_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(FavAccount1.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void FavAccount2_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(FavAccount2.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void FavAccount3_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(FavAccount3.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void FavAccount4_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(FavAccount4.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void AccountsGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int iNum = 0;
            foreach (DataGridViewRow r in AccountsGrid.Rows)
            {
                if (r.Selected)
                {
                    iNum++;
                }
            }

            if (iNum == 0 || iNum > 1)
                return;

            DataGridViewRow row = this.AccountsGrid.Rows[this.AccountsGrid.SelectedCells[0].RowIndex];
            SelectNewAccount(row);
        }

        private void RecentAccounts1_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(RecentAccounts1.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void RecentAccounts2_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(RecentAccounts2.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void RecentAccounts3_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(RecentAccounts3.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void RecentAccounts4_Click(object sender, EventArgs e)
        {
            int index = GetRowIndex(RecentAccounts4.Text);
            if (index == -1)
                return;
            SelectNewAccount(AccountsGrid.Rows[index]);
        }

        private void SortCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int index = 0; index < this.AccountsGrid.Rows.Count; index++)
            {
                DataGridViewRow row = this.AccountsGrid.Rows[index];
                if (SortCategory.SelectedIndex == 0)
                    row.Visible = true;
                else if (row.Cells[2].Value.ToString().Equals(SortCategory.Items[SortCategory.SelectedIndex]))
                    row.Visible = true;
                else
                    row.Visible = false;
            }
        }

        private void importLauncherAccountsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ImportLauncherFile.ShowDialog();
        }

        private void ImportLauncherFile_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = this.ImportLauncherFile.FileName;
            if (!File.Exists(fileName))
            {
                MetroMessageBox.Show(this, "The specified file does not exist.", "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Hand);
                return;
            }

            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                StreamReader streamReader = new StreamReader(fileName);
                xmlDocument.Load(streamReader);
                if (xmlDocument.SelectSingleNode("/AccountsList") == null)
                {
                    MetroMessageBox.Show(this,
                        "The selected file is not a DSLauncher account file.\nIt might be a Launchpad file.",
                        "Invalid XML", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/AccountsList");
                    foreach (XmlNode xmlNode2 in xmlNode1)
                    {
                        string accountName = xmlNode2.InnerText;
                        string accountDescription = xmlNode2.Attributes.GetNamedItem("description").Value;
                        string accountCategory;
                        try // Importing accounts from the old launcher will throw an exception due to them lacking the category field
                        {
                            accountCategory = xmlNode2.Attributes.GetNamedItem("category").Value;
                        }
                        catch (Exception ex)
                        {
                            accountCategory = "None";
                        }

                        string accountFavorite = xmlNode2.Attributes.GetNamedItem("favorite").Value;
                        string accountCode = xmlNode2.Attributes.GetNamedItem("code").Value;
                        string accouneSignature = xmlNode2.Attributes.GetNamedItem("signature").Value;
                        int num4 = 0;
                        foreach (DataGridViewRow row in this.AccountsGrid.Rows)
                        {
                            if (row.Cells[4].Value.ToString() == accountCode)
                            {
                                MetroMessageBox.Show(this, "The account " + accountName + " already exist as " + row.Cells[0].Value,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                num4 = 1;
                                break;
                            }
                        }

                        if (num4 == 0)
                            this.addAccountNode(accountName, accountDescription, accountCategory, accountFavorite, accountCode, accouneSignature);
                    }

                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                this.LauncherSettings.ExHandler.ExHandler("P01", ex.Message, this);
            }
        }

        private void CheckAccountRegistry()
        {
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Microsoft\\Microsoft Games\\Freelancer\\1.0");
                if (registryKey == null)
                    return;
                object obj1 = registryKey.GetValue("MPAccountName");
                object obj2 = registryKey.GetValue("MPAccountNameSig");
                this.LauncherSettings.UserSettings.ActiveCode = obj1.ToString();
                this.LauncherSettings.UserSettings.ActiveSignature = obj2.ToString();
                bool flag = false;
                foreach (DataGridViewRow row in this.AccountsGrid.Rows)
                {
                    if (row.Cells[4].Value.ToString().Equals(this.LauncherSettings.UserSettings.ActiveCode))
                    {
                        int index = row.Index;
                        this.AccountsGrid.Rows[index].Selected = true;
                        this.CurrentSelectedAccountLabel.Text = this.AccountsGrid.Rows[index].Cells[0].Value.ToString();
                        flag = true;
                        break;
                    }
                }
                if (flag)
                    return;
                MetroMessageBox.Show(this, "The account currently in the registry is not in your accounts list. It will now be added in the list as My New Account.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.addAccountNode("New Account", "Extracted from the registry", "None", "False",
                    this.LauncherSettings.UserSettings.ActiveCode, this.LauncherSettings.UserSettings.ActiveSignature);
                this.CurrentSelectedAccountLabel.Text = "New Account";
            }
            catch (Exception)
            {
                MetroMessageBox.Show(this, "Could not find a registry entry for freelancer accounts. This means you probably never created a freelancer account.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void CNSImport_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (!e.Url.ToString().Contains("about:blank"))
            {
                e.Cancel = true;
                Process.Start(e.Url.ToString());
            }
        }

        private void IncreaseDrawDistance_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.DrawDistance = this.IncreaseDrawDistance.Checked;
            this.LauncherSettings.SetDrawDistance();
        }

        private void downloadProgress_TextChanged(object sender, EventArgs e)
        {
            //int newX = this.patchDownload.Location.X + (this.patchDownload.Size.Width / 2) - (this.downloadProgress.Size.Width / 2);
            //int newY = this.downloadProgress.Location.Y;
            //this.downloadProgress.Location = new Point(newX, newY);
        }
    }
}
