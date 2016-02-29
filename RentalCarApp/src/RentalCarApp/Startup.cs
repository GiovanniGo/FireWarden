
using Microsoft.AspNet.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;

namespace RentalCarApp
{
    public class Startup
    {
        private IApplicationEnvironment appEnv;

        public Startup(IApplicationEnvironment appEnv)
        {
            this.appEnv = appEnv;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddEntityFramework().AddSqlite().
                AddDbContext<Models.CarsAppContext>(options =>
                    options.UseSqlite($"Data Source={appEnv.ApplicationBasePath}/carData.db"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseIISPlatformHandler();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

    }
}
