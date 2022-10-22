
using HR_Employess_DataAccess;
using HR_Employess_DataService;
using HR_Employess_Repo;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HR_Employees_Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); 
            

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HR_CompanyContext>
               (option =>
               option.UseLazyLoadingProxies().
               UseSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString")));

            builder.Services.AddTransient<EmployeeDSL>();
            builder.Services.AddTransient<IEmpRepo, EmpRepo>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler(a => a.Run(async context =>
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new { error = "Something Went Wrong Please Contact the Admin" });
            }));

            app.UseCors(configurePolicy =>
            {
                configurePolicy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}