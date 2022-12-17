using EverLight.DTOs;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverLight.BusinessLayer
{
    public static class BusinessExtension
    {
        public static IServiceCollection UseBusinessLogic(this IServiceCollection services)
        {
            services.AddSingleton<EverLight.DC.DataContext>();
            services.AddSingleton<EverLight.Repositories.IRepository<Order>, Repositories.Repository<Order>>();
            services.AddSingleton<EverLight.Repositories.IRepository<Employee>, Repositories.Repository<Employee>>();
            services.AddSingleton<EverLight.BusinessLayer.BusinessLogic>();
            return services;
        }
    }
}
