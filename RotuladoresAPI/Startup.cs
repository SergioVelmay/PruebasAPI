using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using AutoMapper;
using RotuladoresDomain.Mappers;
using RotuladoresDomain.Repositories;
using RotuladoresDomain.Services;
using RotuladoresInfrastructure.Repositories;
using RotuladoresInfrastructure.Context;
using RotuladoresInfrastructure.Mongo;

namespace RotuladoresAPI
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
            services.Configure<MongoDatabaseSettings>(
                Configuration.GetSection(nameof(MongoDatabaseSettings)));

            services.AddSingleton<IMongoDatabaseSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDatabaseSettings>>().Value);

            var mappingConfig = new MapperConfiguration(mapperConfiguration =>
                mapperConfiguration.AddProfile(new RotuladorMapper()));

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IRotuladorContext, RotuladorContext>();

            services.AddScoped<IRotuladorRepository, RotuladorRepository>();

            services.AddScoped<IRotuladorService, RotuladorService>();

            services.AddControllers();

            services.AddAuthentication("Bearer")
            .AddJwtBearer("Bearer", options =>
            {
                options.Authority = "http://localhost:5000";

                options.RequireHttpsMetadata = false;

                options.Audience = "rotuladores";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
