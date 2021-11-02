using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.NotesApp.DataAccess;
using SEDC.WebApi.NotesApp.DataAccess.Adonet;
using SEDC.WebApi.NotesApp.DataModel;
using SEDC.WebApi.NotesApp.Services;
using SEDC.WebApi.NotesApp.Services.Helpers;
using SEDC.WebApi.NotesApp.Services.Interfaces;

namespace SEDC.WebApi.NotesApp.Api
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
            // get conection string
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            // register data access dependencies
            DiModule.RegisterModule(services, connectionString);

            // service registration
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<INoteService, NoteService>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
