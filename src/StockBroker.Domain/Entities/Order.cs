using System;
using StockBroker.Domain.Enums;

namespace StockBroker.Domain.Entities;

public class Order
{
    public Guid Id { get; private set;}
    public string Ticker { get; private set;}
    public int Quantity { get; private set;}
    public decimal Price { get; private set;}
    public OperationStrategy Strategy { get; private set;}

    private Order(string ticker, int quantity, decimal price, OperationStrategy strategy)
    {
        Id = Guid.NewGuid();
        Ticker = ticker;
        Quantity = quantity;
        Price = price;
        Strategy = strategy;
    }

    public static Order Create(string ticker, int quantity, decimal price, OperationStrategy strategy)
    {
        bool isFractional = ticker.EndsWith("F", StringComparison.OrdinalIgnoreCase);

        if (!isFractional && quantity % 100 != 0)
        {
            throw new ArgumentException("Quantity must be a multiple of 100 for non-fractional stocks.");
        }
        if (isFractional && (quantity < 1 || quantity > 99))
        {
            throw new ArgumentException("Quantity must be a multiple of 100 for non-fractional stocks.");       
        }
        return new Order(ticker, quantity, price, strategy);
    }
}