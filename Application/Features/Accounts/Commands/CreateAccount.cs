using Application.Common;
using Application.Contracts.Repositories;
using Domain.AccountManagement.AggragateRoot;
using Domain.AccountManagement.ValueObjects;
using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;

namespace Application.Features.Accounts.Commands;

public record CreateAccountCommand(string Username, string Email, string FirstName, string LastName) : ICommand<Result<Guid>>;

public class CreateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateAccountCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(CreateAccountCommand command, CancellationToken cancellationToken)
    {
        var accountId = AccountId.Create();
        var account = Account.Create(accountId, command.Username, command.Email, command.FirstName, command.LastName);
        
        accountRepository.Add(account);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<Guid>.Success(accountId);
    }
}