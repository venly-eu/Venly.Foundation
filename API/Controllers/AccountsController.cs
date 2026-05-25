using API.Requests.Accounts;
using Application.Features.Accounts.Commands;
using Application.Features.Accounts.Queries;
using Microsoft.AspNetCore.Mvc;
using Venly.Dispatch.Interfaces;

namespace API.Controllers;


[ApiController]
[Route("api/[controller]")]
public class AccountsController(IDispatcher dispatcher) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAccountsAsync(CancellationToken cancellationToken)
    {
        var query = new GetAllAccountsQuery();

        var result = await dispatcher.DispatchAsync(query, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : Problem(statusCode: 500, detail: result.Error);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> CreateAccountAsync([FromBody] CreateAccountRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateAccountCommand(request.AccountName, request.Email, request.FirstName, request.LastName);

        var result = await dispatcher.DispatchAsync(command, cancellationToken);

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetAllAccountsAsync), new { id = result.Value }, result.Value)
            : Problem(statusCode: 500, detail: result.Error);
    }
}