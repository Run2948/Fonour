using Fonour.MVC;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddLog4Net();
    });

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);

app.Run();
