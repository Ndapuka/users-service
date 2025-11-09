using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json.Serialization;
using eCommerce.Core.Mappers;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

//Add controllers to the service colletion
builder.Services.AddControllers().AddJsonOptions(options => 
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

//Add AutoMapper, the type is the type of the mapping profile existing in the Core project
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);

//FluentValidations datect all validation in the Core project
builder.Services.AddFluentValidationAutoValidation();

//add API explorer services
builder.Services.AddEndpointsApiExplorer();

//Add Swagger generation services to create swagger especification
builder.Services.AddSwaggerGen();


var allowedOrigins = new[] { "http://localhost:4200" };
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularLocalhost", builder =>
    {
        builder.WithOrigins(allowedOrigins)
               .AllowAnyHeader()
               .AllowAnyMethod()
               .AllowCredentials()
               .SetIsOriginAllowed(origin => true); // for dev;
    });
});

var app = builder.Build();

app.UseExceptionHandlingMiddleware();

//cors
app.UseCors("AllowAngularLocalhost");



//Routing
app.UseRouting();



//Auth
//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger(); //Adds endpoint that can serve the swagger.json
app.UseSwaggerUI(); //Adds swagger UI (interactive page to explore and test API endpoints)
//Controllers router
app.MapControllers();

app.Run();
