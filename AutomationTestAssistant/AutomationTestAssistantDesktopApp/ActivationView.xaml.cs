﻿using System;
using System.Windows;
using System.Windows.Controls;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class ActivationView : UserControl
    {
        private const string CodeRequiredValidationMessage = "The activation code can not be empty!";
        private const string CodeInvalidValidationMessage = "Your activation code is incorrect or expired!";
        private const string SuccessfullyActivationMessage = "Your account was activated successfully!";

        public string UserName { get; set; }

        public ActivationView()
        {
            InitializeComponent();
            this.UserName = ATACore.RegistryManager.GetUserName();
        }     

        private void btnActivate_Click(object sender, RoutedEventArgs e)
        {
            string code = tbActivationCode.Text;
            if(String.IsNullOrEmpty(code.CleanSpaces()))
            {
                DisplayValidationMessage(CodeRequiredValidationMessage);
                return;
            }
            bool isValid = ATACore.Managers.ActivationCodeManager.IsActivationCodeValid(UserName, code);
            if (!isValid)
            {
                DisplayValidationMessage(CodeInvalidValidationMessage);
                return;
            }
            ATACore.Managers.MemberManager.ActivateUser(ATACore.Managers.ContextManager.Context, UserName);
            DisplayAfterLoginActiveUserWindow();
            ATACore.Managers.ContextManager.Context.Dispose();
        }

        private void DisplayAfterLoginActiveUserWindow()
        {
            //Window window = Window.GetWindow(this);
            Member member = ATACore.Managers.MemberManager.GetMemberByUserName(ATACore.Managers.ContextManager.Context, UserName);
            ATACore.Managers.ContextManager.Context.Dispose();
            ModernDialog.ShowMessage(SuccessfullyActivationMessage, "Success!", MessageBoxButton.OK);
            MainWindow mainW = new MainWindow();
            //mainW.Show();
            //window.Close();
            if (member.UserMemberRole.Equals(MemberRoles.Admin))
                Navigator.Navigate("/AdminApproveMembersView.xaml", this);
            else
                Navigator.Navigate("/BeforeExecutionProjectSettingsView.xaml", this);           
        }

        private void DisplayValidationMessage(string validationMessage)
        {
            tbValidationMessage.Text = validationMessage;
            tbValidationMessage.Visibility = System.Windows.Visibility.Visible;
        }

        private void ResetValidationMessage()
        {
            tbValidationMessage.Text = String.Empty;
            tbValidationMessage.Visibility = System.Windows.Visibility.Hidden;
        }
    }
}
