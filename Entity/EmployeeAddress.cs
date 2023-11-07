using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class EmployeeAddress : BaseEntity
    {
        public int EmployeeID { get; set; }
        public int StateID { get; set; }
        public string Address { get; set; }
        public State State { get; set; }
        public Employee Employee { get; set; }

    }
}