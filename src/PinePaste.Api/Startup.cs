using MediatR;
using Microsoft.EntityFrameworkCore;
using PinePaste.Api.ModelBinders;
using PinePaste.Application.Pastes.Commands.CreatePaste;
using PinePaste.Core.Interfaces;
using PinePaste.Infrastructure.Data;
using PinePaste.Infrastructure.Repositories;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers(options =>
        {
            options.ModelBinderProviders.Insert(0, new GetPasteQueryModelBinderProvider());
        });

        // Configure in-memory database
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseInMemoryDatabase("PinePasteDb"));

        // Register the repository
        services.AddScoped<IPasteRepository, PasteRepository>();

        // Add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreatePasteCommandHandler).Assembly));

        // Add other necessary services here
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}