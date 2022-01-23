using DanBloodworth_PortfolioService.Providers;
using DanBloodworth_PortfolioService.Services;
using DanBloodworth_PortfolioService.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DanBloodworth_PortfolioService
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
            AddGitHubClientOptions(services);
            AddGitHubClientFactory(services);
            
            AddProjectServiceOptions(services);
            
            services.AddTransient<IProjectService, ProjectService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "DanBloodworth_PortfolioService", Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(
                    c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DanBloodworth_PortfolioService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void AddProjectServiceOptions(IServiceCollection services)
        {
            services.AddOptions<ProjectServiceSettings>().Bind(Configuration.GetSection("ApiAccess"));
        }

        private void AddGitHubClientOptions(IServiceCollection services)
        {
            services.AddOptions<GitHubClientSettings>().Bind(Configuration.GetSection("GitHubClient"));
        }

        private void AddGitHubClientFactory(IServiceCollection services)
        {
            services.AddTransient<IGitHubClientFactory, GitHubClientFactory>();
        }
    }
}