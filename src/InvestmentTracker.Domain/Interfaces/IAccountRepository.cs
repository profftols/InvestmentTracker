using InvestmentTracker.Domain.Entities;

namespace InvestmentTracker.Domain.Interfaces;

public interface IAccountRepository
{
    Task<IEnumerable<Account>> GetAll();
    Task<decimal> GetTotalInvestedAsync();
}