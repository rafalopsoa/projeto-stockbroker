using System;
using StockBroker.Domain.Enums;

namespace StockBroker.Application.UseCases;

public record SubmitBuyOrderCommand
(
    string Ticker,
    int Quantity,
    decimal Price,
    OperationStrategy Strategy,
    Guid AccountId = default
);