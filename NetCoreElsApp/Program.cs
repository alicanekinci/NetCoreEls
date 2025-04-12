using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://localhost:9200"))
    {
        AutoRegisterTemplate = true,
        IndexFormat = "netcore-serilog-{0:yyyy.MM}"
    })
    .CreateLogger();

var host = Host.CreateDefaultBuilder()
    .UseSerilog() // Microsoft ILogger -> Serilog
    .ConfigureServices((context, services) =>
    {
        services.AddTransient<MyService>();
    })
    .Build();

var svc = host.Services.GetRequiredService<MyService>();
svc.Run();

Log.CloseAndFlush();
