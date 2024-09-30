using api.DB;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.EntityFrameworkCore;

var bld = WebApplication.CreateBuilder();
bld.Services.AddFastEndpoints();
bld.Services.SwaggerDocument(o =>
{
    o.DocumentSettings = s =>
    {
        s.Title = "My API";
        s.Version = "v1";
    };
});
var dbHost = "localhost";
var dbName = "BlogDB";
var dbPassword = "Pa$$w0rd1";

bld.Services.AddDbContext<Context>(opt => 
{
  opt.UseMySQL("user=root;password={dbPassword};server={dbHost};port=3306;database={dbName};");
});

var app = bld.Build();
app.UseFastEndpoints();
if(app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.Run();






// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// var app = builder.Build();

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// var summaries = new[]
// {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };

// app.MapGet("/weatherforecast", () =>
// {
//     var forecast =  Enumerable.Range(1, 5).Select(index =>
//         new WeatherForecast
//         (
//             DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//             Random.Shared.Next(-20, 55),
//             summaries[Random.Shared.Next(summaries.Length)]
//         ))
//         .ToArray();
//     return forecast;
// })
// .WithName("GetWeatherForecast")
// .WithOpenApi();

// app.Run();

// record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
// {
//     public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
// }
