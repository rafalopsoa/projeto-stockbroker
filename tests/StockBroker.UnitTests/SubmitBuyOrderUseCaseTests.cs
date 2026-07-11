using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using Xunit;

using StockBroker.Domain;
using StockBroker.Domain.Entities;
using StockBroker.Domain.Enums;
using StockBroker.Application.UseCases;

namespace StockBroker.UnitTests;

public class SubmitBuyOrderUseCaseTests
{
    [Fact]
    public async Task Deve_Rejeitar_Ordem_Position_Se_Saldo_Total_For_Insuficiente()
    {
        var accountRepoMock = new Mock<IAccountRepository>();
        var account = new Account(balance: 1000m);

        accountRepoMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>())).ReturnsAsync(account);

        var useCase = new SubmitBuyOrderUseCase(accountRepoMock.Object);
        var command = new SubmitBuyOrderCommand("PETR4", Quantity: 100, Price: 25m, OperationStrategy.Position);

        Func<Task> action = async () => await useCase.ExecuteAsync(command);

        await action.Should().ThrowAsync<InvalidOperationException>()
            .WithMessage("Saldo insuficiente para cobrir o valor total de R$ 2500.");

    }
}