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
using System.Xml.Serialization;

namespace DSLauncherV2
{
    public sealed partial class Primary : MetroFramework.Forms.MetroForm
    {
        public BackgroundWorker LoadingBackgroundWorker;
        private LauncherSettings LauncherSettings = DSLauncherV2.LauncherSettings.Instance;
        private List<MetroLink> lstFavoriteAccounts;
        private List<DataGridViewRow> UnfilterdRows = new List<DataGridViewRow>();
        private List<string> lstAccountCategories = new List<string>();
        private byte[] downloadedData;
        private string currentAnnouncement;
        private int dragIndex = -1;
        private MetroLabel dragLabel = null;
        private Timer timer;

        public Primary()
        {
            // Before we init we want to make sure the patcher is present
            if (!File.Exists(Directory.GetCurrentDirectory() + @"\DSSelfPatch.exe"))
                ExceptionHandler.Throw(ExceptionCode.P03, "Self Patcher not found. Please reinstall Discovery.", this);

            InitializeComponent();
            this.ControlBox = true;
            this.Text = "Discovery Launcher";
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

        private void ApplyLauncherConfig()
        {
            this.ToggleDesktopRes.Checked = this.LauncherSettings.UserSettings.Config.DisplayDesktopRes;
            this.ToggleArrivingPlayer.Checked = this.LauncherSettings.UserSettings.Config.ShowJoiningPlayers;
            this.ToggleChatAppend.Checked = this.LauncherSettings.UserSettings.Config.ChatAppend;
            this.ToggleChatLog.Checked = this.LauncherSettings.UserSettings.Config.ChatLogging;
            this.ToggleDepartingPlayer.Checked = this.LauncherSettings.UserSettings.Config.ShowDepartingPlayers;
            this.ToggleFlightText.Checked = this.LauncherSettings.UserSettings.Config.ShowFlightText;
            this.ToggleLagIcon.Checked = this.LauncherSettings.UserSettings.Config.ShowLagIndicator;
            this.ToggleLocalTime.Checked = this.LauncherSettings.UserSettings.Config.ChatLocalTime;
            this.ToggleWindowedMode.Checked = this.LauncherSettings.UserSettings.Config.DisplayMode;
            this.HeightBox.Text = this.LauncherSettings.UserSettings.Config.DisplayHeight;
            this.WidthBox.Text = this.LauncherSettings.UserSettings.Config.DisplayWidth;
            this.IncreaseDrawDistance.Checked = this.LauncherSettings.UserSettings.Config.DrawDistance;
            this.DisableChat.Checked = this.LauncherSettings.UserSettings.Config.DisableChat;
            this.ThemeSelector.SelectedIndex = this.LauncherSettings.UserSettings.Config.Style;
            this.metroTextBox1.Text = this.LauncherSettings.UserSettings.Config.ExtraArgs; // Optional Args

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.RecentAccounts.One))
            {
                this.RecentAccounts1.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.One;
                this.RecentAccounts1.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.RecentAccounts.Two))
            {
                this.RecentAccounts2.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Two;
                this.RecentAccounts2.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.RecentAccounts.Three))
            {
                this.RecentAccounts3.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Three;
                this.RecentAccounts3.Visible = true;
            }

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.RecentAccounts.Four))
            {
                this.RecentAccounts4.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Four;
                this.RecentAccounts4.Visible = true;
            }
        }

        #region Connections
        private void CheckConnectivity()
        {
            if (this.LauncherSettings.UserSettings.Config.RemotePatchLocation.Contains("discoverygc.com"))
            {
                this.LauncherSettings.UserSettings.Config.RemotePatchLocation = "http://patch.discoverygc.net/";
                SaveConfig();
            }
            try
            {
                WebClient webClient = new WebClient {CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)};
                webClient.DownloadFile(this.LauncherSettings.UserSettings.Config.RemotePatchLocation + "patchlist.xml",
                    this.LauncherSettings.UserSettings.PatchListTempFile);
                webClient.Dispose();
            }
            catch (Exception)
            {
                this.LauncherSettings.UserSettings.Config.RemotePatchLocation = Defaults.Settings.KittyURL;
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
                WebClient webClient = new WebClient { CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore) };
                webClient.DownloadFile(this.LauncherSettings.UserSettings.Config.RemotePatchLocation + "patchlist.xml",
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
                ExceptionHandler.Throw(ExceptionCode.F01, ex.Message, this);
            }
        }

        private void CheckToS()
        {
            try
            {
                WebClient client = new WebClient();
                if (File.Exists(Directory.GetCurrentDirectory() + @"\ToS.txt"))
                {
                    byte[] newBytes = client.DownloadData(this.LauncherSettings.UserSettings.Config.RemotePatchLocation + @"\launcher\ToS.txt");
                    byte[] oldBytes = File.ReadAllBytes(Directory.GetCurrentDirectory() + @"\ToS.txt");
                    if (newBytes.SequenceEqual(oldBytes) == false)
                    {
                        DisplayToS();
                    }
                }

                else
                    DisplayToS();
            }

            catch
            {
                return;
            }
        }

        private void DisplayToS()
        {
            try
            {
                WebClient client = new WebClient();
                string tos = Path.GetTempFileName();
                client.DownloadFile(this.LauncherSettings.UserSettings.Config.RemotePatchLocation + @"\launcher\ToS.txt", tos);
                StreamReader sr = new StreamReader(tos);
                ScrollMessageBox.ShowDialog(sr.ReadLine(), sr.ReadToEnd(), this);
            }
            catch
            {
                return;
            }
        }

        private void CheckLauncherChangeLog()
        {
            try
            {
                string version = Assembly.GetEntryAssembly().GetName().Version.Major + "." +
                                 Assembly.GetEntryAssembly().GetName().Version.Minor
                                 + "." + Assembly.GetEntryAssembly().GetName().Version.Build;

                if (!File.Exists(Directory.GetCurrentDirectory() + @"\DSLauncher.log"))
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\DSLauncher.log", version);
                    DisplayLauncherChangeLog(version);
                    return;
                }

                Regex regex = new Regex(@"((\d+)\.(\d+)\.(\d+))");
                Match match = regex.Match(File.ReadLines(Directory.GetCurrentDirectory() + @"\DSLauncher.log").First());
                if (!match.Success)
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + @"\DSLauncher.log", version);
                    DisplayLauncherChangeLog(version);
                }

                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("https://discoverygc.com/forums/showthread.php?tid=167176");

                if ((web.StatusCode != HttpStatusCode.OK) |
                    doc.DocumentNode.InnerHtml.Contains("The maximum server load limit has been reached"))
                    return;

                string node = doc.GetElementbyId("anchor-ver").NextSibling.InnerHtml;
                match = regex.Match(node);
                if (!match.Success) return;
                if (match.Value == version) return;

                DisplayLauncherChangeLog(version);
            }

            catch
            {
                return;
            }
        }

        private void DisplayLauncherChangeLog(string version)
        {
            try
            {
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load("https://discoverygc.com/forums/showthread.php?tid=167176&action=lastpost");
                if ((web.StatusCode != HttpStatusCode.OK) |
                    doc.DocumentNode.InnerHtml.Contains("The maximum server load limit has been reached"))
                    return;

                // This always matches indents
                HtmlNodeCollection nodes = doc.DocumentNode.SelectNodes("//div[contains(@style, 'margin-left')]");
                HtmlNode node = nodes[nodes.Count - 2]; // The last one in the collection is always contact us

                // We want to switch from the background worker to a UI thread
                // Doing it this way stops us from having lag when invoking the entire function
                // directly from the worker.
                this.Invoke((MethodInvoker) delegate()
                {
                    // We want to replace the first \n we see, as we otherwise we'll have an ugly newline at the start of every log
                    ScrollMessageBox.ShowDialog($"Recent Launcher Update: {version}", node.InnerText.Remove(0, 1), this);
                });
                File.WriteAllText(Directory.GetCurrentDirectory() + @"\DSLauncher.log", version);
            }

            catch
            {
                return;
            }
        }

        #endregion

        #region Background Worker
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
            this.CheckLauncherChangeLog();
        }

        private void LoadingBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void LoadingBackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            switch (e.ProgressPercentage)
            {
                case 0:
                    this.launcherCheckerLabel.Text = "Contacting Patch Server...";
                    this.metroStyleManager1.Style = (MetroColorStyle) this.LauncherSettings.UserSettings.Config.Style;
                    this.ApplyLauncherConfig();
                    break;
                case 1:
                    this.launcherCheckerLabel.Text = "Reading Patchlist Data...";
                    break;
                case 2:
                    CheckToS();
                    this.launcherCheckerLabel.Text = "Loading Accounts...";
                    break;
                case 3:
                    this.launcherCheckerLabel.Text = "Checking If Updates Are Required...";
                    this.MTC.Enabled = true;
                    SetAccountsTab();
                    this.CheckAccountRegistry();
                    break;
                case 4:
                    CNSImport.Capture = false;
                    CNSImport.DocumentText = currentAnnouncement;
                    if(!string.IsNullOrEmpty(CNSImport.DocumentText))
                        CNSImport.Visible = true;
                    if (this.LauncherSettings.UserSettings.RemoteLauncherVersion >
                        this.LauncherSettings.UserSettings.Config.LocalLauncherVersion)
                    {
                        Process.Start(Directory.GetCurrentDirectory() + @"\DSSelfPatch.exe");
                        this.launcherPatchSpinner.Visible = false;
                        this.launcherCheckerLabel.Visible = false;
                        this.downloadProgress.Visible = true;
                        this.downloadProgress.Text = "Launcher updates required; press \"Patch Launcher\" to install.";
                        this.patchGame.Enabled = false;
                        this.patchGame.ForeColor = Color.FromArgb(51, 51, 51);
                    }

                    break;
                case 5:
                    ReadyToLaunch();
                    break;
                case 6:
                    this.patchGame.Enabled = true;
                    this.patchGame.UseCustomForeColor = true;
                    this.patchGame.ForeColor = Color.FromKnownColor(KnownColor.CornflowerBlue);
                    this.launcherPatchSpinner.Visible = false;
                    this.launcherCheckerLabel.Visible = false;
                    this.downloadProgress.Visible = true;
                    this.downloadProgress.Text = "Game updates required; press \"Patch Game\" to install.";
                    break;
                case 7:
                    ReadyToLaunch();
                    break;
            }
        }
        #endregion

        #region Utility Functions
        private void GetDiscoveryAnnouncements()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc;
            
            try
            {
                doc = web.Load("http://patch.discoverygc.net/launcherimages/");
            }
            catch
            {
                return;
            }

            if ((web.StatusCode != HttpStatusCode.OK) |
                doc.DocumentNode.InnerHtml.Contains("The maximum server load limit has been reached"))
                return;

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

        private bool ConvertYesNoBool(string value)
        {
            if (value.ToLower() == "yes")
                return true;
            else
                return false;
        }
        #endregion

        #region Tab Control
        private void MTC_SelectedIndexChanged(object sender, EventArgs e)
        {
            // We assume it's not the accounts tab by default
            this.accountsSearch.Visible = false;
            this.accountsSearchLabel.Visible = false;

            switch (((TabControl) sender).SelectedIndex)
            { 
                // Game Settings
                case 2:
                    this.forcedArguments.Text = this.LauncherSettings.UserSettings.MainServer;
                    this.forcedArguments.ReadOnly = true;
                    this.forcedArguments.Enabled = false;
                    break;
                // Accounts
                case 3:
                    this.accountsSearch.Visible = true;
                    this.accountsSearchLabel.Visible = true;
                    break;
                // About
                case 4:
                    StringBuilder sb = new StringBuilder();

                    sb.Append(
                        "Discovery Freelancer is brought to you by the Discovery Development team.\r\n\r\n");

                    sb.Append("- DSLauncher 2.x Credits -\r\n");
                    sb.Append("Cannon and Kazinsal for the account generator,\r\n");
                    sb.Append("Alley for the original launcher code,\r\n");
                    sb.Append("Alex. for the decompliation of the original launcher,\r\n");
                    sb.Append("Laz for progamming the V2 launcher and continued development,\r\n");
                    sb.Append("Kazinsal for aesthetic updates,\r\n");
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

        private void SetAccountsTab()
        {
            int iNum = 0;
            List<MetroLink> lstMetroLinks = new List<MetroLink>();
            foreach (Account account in LauncherSettings.UserSettings.AccountList.Accounts)
            {
                this.LoadInAccounts(account.Name, account.Description, account.Category, account.IsFavorite, account.Code, account.Signature);

                if (lstAccountCategories.All(category => category != account.Category) && account.Category != "None")
                    lstAccountCategories.Add(account.Category);

                if (iNum < 4 && account.IsFavorite)
                {
                    iNum++;
                    switch (iNum)
                    {
                        case 1:
                            this.FavAccount1.Text = account.Name;
                            this.FavAccount1.Visible = true;
                            lstMetroLinks.Add(FavAccount1);
                            break;
                        case 2:
                            this.FavAccount2.Text = account.Name;
                            this.FavAccount2.Visible = true;
                            lstMetroLinks.Add(FavAccount2);
                            break;
                        case 3:
                            this.FavAccount3.Text = account.Name;
                            this.FavAccount3.Visible = true;
                            lstMetroLinks.Add(FavAccount3);
                            break;
                        case 4:
                            this.FavAccount4.Text = account.Name;
                            this.FavAccount4.Visible = true;
                            lstMetroLinks.Add(FavAccount4);
                            break;
                    }
                }
            }

            lstFavoriteAccounts = lstMetroLinks;
            foreach (string category in lstAccountCategories)
                SortCategory.Items.Add(category);

            if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.LastCategory))
            {
                int iSort = SortCategory.Items.IndexOf(this.LauncherSettings.UserSettings.Config.LastCategory);
                if (iSort > -1)
                    SortCategory.SelectedIndex = iSort;
            }
        }
        #endregion

        #region Accounts
        ///////////////////////////////////////////////
        /// Accounts Manager
        ///////////////////////////////////////////////

        private void LoadInAccounts(string accountName, string accountDescription, string accountCategory, bool isFav,
            string accountCode, string accountSig)
        {
            string fav = isFav ? "No" : "Yes";
            this.AccountsGrid.Rows.Add(accountName, accountDescription, accountCategory, fav, accountCode,
                accountSig);
            this.UnfilterdRows.Add(AccountsGrid.Rows[AccountsGrid.Rows.Count - 1]);
        }

        private void AddAccountNode(string accountName, string accountDescription, string accountCategory, bool isFav,
            string accountCode, string accountSig)
        {
            Account account = new Account()
            {
                Name = accountName,
                Description = accountDescription,
                Category = accountCategory,
                Code = accountCode,
                Signature = accountSig,
                IsFavorite = isFav
            };
            this.AccountsGrid.Rows.Add(accountName, accountDescription, accountCategory, isFav, accountCode,
                accountSig);
            this.UnfilterdRows.Add(AccountsGrid.Rows[AccountsGrid.Rows.Count - 1]);
            this.AccountsGrid.Visible = false;
            this.AccountsGrid.Visible = true;
            this.LauncherSettings.UserSettings.AccountList.Accounts.Add(account);
            this.LauncherSettings.SaveAccounts(this);
        }

        private void DeleteAccountNode(string accountCode)
        {
            for (int i = 0; i < UnfilterdRows.Count; i++)
            {
                DataGridViewRow row = this.UnfilterdRows[i];
                if (row.Cells[4].Value.ToString().Equals(accountCode))
                {
                    this.AccountsGrid.Rows.Remove(row);
                    this.UnfilterdRows.Remove(row);
                }
            }

            Account account = this.LauncherSettings.UserSettings.AccountList.Accounts.Find(x => x.Code == accountCode);
            this.LauncherSettings.UserSettings.AccountList.Accounts.Remove(account);
            this.LauncherSettings.SaveAccounts(this);
        }

        private void EditAccountNode(string accountName, string accountDescription, string accountCategory,
            bool isFav, string accountCode, string accountSig)
        {
            this.DeleteAccountNode(accountCode);
            this.AddAccountNode(accountName, accountDescription, accountCategory, isFav, accountCode, accountSig);
        }

        private void AccountsGrid_MouseDown(object sender, MouseEventArgs e)
        {
            // Taken from:
            // https://stackoverflow.com/questions/43890477/drag-and-drop-rows-of-datagrid-view-winform-c-sharp
            // Modified to work with the application

            // Only do this when we are working without a category
            if (AccountsGrid.Rows.Count != UnfilterdRows.Count) return;
            int i = this.AccountsGrid.HitTest(e.X, e.Y).RowIndex;
            if (i < 0) return; // If we haven't clicked on a row

            timer = new Timer();
            timer.Tick += delegate { MouseHeld_Timer(i); };
            timer.Interval = 1000;
            timer.Start();
        }

        private void MouseHeld_Timer(int row1)
        {
            timer.Stop();
            if (MouseButtons != MouseButtons.Left) return; // If we are not holding down the left mouse button.
            Point i = this.AccountsGrid.PointToClient(Cursor.Position);
            int row2 = this.AccountsGrid.HitTest(i.X, i.Y).RowIndex;
            if (row2 < 0) return; // If we are not selected on a row
            if (row1 != row2) return; // If we are selected on a different row

            dragIndex = row1; // Grab our row index to use later
            this.AccountsGrid.ClearSelection(); // Otherwise we end up selecting all accounts
            this.AccountsGrid.MultiSelect = false;

            // Setup our Label
            if (dragLabel == null)
                dragLabel = new MetroLabel();

            dragLabel.Style = (MetroColorStyle)this.LauncherSettings.UserSettings.Config.Style; // Copy our theme
            dragLabel.Theme = MetroThemeStyle.Dark; // Dark is best
            dragLabel.UseStyleColors = true; // Blue writing by default
            dragLabel.Parent = this.AccountsGrid; // Don't let us drag this outside the grid
            dragLabel.Text = this.AccountsGrid.Rows[dragIndex].Cells[0].Value.ToString(); // So they don't forget the account
            dragLabel.Location = this.AccountsGrid.PointToClient(Cursor.Position); // Summon our label at our cursor
        }

        private void AccountsGrid_MouseMove(object sender, MouseEventArgs e)
        {
            // If the user is no longer holding down left click, or if the label is no longer in use
            if (e.Button != MouseButtons.Left || dragLabel == null)
            {
                this.AccountsGrid.MultiSelect = true; // Re-enable multi-select
                return;
            }

            dragLabel.Location = e.Location; // Keep it glued to our cursor
            AccountsGrid.ClearSelection(); // Clear what was selected 
        }

        private void AccountsGrid_MouseUp(object sender, MouseEventArgs e)
        {
            // If we dont do this and drag outside of the grid, we crash.
            if (AccountsGrid.Rows.Count != UnfilterdRows.Count) return;

            var hit = this.AccountsGrid.HitTest(e.X, e.Y);
            if (hit.Type != DataGridViewHitTestType.None)
            {
                var dropRow = hit.RowIndex;
                if (dragIndex >= 0)
                {
                    int tgtRow = dropRow + (dragIndex > dropRow ? 1 : 0);
                    if (tgtRow != dragIndex)
                    {
                        DataGridViewRow row = this.AccountsGrid.Rows[dragIndex];
                        this.AccountsGrid.Rows.Remove(row);
                        this.AccountsGrid.Rows.Insert(tgtRow, row);
                        this.UnfilterdRows.Clear();
                        foreach (var i in this.AccountsGrid.Rows)
                            this.UnfilterdRows.Add((DataGridViewRow)i);

                        this.LauncherSettings.UserSettings.AccountList.Accounts.Clear();
                        foreach (var i in this.UnfilterdRows)
                        {
                            Account account = new Account()
                            {
                                Name = i.Cells[0].Value.ToString(),
                                Description = i.Cells[1].Value.ToString(),
                                Category = i.Cells[2].Value.ToString(),
                                IsFavorite = i.Cells[3].Value.ToString().ToLower() == "yes",
                                Code = i.Cells[4].Value.ToString(),
                                Signature = i.Cells[5].Value.ToString(),
                            };

                            this.LauncherSettings.UserSettings.AccountList.Accounts.Add(account);
                        }

                        this.LauncherSettings.SaveAccounts(this);

                        this.AccountsGrid.ClearSelection();
                        row.Selected = true;
                    }
                }
            }
            else if (dragIndex > 0)
            {
                this.AccountsGrid.Rows[dragIndex].Selected = true;
            }

            if (dragLabel != null)
            {
                dragLabel.Dispose();
                dragLabel = null;
                dragIndex = 0;
            }
        }

        #endregion

        #region Patching

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
            foreach (KeyValuePair<int, PatchListDataStruct> keyValuePair in this.LauncherSettings
                .UserSettings.PatchListData)
            {
                string str = this.LauncherSettings.UserSettings.Config.InstallPath + "\\" + keyValuePair.Value.PatchURL;
                if (this.LauncherSettings.UserSettings.PatchHistory.All(p => p != keyValuePair.Value.PatchMD5Hash))
                {
                    bool flag1 = System.IO.File.Exists(str) && this.CompareMD5(str, keyValuePair.Value.PatchMD5Hash);
                    if (!flag1)
                    {
                        try
                        {
                            this.downloadedData = new byte[0];
                            WebResponse response = WebRequest
                                .Create(this.LauncherSettings.UserSettings.Config.RemotePatchLocation +
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
                        }
                        catch (Exception ex)
                        {
                            ExceptionHandler.Throw(ExceptionCode.P01, ex.Message, this);
                        }
                    }

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
                                    reader.WriteEntryToDirectory(this.LauncherSettings.UserSettings.Config.InstallPath,
                                        new ExtractionOptions() {Overwrite = true, ExtractFullPath = true});
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Throw(ExceptionCode.P02, ex.Message, this);
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
                            this.LauncherSettings.UserSettings.PatchHistory.Add(keyValuePair.Value.PatchMD5Hash);
                        }
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Throw(ExceptionCode.P02, ex.Message, this);
                    }
                }
            }
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

        #endregion

        #region Launcher Settings Changed

        public void SaveConfig()
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));
                TextWriter writer = new StreamWriter("launcherconfig.xml");
                serializer.Serialize(writer, this.LauncherSettings.UserSettings);
                writer.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C06, ex.Message, this);
            }
        }

        private void ThemeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            metroStyleManager1.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            launcherPatchSpinner.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            metroProgressSpinner1.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            patchDownload.Style = (MetroColorStyle) Convert.ToInt32(ThemeSelector.SelectedIndex);
            this.LauncherSettings.UserSettings.Config.Style = Convert.ToInt32(ThemeSelector.Style);
            SaveConfig();
        }

        private void ToggleChatLog_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ChatLogging = ToggleChatLog.Checked;
            SaveConfig();
        }

        private void ToggleChatAppend_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ChatAppend = ToggleChatAppend.Checked;
            SaveConfig();
        }

        private void ToggleLogTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ChatTime = ToggleLogTime.Checked;
            SaveConfig();
        }

        private void ToggleLocalTime_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ChatLocalTime = ToggleLocalTime.Checked;
            SaveConfig();
        }

        private void ToggleFlightText_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ShowFlightText = ToggleFlightText.Checked;
            SaveConfig();
        }

        private void ToggleLagIcon_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ShowLagIndicator = ToggleLagIcon.Checked;
            SaveConfig();
        }

        private void ToggleArrivingPlayer_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ShowJoiningPlayers = ToggleArrivingPlayer.Checked;
            SaveConfig();
        }

        private void ToggleDepartingPlayer_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.ShowDepartingPlayers = ToggleDepartingPlayer.Checked;
            SaveConfig();
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

            this.LauncherSettings.UserSettings.Config.DisplayDesktopRes = ToggleDesktopRes.Checked;
            SaveConfig();
        }

        private void ToggleWindowedMode_CheckedChanged(object sender, EventArgs e)
        {
            this.LauncherSettings.UserSettings.Config.DisplayMode = ToggleWindowedMode.Checked;
            SaveConfig();
        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e) // Optional Arguments
        {
            this.LauncherSettings.UserSettings.Config.ExtraArgs = this.metroTextBox1.Text;
            SaveConfig();
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
                this.LauncherSettings.UserSettings.Config.DisplayHeight = this.HeightBox.Text;
                SaveConfig();
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
                this.LauncherSettings.UserSettings.Config.DisplayWidth = this.WidthBox.Text;
                SaveConfig();
            }
        }

        private void DisableChat_CheckedChanged(object sender, EventArgs e)
        {
            this.ChatWarning.Visible = DisableChat.Checked;
            this.LauncherSettings.UserSettings.Config.DisableChat = DisableChat.Checked;
            SaveConfig();
        }

        #endregion

        #region Context Menu

        private void CreateNewAccount_Click(object sender, EventArgs e)
        {
            NewAccount accountForm = new NewAccount();
            UserSettings.Favorite = false;
            UserSettings.Name = "";
            UserSettings.Description = "";
            UserSettings.Code = "";
            UserSettings.Signature = "";
            UserSettings.AccountCategory = "";
            accountForm.ShowDialog();
            switch (accountForm.DialogResult)
            {
                case DialogResult.OK:
                    bool flag = false;
                    foreach (DataGridViewRow row in this.UnfilterdRows)
                    {
                        if (row.Cells[5].Value.ToString().Equals(UserSettings.Signature))
                        {
                            MetroMessageBox.Show(this, "This account already exist in the launcher.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            flag = true;
                            break;
                        }
                    }
                    if (flag)
                        break;
                    this.AddAccountNode(UserSettings.Name, UserSettings.Description, UserSettings.AccountCategory, UserSettings.Favorite,
                        UserSettings.Code, UserSettings.Signature);
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
                    this.DeleteAccountNode(row.Cells[4].Value.ToString());
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
                if (!r.Selected) continue;
                currentAccountName = r.Cells[0].Value.ToString();
                iNum++;
            }

            if (iNum == 0)
            {
                MetroMessageBox.Show(this, "You must have an account selected to edit.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if (iNum > 1)
            {
                MetroMessageBox.Show(this, "You cannot select multiple accounts to edit. You must select only one at a time.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else
            {
                DataGridViewRow row = this.AccountsGrid.Rows[this.AccountsGrid.SelectedCells[0].RowIndex];
                UserSettings.Name = row.Cells[0].Value.ToString();
                UserSettings.Description = row.Cells[1].Value.ToString();
                UserSettings.AccountCategory = row.Cells[2].Value.ToString();
                UserSettings.Favorite = ConvertYesNoBool(row.Cells[3].Value.ToString());
                UserSettings.Code = row.Cells[4].Value.ToString();
                UserSettings.Signature = row.Cells[5].Value.ToString();

                NewAccount accountForm = new NewAccount(UserSettings.Name, UserSettings.Description, UserSettings.AccountCategory,
                    UserSettings.Code, UserSettings.Signature);
                accountForm.ShowDialog();
                if (accountForm.DialogResult != DialogResult.OK) return;

                this.EditAccountNode(UserSettings.Name,
                    UserSettings.Description,
                    UserSettings.AccountCategory,
                    UserSettings.Favorite,
                    UserSettings.Code, UserSettings.Signature);

                this.AccountsGrid.Visible = false;
                this.AccountsGrid.Visible = true;
                if (this.CurrentSelectedAccountLabel.Text == currentAccountName)
                    this.CurrentSelectedAccountLabel.Text = UserSettings.Name;

                // ReSharper disable once ForCanBeConvertedToForeach
                for (int i = 0; i < lstFavoriteAccounts.Count; i++) // Using Foreach will throw exception
                {
                    if (lstFavoriteAccounts[i].Text == currentAccountName)
                        lstFavoriteAccounts[i].Text = UserSettings.Name;
                }
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

            UserSettings.Name = row.Cells[0].Value.ToString();
            UserSettings.Description = row.Cells[1].Value.ToString();
            UserSettings.AccountCategory = row.Cells[2].Value.ToString();
            UserSettings.Favorite = !ConvertYesNoBool(row.Cells[3].Value.ToString()); // Invert whatever it already is
            UserSettings.Code = row.Cells[4].Value.ToString();
            UserSettings.Signature = row.Cells[5].Value.ToString();

            if (lstFavoriteAccounts.Count == 4 && UserSettings.Favorite)
            {
                MetroMessageBox.Show(this, "You already have four accounts favorited. You can not add more.", "",
                    MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            this.EditAccountNode(UserSettings.Name, UserSettings.Description,
                UserSettings.AccountCategory, UserSettings.Favorite,
                UserSettings.Code, UserSettings.Signature);
        }

        #endregion

        #region Accounts Grid

        private void UpdateRecentAccounts()
        {
            this.RecentAccounts1.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.One;
            this.RecentAccounts2.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Two;
            this.RecentAccounts3.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Three;
            this.RecentAccounts4.Text = this.LauncherSettings.UserSettings.Config.RecentAccounts.Four;
            SaveConfig();
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

                if (this.LauncherSettings.UserSettings.Config.RecentAccounts.One == accName ||
                    this.LauncherSettings.UserSettings.Config.RecentAccounts.Two == accName ||
                    this.LauncherSettings.UserSettings.Config.RecentAccounts.Three == accName ||
                    this.LauncherSettings.UserSettings.Config.RecentAccounts.Four == accName)
                    return;

                this.LauncherSettings.UserSettings.Config.RecentAccounts.Four = this.LauncherSettings.UserSettings.Config.RecentAccounts.Four;
                this.LauncherSettings.UserSettings.Config.RecentAccounts.Three = this.LauncherSettings.UserSettings.Config.RecentAccounts.Three;
                this.LauncherSettings.UserSettings.Config.RecentAccounts.Two = this.LauncherSettings.UserSettings.Config.RecentAccounts.Two;
                this.LauncherSettings.UserSettings.Config.RecentAccounts.One = accName;
                UpdateRecentAccounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // This function is called when someone selects a recent or favorite account.
        private void QuickSelectAccount(object sender, EventArgs e)
        {
            int index = -1;

            if (SortCategory.SelectedIndex <= 0)
            {
                foreach (DataGridViewRow r in AccountsGrid.Rows)
                {
                    if (r.Cells[0].Value.ToString() != ((MetroLink)sender).Text) continue;
                    index = r.Index;
                    break;
                }

                if (index == -1)
                {
                    ExceptionHandler.Throw(ExceptionCode.C05, "", this);
                    ((MetroLink) sender).Visible = false;
                    return;
                }

                SelectNewAccount(AccountsGrid.Rows[index]);
            }

            else
            {
                for (var i = 0; i < UnfilterdRows.Count; i++)
                {
                    DataGridViewRow r = UnfilterdRows[i];
                    if (r.Cells[0].Value.ToString() != ((MetroLink) sender).Text) continue;
                    index = i;
                    break;
                }

                if (index == -1)
                {
                    ExceptionHandler.Throw(ExceptionCode.C05, "", this);
                    ((MetroLink)sender).Visible = false;
                    return;
                }

                SelectNewAccount(UnfilterdRows[index]);
            }
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

        private void SortCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SortCategory.SelectedIndex <= 0)
            {
                this.AccountsGrid.Rows.Clear();
                foreach (DataGridViewRow row in UnfilterdRows)
                {
                    this.AccountsGrid.Rows.Add(row);
                }

                this.LauncherSettings.UserSettings.Config.LastCategory = null;
                this.SaveConfig();
                return;
            }

            this.AccountsGrid.Rows.Clear();
            foreach (var row in UnfilterdRows)
            {
                if (row.Cells[2].Value.ToString().Equals(SortCategory.Items[SortCategory.SelectedIndex]))
                {
                    this.AccountsGrid.Rows.Add(row);
                }
            }
            this.LauncherSettings.UserSettings.Config.LastCategory = SortCategory.Items[SortCategory.SelectedIndex].ToString();
            this.SaveConfig();
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
                        foreach (DataGridViewRow row in this.UnfilterdRows)
                        {
                            if (row.Cells[4].Value.ToString() == accountCode)
                            {
                                MetroMessageBox.Show(this, "The account " + accountName + " already exist as " + row.Cells[0].Value,
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                                num4 = 1;
                                break;
                            }
                        }

                        bool isFav = accountFavorite.ToLower() == "true";
                        if (num4 == 0)
                            this.AddAccountNode(accountName, accountDescription, accountCategory, isFav, accountCode, accouneSignature);
                    }

                    streamReader.Close();
                    streamReader.Dispose();
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.I01, ex.Message, this);
            }
        }

        private void accountsSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.accountsSearch.Text))
            {
                if (this.SortCategory.SelectedIndex <= 0)
                {
                    this.AccountsGrid.Rows.Clear();
                    foreach (DataGridViewRow row in this.UnfilterdRows)
                    {
                        this.AccountsGrid.Rows.Add(row);
                    }
                }

                else
                {
                    // A bit unorthadox, but since we never use sender or event args in that function, should be fine.
                    SortCategory_SelectedIndexChanged(sender, e);
                    
                }
                return;
            }

            this.AccountsGrid.Rows.Clear();
            foreach (var row in this.UnfilterdRows)
            {
                // If we get a partial match to the name or description
                if (row.Cells[0].Value.ToString().ToLowerInvariant().Contains(this.accountsSearch.Text.ToLowerInvariant()) || 
                    row.Cells[1].Value.ToString().ToLowerInvariant().Contains(this.accountsSearch.Text.ToLowerInvariant()))
                {
                    this.AccountsGrid.Rows.Add(row);
                }
            }
        }

        #endregion

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
                foreach (DataGridViewRow row in this.UnfilterdRows)
                {
                    if (row.Cells[4].Value.ToString().Equals(this.LauncherSettings.UserSettings.ActiveCode))
                    {
                        this.CurrentSelectedAccountLabel.Text = row.Cells[0].Value.ToString();
                        int index = this.AccountsGrid.Rows.IndexOf(row);
                        if (index != -1)
                            this.AccountsGrid.Rows[index].Selected = true;
                        return;
                    }
                }

                MetroMessageBox.Show(this, "The account currently in the registry is not in your accounts list. It will now be added in the list as My New Accounts.",
                    "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.AddAccountNode("New Accounts", "Extracted from the registry", "None", false, this.LauncherSettings.UserSettings.ActiveCode,
                    this.LauncherSettings.UserSettings.ActiveSignature);
                this.CurrentSelectedAccountLabel.Text = "New Accounts";
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
            this.LauncherSettings.UserSettings.Config.DrawDistance = this.IncreaseDrawDistance.Checked;
            SaveConfig();
        }

        private void downloadProgress_TextChanged(object sender, EventArgs e)
        {
            //int newX = this.patchDownload.Location.X + (this.patchDownload.Size.Width / 2) - (this.downloadProgress.Size.Width / 2);
            //int newY = this.downloadProgress.Location.Y;
            //this.downloadProgress.Location = new Point(newX, newY);
        }

        #region Launching
        // Launch Game
        void LaunchFreelancer()
        {
            string FLExe = this.LauncherSettings.UserSettings.Config.InstallPath + @"/EXE/Freelancer.exe";
            string DSAce = this.LauncherSettings.UserSettings.Config.InstallPath + @"/EXE/DSAce.dll";
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
                        ExceptionHandler.Throw(ExceptionCode.L04, ex.Message, this);
                    }
                }
            }

            if (!File.Exists(FLExe)) // We cannot find Freelancer.exe
            {
                ExceptionHandler.Throw(ExceptionCode.L01, "", this);
            }

            else
            {
                if (!File.Exists(DSAce))
                {
                    ExceptionHandler.Throw(ExceptionCode.L03, "", this);
                }

                else
                {
                    // Clean the saves directory in case multiple Discovery versions or FL mods are being run simultaneously
                    if (System.IO.File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games/Freelancer/Accts/SinglePlayer/Restart.fl")))
                        foreach (string file in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Games/Freelancer/Accts/SinglePlayer/"), "*.fl"))
                            System.IO.File.Delete(file);

                    string launchSettings = this.LauncherSettings.UserSettings.MainServer;

                    if (this.LauncherSettings.UserSettings.Config.DisplayMode)
                        launchSettings += " -windowed";

                    if (this.LauncherSettings.UserSettings.Config.DisplayDesktopRes)
                        launchSettings += " -dx";

                    else
                    {
                        string width = "800";
                        string height = "600";
                        if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.DisplayHeight))
                            height = this.LauncherSettings.UserSettings.Config.DisplayHeight;
                        if (!string.IsNullOrEmpty(this.LauncherSettings.UserSettings.Config.DisplayWidth))
                            width = this.LauncherSettings.UserSettings.Config.DisplayWidth;

                        launchSettings += " -d" + width + "-x" + height;
                    }

                    if (this.LauncherSettings.UserSettings.Config.ChatLogging)
                        launchSettings += " -logchat";

                    if (this.LauncherSettings.UserSettings.Config.ChatAppend)
                        launchSettings += " -logappend";

                    if (this.LauncherSettings.UserSettings.Config.ChatTime)
                        launchSettings += " -logtime";

                    if (this.LauncherSettings.UserSettings.Config.ChatLocalTime)
                        launchSettings += " -localtime";

                    if (!this.LauncherSettings.UserSettings.Config.ShowFlightText)
                        launchSettings += " -noflighttext";

                    if (this.LauncherSettings.UserSettings.Config.ShowDepartingPlayers)
                        launchSettings += " -dptplayer";

                    if (this.LauncherSettings.UserSettings.Config.ShowJoiningPlayers)
                        launchSettings += " -newplayer";

                    if (this.LauncherSettings.UserSettings.Config.ShowLagIndicator)
                        launchSettings += " -lag";

                    if (this.LauncherSettings.UserSettings.Config.DrawDistance)
                        launchSettings += " -hdfx";

                    if (this.LauncherSettings.UserSettings.Config.DisableChat)
                        launchSettings += " -nochat";

                    if (!string.IsNullOrEmpty(LauncherSettings.UserSettings.Config.ExtraArgs))
                    {
                        try
                        {
                            WebClient client = new WebClient();
                            string whitelist = Path.GetTempFileName();
                            client.DownloadFile(
                                this.LauncherSettings.UserSettings.Config.RemotePatchLocation + @"\launcher\whitelisted-servers.txt",
                                whitelist);
                            StreamReader sr = new StreamReader(whitelist);
                            string[] allowedServers = sr.ReadToEnd().Split('\n');
                            List<string> extraArgs = this.LauncherSettings.UserSettings.Config.ExtraArgs.Split(' ').ToList();
                            for (var index = 0; index < extraArgs.Count; index++)
                            {
                                string arg = extraArgs[index];
                                if (!arg.StartsWith("-s")) continue;
                                if (!allowedServers.Any(s => s.Contains(arg)))
                                    extraArgs.RemoveAt(index);
                            }

                            this.LauncherSettings.UserSettings.Config.ExtraArgs = string.Join(" ", extraArgs);
                        }

                        catch { }
                    }

                    try
                    {
                        Process.Start(new ProcessStartInfo()
                        {
                            FileName = this.LauncherSettings.UserSettings.Config.InstallPath + "//EXE//Freelancer.exe",
                            WorkingDirectory = this.LauncherSettings.UserSettings.Config.InstallPath + "//EXE//",
                            Arguments = launchSettings + " " + this.LauncherSettings.UserSettings.Config.ExtraArgs + " " +
                                        this.forcedArguments.Text
                        });
                    }
                    catch (Exception ex)
                    {
                        ExceptionHandler.Throw(ExceptionCode.L02, ex.Message, this);
                    }
                }
            }
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
            this.patchGame.Enabled = false;
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
        #endregion
    }
}
