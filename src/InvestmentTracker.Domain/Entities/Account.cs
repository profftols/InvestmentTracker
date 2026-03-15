using InvestmentTracker.Domain.Enums;
using InvestmentTracker.Domain.ValueObjects;

namespace InvestmentTracker.Domain.Entities;

public class Account
{
    private Account(){}
    
    public Account(string name, AccountType type, Money money)
    {
        Id = Guid.NewGuid();
        Name = name;
        Type = type;
        CurrentBalance = money;
        TotalInvested = money;
        CreatedAt = DateTime.UtcNow;
    }

    public DateTime CreatedAt { get; private set; }
    public Guid Id { get; private set; }
    public string Name { get; private set;}
    public AccountType Type { get; private set; }
    public Money CurrentBalance { get; private set; }
    public Money TotalInvested { get; private set; }
    public DateTime? UpdatedAt { get; private set; }

    public void Deposit(Money money)
    {
        if (money.Value < 0)
            throw new InvalidOperationException($"Failed to add {money.Value} because there are not enough or they are zero.");
        
        CurrentBalance += money;
        TotalInvested += money;
        UpdatedAt = DateTime.UtcNow;
    }

    public void Withdraw(Money money)
    {
        if (money.Value <= 0)
            throw new InvalidOperationException($"Cannot withdraw zero or negative amount of {money.Value}");

        if (money.Value > CurrentBalance.Value)
            throw new InvalidOperationException($"It is impossible to withdraw more than the amount on the balance.");
        
        CurrentBalance -= money;
        TotalInvested -= money;
        UpdatedAt = DateTime.UtcNow;
    }
}