using DSSelfPatch.Properties;
using MetroFramework;
using MetroFramework.Controls;
using System;
using System.Collections;
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
using System.Windows.Forms;
using System.Xml;

namespace DSSelfPatch
{
	public class Patch : MetroFramework.Forms.MetroForm
	{
		private UserSettings settings = UserSettings.Instance;

		private byte[] downloadedData;

		private IContainer components;
        private Label label1;

		private BackgroundWorker settingsBackgroundWorker;
        private MetroProgressSpinner metroProgressSpinner1;
        private MetroProgressBar ProgressBar;
        private BackgroundWorker startDownloadBackgroundWorker;

		public Patch()
		{
			this.InitializeComponent();
		}

		private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
		{
			this.ReadConfigFile();
			this.CheckConnectivity();
			this.ReadPatchListFile();
		}

		private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (this.settings.RemoteLauncherVersion.CompareTo(this.settings.LocalLauncherVersion) < 0)
			{
				this.startDownloadBackgroundWorker.RunWorkerAsync();
				return;
			}
			this.Invoke((MethodInvoker) delegate() 
            {
                MetroMessageBox.Show(this, 
                    "Remote Version is less than or equal to local version.\nRemote: " + this.settings.RemoteLauncherVersion + "\nLocal:"
                    + this.settings.LocalLauncherVersion + "\nThe program will now exit.", "Unnecessary", MessageBoxButtons.OK, MessageBoxIcon.Information); });
			Environment.Exit(0);
		}

        private void CheckConnectivity()
		{
            if (this.settings.RemotePatchLocation.Contains("discoverygc.com"))
            {
                this.settings.RemotePatchLocation = "http://patch.discoverygc.net/";
            }

            try
			{
				WebClient webClient = new WebClient()
				{
					CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
				};
				webClient.DownloadFile(this.settings.RemotePatchLocation, this.settings.PatchListTempFile);
				webClient.Dispose();
			}

			catch (Exception exception)
			{
				this.settings.UseKitty = 1;
				this.settings.RemotePatchLocation = Defaults.Settings.KittyURL;
				this.label1.Invoke(new MethodInvoker(() => {
					this.label1.Text = "No response. Attempting to contact Kitty...";
					this.label1.Refresh();
					Application.DoEvents();
				}));
				this.ContactKitty();
			}
		}

		private bool CompareMD5(string file, string patchhash)
		{
			bool flag;
			if (!File.Exists(file))
			{
				return false;
			}
			using (FileStream fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				using (MD5 mD5CryptoServiceProvider = new MD5CryptoServiceProvider())
				{
					byte[] numArray = mD5CryptoServiceProvider.ComputeHash(fileStream);
					fileStream.Close();
					StringBuilder stringBuilder = new StringBuilder();
					byte[] numArray1 = numArray;
					for (int i = 0; i < (int)numArray1.Length; i++)
					{
						byte num = numArray1[i];
						stringBuilder.Append($"{num:X2}");
					}
					flag = (patchhash == stringBuilder.ToString());
				}
			}
			return flag;
		}

