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

#pragma warning disable 1587
/// <summary>
///  This class is deisnged to hold all the data concerning the LauncherConfig File
/// </summary>

namespace DSLauncherV2
{
    class LauncherSettings
    {
        public static LauncherSettings Instance { get; } = new LauncherSettings();
        public UserSettings UserSettings = UserSettings.Instance;

        // Set Launcher Config

        public void SetConfigValue(string node, bool state)
        {
            XmlDocument XML = new XmlDocument();
            XML.Load("launcherconfig.xml");
            XML.SelectSingleNode("/BadassRoot/Config/" + node).InnerText = state.ToString();
            XML.Save("launcherconfig.xml");
        }

        public void SetDisableChat()
        {
            XmlDocument XML = new XmlDocument();
            XML.PreserveWhitespace = true;
            XML.Load("launcherconfig.xml");

            try
            {
                XML.SelectSingleNode("/BadassRoot/Config/DisableChat").InnerText = this.UserSettings.DisableChat.ToString();
                XmlNode node = XML.SelectSingleNode("/BadassRoot/Config/DisableChat");
                if (node == null)
                    throw new Exception("XML Node - 'DisableChat' does not exist.");
            }

            catch (Exception ex)
            {
                XmlNode config = XML.SelectSingleNode("/BadassRoot/Config");
                config = XML.SelectSingleNode("/BadassRoot/Config");
                XmlElement enabled = XML.CreateElement("DisableChat");
                enabled.InnerText = this.UserSettings.DisableChat.ToString();
                config.AppendChild(enabled);
            }

            XML.Save("launcherconfig.xml");
        }

