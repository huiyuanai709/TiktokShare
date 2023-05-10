using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using SourceGeneratorPower.Services.Attributes;

namespace Identity.Application.Resources.Commands;

[ScopedService]
public class SingOutCommandHandler : IRequestHandler<SingOutCommand>
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SingOutCommandHandler(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Handle(SingOutCommand request, CancellationToken cancellationToken)
    {
        await _httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    }
}