		private void ContactKitty()
		{
			try
			{
				WebClient webClient = new WebClient()
				{
					CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore)
				};
				webClient.DownloadFile(this.settings.RemotePatchLocation, this.settings.PatchListTempFile);
				webClient.Dispose();
				this.label1.Invoke(new MethodInvoker(() => {
					this.label1.Text = "OK, Kitty is reachable.";
					this.label1.Refresh();
					Application.DoEvents();
				}));
			}
			catch (Exception exception)
			{
                this.Invoke((MethodInvoker) delegate()
                {
                    MetroMessageBox.Show(this, "Could not contact Patch Sever. Please report this error on the forums to receive assistance.\n\nReason: " + exception.Message, "404", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				    Environment.Exit(0);
                });
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			try
			{
				Process[] processesByName = Process.GetProcessesByName("DSLauncher");
				for (int i = 0; i < (int)processesByName.Length; i++)
				{
					processesByName[i].Kill();
				}
			}
			catch (Exception exception)
			{
				MessageBox.Show("Found a duplicate DSLauncher.exe process running, but couldn't kill it. Exiting.");
				Environment.Exit(0);
			}
			this.settingsBackgroundWorker.RunWorkerAsync();
		}

		private void InitializeComponent()
		{
            this.Icon = Resources.Starflier;
            this.label1 = new System.Windows.Forms.Label();
            this.settingsBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.startDownloadBackgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.ProgressBar = new MetroFramework.Controls.MetroProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(47, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Updating launcher, please wait.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // settingsBackgroundWorker
            // 
            this.settingsBackgroundWorker.WorkerReportsProgress = true;
            this.settingsBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.settingsBackgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.settingsBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // startDownloadBackgroundWorker
            // 
            this.startDownloadBackgroundWorker.WorkerReportsProgress = true;
            this.startDownloadBackgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.startDownloadBackgroundWorker_DoWork);
            this.startDownloadBackgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.startDownloadBackgroundWorker_RunWorkerCompleted);
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.metroProgressSpinner1.Location = new System.Drawing.Point(23, 11);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(35, 33);
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroProgressSpinner1.TabIndex = 2;
            this.metroProgressSpinner1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroProgressSpinner1.UseSelectable = true;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ProgressBar.Location = new System.Drawing.Point(27, 48);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(295, 23);
            this.ProgressBar.Style = MetroFramework.MetroColorStyle.Blue;
            this.ProgressBar.TabIndex = 3;
            this.ProgressBar.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // Patch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 79);
            this.ControlBox = false;
            this.Controls.Add(this.ProgressBar);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.label1);
            this.Name = "Patch";
            this.Resizable = false;
            this.Theme = MetroThemeStyle.Dark;
            this.TopMost = true;
            this.TransparencyKey = Color.PaleTurquoise;
            this.Shown += new EventHandler(this.Form1_Shown);
            this.ResumeLayout(false);

		}

		private void ReadConfigFile()
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				StreamReader streamReader = new StreamReader(this.settings.CONFIG_FILE);
				xmlDocument.Load(streamReader);
				XmlNode xmlNodes = xmlDocument.SelectSingleNode("/BadassRoot/Config");
				XmlElement xmlElement = xmlNodes.SelectSingleNode("LauncherVersion") as XmlElement;
				XmlElement xmlElement1 = xmlElement;
				if (xmlElement != null)
				{
				    if (Version.TryParse(xmlElement.InnerText, out Version version))
				    {
				        this.settings.LocalLauncherVersion = version;
				    }

				    else
				    {
                        int[] i = xmlElement.InnerText.ToCharArray().Select(Convert.ToInt32).ToArray();
				        this.settings.LocalLauncherVersion = new Version(i[0], i[1], i[2]);
				    }
				}
				XmlElement xmlElement2 = xmlNodes.SelectSingleNode("InstallPath") as XmlElement;
				xmlElement1 = xmlElement2;
				if (xmlElement2 != null)
				{
					if (!string.IsNullOrEmpty(xmlElement1.InnerText))
					{
						this.settings.InstallPath = xmlElement1.InnerText;
                        if (!Directory.Exists(this.settings.InstallPath))
                        {
                            this.settings.InstallPath = Path.GetDirectoryName(Application.ExecutablePath);
                            MetroMessageBox.Show(this, "Directory Error", 
                                "Warning: Unable to find install directory specified in launcherconfig.xml - Using the following directory instead: ", 
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
					else
					{
						this.settings.InstallPath = Path.GetDirectoryName(Application.ExecutablePath);
					}
				}
				XmlElement xmlElement3 = xmlNodes.SelectSingleNode("LauncherPatchLocation") as XmlElement;
				xmlElement1 = xmlElement3;
				if (xmlElement3 != null)
				{
					this.settings.RemotePatchLocation = xmlElement1.InnerText;
				}
				streamReader.Close();
				streamReader.Dispose();
			}
			catch (Exception exception)
			{
                this.Invoke((MethodInvoker)delegate ()
                {
                   MetroMessageBox.Show(this, "We couldn't read the config file.\n\nReason: " + exception.Message, "Config Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                   Environment.Exit(0);
                });
			}
		}

		private void ReadPatchListFile()
		{
			try
			{
				XmlDocument xmlDocument = new XmlDocument();
				StreamReader streamReader = new StreamReader(this.settings.PatchListTempFile);
				xmlDocument.Load(streamReader);
				XmlNode xmlNodes = xmlDocument.SelectSingleNode("/PatcherData/Settings");
				XmlNode xmlNodes1 = xmlDocument.SelectSingleNode("/PatcherData/PatchList");
				int num = 0;
				foreach (XmlNode xmlNodes2 in xmlNodes1)
				{
					num++;
					string innerText = xmlNodes2.InnerText;
					string value = xmlNodes2.Attributes.GetNamedItem("url").Value;
					string str = xmlNodes2.Attributes.GetNamedItem("md5hash").Value;
					Dictionary<int, UserSettings.PatchListDataStruct> patchListData = this.settings.PatchListData;
					UserSettings.PatchListDataStruct patchListDataStruct = new UserSettings.PatchListDataStruct()
					{
						PatchName = innerText,
						PatchURL = value,
						PatchMD5Hash = str
					};
					patchListData.Add(num, patchListDataStruct);
				}
				XmlElement xmlElement = xmlNodes.SelectSingleNode("launcherversion") as XmlElement;
				XmlElement xmlElement1 = xmlElement;
				if (xmlElement != null)
				{
					this.settings.RemoteLauncherVersion = Version.Parse(xmlElement1.InnerText);
				}
				streamReader.Close();
				streamReader.Dispose();
			}
			catch (Exception exception)
			{
                this.Invoke((MethodInvoker) delegate()
                {
                    MetroMessageBox.Show(this, "Couldn't read the patch data. The file may be malformed.\n\nReason: " + exception.Message, "Patch List Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				    Environment.Exit(0);
                });
				
			}
		}

		private void startDownloadBackgroundWorker_DoWork(object sender, DoWorkEventArgs e)
		{
		    foreach (KeyValuePair<int, UserSettings.PatchListDataStruct> patchListDatum in this.settings.PatchListData)
			{
				string str = string.Concat(this.settings.InstallPath, "\\", patchListDatum.Value.PatchURL);
				if (!this.CompareMD5(str, patchListDatum.Value.PatchMD5Hash))
				{
					try
					{
						this.downloadedData = new byte[0];
						WebRequest webRequest = WebRequest.Create(patchListDatum.Value.PatchURL);
						WebResponse response = webRequest.GetResponse();
						Stream responseStream = response.GetResponseStream();
						byte[] numArray = new byte[1024];
						int contentLength = (int)response.ContentLength;
						this.ProgressBar.Invoke(new MethodInvoker(() => {
							this.ProgressBar.Value = 0;
							this.ProgressBar.Maximum = contentLength;
							Application.DoEvents();
						}));
						FileStream fileStream = new FileStream(str, FileMode.Create);
						while (true)
						{
							int num = responseStream.Read(numArray, 0, (int)numArray.Length);
							if (num == 0)
							{
								break;
							}
							fileStream.Write(numArray, 0, num);
							this.ProgressBar.Invoke(new MethodInvoker(() => {
								this.ProgressBar.Value = this.ProgressBar.Value + num;
								this.ProgressBar.Refresh();
								Application.DoEvents();
							}));
						}
						responseStream.Close();
						fileStream.Close();
						if (!this.CompareMD5(str, patchListDatum.Value.PatchMD5Hash))
						{
                            this.Invoke((MethodInvoker) delegate()
                            {
                                MetroMessageBox.Show(this, "Can't download the file. Restart the launcher to begin again.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                Environment.Exit(0);
                            });
						}
					}
					catch (Exception exception)
					{
                        this.Invoke((MethodInvoker) delegate ()
                        {
                            MetroMessageBox.Show(this, "Can't download the file. Restart the launcher or ask for help on the forums.\n\nReason: " + exception.Message, "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            Environment.Exit(0);
                        });
					}
				}
			}
		}

		private void startDownloadBackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load("launcherconfig.xml");
			xmlDocument.SelectSingleNode("/BadassRoot/Config/LauncherVersion").InnerText = this.settings.RemoteLauncherVersion.ToString();
			xmlDocument.Save("launcherconfig.xml");
			Process.Start(string.Concat(this.settings.InstallPath, "\\DSLauncher.exe"));
			Environment.Exit(0);
		}

		private void UpdateProgressbar(int percent, long bytesReceived, long totalBytesToReceive)
		{
			this.ProgressBar.Value = percent;
		}
	}
}