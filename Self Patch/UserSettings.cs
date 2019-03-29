using DSSelfPatch.Properties;
using System;
using System.Collections.Generic;
using System.IO;

namespace DSSelfPatch
{
	public sealed class UserSettings
	{
		private static readonly UserSettings _instance;

		public Dictionary<int, UserSettings.PatchListDataStruct> PatchListData;

		public string PatchListTempFile;

		public string InstallPath;

		public string RemotePatchLocation;

		public string CONFIG_FILE;

		public Version RemoteLauncherVersion;

		public Version LocalLauncherVersion;

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
			this.RemoteLauncherVersion = new Version(0, 0, 0);
			this.LocalLauncherVersion = new Version(0, 0, 0);
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