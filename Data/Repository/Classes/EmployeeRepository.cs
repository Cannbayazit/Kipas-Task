using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository.Classes.Base;
using Data.Repository.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Classes
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(KipasContext context) : base(context)
        {
        }
    }
}