        public void SetRecentAccount(int slot)
        {
            XmlDocument XML = new XmlDocument();
            //XML.PreserveWhitespace = true;
            XML.Load("launcherconfig.xml");

            try
            {
                switch (slot)
                {
                    case 1:
                        XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/One").InnerText = this.UserSettings.RecentAccount1;
                        XmlNode node = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/One");
                        if (node == null)
                            throw new Exception("XML Node - 'RecentAccounts/One' does not exist.");
                        break;

                    case 2:
                        XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Two").InnerText = this.UserSettings.RecentAccount2;
                        XmlNode node2 = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Two");
                        if (node2 == null)
                            throw new Exception("XML Node - 'RecentAccounts/Two' does not exist.");
                        break;

                    case 3:
                        XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Three").InnerText = this.UserSettings.RecentAccount3;
                        XmlNode node3 = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Three");
                        if (node3 == null)
                            throw new Exception("XML Node - 'RecentAccounts/Three' does not exist.");
                        break;

                    case 4:
                        XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Four").InnerText = this.UserSettings.RecentAccount4;
                        XmlNode node4 = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts/Four");
                        if (node4 == null)
                            throw new Exception("XML Node - 'RecentAccounts/Four' does not exist.");
                        break;
                }
            }

            catch (Exception ex)
            {
                XmlNode config = XML.SelectSingleNode("/BadassRoot/Config");
                XmlElement ra;
                if ((ra = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts") as XmlElement) == null)
                {
                    ra = XML.CreateElement("RecentAccounts");
                    ra.InnerText = "\n";
                    config.AppendChild(ra);
                }

                switch (slot)
                {
                    case 1:
                        config = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts");
                        XmlElement one = XML.CreateElement("One");
                        one.InnerText = this.UserSettings.RecentAccount1;
                        config.AppendChild(one);
                        break;
                    case 2:
                        config = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts");
                        XmlElement two = XML.CreateElement("Two");
                        two.InnerText = this.UserSettings.RecentAccount2;
                        config.AppendChild(two);
                        break;
                    case 3:
                        config = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts");
                        XmlElement three = XML.CreateElement("Three");
                        three.InnerText = this.UserSettings.RecentAccount3;
                        config.AppendChild(three);
                        break;
                    case 4:
                        config = XML.SelectSingleNode("/BadassRoot/Config/RecentAccounts");
                        XmlElement four = XML.CreateElement("Four");
                        four.InnerText = this.UserSettings.RecentAccount4;
                        config.AppendChild(four);
                        break;
                }
            }

            XML.Save("launcherconfig.xml");
        }

        public void SetDrawDistance()
        {
            XmlDocument XML = new XmlDocument();
            XML.PreserveWhitespace = true;
            XML.Load("launcherconfig.xml");
            try
            {
                XML.SelectSingleNode("/BadassRoot/Config/DrawDistance").InnerText = this.UserSettings.DrawDistance.ToString();
                XmlNode node = XML.SelectSingleNode("/BadassRoot/Config/DrawDistance");
                if (node == null)
                    throw new Exception("XML Node - 'DrawDistance' does not exist.");
            }

            catch (Exception ex)
            {
                XmlElement drpc = XML.CreateElement("DrawDistance");
                drpc.InnerText = this.UserSettings.DiscordRPC.ToString();
                XmlNode config = XML.SelectSingleNode("/BadassRoot/Config");
                config.AppendChild(drpc);
            }

            XML.Save("launcherconfig.xml");
        }

        public void SetDiscordRPC()
        {
            XmlDocument XML = new XmlDocument();
            XML.PreserveWhitespace = true;
            XML.Load("launcherconfig.xml");
            try
            {
                XML.SelectSingleNode("/BadassRoot/Config/DiscordRPC").InnerText = this.UserSettings.DiscordRPC.ToString();
                XmlNode node = XML.SelectSingleNode("/BadassRoot/Config/DiscordRPC");
                if(node == null)
                    throw new Exception("XML Node - 'DiscordRPC' does not exist.");
            }

            catch (Exception ex)
            {
                XmlElement drpc = XML.CreateElement("DiscordRPC");
                drpc.InnerText = this.UserSettings.DiscordRPC.ToString();
                XmlNode config = XML.SelectSingleNode("/BadassRoot/Config");
                config.AppendChild(drpc);
            }

            XML.Save("launcherconfig.xml");
        }

        public void SetLauncherStyle(int iStyle)
        {
            XmlDocument XML = new XmlDocument();
            XML.Load("launcherconfig.xml");
            XML.SelectSingleNode("/BadassRoot/Config/Style").InnerText = iStyle.ToString();
            XML.Save("launcherconfig.xml");
        }

        public void SetRemotePatchLocation(string sNewPatchLocation)
        {
            XmlDocument XML = new XmlDocument();
            XML.Load("launcherconfig.xml");
            XML.SelectSingleNode("/BadassRoot/Config/RemotePatchLocation").InnerText = sNewPatchLocation;
            XML.Save("launcherconfig.xml");
        }

        // Get Launcher Config

        public void ReadConfigFile(Primary primary)
        {
            try
            {
                this.UserSettings.InstallPath = Path.GetDirectoryName(Application.ExecutablePath);
                if (!System.IO.File.Exists(this.UserSettings.ConfigFile))
                    ExceptionHandler.Throw("C01", "", primary);

                XmlDocument xmlDocument = new XmlDocument();
                StreamReader streamReader = new StreamReader(this.UserSettings.ConfigFile);
                xmlDocument.Load((TextReader)streamReader);

                XmlNode xmlNode1 = xmlDocument.SelectSingleNode("/BadassRoot/Config");
                foreach (XmlNode xmlNode2 in xmlDocument.SelectSingleNode("/BadassRoot/PatchHistory"))
                    this.UserSettings.installedpatchlist.Add(xmlNode2.InnerText);

                XmlElement xmlElement1;
                if ((xmlElement1 = xmlNode1.SelectSingleNode("LauncherVersion") as XmlElement) != null)
                    this.UserSettings.LocalLauncherVersion = Convert.ToInt32(xmlElement1.InnerText);

                XmlElement xmlElement2;
                if ((xmlElement2 = xmlNode1.SelectSingleNode("ExtraArgs") as XmlElement) != null)
                    this.UserSettings.ExtraArgs = xmlElement2.InnerText;

                XmlElement xmlElement3;
                if ((xmlElement3 = xmlNode1.SelectSingleNode("Style") as XmlElement) != null)
                    this.UserSettings.Style = Convert.ToInt32(xmlElement3.InnerText);

                XmlElement xmlElement4;
                if ((xmlElement4 = xmlNode1.SelectSingleNode("ShowJoiningPlayers") as XmlElement) != null)
                {
                    switch (xmlElement4.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ShowJoiningPlayers = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ShowJoiningPlayers = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ShowJoiningPlayers>");
                            break;
                    }
                }

                XmlElement xmlElement5;
                if ((xmlElement5 = xmlNode1.SelectSingleNode("HideServers") as XmlElement) != null)
                {
                    xmlNode1.RemoveChild(xmlElement5); // We don't support unofficial servers anymore
                }

                XmlElement xmlElement6;
                if ((xmlElement6 = xmlNode1.SelectSingleNode("ShowDepartingPlayers") as XmlElement) != null)
                {
                    switch (xmlElement6.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ShowDepartingPlayers = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ShowDepartingPlayers = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ShowDepartingPlayers>");
                            break;
                    }
                }

                XmlElement xmlElement7;
                if ((xmlElement7 = xmlNode1.SelectSingleNode("ShowLagIndicator") as XmlElement) != null)
                {
                    switch (xmlElement7.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ShowLagIndicator = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ShowLagIndicator = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ShowLagIndicator>");
                            break;
                    }
                }

                XmlElement xmlElement8;
                if ((xmlElement8 = xmlNode1.SelectSingleNode("ShowFlightText") as XmlElement) != null)
                {
                    switch (xmlElement8.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ShowFlightText = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ShowFlightText = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ShowFlightText>");
                            break;
                    }
                }

                XmlElement xmlElement9;
                if ((xmlElement9 = xmlNode1.SelectSingleNode("ChatLogging") as XmlElement) != null)
                {
                    switch (xmlElement9.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ChatLogging = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ChatLogging = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ChatLogging>");
                            break;
                    }
                }

                XmlElement xmlElement10;
                if ((xmlElement10 = xmlNode1.SelectSingleNode("ChatAppend") as XmlElement) != null)
                {
                    switch (xmlElement10.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ChatAppend = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ChatAppend = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ChatAppend>");
                            break;
                    }
                }

                XmlElement xmlElement11;
                if ((xmlElement11 = xmlNode1.SelectSingleNode("ChatTime") as XmlElement) != null)
                {
                    switch (xmlElement11.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            UserSettings.ChatTime = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ChatTime = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ChatTime>");
                            break;
                    }
                }

                XmlElement xmlElement12;
                if ((xmlElement12 = xmlNode1.SelectSingleNode("ChatLocalTime") as XmlElement) != null)
                {
                    switch (xmlElement12.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.ChatLocalTime = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.ChatLocalTime = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <ChatLocalTime>");
                            break;
                    }
                }

                XmlElement xmlElement13;
                if ((xmlElement13 = xmlNode1.SelectSingleNode("DisplayDesktopRes") as XmlElement) != null)
                {
                    switch (xmlElement13.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.DisplayDesktopRes = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.DisplayDesktopRes = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <DisplayDesktopRes>");
                            break;
                    }
                }

                XmlElement xmlElement14;
                if ((xmlElement14 = xmlNode1.SelectSingleNode("DisplayMode") as XmlElement) != null)
                {
                    switch (xmlElement14.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.DisplayMode = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.DisplayMode = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <DisplayMode>");
                            break;
                    }
                }

                XmlElement xmlElement15;
                if ((xmlElement15 = xmlNode1.SelectSingleNode("DisplayWidth") as XmlElement) != null)
                    this.UserSettings.DisplayWidth = xmlElement15.InnerText;

                XmlElement xmlElement16;
                if ((xmlElement16 = xmlNode1.SelectSingleNode("DisplayHeight") as XmlElement) != null)
                    this.UserSettings.DisplayHeight = xmlElement16.InnerText;

                XmlElement xmlElement17;
                if ((xmlElement17 = xmlNode1.SelectSingleNode("ModName") as XmlElement) != null)
                {
                    this.UserSettings.ModName = xmlElement17.InnerText;
                    this.UserSettings.AccountsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/My Games/" +
                         this.UserSettings.ModName + "/launcheraccounts.xml");
                }

                XmlElement xmlElement18;
                if ((xmlElement18 = xmlNode1.SelectSingleNode("RemotePatchLocation") as XmlElement) != null)
                    this.UserSettings.RemotePatchLocation = xmlElement18.InnerText;

                XmlElement xmlElement19;
                if ((xmlElement19 = xmlNode1.SelectSingleNode("LocalGameVersion") as XmlElement) != null)
                    this.UserSettings.LocalGameVersion = xmlElement19.InnerText;

                XmlElement xmlElement20;
                if ((xmlElement20 = xmlNode1.SelectSingleNode("IDPrompt") as XmlElement) != null)
                {
                    switch (xmlElement20.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.IDPrompt = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.IDPrompt = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <IDPrompt>");
                            break;
                    }
                }

                XmlElement xmlElement21;
                if ((xmlElement21 = xmlNode1.SelectSingleNode("UserLogin") as XmlElement) != null)
                    this.UserSettings.UserLogin = xmlElement21.InnerText;

                XmlElement xmlElement22;
                if ((xmlElement22 = xmlNode1.SelectSingleNode("UserPassword") as XmlElement) != null)
                    this.UserSettings.UserPassword = xmlElement22.InnerText;

                XmlElement xmlElement23;
                if ((xmlElement23 = xmlNode1.SelectSingleNode("AutoLogin") as XmlElement) != null)
                {
                    switch (xmlElement23.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.AutoLogin = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.AutoLogin = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <AutoLogin>");
                            break;
                    }
                }

                XmlElement xmlElement24;
                if ((xmlElement24 = xmlNode1.SelectSingleNode("AutoCloudAccounts") as XmlElement) != null)
                {
                    switch (xmlElement24.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.AutoCloudAccounts = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.AutoCloudAccounts = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <AutoCloudAccounts>");
                            break;
                    }
                }

                XmlElement xmlElement25; // DiscordRPC
                if ((xmlElement25 = xmlNode1.SelectSingleNode("DiscordRPC") as XmlElement) != null)
                {
                    switch (xmlElement25.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.DiscordRPC = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.DiscordRPC = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <DiscordRPC>");
                            break;
                    }
                }

                XmlElement xmlElement26; // Increase Draw Distance
                if ((xmlElement26 = xmlNode1.SelectSingleNode("DrawDistance") as XmlElement) != null)
                {
                    switch (xmlElement26.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.DrawDistance = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.DrawDistance = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <DrawDistance>");
                            break;
                    }
                }

                XmlElement xmlElement29; // Disable Chat
                if ((xmlElement29 = xmlNode1.SelectSingleNode("DisableChat") as XmlElement) != null)
                {
                    switch (xmlElement29.InnerText.Trim().ToLower())
                    {
                        case "1":
                        case "true":
                            this.UserSettings.DisableChat = true;
                            break;
                        case "0":
                        case "false":
                            this.UserSettings.DisableChat = false;
                            break;
                        default:
                            MessageBox.Show("Config Error <DisableChat>");
                            break;
                    }
                }

                XmlElement xmlElement30;
                if ((xmlElement30 = xmlNode1.SelectSingleNode("RecentAccounts/One") as XmlElement) != null)
                {
                    this.UserSettings.RecentAccount1 = xmlElement30.InnerText;
                }

                XmlElement xmlElement31;
                if ((xmlElement31 = xmlNode1.SelectSingleNode("RecentAccounts/Two") as XmlElement) != null)
                {
                    this.UserSettings.RecentAccount2 = xmlElement31.InnerText;
                }

                XmlElement xmlElement32;
                if ((xmlElement32 = xmlNode1.SelectSingleNode("RecentAccounts/Three") as XmlElement) != null)
                {
                    this.UserSettings.RecentAccount3 = xmlElement32.InnerText;
                }

                XmlElement xmlElement33;
                if ((xmlElement33 = xmlNode1.SelectSingleNode("RecentAccounts/Four") as XmlElement) != null)
                {
                    this.UserSettings.RecentAccount4 = xmlElement33.InnerText;
                }
                
                streamReader.Close();
                xmlDocument.Save("launcherconfig.xml");
                streamReader.Dispose();
            }
            catch (Exception ex)
            {
                ExceptionHandler.Throw("C02", ex.Message, primary);
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
            if (!System.IO.File.Exists(this.UserSettings.AccountsFile))
            {
                try
                {
                    Directory.CreateDirectory(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "/My Games/" + this.UserSettings.ModName));
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlComment comment = xmlDocument.CreateComment("Launcher Accounts File, do not edit unless you know what you're doing.");
                    xmlDocument.AppendChild((XmlNode)comment);
                    XmlNode element = (XmlNode)xmlDocument.CreateElement("AccountsList");
                    xmlDocument.AppendChild(element);
                    xmlDocument.Save(this.UserSettings.AccountsFile);
                }
                catch (Exception ex)
                {
                    ExceptionHandler.Throw("C03", ex.Message, primary);
                }
            }
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                StreamReader streamReader = new StreamReader(this.UserSettings.AccountsFile);
                xmlDocument.Load((TextReader)streamReader);
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

                    this.UserSettings.AccountListData.Add(key, new UserSettings.AccountsListDataStruct()
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
                ExceptionHandler.Throw("C04", ex.Message, primary);
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
                    this.UserSettings.PatchListData.Add(key, new UserSettings.PatchListDataStruct()
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
                ExceptionHandler.Throw("F02", ex.Message, primary);
            }
        }

        public void CheckForPatches(Primary primary)
        {
            bool needPatching = false;
            foreach (KeyValuePair<int, UserSettings.PatchListDataStruct> keyValuePair in this.UserSettings.PatchListData)
            {
                string str = this.UserSettings.InstallPath + "\\" + keyValuePair.Value.PatchURL;
                if (!this.UserSettings.installedpatchlist.Contains(keyValuePair.Value.PatchMD5Hash))
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
