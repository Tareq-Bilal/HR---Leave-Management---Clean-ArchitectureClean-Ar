using HRLeaveManagement.Application.Contracts.Email;
using HRLeaveManagement.Application.Contracts.Logging;
using HRLeaveManagement.Application.Models.Email;
using HRLeaveManagement.Infrastructure.EmailService;
using HRLeaveManagement.Infrastructure.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRLeaveManagement.Infrastructure
{
    public static class InfrastructureServicesRegestration
    {
        public static IServiceCollection ConfigureInfrastructureServices(
            this IServiceCollection services , IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>) , typeof(LoggerAdapter<>));
            return services;
        }
    }
}
