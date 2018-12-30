using System.Configuration;
using System.Diagnostics;
using System.Net;

namespace DSLauncherV2.Properties
{
    internal sealed class Defaults : ApplicationSettingsBase
    {

        public static Defaults Settings { get; } = (Defaults) Synchronized(new Defaults());
        [DefaultSettingValue("http://patch.discoverygc.net/")]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public string KittyURL => (string) this[nameof(KittyURL)];
    }
}