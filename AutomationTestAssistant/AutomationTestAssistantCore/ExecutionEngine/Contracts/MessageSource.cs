﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutomationTestAssistantCore.ExecutionEngine.Contracts
{
    public enum MessageSource
    {
        MsBuildLogger,
        EnqueueLogger,
        DenqueueLogger,
        ExecutionLogger,
        ResultsParser
    }
}
