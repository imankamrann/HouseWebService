using Microsoft.OpenApi.Models;
using RealEstate.DB;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "MarketPlace API", Description = "Selling the things you love", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "MarketPlace API V1");
    });
}


app.MapGet("/", () => "Hello World!");

app.MapGet("/properties/{id}", (int id) => PropertyDB.GetProperty(id));
app.MapGet("/properties", () => PropertyDB.GetProperties());
app.MapPost("/properties", (Property property) => PropertyDB.CreateProperty(property));
app.MapPut("/properties", (Property property) => PropertyDB.UpdateProperty(property));
app.MapDelete("/properties/{id}", (int id) => PropertyDB.RemoveProperty(id));

app.Run();
