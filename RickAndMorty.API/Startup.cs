using System.Net.Mime;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Middleware;
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

        services.AddTransient<ICharacterService, CharacterService>();
        services.AddTransient<IEpisodeService, EpisodeService>();
        services.AddTransient<ILocationService, LocationService>();

        services.AddHttpClient("apiClient",
            c =>
            {
                c.BaseAddress = new Uri(Configuration["BaseUrl"]);
                c.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
            });
        
        services.AddControllers();

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

        app.UseRouting();
        
        app.UseMiddleware<ExceptionMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();


        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
}