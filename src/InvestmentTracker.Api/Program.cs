using InvestmentTracker.Application.Services;
using InvestmentTracker.Domain.Interfaces;
using InvestmentTracker.Infrastructure.Data;
using InvestmentTracker.Infrastructure.Fakes;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IAccountRepository, FakeAccountRepository>();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/total-invested", async (IPortfolioService portfolioService) =>
{
    var price = await portfolioService.GetTotalInvestedAmountAsync();
    return price;
});