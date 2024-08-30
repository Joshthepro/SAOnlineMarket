using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SAOnlineMart.Models;

public class Startup
{
    private readonly IConfiguration _configuration;

    // Constructor to initialize the configuration
    public Startup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // Method to configure services for dependency injection
    public void ConfigureServices(IServiceCollection services)
    {
        // Register the database context with SQL Server provider and connection string from configuration
        services.AddDbContext<SAOnlineMartContext>(options =>
            options.UseSqlServer(_configuration.GetConnectionString("DefaultConnection")));

        // Register default identity services with email confirmation required for account sign-in
        services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<SAOnlineMartContext>();

        // Register services for controllers with views and Razor Pages
        services.AddControllersWithViews();
        services.AddRazorPages();

        // Add session support to the application
        services.AddSession();
    }

    // Method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            // Show developer exception page in development environment
            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage(); // Shows database-related errors in development
        }
        else
        {
            // Handle exceptions in production and use HSTS for security
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        // Redirect HTTP requests to HTTPS
        app.UseHttpsRedirection();
        app.UseStaticFiles(); // Serve static files (like CSS, JavaScript)

        app.UseRouting(); // Add routing middleware to the pipeline

        app.UseAuthentication(); // Add authentication middleware to the pipeline
        app.UseAuthorization();  // Add authorization middleware to the pipeline

        app.UseSession(); // Add session middleware to the pipeline

        app.UseEndpoints(endpoints =>
        {
            // Define the default route pattern
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Map Razor Pages endpoints
            endpoints.MapRazorPages();
        });
    }
}
