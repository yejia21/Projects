﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class TeamTestsExecutionViewModel : Team
    {
        public TeamTestsExecutionViewModel(int id, string name, ObservableCollection<ProjectViewModel> observableProjects, ObservableCollection<AgentMachineViewModel> observableAgentMachines)
        {
            base.TeamId = id;
            base.Name = name;
            projects = new ObservableCollection<ProjectTestsExecutionViewModel>();
            agentMachines = new ObservableCollection<AgentMachineViewModel>();
            agentMachines = observableAgentMachines;
            InitializeObeservableProjects(observableProjects);
        }

        private void InitializeObeservableProjects(ObservableCollection<ProjectViewModel> observableProjects)
        {
            foreach (var cP in observableProjects)
            {
                if (cP.IsSelected)
                projects.Add(new ProjectTestsExecutionViewModel(cP));
            }
        }

        private ObservableCollection<ProjectTestsExecutionViewModel> projects;

        public ObservableCollection<ProjectTestsExecutionViewModel> ObservableProjects
        {
            get
            {
                return projects;
            }
            set
            {
                projects = value;
               
            }
        }

        private ObservableCollection<AgentMachineViewModel> agentMachines;

        public ObservableCollection<AgentMachineViewModel> ObservableAgentMachines
        {
            get
            {
                return agentMachines;
            }
            set
            {
                agentMachines = value;

            }
        }
    }
}
