using System.Collections.Generic;
using System.IO;

namespace DSLauncherV2
{
    public sealed class UserSettings
    {
        public static UserSettings Instance { get; } = new UserSettings();
        public List<string> installedpatchlist;
        public Dictionary<int, UserSettings.PatchListDataStruct> PatchListData;
        public Dictionary<int, UserSettings.AccountsListDataStruct> AccountListData;
        public string PatchListTempFile;
        public string AName;
        public string ADescription;
        public string ACode;
        public string ASignature;
        public string MainServer;
        public string InstallPath;
        public string ActiveCode;
        public string ActiveSignature;
        public string ExtraArgs;
        public string DisplayWidth;
        public string DisplayHeight;
        public string LocalGameVersion;
        public string RemotePatchLocation;
        public string UserLogin;
        public string UserPassword;
        public string RemoteGameVersion;
        public string RemoteExtraArgs;
        public string ConfigFile;
        public string AccountsFile;
        public string ModName;
        public string AccountCategory;
        public string RecentAccount1;
        public string RecentAccount2;
        public string RecentAccount3;
        public string RecentAccount4;
        public bool AFavorite;
        public bool DisplayMode;
        public bool DisplayDesktopRes;
        public bool ShowJoiningPlayers;
        public bool ShowDepartingPlayers;
        public bool ShowLagIndicator;
        public bool ShowFlightText;
        public bool ChatLogging;
        public bool ChatAppend;
        public bool ChatTime;
        public bool ChatLocalTime;
        public bool AutoLogin;
        public bool AutoCloudAccounts;
        public bool IDPrompt;
        public bool DiscordRPC;
        public bool DrawDistance;
        public bool DisableChat;
        public int RemoteLauncherVersion;
        public int LocalLauncherVersion;
        public int Style;
        public int UseKitty;

        public UserSettings()
        {
            this.ModName = "";
            this.ConfigFile = "launcherconfig.xml";
            this.AccountsFile = "/launcheraccounts.xml";
            this.InstallPath = "";
            this.RemotePatchLocation = "";
            this.ExtraArgs = "";
            this.RemoteExtraArgs = "";
            this.RemoteLauncherVersion = 0;
            this.LocalLauncherVersion = 0;
            this.RemoteGameVersion = "";
            this.UserLogin = "";
            this.UserPassword = "";
            this.ActiveCode = "";
            this.ActiveSignature = "";
            this.Style = 0;
            this.UseKitty = 0;
            this.MainServer = "";
            this.DisplayWidth = "";
            this.DisplayHeight = "";
            this.LocalGameVersion = "";
            this.RecentAccount1 = "";
            this.RecentAccount2 = "";
            this.RecentAccount3 = "";
            this.RecentAccount4 = "";
            this.DisplayMode = false;
            this.DisplayDesktopRes = true;
            this.ShowJoiningPlayers = true;
            this.ShowDepartingPlayers = false;
            this.ShowLagIndicator = false;
            this.ShowFlightText = false;
            this.ChatLogging = true;
            this.ChatAppend = true;
            this.ChatTime = true;
            this.ChatLocalTime = true;
            this.AutoLogin = true;
            this.AutoCloudAccounts = true;
            this.IDPrompt = false;
            this.DiscordRPC = false;
            this.DrawDistance = false;
            this.DisableChat = false;
            this.AccountListData = new Dictionary<int, AccountsListDataStruct>();
            this.PatchListData = new Dictionary<int, PatchListDataStruct>();
            this.installedpatchlist = new List<string>();
            this.PatchListTempFile = Path.GetTempFileName();
            this.AFavorite = false;
            this.AName = "";
            this.ADescription = "";
            this.ASignature = "";
            this.ACode = "";
            this.AccountCategory = "";
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
}