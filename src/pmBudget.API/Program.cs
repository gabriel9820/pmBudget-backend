using Microsoft.AspNetCore.Mvc;
using pmBudget.API.Middlewares;
using pmBudget.API.Responses;
using pmBudget.API.Services;
using pmBudget.Application.Interfaces;
using pmBudget.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = (context) => new BadRequestObjectResult(new pmBudgetInvalidModelStateResponse(context));
});

builder.Services.AddScoped<ILoggedInUserService, LoggedInUserService>();

builder.Services.AddInfrastructure(builder.Configuration)
    .AddRepositories()
    .AddServices()
    .AddAutoMapper()
    .AddApplicationServices();

builder.Services.AddCors(options =>
{
    options.AddPolicy("development", policy =>
        policy
        .WithOrigins("http://localhost:3000")
        .AllowAnyMethod()
        .AllowAnyHeader()
    );
});

var app = builder.Build();

// Configure the HTTP request pipeline.
/* Provisório para funcionar o Swagger no DOCKER */
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseCors("development");
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
