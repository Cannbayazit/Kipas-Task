using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity
{
    public class State : BaseEntity
    {
        public string Name { get; set; }
        public List<EmployeeAddress> EmployeeAddressList { get; set; }
    }
}