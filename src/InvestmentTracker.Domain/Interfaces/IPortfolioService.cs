namespace InvestmentTracker.Domain.Interfaces;

public interface IPortfolioService
{
    Task<decimal> GetTotalInvestedAmountAsync();
}