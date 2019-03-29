using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace DSSelfPatch.Properties
{
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed class Defaults : ApplicationSettingsBase
	{
        public static Defaults Settings { get; } = (Defaults)Synchronized(new Defaults());
        [DefaultSettingValue("https://github.com/LazDisco/DSLauncher/blob/patch/patchlist.xml")]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public string KittyURL => (string)this[nameof(KittyURL)];
	}
}