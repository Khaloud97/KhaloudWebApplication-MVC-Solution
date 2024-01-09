using KhaloudWebApplication_MVC_.BLL.Interface;
using KhaloudWebApplication_MVC_.BLL.Reposatory;
using KhaloudWebApplication_MVC_.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace KhaloudWebApplication_MVC_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));


            builder.Services.AddScoped<IDepartmentReposatory, DepartmentReposatory>();// here create object from DepartmentRepository
            builder.Services.AddScoped<IEmployeeReposatory,EmployeeReposatory>();// here create object from EmployeeReposatory


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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}