using System;
using System.Collections.Generic;
using System.Text;

namespace Employee.Domain.Model
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public Address() { }
    }
}
