using Application.Contracts.Repositories;
using Domain.AccountManagement.AggragateRoot;
using Infrastructure.Persistence;

namespace Infrastructure.Accounts;

internal class AccountRepository(ApplicationDbContext context) : IAccountRepository
{
    public void Add(Account account)
    {
        context.Add(account);
    }
}