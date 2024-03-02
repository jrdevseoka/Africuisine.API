using NLog;
using Africuisine.API.Extensions;

var Logger = LogManager.Setup().LoadConfigurationFromFile("NLog.config").GetCurrentClassLogger();
try
{

    var builder = WebApplication.CreateBuilder(args);

    //Adding Custom API Services to the container.

    // Add Build-in services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddAPIVersioning();
    builder.Services.AddSwaggerGeneration();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch(Exception exception)
{
    Logger.Error(exception);
}
finally {
    LogManager.Shutdown();
}