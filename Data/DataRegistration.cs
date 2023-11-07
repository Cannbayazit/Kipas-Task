using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Repository.Classes;
using Data.Repository.Interfaces;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public static class DataRegistration
    {

        public static void RegisterDataLayer(this IServiceCollection service)
        {
            service.AddDbContext<KipasContext>(p =>
            {
                p.UseSqlServer("data source=DESKTOP-34DS74H\\SQLEXPRESS;initial catalog=Kipas;integrated security=true;trustservercertificate=true;");
            });
            service.AddScoped<IEmployeeAddressRepository, EmployeeAddressRepository>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IStateRepository, StateRepository>();
        }
    }
}