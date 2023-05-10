using Microsoft.Extensions.DependencyInjection;

namespace Identity.Application;

public static class IdentityExtension
{
    public static IMvcBuilder AddIdentityPart(this IMvcBuilder builder)
    {
        return builder.AddApplicationPart(typeof(IdentityExtension).Assembly);
    }
}