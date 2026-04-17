using InvestmentTracker.Domain.Interfaces;

namespace InvestmentTracker.Infrastructure.Fakes;

public class FakeAccountRepository : IAccountRepository
{
    public async Task<decimal> GetTotalInvestedAsync()
    {
        await Task.Delay(100);

        return 15000.50m;
    }
}