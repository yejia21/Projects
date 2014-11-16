﻿using System.Windows;
using System.Windows.Controls;

namespace AutomationTestAssistantDesktopApp
{
    public partial class BeforeExecutionProjectSettingsView : UserControl
    {  
        public AdminProjectSettingsViewModel AdminProjectSettingsViewModel { get; set; }

        public BeforeExecutionProjectSettingsView()
        {
            InitializeComponent();
            AdminProjectSettingsViewModel = new AdminProjectSettingsViewModel();
            mainGrid.DataContext = AdminProjectSettingsViewModel.GetTeams();        
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.AdminProjectSettingsViewModel = AdminProjectSettingsViewModel;
            Navigator.Navigate("/ProjectSettingsLoadingView.xaml", this);
        }
    }
}