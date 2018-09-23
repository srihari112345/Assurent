using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Model
{
    public class ProjectEngagement
    {
        public int EngagementId { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }

        public ProjectEngagement() { }
    }
}
