using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations();
    options.SwaggerDoc("v1",
        new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "Rainfall Api",
            Version = "1.0",
            Contact = new Microsoft.OpenApi.Models.OpenApiContact()
            {
                //Email = "jonathansalveuy@gmail.com",
                Name = "Sorted",
                Url = new Uri("https://www.sorted.com")
            },
            Description = "An API which provides rainfall reading data",



        });
    var filename = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
    var filepath = Path.Combine(AppContext.BaseDirectory, filename);
    options.IncludeXmlComments(filepath);
});


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseAuthorization();

app.MapControllers();

app.UseSwagger(options =>
{

    options.PreSerializeFilters.Add((swagger, httpReq) =>
    {
        swagger.Servers = new List<OpenApiServer>
        {

            new OpenApiServer
            {
                Url = "http://localhost:3000",
                Description = "Rainfall Api"
            }
        };
    });
});


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "1.0");
    options.RoutePrefix = string.Empty;
    options.DocumentTitle = "Rainfall API";
}
);

//Map endpoints
//app.MapGet("/alerts", async () => Results.Ok()).WithTags("Alerts");
app.Run();
