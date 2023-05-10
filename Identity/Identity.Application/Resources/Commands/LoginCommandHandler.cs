using System.Security.Claims;
using Identity.Domain.UserAggregate;
using Infrastructure.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

namespace Identity.Application.Resources.Commands;

public class LoginCommandHandler : IRequestHandler<LoginCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public LoginCommandHandler(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        _userRepository = userRepository;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindByUserName(request.Username, cancellationToken);
        if (user is null)
        {
            throw new BusinessException("用户名或密码错误");
        }

        if (user.Password != request.Password)
        {
            throw new BusinessException("用户名或密码错误");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Username),
            new(ClaimTypes.Name, user.FullName),
            new(ClaimTypes.MobilePhone, user.ContactPhone)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        
        await _httpContextAccessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    }
}