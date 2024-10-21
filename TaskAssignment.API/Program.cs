using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;
using System.Net;
using Hidrolik.API.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen();
builder.Services.JwtServiceCollection();
builder.Services.ApplicationServiceConfigurations();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder
            .AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(options =>
{
    options.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var exceptionObject = context.Features.Get<IExceptionHandlerFeature>();
        if (exceptionObject != null)
        {
            var errorMessage = new { error = exceptionObject.Error.Message };
            var errorJson = JsonConvert.SerializeObject(errorMessage);
            await context.Response.WriteAsync(errorJson).ConfigureAwait(false);
        }
    });
});

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
