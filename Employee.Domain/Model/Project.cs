using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }

        public virtual IEnumerable<ProjectEngagement> ProjectEngagements { get; set; }
    }
}
