﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Messages
{
    public class MessageArgsWorkspaceDeletion : BaseMessageArgs
    {
        public string TfsServerUrl { get; set; }

        public string WorkspaceName { get; set; }

        public string UserName { get; set; }

        public MessageArgsWorkspaceDeletion(Command command, string projectPath, IpAddressSettings ipAddressSettings, string tfsServerUrl, string workspaceName, string userName)
            : base(command, projectPath, ipAddressSettings)
        {
            this.TfsServerUrl = tfsServerUrl;
            this.WorkspaceName = workspaceName;
            this.UserName = userName;
        }

        public MessageArgsWorkspaceDeletion()
        {
        }
       
    }
}
