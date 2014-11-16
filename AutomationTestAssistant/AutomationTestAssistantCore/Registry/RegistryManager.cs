﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace AutomationTestAssistantCore
{
    public class RegistryManager
    {
        public const string MainRegistrySubKeyName = "AutomationTestAssistant";
        public const string DataRegistrySubKeyName = "data";
        public const string UserNameRegistrySubKeyName = "userName";
        public const string ThemeRegistrySubKeyName = "theme";
        public const string AppereanceRegistrySubKeyName = "Appereance";
        public const string LocalPathsRegistrySubKeyName = "LocalPaths";
        public const string WorkspaceNamesRegistrySubKeyName = "WorkspaceNames";
        public const string ColorRegistrySubKeyName = "color";

        public void WriterCurrentUserToRegistry(string userName)
        {
            RegistryKey ata = Registry.CurrentUser.CreateSubKey(MainRegistrySubKeyName);
            // Create two subkeys under HKEY_CURRENT_USER\AutomationTestAssistant. The
            // keys are disposed when execution exits the using statement.
            RegistryKey dataR = ata.CreateSubKey(DataRegistrySubKeyName);
            // Create data for the TestSettings subkey.
            dataR.SetValue(UserNameRegistrySubKeyName, userName);
            dataR.Close();
            ata.Close();
        }

        public void WriterCurrentThemeToRegistry(string currentUserName, string theme)
        {
            RegistryKey ata = Registry.CurrentUser.CreateSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.CreateSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.CreateSubKey(currentUserName);
            RegistryKey appereanceR = currentUserR.CreateSubKey(AppereanceRegistrySubKeyName);
            appereanceR.SetValue(ThemeRegistrySubKeyName, theme);
            appereanceR.Close();
            currentUserR.Close();
            dataR.Close();
            ata.Close();
        }

        public void WriterLocalPathToRegistry(string currentUserName, string tfsPath, string localPath)
        {
            RegistryKey ata = Registry.CurrentUser.CreateSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.CreateSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.CreateSubKey(currentUserName);
            RegistryKey localPathsR = currentUserR.CreateSubKey(LocalPathsRegistrySubKeyName);
            localPathsR.SetValue(tfsPath, localPath);
            localPathsR.Close();
            currentUserR.Close();
            dataR.Close();
            ata.Close();
        }

        public void WriterWorkspaceNameToRegistry(string userName, string localPath, string workspaceName)
        {
            RegistryKey ata = Registry.CurrentUser.CreateSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.CreateSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.CreateSubKey(userName);
            RegistryKey workspaceNamesR = currentUserR.CreateSubKey(WorkspaceNamesRegistrySubKeyName);
            workspaceNamesR.SetValue(localPath, workspaceName);
            workspaceNamesR.Close();
            currentUserR.Close();
            dataR.Close();
            ata.Close();
        }

        public void WriterCurrentColorsToRegistry(string currentUserName, byte red, byte green, byte blue)
        {
            RegistryKey ata = Registry.CurrentUser.CreateSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.CreateSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.CreateSubKey(currentUserName);
            RegistryKey appereanceR = currentUserR.CreateSubKey(AppereanceRegistrySubKeyName);
            appereanceR.SetValue(ColorRegistrySubKeyName, String.Format("{0}&{1}&{2}", red, green, blue));
            appereanceR.Close();
            currentUserR.Close();
            dataR.Close();
            ata.Close();
        }

        public string[] GetColors(string currentUserName)
        {
            string[] colorsStr = null;
            try
            {
                RegistryKey ata = Registry.CurrentUser.OpenSubKey(MainRegistrySubKeyName);
                RegistryKey dataR = ata.OpenSubKey(DataRegistrySubKeyName);
                RegistryKey currentUserR = dataR.OpenSubKey(currentUserName);
                RegistryKey appereanceR = currentUserR.OpenSubKey(AppereanceRegistrySubKeyName);
                string colors = String.Empty;

                if (appereanceR != null && currentUserR != null && dataR != null && ata != null)
                {
                    colors = (string)appereanceR.GetValue(ColorRegistrySubKeyName);
                    appereanceR.Close();
                    currentUserR.Close();
                    dataR.Close();
                    ata.Close();
                }
                if (!String.IsNullOrEmpty(colors))
                    colorsStr = colors.Split('&');
            }
            catch { }
            return colorsStr;
        }

        public string GetUserName()
        {
            RegistryKey ata = Registry.CurrentUser.OpenSubKey(MainRegistrySubKeyName);
            RegistryKey data = ata.OpenSubKey(DataRegistrySubKeyName);
            string userName = (string)data.GetValue(UserNameRegistrySubKeyName);
            data.Close();
            ata.Close();

            return userName;
        }

        public string GetTheme(string currentUserName)
        {
            string theme = String.Empty;
            try
            {
                RegistryKey ata = Registry.CurrentUser.OpenSubKey(MainRegistrySubKeyName);
                RegistryKey dataR = ata.OpenSubKey(DataRegistrySubKeyName);
                RegistryKey currentUserR = dataR.OpenSubKey(currentUserName);
                RegistryKey appereanceR = currentUserR.OpenSubKey(AppereanceRegistrySubKeyName);

                if (appereanceR != null && currentUserR != null && dataR != null && ata != null)
                {
                    theme = (string)appereanceR.GetValue(ThemeRegistrySubKeyName);
                    appereanceR.Close();
                    currentUserR.Close();
                    dataR.Close();
                    ata.Close();
                }
            }
            catch { }
            return theme;
        }

        public string GetProjectLocalPath(string userName, string tfsPath)
        {
            RegistryKey ata = Registry.CurrentUser.OpenSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.OpenSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.OpenSubKey(userName);
            RegistryKey localPathsR = currentUserR.OpenSubKey(LocalPathsRegistrySubKeyName);
            string localPath = String.Empty;
            if (localPathsR != null && currentUserR != null && dataR != null && ata != null)
            {
                localPath = (string)localPathsR.GetValue(tfsPath);
                localPathsR.Close();
                currentUserR.Close();
                dataR.Close();
                ata.Close();
            }

            return localPath;
        }

        public string GetWorkspaceName(string userName, string localPath)
        {
            RegistryKey ata = Registry.CurrentUser.OpenSubKey(MainRegistrySubKeyName);
            RegistryKey dataR = ata.OpenSubKey(DataRegistrySubKeyName);
            RegistryKey currentUserR = dataR.OpenSubKey(userName);
            RegistryKey workspaceNames = currentUserR.OpenSubKey(WorkspaceNamesRegistrySubKeyName);
            string cWorkspaceName = String.Empty;
            if (workspaceNames != null && currentUserR != null && dataR != null && ata != null)
            {
                cWorkspaceName = (string)workspaceNames.GetValue(localPath);
                workspaceNames.Close();
                currentUserR.Close();
                dataR.Close();
                ata.Close();
            }

            return cWorkspaceName;
        }
    }
}
