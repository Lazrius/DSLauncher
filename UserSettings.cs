using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using DSLauncherV2.Properties;

namespace DSLauncherV2
{
    [XmlRoot("BadassRoot")]
    public sealed class UserSettings
    {
        [XmlElement("Config")]
        public Config Config { get; set; }

        [XmlArray]
        [XmlArrayItem("Patch")]
        public List<string> PatchHistory { get; set; }

        [XmlIgnore]
        public string Name = "";
        [XmlIgnore]
        public string Description = "";
        [XmlIgnore]
        public string Code = "";
        [XmlIgnore]
        public string Signature = "";
        [XmlIgnore]
        public bool Favorite = false;
        [XmlIgnore]
        public string ActiveCode = "";
        [XmlIgnore]
        public string ActiveSignature = "";
        [XmlIgnore]
        public string AccountsFile = "/launcheraccounts.xml";
        [XmlIgnore]
        public string AccountCategory = "";

        [XmlIgnore]
        public Dictionary<int, PatchListDataStruct> PatchListData = new Dictionary<int, PatchListDataStruct>();
        [XmlIgnore]
        public Dictionary<int, AccountsListDataStruct> AccountListData = new Dictionary<int, AccountsListDataStruct>();

        // Remote Patch Files
        [XmlIgnore]
        public string MainServer = "";
        [XmlIgnore]
        public int RemoteLauncherVersion = 0;
        [XmlIgnore]
        public string RemoteGameVersion = "";
        [XmlIgnore]
        public string RemoteExtraArgs = "";
        [XmlIgnore]
        public string PatchListTempFile = Path.GetTempFileName();
    }

    public sealed class Config
    {      
        [XmlElement("ModName")]
        public string ModName { get; set; }

        [XmlElement("InstallPath")]
        public string InstallPath { get; set; }

        [XmlElement("RemotePatchLocation")]
        public string RemotePatchLocation = Defaults.Settings.KittyURL;

        [XmlElement("DisplayMode")]
        public bool DisplayMode { get; set; }

        [XmlElement("DisplayDesktopRes")]
        public bool DisplayDesktopRes { get; set; }

        [XmlElement("DisplayWidth"), DefaultValue("800")]
        public string DisplayWidth { get; set; }

        [XmlElement("DisplayHeight"), DefaultValue("600")]
        public string DisplayHeight { get; set; }

        [XmlElement("ShowJoiningPlayers")]
        public bool ShowJoiningPlayers { get; set; }

        [XmlElement("ShowDepartingPlayers")]
        public bool ShowDepartingPlayers { get; set; }

        [XmlElement("ShowLagIndicator")]
        public bool ShowLagIndicator { get; set; }

        [XmlElement("ShowFlightText")]
        public bool ShowFlightText { get; set; }

        [XmlElement("ChatLogging")]
        public bool ChatLogging { get; set; }

        [XmlElement("ChatAppend")]
        public bool ChatAppend { get; set; }

        [XmlElement("ChatTime")]
        public bool ChatTime { get; set; }

        [XmlElement("ChatLocalTime")]
        public bool ChatLocalTime { get; set; }

        [XmlElement("ExtraArgs")]
        public string ExtraArgs { get; set; }

        [XmlElement("LauncherVersion")]
        public int LocalLauncherVersion { get; set; }

        [XmlElement("Style")]
        public int Style { get; set; }

        [XmlElement("RecentAccounts")]
        public RecentAccounts RecentAccounts { get; set; }

        [XmlElement("DrawDistance")]
        public bool DrawDistance { get; set; }

        [XmlElement("DisableChat")]
        public bool DisableChat { get; set; }
    }

    public sealed class RecentAccounts
    {
        [XmlElement("One")]
        public string One;
        [XmlElement("Two")]
        public string Two;
        [XmlElement("Three")]
        public string Three;
        [XmlElement("Four")]
        public string Four;
    }

    public struct PatchListDataStruct
    {
        public string PatchName;
        public string PatchURL;
        public string PatchMD5Hash;
    }

    public struct AccountsListDataStruct
    {
        public string AccountName;
        public string AccountDescription;
        public string AccountSignature;
        public string AccountCode;
        public string IsFavorite;
        public string AccountCategory;
    }
}