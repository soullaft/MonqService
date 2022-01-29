using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MonqService.Extensions;
using MonqService.Map;
using MonqService.Services;

namespace MonqService
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        #region Constructor

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        #endregion
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_configuration);
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MonqService", Version = "v1" });
            });

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IEmailService, EmailService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MonqService v1"));
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
