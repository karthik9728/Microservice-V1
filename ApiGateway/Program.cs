using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

//Json Configure File for Ocelot API Gateway
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json",optional:false,reloadOnChange:true)
    .AddEnvironmentVariables();

//Ocelot Config
builder.Services.AddOcelot(builder.Configuration);



var app = builder.Build();

await app.UseOcelot();

app.Run();
