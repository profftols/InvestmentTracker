using InvestmentTracker.Application.Services;
using InvestmentTracker.Domain.Interfaces;
using InvestmentTracker.Infrastructure.Data;
using InvestmentTracker.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<PortfolioService>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<ApplicationDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/total-invested", (PortfolioService portfolioService) =>
{
    return portfolioService.GetTotalInvestedAmountAsync();
});