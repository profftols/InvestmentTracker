using InvestmentTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentTracker.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Account> Accounts { get; private set; }
}