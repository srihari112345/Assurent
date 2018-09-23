using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Model
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string BaseLocation { get; set; }

        public virtual IEnumerable<Address> Addresses { get; set; }
        public virtual IEnumerable<ProjectEngagement> ProjectEngagements { get; set; }

        public Employee() { }
    }  
}
