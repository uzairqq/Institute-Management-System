using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Sms.Domain.Repostories.Implementation;
using Sms.Domain.Repostories.Interfaces;

namespace Sms.Domain
{
   public class DataAccessRegistry
    {
        public static void RegisterRepository(IServiceCollection services)
        {
            services.AddScoped(typeof(IAsyncRepository<>), typeof(EfRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            //services.AddScoped(typeof(ICustomerRepository), typeof(CustomerRepository));
            //services.AddScoped(typeof(ICustomerRateRepository), typeof(CustomerRatesRepository));
        }
    }
}
