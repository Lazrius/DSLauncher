using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C02, ex.Message, primary);
            }
        }

        private static string GetXMLText(XmlNode XML, string attrName)
        {
            var xmlAttribute = XML.Attributes[attrName];

            if (xmlAttribute == null)
                return string.Empty;

            var value = xmlAttribute.Value;
            if (value == null)
                return string.Empty;

            return value;
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
                XmlDocument xmlDocument = new XmlDocument();
                StreamReader streamReader = new StreamReader(this.UserSettings.AccountsFile);
                xmlDocument.Load(streamReader);
                XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/AccountsList");
                int key = 0;
                foreach (XmlNode xmlNode2 in xmlNode1)
                {
                    ++key;
                    string innerText = xmlNode2.InnerText;
                    string str1 = GetXMLText(xmlNode2, "description");
                    string str2 = GetXMLText(xmlNode2, "code");
                    string str3 = GetXMLText(xmlNode2, "signature");
                    string str4 = GetXMLText(xmlNode2, "favorite");
                    string str5 = GetXMLText(xmlNode2, "category");
                    if (string.IsNullOrEmpty(str5))
                        str5 = "None";

                    this.UserSettings.AccountListData.Add(key, new AccountsListDataStruct()
                    {
                        AccountName = innerText,
                        AccountDescription = str1,
                        AccountCode = str2,
                        AccountSignature = str3,
                        IsFavorite = str4,
                        AccountCategory = str5
                    });
                }
                streamReader.Close();
                streamReader.Dispose();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw(ExceptionCode.C04, ex.Message, primary);
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
                XmlElement xmlElement1;
                if ((xmlElement1 = xmlNode1.SelectSingleNode("launcherversion") as XmlElement) != null)
                    this.UserSettings.RemoteLauncherVersion = Convert.ToInt32(xmlElement1.InnerText);
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
