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
                case ExceptionCode.C05:
                    MetroMessageBox.Show(activeForm, "Unable to load account. Account no longer exists or is corrpted.", "Error Code: C05", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    break;
                case ExceptionCode.C06:
                    MetroMessageBox.Show(activeForm, "Unable to save config file.\n\nAdditional Informations: " + exmessage, "Error Code: C06", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    MetroMessageBox.Show(activeForm, "DSLauncher account import exception.\n\nAdditional Informations: " + exmessage, "Error Code: I01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
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
                    MetroMessageBox.Show(activeForm, "An error has occurred while downloading a patch.\n\nAdditional Informations: " + exmessage, "Error Code: P01", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.P02:
                    MetroMessageBox.Show(activeForm, "A fatal error has occurred while applying a patch.\n\nAdditional Informations: " + exmessage, "Error Code: P02", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    Environment.Exit(0);
                    break;
                case ExceptionCode.P03:
                    MetroMessageBox.Show(activeForm, exmessage, "Error Code: P03", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        /// <summary>Cannot find config file</summary>
        C01,
        /// <summary>Config file is corrupted</summary>
        C02,
        /// <summary>Cannot create default account (probably a registry issue)</summary>
        C03,
        /// <summary>Cannot load in account (probably a malformed account or registry issue)</summary>
        C04,
        /// <summary>Account in fav/recent menu no longer exists</summary>
        C05,
        /// <summary>Unable to save config file </summary>
        C06,
        /// <summary>Can't download patch</summary>
        P01,
        /// <summary>Can't install patch</summary>
        P02,
        /// <summary>Can't find DSSelfPatch</summary>
        P03,
        /// <summary>Can't contact patch server</summary>
        F01,
        /// <summary>Can't download patch from server</summary>
        F02,
        /// <summary>Can't Import account</summary>
        I01,
        /// <summary>Can't find Freelancer</summary>
        L01,
        /// <summary>Can't start Freelancer</summary>
        L02,
        /// <summary>Can't find DSAce</summary>
        L03,
        /// <summary>Can't close Freelancer/Programs reading FL's data</summary>
        L04, 
        Unknown
    }
}