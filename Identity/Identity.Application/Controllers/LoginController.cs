using Identity.Application.Resources.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Application.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private readonly IMediator _mediator;

    public LoginController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// 登录
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    [AllowAnonymous]
    [HttpPost]
    public async Task Login(LoginCommand command, CancellationToken cancellationToken = default)
    {
        await _mediator.Send(command, cancellationToken);
    }

    /// <summary>
    /// 登出
    /// </summary>
    /// <param name="cancellationToken"></param>
    [HttpGet("[action]")]
    public async Task SignOut(CancellationToken cancellationToken = default)
    {
        await _mediator.Send(new SingOutCommand(), cancellationToken);
    }
}