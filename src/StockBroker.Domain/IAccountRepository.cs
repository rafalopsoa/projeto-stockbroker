using System;
using System.Threading.Tasks;
using StockBroker.Domain.Entities;

namespace StockBroker.Domain;

public interface IAccountRepository
{
    Task<Account> GetByIdAsync(Guid id);
    Task SaveAsync(Account account);
}