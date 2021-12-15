using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scout.Application;
using Scout.Application.Common.Services;
using Scout.Infrastructure;
using Scout.Infrastructure.Common.UserServices;
using Scout.Infrastructure.EF;
using Scout.WebAPI.Extensions;
using Scout.WebAPI.Filters;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services for getting httpContext
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.TryAddScoped(typeof(ICurrentUserService), typeof(CurrentUserService));

//Add services from layers
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure(builder.Configuration);

// Add API services
builder.Services.AddSwaggerConfig();


builder.Services.AddControllers(opt =>
{
    opt.Filters.Add(new ApiExceptionFilterAttribute());
    
}).AddFluentValidation();

//Default Data Annotation validation response
builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    //Custom response from ModelValidation
    opt.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .ToDictionary(a => a.Key, a => a.Value?.Errors.Select(b => b.ErrorMessage).ToArray());

        return new BadRequestObjectResult(new
        {
            Title = "One or more validation failures have occurred",
            StatusCode = 400,
            Errors = errors
        });
    };
});

//Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});



builder.Services.AddEndpointsApiExplorer();

builder.WebHost.UseSerilog();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Scout.WebAPI v1"));

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

try
{
    Log.Information("Application starting up");
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Unable to run application");
}
finally
{
    Log.CloseAndFlush();
}