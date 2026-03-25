using InvestmentTracker.Application.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<PortfolioService>();

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
})
.WithName("GetTotalInvestedAmount");


app.Run();