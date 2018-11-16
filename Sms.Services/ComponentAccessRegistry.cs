using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sms.Services.Service.Implementation;
using Sms.Services.Service.Interfaces;

namespace Sms.Services
{
   public static class ComponentAccessRegistry
    {
        public static void RegisterServices(IServiceCollection service)
        {
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<IEmployeeTypeService, EmployeeTypeService>();
        }
    }
}
