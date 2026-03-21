using InvestmentTracker.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvestmentTracker.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Account> Accounts { get; set; }
}