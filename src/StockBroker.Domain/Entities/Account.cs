namespace StockBroker.Domain.Entities;

public class Account
{
    public Guid Id { get; private set; }
    public decimal Balance { get; private set; }

    public Account(decimal balance)
    {
        Id = Guid.NewGuid();
        Balance = balance;
    }

    public void DebitBalance(decimal amount) => Balance -= amount;
}