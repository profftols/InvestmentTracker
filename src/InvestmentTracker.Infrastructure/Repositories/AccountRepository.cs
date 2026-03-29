using InvestmentTracker.Domain.Interfaces;
using InvestmentTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace InvestmentTracker.Infrastructure.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly ApplicationDbContext _context;

    public AccountRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<decimal> GetTotalInvestedAsync()
    {
        return await _context.Accounts.SumAsync(account => account.TotalInvested.Value);
    }
}