using HRLeaveManagement.Application.Contracts.Presistence;
using HRLeaveManagement.Presistence.DatabaseContext;
using HRLeaveManagement.Presistence.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Presistence
{
    public static class PresistenceServiceRegestration
    {
        
        public static IServiceCollection AddPresistenceServices(
            this IServiceCollection services , IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnections"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(ILeaveTypeRepository), typeof(LeaveTypeRepository));
            services.AddScoped(typeof(ILeaveRequestRepository), typeof(LeaveRequestRepository));

            return services;
        }
    }
}
