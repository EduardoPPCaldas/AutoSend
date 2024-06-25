using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Http.HttpResults;

namespace AutoSend.WebApi.Endpoints;

public static class AuthEndpoint
{
    public const string EndpointPrefix = "auth";
    public static IEndpointRouteBuilder AddAuthEndpoints(this IEndpointRouteBuilder builder)
    {
        builder.MapGet("login", Login);

        return builder;
    }

    public static IResult Login()
    {
        var props = new AuthenticationProperties { RedirectUri = $"{EndpointPrefix}/signin-google" };
        return Results.Challenge(props, [GoogleDefaults.AuthenticationScheme]);
    }

    public static async Task<IResult> SignInGoogle(HttpContext httpContext)
    {
        var response = await httpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if(response.Principal is null)
        {
            return Results.BadRequest();
        }

        return Results.Ok();
    }
}
