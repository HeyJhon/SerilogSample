using Serilog;
using WorkerServiceSeriLog;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

//var logger = new LoggerConfiguration()
//.WriteTo.Console()
//.CreateLogger();

//var logger = new LoggerConfiguration()
//    .MinimumLevel.Debug()
//    .WriteTo.File(Path.Combine("Logs", "MyApp-.log"),
//        rollingInterval: RollingInterval.Day,
//        outputTemplate: "[{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level}] {Message}{NewLine}{Exception}")
//    .CreateLogger();

var logger = new LoggerConfiguration()
                .ReadFrom
                .Configuration(builder.Configuration)
                .CreateLogger();

builder.Logging.AddSerilog(logger);

var host = builder.Build();
host.Run();
