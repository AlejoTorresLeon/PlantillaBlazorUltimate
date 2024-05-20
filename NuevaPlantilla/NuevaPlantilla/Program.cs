using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor.Services;
using NuevaPlantilla.Client.Pages;
using NuevaPlantilla.Components;
//using NuevaPlantilla.Client.Extensions;
using System.Linq;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using NuevaPlantilla.Extensions;
//using NuevaPlantilla.Client.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "auth_token";
        options.LoginPath = "/login";
        options.Cookie.MaxAge = TimeSpan.FromMinutes(30);
        options.AccessDeniedPath = "/access-denied";
    });

//builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpClient();
builder.Services.AddHttpContextAccessor();
//builder.Services.AddScoped<AuthenticationServiceCustom>();
//builder.Services.AddScoped<ICustomAuthenticationStateProvider,CustomAuthenticationStateProvider>();

//builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<ISessionService, SessionService>();
builder.Services.AddScoped<AuthenticationStateProvider, SessionService>();
//builder.Services.AddScoped<AuthenticationStateProvider, SessionService>();


builder.Services.AddMudServices();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(options =>
//    {
//        options.Cookie.Name = "auth_token";
//        options.LoginPath = "/api/Usuario/Login";
//    });
//builder.Services.AddAuthorization();
//builder.Services.AddCascadingAuthenticationState();

builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();


//builder.Services.AddAuthorizationCore();
//builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddServerSideBlazor(options => options.DetailedErrors = true);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();
// Middleware personalizado para inicialización adicional



app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()    
    .AddAdditionalAssemblies(typeof(NuevaPlantilla.Client._Imports).Assembly);
app.UseStatusCodePagesWithRedirects("/404");
app.Run();

