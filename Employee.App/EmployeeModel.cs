using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.App
{
    class EmployeeModel : IEmployee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string BaseLocation { get; set; }
    }
}
