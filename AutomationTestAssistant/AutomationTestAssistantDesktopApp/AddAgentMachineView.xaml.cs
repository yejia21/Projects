﻿using System;
using System.Windows;
using System.Windows.Controls;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using FirstFloor.ModernUI.Windows;

namespace AutomationTestAssistantDesktopApp
{
    public partial class AddAgentMachineView : UserControl, IContent
    {
        private const string AgentMachineSuccessfullyAddedMessage = "Agent Machine successfully added!";
        public string ReturnUrl { get; set; }

        public AddAgentMachineView()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);          
            window.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            string agentMachineName = tbAgentMachineName.Text;
            string ip = tbIp.Text;
            string workingDir = tbWorkingDir.Text;
            ATACore.Managers.AgentMachineManager.AddNew(ATACore.Managers.ContextManager.Context, agentMachineName, ip, workingDir);
            ATACore.Managers.ContextManager.Context.Dispose();
            ModernDialog.ShowMessage(AgentMachineSuccessfullyAddedMessage, "Success!", MessageBoxButton.OK);
            if (ReturnUrl.Equals("/AdminProjectSettingsView.xaml"))
            {
                Window window = Window.GetWindow(this);
                window.Close();
            }
            else
            {
                //AddSettingsWindow mnw = new AddSettingsWindow();
                //mnw.ContentSource = new Uri(ReturnUrl, UriKind.Relative);
                //mnw.Show();
                Navigator.Navigate(ReturnUrl, this);
            }
        }

        public void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            FragmentManager fm = new FragmentManager(e.Fragment);
            ReturnUrl = fm.Fragments["returnUrl"];
        }

        public void OnNavigatedFrom(NavigationEventArgs e)
        {
            Uri source = e.Source;
        }

        public void OnNavigatedTo(NavigationEventArgs e)
        {
            Uri source = e.Frame.Source;
        }

        public void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            bool result = e.IsParentFrameNavigating;
        }
    }
}
