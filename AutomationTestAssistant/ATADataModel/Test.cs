//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ATADataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Test
    {
        public Test()
        {
            this.TeamSuiteTests = new HashSet<TeamSuiteTest>();
            this.TestResultRuns = new HashSet<TestResultRun>();
        }
    
        public int TestId { get; set; }
        public string Name { get; set; }
        public string ClassName { get; set; }
        public System.DateTime AdditionDate { get; set; }
        public System.DateTime DeletionDate { get; set; }
        public int ProjectId { get; set; }
        public string FullName { get; set; }
        public string MethodId { get; set; }
    
        public virtual ICollection<TeamSuiteTest> TeamSuiteTests { get; set; }
        public virtual Project Project { get; set; }
        public virtual ICollection<TestResultRun> TestResultRuns { get; set; }
    }
}
