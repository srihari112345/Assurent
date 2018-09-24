using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.App
{
    interface IEmployee
    {
        int EmployeeId { get; set; }
        string Name { get; set; }
        string BaseLocation { get; set; }
    }
}
