using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Self.Api.Auth;


internal static class AuthConfiguration
{
    public static void ConfigureAuthOptions(this IServiceCollection srvs, Action<AuthOptions> options)
    {
        var authOptions = new AuthOptions();
        options.Invoke(authOptions);

        var key = Encoding.ASCII.GetBytes(authOptions.JwtKey!);

        srvs.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        srvs.AddAuthorization();
    }


    public static void UseAuth(this WebApplication webApp)
    {
        webApp.UseAuthentication();
        webApp.UseAuthorization();
    }
}