using System.Net;
using CleanArch.Application.UseCases.User.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController
    (IMediator mediator) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken token)
    {
        // TODO: move it to service specified
        var result = await new CreateUserValidator()
            .ValidateAsync(request, token);

        if (result.IsValid is false)
            return BadRequest(result.Errors);
        // --

        var response = await mediator.Send(request, token);

        return Ok(response);
    }
}