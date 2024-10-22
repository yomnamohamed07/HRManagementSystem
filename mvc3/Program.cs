
using Business_acess_lyer.interfaces;
using Business_acess_lyer.repositories;
using Data_access_lyer.data;
using Data_access_lyer.models;
using Microsoft.EntityFrameworkCore;
using mvc3.profiles;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace mvc3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<datacontextcs>();
         
            builder.Services.AddDbContext<datacontextcs>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultconnection"));
            }
            );
            builder.Services.AddIdentity<applicationuser, IdentityRole>()
                .AddEntityFrameworkStores<datacontextcs>()
                .AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(c => { });// redirect to acount //asseccdenied path
           //this congigration the token
             builder.Services.AddAutoMapper(typeof(employeeprofile));
           builder.Services.AddScoped<Idata_repositories, data_repositories>();
           // builder.Services.AddScoped<IEmployee_repositories, Employee_repositories>();
            builder.Services.AddScoped<IUnitofwork, Unitofwork>();
           // builder.Services.AddScoped<IGenericRepositories<department>, GenericRepositories<department>>();
            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
       

           
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        
            app.Run();
        }
    }
}
