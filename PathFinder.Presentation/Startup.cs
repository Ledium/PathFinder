using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PathFinder.DataAccess;
using PathFinder.Presentation.Requests;
using PathFinder.Presentation.Validators;
using PathFinder.Service.PathFinderService;

namespace PathFinder.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
          
            services.AddScoped<IPathService, PathService>();

            services.AddScoped<IPathRepository, PathRepository>();

            services
                .AddMvc()
                .AddFluentValidation(fv => { });

            services.AddTransient<IValidator<PathCreateRequest>, PathCreateRequestValidator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
