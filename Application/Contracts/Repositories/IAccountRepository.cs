using Domain.AccountManagement.AggragateRoot;

namespace Application.Contracts.Repositories;

public interface IAccountRepository
{
    void Add(Account account);
}