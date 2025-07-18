using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Application
{
    public static class ApplicationServiceRegestration
    {
        public static IServiceCollection ApplicationServices (
            this IServiceCollection services ,
            IConfiguration configuration 
            )
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
