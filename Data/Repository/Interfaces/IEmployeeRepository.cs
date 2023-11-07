using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Repository.Interfaces.Base;
using Entity;

namespace Data.Repository.Interfaces
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {

    }
}