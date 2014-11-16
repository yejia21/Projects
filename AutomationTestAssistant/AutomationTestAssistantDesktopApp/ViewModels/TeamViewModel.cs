﻿using System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATADataModel;
using AutomationTestAssistantCore;

namespace AutomationTestAssistantDesktopApp
{
    public class TeamViewModel : Team
    {
        public TeamViewModel(int id, string name)
        {
            base.TeamId = id;
            base.Name = name;
            projects = new ObservableCollection<ProjectViewModel>();
            agentMachines = new ObservableCollection<AgentMachineViewModel>();
            List<ATADataModel.Project> projectsList = ATACore.Managers.ProjectManager.GetAllProjectsByTeamId(ATACore.Managers.ContextManager.Context, TeamId);

            string currentUser = ATACore.RegistryManager.GetUserName();
            projectsList.ForEach(p => projects.Add(new ProjectViewModel(p, currentUser)));
            List<ATADataModel.AgentMachine> agentMachinesList = ATACore.Managers.AgentMachineManager.GetAllAgentMachinesByTeamId(ATACore.Managers.ContextManager.Context, TeamId);
            agentMachinesList.ForEach(a => agentMachines.Add(new AgentMachineViewModel(a)));
            ATACore.Managers.ContextManager.Context.Dispose();
        }

        private ObservableCollection<ProjectViewModel> projects;

        public ObservableCollection<ProjectViewModel> ObservableProjects
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
