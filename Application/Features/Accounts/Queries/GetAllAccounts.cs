using Application.Common;
using Application.Contracts.Queries;
using Application.Features.Accounts.DTOs;
using Venly.Dispatch.Interfaces;
using Venly.Dispatch.Interfaces.Messaging;

namespace Application.Features.Accounts.Queries;

public record GetAllAccountsQuery() : IQuery<Result<IReadOnlyList<AccountDTO>>>;

public class GetUsersRequiringSyncHandler(IAccountQueries accountQueries)
    : IQueryHandler<GetAllAccountsQuery, Result<IReadOnlyList<AccountDTO>>>
{
    public async Task<Result<IReadOnlyList<AccountDTO>>> Handle(GetAllAccountsQuery query, CancellationToken cancellationToken)
    {
        var users = await accountQueries.GetAllAccountsQuery(cancellationToken);
        return Result<IReadOnlyList<AccountDTO>>.Success(users);
    }
}