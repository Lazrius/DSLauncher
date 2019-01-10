using System;
using System.Windows.Forms;
using MetroFramework;

namespace DSLauncherV2
{
    internal static class ExceptionHandler
    {
        internal static void Throw(string code, string exmessage, Primary ActiveForm)
        {
            if (code == "L01")
            {
                MetroMessageBox.Show(ActiveForm, "Could not find Freelancer.exe \n\n" + exmessage, "Error Code: L01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if (code == "L02")
            {
                MetroMessageBox.Show(ActiveForm, "Could not start Freelancer.exe \n\nAdditional Informations: " + exmessage, "Error Code: L02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if (code == "L03")
            {
                MetroMessageBox.Show(ActiveForm, "DSAce.dll is missing. Add an exception to your antivirus and use the \"Restore DSAce.dll\" button in the parameters tab. \n\nAdditional Informations: " + exmessage, "Error Code: L03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if (code == "L04")
            {
                MetroMessageBox.Show(ActiveForm, "Unable to terminate Freelancer process. \n\nAdditional Information: " + exmessage, "Error Code L04", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "C01")
            {
                MetroMessageBox.Show(ActiveForm, "Could not find DSLauncher's configuration file. \n\nAdditional Informations: " + exmessage, "Error Code: C01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "C02")
            {
                MetroMessageBox.Show((IWin32Window)Form.ActiveForm, "DSLauncher configuration file corrupted. \n\nAdditional Informations: " + exmessage, "Error Code: C02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "C03")
            {
                MetroMessageBox.Show(ActiveForm, "Could not create a default account file. \n\nAdditional Informations: " + exmessage, "Error Code: C03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "C04")
            {
                MetroMessageBox.Show(ActiveForm, "DSLauncher could not load the account file.\n\nAdditional Informations: " + exmessage, "Error Code: C04", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "F01")
            {
                MetroMessageBox.Show(ActiveForm, "DSLauncher could not contact the patch server.\n\nAdditional Informations: " + exmessage, "Error Code: F01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

            else if (code == "F02")
            {
                MetroMessageBox.Show(ActiveForm, "An error has occured while parsing the content of the patch list file.\n\nAdditional Informations: " + exmessage, "Error Code: F02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if(!exmessage.Contains("Could not find file"))
                    Environment.Exit(0);
            }

            else if (code == "F03")
            {
                MetroMessageBox.Show(ActiveForm, "An error has occured while parsing the web resources file.\n\nAdditional Informations: " + exmessage, "Error Code: F03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "P01")
            {
                MetroMessageBox.Show(ActiveForm, "DSLauncher account import exception.\n\nAdditional Informations: " + exmessage, "Error Code: P01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "P02")
            {
                MetroMessageBox.Show(ActiveForm, "Discovery Launchpad account import exception.\n\nAdditional Informations: " + exmessage, "Error Code: P02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "P03")
            {
                MetroMessageBox.Show(ActiveForm, "ADF account import exception.\n\nAdditional Informations: " + exmessage, "Error Code: P03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "D01")
            {
                MetroMessageBox.Show(ActiveForm, "An error has occured while downloading a patch.\n\nAdditional Informations: " + exmessage, "Error Code: D01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "D02")
            {
                MetroMessageBox.Show(ActiveForm, "A fatal error has occured while applying a patch.\n\nAdditional Informations: " + exmessage, "Error Code: D02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Environment.Exit(0);
            }

            else if (code == "D03")
            {
                MetroMessageBox.Show(ActiveForm, exmessage, "Error Code: D03", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

            else
            {
                if (code != "Z01")
                    return;
                MetroMessageBox.Show(ActiveForm, "An error has occured while attempting to restore DSAce.\n\nAdditional Informations: " + exmessage, "Error Code: Z01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }
    }
}