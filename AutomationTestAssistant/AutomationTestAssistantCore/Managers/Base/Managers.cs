﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore
{
    public class Managers
    {
        public MemberManager MemberManager
        {
            get
            {
                return new MemberManager();
            }
        }

        public TeamManager TeamManager
        {
            get
            {
                return new TeamManager();
            }
        }

        public MemberRoleManager MemberRoleManager
        {
            get
            {
                return new MemberRoleManager();
            }
        }

        public ActivationCodeManager ActivationCodeManager
        {
            get
            {
                return new ActivationCodeManager();
            }
        }

        public ProjectManager ProjectManager
        {
            get
            {
                return new ProjectManager();
            }
        }

        public AdditionalPathManager AdditionalPathManager
        {
            get
            {
                return new AdditionalPathManager();
            }
        }

        public TestManager TestManager
        {
            get
            {
                return new TestManager();
            }
        }

        public AgentMachineManager AgentMachineManager
        {
            get
            {
                return new AgentMachineManager();
            }
        }

        public ContextManager ContextManager
        {
            get
            {
                return new ContextManager();
            }
        }

        public ExecutionResultRunManager ExecutionResultRunManager
        {
            get
            {
                return new ExecutionResultRunManager();
            }
        }

        public TestResultRunManager TestResultRunManager
        {
            get
            {
                return new TestResultRunManager();
            }
        }
    }
}
