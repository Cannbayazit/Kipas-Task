using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class Employee : BaseEntity
    {
        public string Gender { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public EmployeeAddress EmployeeAddress { get; set; }
        public string Position { get; set; }
        public int EmployeeAddressID { get; set; }
        public int PositionID { get; set; }
    }
}