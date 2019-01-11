using System;
using System.Windows.Forms;
using MetroFramework;

namespace DSLauncherV2
{
    internal static class ExceptionHandler
    {
        internal static void Throw(ExceptionCode code, string exmessage, Primary activeForm)
        {
            switch (code)
            {
                case ExceptionCode.C01:
                    MetroMessageBox.Show(activeForm, "Could not find DSLauncher's configuration file. \n\nAdditional Informations: " + exmessage, "Error Code: C01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.C02:
                    MetroMessageBox.Show((IWin32Window)Form.ActiveForm, "DSLauncher configuration file corrupted. \n\nAdditional Informations: " + exmessage, "Error Code: C02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.C03:
                    MetroMessageBox.Show(activeForm, "Could not create a default account file. \n\nAdditional Informations: " + exmessage, "Error Code: C03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.C04:
                    MetroMessageBox.Show(activeForm, "DSLauncher could not load the account file.\n\nAdditional Informations: " + exmessage, "Error Code: C04", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.F01:
                    MetroMessageBox.Show(activeForm, "DSLauncher could not contact the patch server.\n\nAdditional Informations: " + exmessage, "Error Code: F01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.F02:
                    MetroMessageBox.Show(activeForm, "An error has occurred while parsing the content of the patch list file.\n\nAdditional Informations: " + exmessage, "Error Code: F02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    if(!exmessage.Contains("Could not find file"))
                        Environment.Exit(0);
                    break;
                case ExceptionCode.I01:
                    MetroMessageBox.Show(activeForm, "DSLauncher account import exception.\n\nAdditional Informations: " + exmessage, "Error Code: P01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.L01:
                    MetroMessageBox.Show(activeForm, "Could not find Freelancer.exe \n\n" + exmessage, "Error Code: L01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.L02:
                    MetroMessageBox.Show(activeForm, "Could not start Freelancer.exe \n\nAdditional Informations: " + exmessage, "Error Code: L02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.L03:
                    MetroMessageBox.Show(activeForm, "DSAce.dll is missing. \n\nAdditional Informations: " + exmessage, "Error Code: L03", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.L04:
                    MetroMessageBox.Show(activeForm, "Unable to terminate Freelancer process. \n\nAdditional Information: " + exmessage, "Error Code L04", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.P01:
                    MetroMessageBox.Show(activeForm, "An error has occurred while downloading a patch.\n\nAdditional Informations: " + exmessage, "Error Code: D01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.P02:
                    MetroMessageBox.Show(activeForm, "A fatal error has occurred while applying a patch.\n\nAdditional Informations: " + exmessage, "Error Code: D02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.P03:
                    MetroMessageBox.Show(activeForm, exmessage, "Error Code: D03", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Environment.Exit(0);
                    break;
                default:
                    MetroMessageBox.Show(activeForm, "Unknown Error: \n\nAdditional Informations: " + exmessage,
                        "Unknown Error Code: " + code, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
        }
    }

    internal enum ExceptionCode
    {
        C01, // Cannot find config file
        C02, // Config file is corrupted
        C03, // Cannot create default account (probably a registry issue)
        C04, // Cannot load in account (probably a malformed account or registry issue)
        P01, // Can't download patch
        P02, // Can't install patch
        P03, // Can't find DSSelfPatch
        F01, // Can't contact patch server
        F02, // Can't download patch from server
        I01, // Can't Import account
        L01, // Can't find Freelancer
        L02, // Can't start Freelancer
        L03, // Can't find DSAce
        L04, // Can't close Freelancer/Programs reading FL's data
        Unknown
    }
}