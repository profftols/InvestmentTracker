namespace InvestmentTracker.Domain.ValueObjects;

public readonly struct Money(decimal value, string currency)
{
    public decimal Value { get; } = value;
    public string Currency { get; } = currency.ToUpperInvariant();

    public static Money operator +(Money left, Money right)
    {
        if (left.Currency != right.Currency)
        {
            throw new InvalidOperationException(
                $"Cannot add {right.Currency} to {left.Currency}. Currencies must match");
        }
        
        return new Money(left.Value + right.Value, left.Currency);
    }
    
    public static Money operator -(Money left, Money right)
    {
        if (left.Currency != right.Currency)
            throw new InvalidOperationException($"Cannot subtract {right.Currency} from {left.Currency}.");
        
        return new Money(left.Value - right.Value, left.Currency);
    }
}