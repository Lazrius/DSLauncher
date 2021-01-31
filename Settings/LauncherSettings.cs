using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using DSLauncherV2.Properties;

#pragma warning disable 1587
/// <summary>
///  This class is deisnged to hold all the data concerning the LauncherConfig File
/// </summary>

namespace DSLauncherV2
{
    class LauncherSettings
    {
        public static LauncherSettings Instance { get; } = new LauncherSettings();
        public UserSettings UserSettings;
        // Get Launcher Config

        public void ReadConfigFile(Primary primary)
        {
            try
            {
                if (!File.Exists(Defaults.Settings.ConfigFile))
                    ExceptionHandler.Throw(ExceptionCode.C01, "", primary);

                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));

                string xml = File.ReadAllText(Defaults.Settings.ConfigFile);
                xml = xml.Replace("True", "true");
                xml = xml.Replace("False", "false");
                using (TextReader reader = new StringReader(xml))
                {
                    UserSettings = (UserSettings)serializer.Deserialize(reader);
                    if (string.IsNullOrEmpty(UserSettings.Config.ModName))
                        UserSettings.Config.ModName = "Discovery";

                    this.UserSettings.AccountsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/My Games/" +
                        this.UserSettings.Config.ModName + "/launcheraccounts.xml");
                    this.UserSettings.Config.InstallPath = Path.GetDirectoryName(Application.ExecutablePath);

                    try
                    {
                        if(Regex.IsMatch(this.UserSettings.Config.LocalLauncherVersionS, @"^[+-]?\d*$"))
                        {
                            char[] i = this.UserSettings.Config.LocalLauncherVersionS.ToCharArray();
                            this.UserSettings.Config.LocalLauncherVersionS = i[0]+"."+ i[1]+"."+ i[2];
                        }
                        this.UserSettings.Config.LocalLauncherVersion = new Version(this.UserSettings.Config.LocalLauncherVersionS);
                    }
                    catch
                    {
                        // ignored
                    }
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C02, ex.Message, primary);
            }
        }

        public void LoadAccounts(Primary primary)
        {
            if (!File.Exists(this.UserSettings.AccountsFile))
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/My Games/" + this.UserSettings.Config.ModName));
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlComment comment = xmlDocument.CreateComment("Launcher Accounts File, do not edit unless you know what you're doing.");
                    xmlDocument.AppendChild((XmlNode)comment);
                    XmlNode element = (XmlNode)xmlDocument.CreateElement("AccountsList");
                    xmlDocument.AppendChild(element);
                    xmlDocument.Save(this.UserSettings.AccountsFile);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Throw(ExceptionCode.C03, ex.Message, primary);
                }
            }
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AccountList));

                string xml = File.ReadAllText(this.UserSettings.AccountsFile);
                xml = xml.Replace("True", "true");
                xml = xml.Replace("False", "false");
                xml = xml.Replace("favorite=\"Yes\"", "favorite=\"true\"");
                xml = xml.Replace("favorite=\"No\"", "favorite=\"false\"");
                xml = xml.Replace("favorite=\"yes\"", "favorite=\"true\"");
                xml = xml.Replace("favorite=\"no\"", "favorite=\"false\"");
                using (TextReader reader = new StringReader(xml))
                {
                    this.UserSettings.AccountList = (AccountList) serializer.Deserialize(reader);
                    reader.Dispose();
                }

                for (var index = 0; index < this.UserSettings.AccountList.Accounts.Count; index++)
                {
                    Account account = this.UserSettings.AccountList.Accounts[index];
                    if (string.IsNullOrEmpty(account.Category))
                        account.Category = "None";

                    if (string.IsNullOrEmpty(account.Code) || string.IsNullOrEmpty(account.Name) ||
                        string.IsNullOrEmpty(account.Signature) || string.IsNullOrEmpty(account.Description))
                        this.UserSettings.AccountList.Accounts.RemoveAt(index);
                    else
                        this.UserSettings.AccountList.Accounts[index] = account;
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C04, ex.Message, primary);
            }
        }

        public void SaveAccounts(Primary primary)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AccountList));
                TextWriter writer = new StreamWriter(this.UserSettings.AccountsFile);
                serializer.Serialize(writer, this.UserSettings.AccountList);
                writer.Close();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C07, ex.Message, primary);
            }
        }

        // Patch Functions

        public void ReadPatchListFile(Primary primary)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                StreamReader streamReader = new StreamReader(this.UserSettings.PatchListTempFile);
                xmlDocument.Load((TextReader)streamReader);
                XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/PatcherData/Settings");
                XmlNode xmlNode2 = xmlDocument.SelectSingleNode("/PatcherData/PatchList");
                int key = 0;
                foreach (XmlNode xmlNode3 in xmlNode2)
                {
                    ++key;
                    string innerText = xmlNode3.InnerText;
                    string str1 = xmlNode3.Attributes.GetNamedItem("url").Value;
                    string str2 = xmlNode3.Attributes.GetNamedItem("md5hash").Value;
                    this.UserSettings.PatchListData.Add(key, new PatchListDataStruct()
                    {
                        PatchName = innerText,
                        PatchURL = str1,
                        PatchMD5Hash = str2
                    });
                }
                XmlElement xmlElement2;
                if ((xmlElement2 = xmlNode1.SelectSingleNode("gameversion") as XmlElement) != null)
                    this.UserSettings.RemoteGameVersion = xmlElement2.InnerText;
                XmlElement xmlElement3;
                if ((xmlElement3 = xmlNode1.SelectSingleNode("mainserver") as XmlElement) != null)
                    this.UserSettings.MainServer = xmlElement3.InnerText;
                XmlElement xmlElement4;
                if ((xmlElement4 = xmlNode1.SelectSingleNode("launcherargs") as XmlElement) != null)
                    this.UserSettings.RemoteExtraArgs = xmlElement4.InnerText;
                streamReader.Close();
                streamReader.Dispose();

                // Load the patchlist file if it exists
                if (new FileInfo(this.UserSettings.LauncherPatchFile).Length == 0) return;
                streamReader = new StreamReader(this.UserSettings.LauncherPatchFile);
                xmlDocument = new XmlDocument();
                xmlDocument.Load(streamReader);
                if (!(xmlDocument.SelectSingleNode("/PatcherData/Settings/launcherversion") is XmlElement xml1))
                    return;
                String versionS = xml1.InnerText;
                if (Regex.IsMatch(versionS, @"^[+-]?\d*$"))
                {
                    versionS = versionS[0] + "." + versionS[1] + "." + versionS[2];
                }
                Version.TryParse(versionS, out Version version);
                if (version == null)
                    return;
                this.UserSettings.RemoteLauncherVersion = version;
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.F02, ex.Message, primary);
            }
        }

        public void CheckForPatches(Primary primary)
        {
            bool needPatching = false;
            foreach (KeyValuePair<int, PatchListDataStruct> keyValuePair in this.UserSettings.PatchListData)
            {
                string str = this.UserSettings.Config.InstallPath + "\\" + keyValuePair.Value.PatchURL;
                if (this.UserSettings.PatchHistory.All(p => p != keyValuePair.Value.PatchMD5Hash))
                {
                    primary.LoadingBackgroundWorker.ReportProgress(6);
                    needPatching = true;
                    break;
                }
            }

            if (!needPatching)
            {
                primary.LoadingBackgroundWorker.ReportProgress(5);
            }
        }
    }
}
