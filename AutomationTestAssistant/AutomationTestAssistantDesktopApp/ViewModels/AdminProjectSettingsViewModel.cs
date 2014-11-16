﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using ATADataModel;
using CustomControls;
using FirstFloor.ModernUI.Presentation;
using AutomationTestAssistantCore;
using System.Collections.ObjectModel;

namespace AutomationTestAssistantDesktopApp
{
    public class AdminProjectSettingsViewModel : NotifyPropertyChanged
    {      
        public ObservableCollection<TeamViewModel> Teams { get; set; }
        public string UserName { get; set; }

        public AdminProjectSettingsViewModel()
        {
            Teams = new ObservableCollection<TeamViewModel>();
            UserName = ATACore.RegistryManager.GetUserName();
            List<Team> teams = ATACore.Managers.TeamManager.GetAllUserTeams(ATACore.Managers.ContextManager.Context, UserName);
            teams.ForEach(t => Teams.Add(new TeamViewModel(t.TeamId, t.Name)));            
        }

        public ObservableCollection<TeamViewModel> GetTeams()
        {
            return Teams;
        }
    }
}
