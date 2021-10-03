using BlazorStrap;
using ControlCenter.Client;
using ControlCenter.Client.Auth;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

/*------------ Authorization ------------*/
builder.Services.AddAuthorizationCore();

builder.Services.AddScoped<TokenAuthenticationProvider>();

builder.Services.AddScoped<IAuthorizeService, TokenAuthenticationProvider>(
               provider => provider.GetRequiredService<TokenAuthenticationProvider>());

builder.Services.AddScoped<AuthenticationStateProvider, TokenAuthenticationProvider>(
provider => provider.GetRequiredService<TokenAuthenticationProvider>());

/*----------------------------------*/
builder.Services.AddBootstrapCss();

builder.Services.AddScoped<DialogService>();
builder.Services.AddScoped<NotificationService>();
builder.Services.AddScoped<TooltipService>();
builder.Services.AddScoped<ContextMenuService>();
/*----------------------------------*/

await builder.Build().RunAsync();
