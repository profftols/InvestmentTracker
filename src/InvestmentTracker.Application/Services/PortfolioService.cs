using InvestmentTracker.Domain.Interfaces;

namespace InvestmentTracker.Application.Services;

public class PortfolioService
{
    private readonly IAccountRepository _repository;

    public PortfolioService(IAccountRepository repository)
    {
        _repository = repository;
    }

    public async Task<decimal> GetTotalInvestedAmountAsync()
    {
        return await _repository.GetTotalInvestedAsync();
    }
}