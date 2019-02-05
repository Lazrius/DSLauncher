using DSSelfPatch.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace DSSelfPatch
{
	public sealed class UserSettings
	{
		private readonly static UserSettings _instance;

		public Dictionary<int, UserSettings.PatchListDataStruct> PatchListData;

		public string PatchListTempFile;

		public string InstallPath;

		public string RemotePatchLocation;

		public string CONFIG_FILE;

		public int RemoteLauncherVersion;

		public int LocalLauncherVersion;

		public int UseKitty;

        public static UserSettings Instance => _instance;

        static UserSettings()
		{
			_instance = new UserSettings();
		}

		public UserSettings()
		{
			this.CONFIG_FILE = "launcherconfig.xml";
			this.InstallPath = "";
			this.RemotePatchLocation = Defaults.Settings.KittyURL;
			this.RemoteLauncherVersion = 0;
			this.LocalLauncherVersion = 0;
			this.UseKitty = 0;
			this.PatchListData = new Dictionary<int, PatchListDataStruct>();
			this.PatchListTempFile = Path.GetTempFileName();
		}

		public struct PatchListDataStruct
		{
			public string PatchName;

			public string PatchURL;

			public string PatchMD5Hash;
		}
	}
}