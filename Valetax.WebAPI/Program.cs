using System.Reflection;
using Microsoft.OpenApi.Models;
using Valetax.Infrastructure.Contracts;
using Valetax.Infrastructure.Services;
using Valetax.WebAPI.Middlewares;

#region BUILDER

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region SWAGGER

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Valetax API",
        Description = "An ASP.NET Core Web API for managing Tree items"
    });

    options.EnableAnnotations();

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

#endregion


#region SERVICES

builder.Services.AddScoped<IUSerRememberMe, UserRememberMe>();
builder.Services.AddScoped<ITreeService, TreeService>();
builder.Services.AddScoped<ITreeNodeService, TreeNodeService>();
builder.Services.AddScoped<IJournalService, JournalService>();
builder.Services.AddTransient<IErrorHandleService, ErrorHandleService>();

#endregion

#region APP

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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

#endregion