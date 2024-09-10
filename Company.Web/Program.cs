using Company.Data.Context;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Repository.Repository;
using Company.Service.InterFaces;
using Company.Service.Mapping;
using Company.Service.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Company.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CompanyDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
            });
            //builder.Services.AddScoped<IDepartmentRepsoitory,DepartmentReposoitory>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IDepartment, DepartmentService>();
            builder.Services.AddScoped<IEmployee, EmployeeServices>();

            builder.Services.AddAutoMapper(x => x.AddProfile(new EmployeeProfile()));
            builder.Services.AddAutoMapper(x => x.AddProfile(new DepartmentProfile()));
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Config => {
                Config.Password.RequiredUniqueChars = 1;
                Config.Password.RequireDigit = true;
                Config.Password.RequireLowercase = true;
                Config.Password.RequireUppercase = true;
                Config.Password.RequireNonAlphanumeric = true;
                Config.Password.RequiredLength = 6;
                Config.User.RequireUniqueEmail = true;
                Config.Lockout.AllowedForNewUsers = true;
                Config.Lockout.MaxFailedAccessAttempts = 3;
                Config.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(1);



            
            }).AddEntityFrameworkStores<CompanyDBContext>().AddDefaultTokenProviders();
                 builder.Services.ConfigureApplicationCookie(options => {
                 options.Cookie.HttpOnly = true;
                 options.SlidingExpiration = true;
                 options.LoginPath = "/Acount/Login";
                 options.LogoutPath = "/Acount/Logout";
                 options.AccessDeniedPath = "/Acount/AccessDenied";


            });
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
            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
