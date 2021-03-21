using BPT.Test.ANG.BackEnd.API.Models;
using BPT.Test.ANG.BackEnd.BusinessLayer.School;
using BPT.Test.ANG.BackEnd.DataAccess;
using BPT.Test.ANG.BackEnd.DataAccess.DAO.School;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BPT.Test.ANG.BackEnd.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IBusStudent, BusStudent>();
            services.AddTransient<IBusAssignment, BusAssignment>();
            services.AddTransient<IDatStudent, DatStudent>();
            services.AddTransient<IDatAssignment, DatAssignment>();
            var connection = @"Server=LAPTOP-D0I9JI4S; Database=BTPAGC;ConnectRetryCount=0;User ID=sa;Password=ditec066";
            services.AddDbContext<SchoolContext>(option => option.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
