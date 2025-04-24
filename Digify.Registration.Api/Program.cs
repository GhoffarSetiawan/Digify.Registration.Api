using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Digify.Registration.Api;
using Digify.Registration.Api.Routes;
using Digify.Registration.Application;
using Digify.Registration.Application.Models;
using Digify.Registration.Application.SelectParameters;
using Digify.Registration.Application.Services;
using Digify.Registration.Application.UseCases.Companies;
using Digify.Registration.Core.Entities;
using Digify.Registration.Core.Validators;
using Digify.Registration.Infrastructure.Repositories;
using Digify.Registration.Infrastructure.UnitOfWorks;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Add Services
builder.Services.AddScoped<IBusinessRepository<CompanyApplicationModel>, CompanyRepository>();

// Add Unit Of Work
builder.Services.AddScoped<IUnitOfWork<CompanyApplicationModel>, CompanyUnitOfWork>();

// Add Use Cases
builder.Services.AddScoped<IUseCase<Guid, CompanyApplicationModel>, FindCompanyUseCase>();
builder.Services.AddScoped<IUseCase<CompanySelectParameter, SelectResult<CompanyApplicationModel>>, SearchCompanyUseCase>();
builder.Services.AddScoped<IUseCase<DeleteParameter, bool>, DeleteCompanyUseCase>();
builder.Services.AddKeyedScoped<IUseCase<CompanyApplicationModel, bool>, CreateCompanyUseCase>(AppConst.SERVICE_KEY_CREATE);
builder.Services.AddKeyedScoped<IUseCase<CompanyApplicationModel, bool>, UpdateCompanyUseCase>(AppConst.SERVICE_KEY_UPDATE);


// Add Validator
builder.Services.AddScoped<IValidator<Company>, CompanyValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();


//Mapping Route
CompanyRoute.Map(app);

app.Run();

