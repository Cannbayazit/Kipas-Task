using System.Diagnostics;
using Data.Repository.Classes;
using Data.Repository.Interfaces;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Models;

namespace web.Controllers;

public class HomeController : Controller
{
    public IEmployeeRepository EmployeeRepository { get; set; }
    public IEmployeeAddressRepository EmployeeAddressRepository { get; set; }
    public IStateRepository StateRepository { get; set; }
    public HomeController(IEmployeeRepository employeeRepository, IStateRepository stateRepository, IEmployeeAddressRepository employeeAddressRepository)
    {
        EmployeeRepository = employeeRepository;
        StateRepository = stateRepository;
        EmployeeAddressRepository = employeeAddressRepository;
    }
    public void CreateEmployee()
    {
        EmployeeRepository.Create(new Entity.Employee()
        {
            Gender = "Erkek",
            Name = "Selcuk",
            LastName = "Sahin",
            BirthDate = DateTime.Now,
            EmployeeAddress = new Entity.EmployeeAddress() { Address = "Kahramanmaras/Onikişubat", State = new Entity.State() { Name = "Kahramanmaraş" } },
            Position = "Esnaf"
        });
    }

    public async Task<IActionResult> Index()
    {
        var Employees = await EmployeeRepository.Queryable().Include(e => e.EmployeeAddress).ThenInclude(e => e.State).ToListAsync();
        ViewData["States"] = await StateRepository.GetAllAsync();
        return View(Employees);
    }

    [HttpPost]
    public async Task<IActionResult> UpdtEmployeeData(Employee employee)
    {
        await EmployeeAddressRepository.UpdateAsync(employee.EmployeeAddress);
        await EmployeeRepository.UpdateAsync(employee);
        return RedirectToAction("Index");
    }
}

