using System.Net.Mime;
using Autofac;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using RickAndMorty.Application.Abstraction.IServices;
using RickAndMorty.Application.Common;
using RickAndMorty.Application.Services;
using RickAndMorty.Net.Api.DI;

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
        
        services.AddTransient<IRickAndMortyApi, RickAndMortyApiProxy>();
        
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

    public void ConfigureContainer(ContainerBuilder builder)
    {
        // Add any Autofac modules or registrations.
        // This is called AFTER ConfigureServices so things you
        // register here OVERRIDE things registered in ConfigureServices.
        //
        // You must have the call to AddAutofac in the Program.Main
        // method or this won't be called.
        builder.RegisterModule(new RickAndMortyModule());
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