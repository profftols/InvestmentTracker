namespace InvestmentTracker.Domain.Entities;

public class PortfolioSnapshot
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public DateTime Date { get; private set; }
    public decimal TotalValue { get; private set; }

    public PortfolioSnapshot(Guid accountId, decimal totalValue)
    {
        AccountId = accountId;
        TotalValue = totalValue;
        Date = DateTime.UtcNow;
        Id = Guid.NewGuid();
    }
}