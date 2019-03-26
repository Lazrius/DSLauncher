using System;
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

        // Static because need to call them from multiple forms.
        [XmlIgnore]
        public static string Name = "";
        [XmlIgnore]
        public static string Description = "";
        [XmlIgnore]
        public static string Code = "";
        [XmlIgnore]
        public static string Signature = "";
        [XmlIgnore]
        public static bool Favorite = false;
        [XmlIgnore]
        public static string AccountCategory = "";

        [XmlIgnore]
        public string ActiveCode = "";
        [XmlIgnore]
        public string ActiveSignature = "";
        [XmlIgnore]
        public string AccountsFile = "/launcheraccounts.xml";

        [XmlIgnore]
        public Dictionary<int, PatchListDataStruct> PatchListData = new Dictionary<int, PatchListDataStruct>();

        [XmlIgnore]
        public AccountList AccountList { get; set; }

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
        [XmlElement("ModName"), DefaultValue("Discovery")]
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

        [XmlElement("LastCategory")]
        public string LastCategory { get; set; }

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

        [XmlElement("RecentAccounts", IsNullable = true)]
        public RecentAccounts RecentAccounts { get; set; }

        [XmlElement("NunericDamage"), DefaultValue(false)]
        public bool NunericDamage { get; set; }

        [XmlElement("DisableChat"), DefaultValue(false)]
        public bool DisableChat { get; set; }
    }

    public sealed class RecentAccounts
    {
        [XmlElement("One", IsNullable = true)]
        public string One;
        [XmlElement("Two", IsNullable = true)]
        public string Two;
        [XmlElement("Three", IsNullable = true)]
        public string Three;
        [XmlElement("Four", IsNullable = true)]
        public string Four;
    }

    public struct PatchListDataStruct
    {
        public string PatchName;
        public string PatchURL;
        public string PatchMD5Hash;
    }

    [XmlRoot("AccountsList")]
    public sealed class AccountList
    {
        [XmlElement("account")]
        public List<Account> Accounts { get; set; }
    }

    public class Account
    {
        [XmlText]
        public string Name { get; set; }
        [XmlAttribute("description")]
        public string Description { get; set; }
        [XmlAttribute("signature")]
        public string Signature { get; set; }
        [XmlAttribute("code")]
        public string Code { get; set; }
        [XmlAttribute("favorite")]
        public bool IsFavorite { get; set; }
        [XmlAttribute("category")]
        public string Category { get; set; }
    }
}