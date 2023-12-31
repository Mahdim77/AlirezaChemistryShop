using BlogManagement.Infrastracture.Config;
using CustomFramework.Presentation;
using ShopManagement.Infrastructure.Bootstrapper;

namespace ServiceHost
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            var connectionstring = builder.Configuration.GetConnectionString("ChemistryShop");
            ShopManagementBootstrapper.Configure(builder.Services, connectionstring);
            BlogManagementBootstrapper.Configure(builder.Services, connectionstring);
            builder.Services.AddScoped<IFileUploader,FileUploader>();


            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();
            app.MapDefaultControllerRoute();

            app.Run();
        }
    }
}
