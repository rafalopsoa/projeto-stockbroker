using System;
using System.Threading.Tasks;
using StockBroker.Domain;
using StockBroker.Domain.Entities;
using StockBroker.Domain.Enums;

namespace StockBroker.Application.UseCases;

public class SubmitBuyOrderUseCase
{
    private readonly IAccountRepository _accountRepository;

    public SubmitBuyOrderUseCase(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task ExecuteAsync(SubmitBuyOrderCommand command)
    {
        var account = await _accountRepository.GetByIdAsync(command.AccountId);

        decimal requiredMargin = command.Strategy switch
        {
            OperationStrategy.Position => command.Quantity * command.Price,
            OperationStrategy.DayTrade => (command.Quantity * command.Price) * 0.05m,
            _ => throw new NotSupportedException("Estratégia de operação não suportada..")
        };

        if (account.Balance < requiredMargin)
        {
            throw new InvalidOperationException($"Saldo insuficiente para cobrir o valor total de R$ {requiredMargin}.");

        }
        
            var order = Order.Create(command.Ticker, command.Quantity, command.Price, command.Strategy);

            account.DebitBalance(requiredMargin);
            await _accountRepository.SaveAsync(account);
    }
}