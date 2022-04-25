using System.Net.Mime;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Services;

namespace RickAndMorty.API;

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
        services.AddAutoMapper(typeof(AutoMapperProfile));
        
        services.AddScoped<ICharacterService, CharacterService>();
        
        services.AddHttpClient("apiClient",
            c =>
            {
                c.BaseAddress = new Uri(Configuration["BaseUrl"]);
                c.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
            });
        
        services.AddControllers();
        
        //convert Enums to Strings (instead of Integer) globally
        JsonConvert.DefaultSettings = (() =>
        {
            var settings = new JsonSerializerSettings();
            settings.Converters.Add(new StringEnumConverter { CamelCaseText = true });
            return settings;
        });
        
        services.AddEndpointsApiExplorer();
        
        services.AddSwaggerGen();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DU.User.Api v1"));
        }

        app.UseHttpsRedirection();
        
        app.UseAuthorization();
        
        app.UseRouting();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

   
}