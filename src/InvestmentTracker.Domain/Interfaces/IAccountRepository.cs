using InvestmentTracker.Domain.Entities;

namespace InvestmentTracker.Domain.Interfaces;

public interface IAccountRepository
{
    Task<decimal> GetTotalInvestedAsync();
}