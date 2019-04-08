# DSLauncher
The DSLauncher is the tool used to launch the modified version of Freelancer executable for the Discovery mod.
The launcher supplys a neat interface to specify different launch parameters that affect the in game settings.

# Updating From Stock Discovery
If you are wanting to switch from base Discovery Launcher to this one, you need to download the following steps:

1. Download the most recent version of DSSelfPatch.exe from the releases tab.
2. Download the most recent launcher version from the releasese tab.
3. Copy both exe files to your Discovery directory, replacing the old versions.
4. Open up the DSLauncher.
5. Click on the button labeled - "Set New Launcher Patch Server"
6. It'll prompt you for input. Type in the following (no quotes): "https://github.com/LazDisco/DSLauncher/raw/patch/patchlist.xml"

# Build
Building the the project is pretty straight forward. The only real requirement is .NET 4.0 which any
Windows 7 machine onwards should have by default. If you have that, it should be as simple as opening the .sln file
in Visual Studio and running 'Build Solution'.

The project requires and assumes you have access to a launcherconfig.xml file that comes with any installation of the
Discovery mod. If you don't have an installation of the mod, grab it [here](https://discoverygc.com/forums/showthread.php?tid=126999).
In addition, the launcher will crash if you don't have the game files within the directory. Place the executable within the root
directory of a Discovery installation.

# Contributing
Create issues or pull requests to discuss.
