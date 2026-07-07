using Course.CloudNativeDev.Api.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//here we setup the Serilog logging provider to read from the appsettings.json file
builder.Host.UseSerilog((context, configuration) =>
{
    configuration.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// using var scope = app.Services.CreateScope();
// var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
// dbContext.Database.Migrate();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();