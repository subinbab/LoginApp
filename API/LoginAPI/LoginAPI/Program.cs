using Core.AbstractModels.Login;
using Core.AbstractModels.User;
using Infrastructure.DB;
using Infrastructure.Login;
using Infrastructure.Project;
using Infrastructure.Register;
using LoginAPI.Controllers;
using LoginAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;
using System;
using System.Data.Entity;
using System.Text;
using UseCases.Login;
using UseCases.Register;
using UseCases.Response;
using UseCases.UseCases.ProjectOperation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuraion = builder.Configuration;

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(configuraion.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IUseCasesProjectOperations, UseCasesProjectOperations>();
builder.Services.AddScoped<IProjectOperation, ProjectOperation>();
builder.Services.AddEndpointsApiExplorer();
var appSettingsSection = configuraion.GetSection("ServiceConfiguration");
builder.Services.Configure<ServiceConfiguration>(appSettingsSection);

// configure jwt authentication
var serviceConfiguration = appSettingsSection.Get<ServiceConfiguration>();
var JwtSecretkey = Encoding.ASCII.GetBytes(serviceConfiguration.JwtSettings.Secret);


builder.Services.AddSwaggerGen(options =>
{
  options.SwaggerDoc("v1", new OpenApiInfo
  {
    Version = "v1",
    Title = "ToDo API",
    Description = "An ASP.NET Core Web API for managing ToDo items",
    TermsOfService = new Uri("https://example.com/terms"),
    Contact = new OpenApiContact
    {
      Name = "Example Contact",
      Url = new Uri("https://example.com/contact")
    },
    License = new OpenApiLicense
    {
      Name = "Example License",
      Url = new Uri("https://example.com/license")
    }
  });
});
builder.Services.AddScoped<IRegisterOperations, RegisterOperations>();
builder.Services.AddScoped<IRegisterUser, Infrastructure.Register.Register>();
builder.Services.AddScoped<ILoginOperations<ResponseData<UserLogin>>, LoginOperations>();
builder.Services.AddScoped<ILogin, Login>();
builder.Services.AddCors(options =>
{
  options.AddPolicy(name: "AllowedCorsOrigins",
      builder =>
      {
        builder
        .WithOrigins("http://localhost:4200")  // Allow requests from your Angular app's URL
                      .AllowAnyHeader()
                      .AllowAnyMethod()
                      .AllowCredentials();
      });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}
app.UseCors("AllowedCorsOrigins");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI(c =>
{
  c.SwaggerEndpoint("/swagger/v1/swagger.json", "Values Api V1");
});

app.Run();
