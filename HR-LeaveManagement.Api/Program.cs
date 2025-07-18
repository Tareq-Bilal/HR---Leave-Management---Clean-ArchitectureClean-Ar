using HRLeaveManagement.Application;
using HRLeaveManagement.Infrastructure;
using HRLeaveManagement.Presistence;
namespace HR_LeaveManagement.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("all", builder => builder
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyHeader());
            });

            builder.Services.ApplicationServices(builder.Configuration);
            builder.Services.ConfigureInfrastructureServices(builder.Configuration);
            builder.Services.AddPresistenceServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
