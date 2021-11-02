using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SEDC.WebApi.NotesApp.DataAccess;
using SEDC.WebApi.NotesApp.DataAccess.Adonet;
using SEDC.WebApi.NotesApp.DataAccess.Dapper;
using SEDC.WebApi.NotesApp.DataAccess.EntityFramework;
using SEDC.WebApi.NotesApp.DataModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.WebApi.NotesApp.Services.Helpers
{
    public static class DiModule
    {
        public static IServiceCollection RegisterModule(
            IServiceCollection services,
            string connectionString)
        {
            // registering db context
            services.AddDbContext<NotesDbContext>(x =>
            x.UseSqlServer(connectionString));

            // register repositories

            // entity framework
            services.AddTransient<IRepository<User>, UserRepository>();
            services.AddTransient<IRepository<Note>, NoteRepository>();

            //// adonet repos
            //services.AddTransient<IRepository<User>>
            //    (x => new AdoUserRepository(connectionString));

            // dapper repos
            //services.AddTransient<IRepository<User>>
            //      (x => new DapperUserRepository(connectionString));
            return services;
        }
    }
}
