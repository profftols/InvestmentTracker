namespace InvestmentTracker.Domain;

public class PortfolioSnapshot
{
    public Guid Id { get; private set; }
    public Guid AccountId { get; private set; }
    public decimal TotalValue { get; private set; }
    public DateTime Date { get; private set; }
}