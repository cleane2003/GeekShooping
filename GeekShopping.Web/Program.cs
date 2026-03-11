using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Options;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure OpenID Connect
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
        })
        .AddCookie()
        .AddOpenIdConnect(options =>
        {
            options.Authority = "{identityServerUrl}";
            options.ClientId = "your_client_id";
            options.ClientSecret = "your_client_secret";
            options.ResponseType = "code";
            options.SaveTokens = true;
            options.Scope.Add("openid");
            options.Scope.Add("profile");
            options.Scope.Add("geek_shopping");
            options.Backchannel.BaseAddress = new Uri("{identityServerUrl}");

            options.Events = new OpenIdConnectEvents
            {
                OnAuthenticationFailed = context =>
                {
                    // Log the failure
                    Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                    context.HandleResponse();
                    context.Response.Redirect("/Home/Error");
                    return Task.CompletedTask;
                }
            };
        });

        var app = builder.Build();
        // Configure other middleware
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}