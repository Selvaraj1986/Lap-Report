using Microsoft.EntityFrameworkCore;
using Report.Entity;
using Report.Repository.Interfaces;
using Report.Repository.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IPatientDetailRepository, PatientDetailRepository>();
builder.Services.AddScoped<ITypeOfTestRepository, TypeOfTestRepository>();
builder.Services.AddScoped<ITestResultRepository, TestResultRepository>();
builder.Services.AddScoped<ITestReportRepository, TestReportRepository>();
builder.Services.AddScoped<IGenerateReportRepository, GenerateReportRepository>();
builder.Services.AddEndpointsApiExplorer();

//Add model data's into InMomeryDatabase
builder.Services.AddDbContext<DBContext>(options =>
    options.UseInMemoryDatabase("DBLabReports"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
