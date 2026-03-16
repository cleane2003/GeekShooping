using GeekShopping.Web.Services;
using GeekShopping.Web.Services.IServices;
using Microsoft.AspNetCore.Authentication;

var builder = WebApplication.CreateBuilder(args);

var productApiUrl = builder.Configuration["ServiceUrls:ProductAPI"]
    ?? throw new InvalidOperationException("ServiceUrls:ProductAPI não está configurado");

var identityServerUrl = builder.Configuration["ServiceUrls:IdentityServer"]
    ?? throw new InvalidOperationException("ServiceUrls:IdentityServer não está configurado");

var cartApiUrl = builder.Configuration["ServiceUrls:CartAPI"]
    ?? throw new InvalidOperationException("ServiceUrls:CartAPI não está configurado");

var couponApiUrl = builder.Configuration["ServiceUrls:CouponAPI"]
    ?? throw new InvalidOperationException("ServiceUrls:CouponAPI não está configurado");

builder.Services.AddHttpClient<IProductService, ProductService>(c =>
    c.BaseAddress = new Uri(productApiUrl));

builder.Services.AddHttpClient<ICartService, CartService>(c =>
    c.BaseAddress = new Uri(cartApiUrl));

builder.Services.AddHttpClient<ICouponService, CouponService>(c =>
    c.BaseAddress = new Uri(couponApiUrl));

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = "Cookies";
    options.DefaultChallengeScheme = "oidc";
})
    .AddCookie("Cookies", c => c.ExpireTimeSpan = TimeSpan.FromMinutes(10))
    .AddOpenIdConnect("oidc", options =>
    {
        options.Authority = identityServerUrl;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.ClientId = "geek_shopping";
        options.ClientSecret = "my_super_secret";
        options.ResponseType = "code";
        options.ClaimActions.MapJsonKey("role", "role", "role");
        options.ClaimActions.MapJsonKey("sub", "sub", "sub");
        options.TokenValidationParameters.NameClaimType = "name";
        options.TokenValidationParameters.RoleClaimType = "role";
        options.Scope.Add("geek_shopping");
        options.SaveTokens = true;
    }
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();