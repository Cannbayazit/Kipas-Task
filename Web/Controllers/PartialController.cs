using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Repository.Classes;
using Data.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Web.Controllers
{
    [Route("[controller]")]
    public class PartialController : Controller
    {

        public IEmployeeRepository EmployeeRepository { get; set; }
        public IStateRepository StateRepository { get; set; }
        public PartialController(IEmployeeRepository employeeRepository, IStateRepository stateRepository)
        {
            EmployeeRepository = employeeRepository;
            StateRepository = stateRepository;
        }

        [HttpGet]
        [Route("GetEmployeeModal")]
        public async Task<IActionResult> GetEmployee(int ID)
        {
            var employee = await EmployeeRepository.Queryable().Include(e => e.EmployeeAddress).ThenInclude(e => e.State).FirstOrDefaultAsync(e => e.ID == ID);
            ViewData["States"] = await StateRepository.GetAllAsync();
            return PartialView("UpdateEmployeeModal", employee);
        }
    }
}