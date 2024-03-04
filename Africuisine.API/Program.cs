using Africuisine.Application.Data.Config;
using Africuisine.Application.Extensions;
using Africuisine.Infrastructure.Extensions;
using Africuisine.API.Extensions;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddAPIAutoMappingAndFluentValidation();
builder.Services.AddAPIUserDbContext(builder.Configuration);
builder.Services.AddAPIDefaultDbContext(builder.Configuration);
builder.Services.AddAPIAuthentication(builder.Configuration);

//Add Custom API Repositories To The Container

//Add Custom API Services To The Container
builder.Services.AddAPIApplicationServices();
builder.Services.AddAPIInfrastructureServices();

//Adding Configuration Options
builder.Services.Configure<PostmarkConfig>(builder.Configuration.GetSection("Postmark"));
builder.Services.Configure<JwtConfig>(builder.Configuration.GetSection("JWT"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAPISwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
