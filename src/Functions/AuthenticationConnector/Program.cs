using AuthenticationConnector;
using BeforeSignUp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Omini.Opme.Be.Infrastructure;
using Omini.Opme.Be.Shared;
using Omini.Opme.Be.Shared.Interfaces;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults((worker) =>
    {
        worker.UseMiddleware<AuthenticationMiddleware>();
    })
    .ConfigureAppConfiguration((hostContext, builder) =>
    {
        builder.AddJsonFile("local.settings.json");
        builder.AddConfiguration(hostContext.Configuration);
        builder.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        var apiConnectorsOptions = hostContext.Configuration.GetSection("APIConnectors");
        services.Configure<ApiConnector>(apiConnectorsOptions);

        services.AddInfrastructure(hostContext.Configuration);
        services.AddScoped<IClaimsService, ClaimsService>();
    })
    .Build();

host.Run();
