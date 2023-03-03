
global using static api.Data.Common.GlobalConst;
global using static api.Infrastructure.ErrorMessages;

using api.Infrastructure.Extensions;
using api.Infrastructure.Middlewares;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddAppDbContext(builder.Configuration)
    .AddAutoMapper(Assembly.GetExecutingAssembly())
    .AddApplicationServices()
    .AddControllers();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app
    .UseExceptionHandling(app.Environment)
    .UseValidationExceptionHandler()
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseRouting()
    .UseAnyCors()
    .UseEndpoints();

app.Run();
