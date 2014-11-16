﻿using System;
using System.Windows;
using System.Windows.Controls;
using ATADataModel;
using AutomationTestAssistantCore;
using FirstFloor.ModernUI.App.Content;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class LoginView : UserControl
    {
        private const string ToBeApprovedMessage = "Your Account will be approved in short period!";
        private const string InvalidCredentialsMessage = "Invalid email or password!";
        private const string RequiredFieldsValidationMessage = "You should fill the required fields!";
        public MemberViewModel MemberProxy { get; set; }

        public LoginView()
        {
            InitializeComponent();           
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            ResetValidationMessage();
            MemberProxy.Password = tbPassword.Password;
            bool areFilled = MemberProxy.AreRequiredCredentialsFieldsFilled();
            if (!areFilled)
            {
                DisplayValidationMessage(RequiredFieldsValidationMessage);
                return;              
            }
       
            var context = new ATAEntities();
            Member currentMember = ATACore.Managers.MemberManager.RetrieveMemberByCredentials(ATACore.Managers.ContextManager.Context, this.tbMemberUserName.Text, tbPassword.Password);
            ATACore.Managers.ContextManager.Context.Dispose();
            if (currentMember != null)
                ResolveStatus(currentMember);
            else
                DisplayIncorrectUserCredentialsMessage();
         
        }

        private void DisplayIncorrectUserCredentialsMessage()
        {
            DisplayValidationMessage(InvalidCredentialsMessage);
        }       

        private void ResolveStatus(Member currentMember)
        {
            Statuses currentUserStatus = ATACore.Managers.MemberManager.GetMemberStatus(currentMember);
            ATACore.RegistryManager.WriterCurrentUserToRegistry(currentMember.UserName);
            SettingsAppearanceViewModel aSettings = new SettingsAppearanceViewModel();
            switch (currentUserStatus)
            {
                case Statuses.Active:
                    ResetValidationMessage();
                    MemberRoles currentRole = ATACore.Managers.MemberRoleManager.GetMemberRoleByUserName(ATACore.Managers.ContextManager.Context, MemberProxy.UserName);
                    ATACore.Managers.ContextManager.Context.Dispose();
                    
                    if (currentRole.Equals(MemberRoles.Admin))
                        DisplayAdminWindow();
                    else
                         DisplayAfterLoginActiveUserWindow();
                    break;
                case Statuses.ToBeApproved:
                    DisplayValidationMessage(ToBeApprovedMessage);
                    break;
                case Statuses.PendingActivation:                 
                    DisplayActivationWindow();
                    break;
                default:
                    break;
            }
        }      

        private void DisplayAfterLoginActiveUserWindow()
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
      
            mw.MenuLinkGroups.Clear();
            //LinkGroup lg = new LinkGroup();
            //Link l1 = new Link();
            //Uri u2 = new Uri("/AllResultsView.xaml", UriKind.Relative);
            //l1.DisplayName = "View All Results";
            //l1.Source = u2;
            //lg.Links.Add(l1);
            //mw.MenuLinkGroups.Add(lg);
            Uri u1 = new Uri("/ModeChoosingView.xaml", UriKind.Relative);
            //Uri u1 = new Uri("/ExecutionResultsView.xaml#executionResultRunId=ccb4dc49-7e20-4f12-a7b0-80cd643409af", UriKind.Relative);
            mw.ContentSource = u1;
        }

        private void DisplayAdminWindow()
        {
            ModernWindow mw = Window.GetWindow(this) as ModernWindow;
            Uri u1 = new Uri("/AdminApproveMembersView.xaml", UriKind.Relative);
            mw.ContentSource = u1;
            mw.MenuLinkGroups.Clear();
            LinkGroup lg = new LinkGroup();
            Link l1 = new Link();
            l1.DisplayName = "Manage Members";
            l1.Source = u1;
            lg.Links.Add(l1);
            Uri u2 = new Uri("/AdminProjectSettingsView.xaml", UriKind.Relative);
            Link l2 = new Link();
            l2.DisplayName = "Manage Project Settings";
            l2.Source = u2;
            lg.Links.Add(l2);
            mw.MenuLinkGroups.Add(lg);
            Uri logoutUri = new Uri("/LoginView.xaml", UriKind.Relative);
            Link logoutLink = new Link();
            logoutLink.DisplayName = "Log out";
            logoutLink.Source = logoutUri;
            mw.TitleLinks.Add(logoutLink);
        }

        private void DisplayActivationWindow()
        {
            mainGrid.Children.Clear();
            ActivationView ac = new ActivationView();
            mainGrid.Children.Add(ac);
        }

        private void Login_Loaded(object sender, RoutedEventArgs e)
        {
            this.tbMemberUserName.Focus();
            MemberProxy = new MemberViewModel();
            DataContext = MemberProxy;           
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
