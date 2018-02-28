using System.IO;
using GameServices.Domain.GamesContext.Handlers;
using GameServices.Domain.GamesContext.Repositories;
using GameServices.Infra.Contexts;
using GameServices.Infra.Repositories;
using GameServices.Infra.Transactions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Settings = GameService.Shared.Settings;

namespace GameService.API
{
    public class Startup
    {
        public Startup()
        {
        }

        public static IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            services.AddMvc();
            
            services.AddCors();
            
            services.AddResponseCompression();

            services.AddScoped<GameServiceContext, GameServiceContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IFriendRepository, FriendRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGameCompanyRepository, GameCompanyRepository>();
            services.AddTransient<IGameRepository, GameRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<FriendHandler, FriendHandler>();
            services.AddTransient<UserHandler, UserHandler>();
            services.AddTransient<GameCompanyHandler, GameCompanyHandler>();
            services.AddTransient<GameHandler, GameHandler>();
            
            Settings.ConnectionString = $"{Configuration["connectionString"]}";
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(x =>
            {
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowAnyOrigin();
            });

            app.UseMvc();
            app.UseResponseCompression();

            app.Run(async (context) => { await context.Response.WriteAsync("Hello World!"); });
        }
    }
}