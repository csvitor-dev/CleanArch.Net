using CleanArch.Application.UseCases.User.Create;
using CleanArch.Application.UseCases.User.Delete;
using CleanArch.Application.UseCases.User.GetAll;
using CleanArch.Application.UseCases.User.Update;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController
    (IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetAllUserResponse>>> FindAll(CancellationToken token)
    {
        var response = await mediator.Send(new GetAllUserRequest(), token);

        return Ok(response);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CreateUserResponse), StatusCodes.Status201Created)]
    public async Task<ActionResult> Create(CreateUserRequest request, CancellationToken token)
    {
        var response = await mediator.Send(request, token);

        return Created(string.Empty, response);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(typeof(UpdateUserResponse), StatusCodes.Status200OK)]
    public async Task<ActionResult> 
        Update(Guid? id, UpdateUserRequest request, CancellationToken token)
    {
        if (id != request.Id)
            return BadRequest();

        var response = await mediator.Send(request, token);
        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid? id, CancellationToken cancellationToken)
    {
        if (id is null)
            return BadRequest();

        var response = await mediator
            .Send(new DeleteUserRequest(id.Value), cancellationToken);
        return Ok(response);
    }
}