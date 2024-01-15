using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Geprofs3.Data;
using Microsoft.AspNetCore.Identity;
namespace Geprofs3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<Geprofs3Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Geprofs3Context") ?? throw new InvalidOperationException("Connection string 'Geprofs3Context' not found.")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<Geprofs3Context>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddAuthorization(options =>
                options.AddPolicy("Admin", policy =>
                    policy.RequireAuthenticatedUser()
                        .RequireClaim("IsAdmin", bool.TrueString)));

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
            app.MapRazorPages();

            app.Run();
        }
    }
}