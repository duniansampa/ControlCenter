using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HyperAutomation.ControlRoom.Client.Auth
{
    public class MyAuthStateProvider : AuthenticationStateProvider
    {
        public async override Task<AuthenticationState>
            GetAuthenticationStateAsync()
        {
            await Task.Delay(2000);
            //indicamos se o usuário esta autenticado e 
            //também os seus claims
            var usuario = new ClaimsIdentity(new List<Claim>() {
              new Claim("Chave", "Valor"),
              new Claim(ClaimTypes.Name, "Jose Carlos Macoratti")
              //new Claim(ClaimTypes.Role, "Admin")
            });

            return await Task.FromResult(new AuthenticationState(
                new ClaimsPrincipal(usuario)));
        }
    }
}
