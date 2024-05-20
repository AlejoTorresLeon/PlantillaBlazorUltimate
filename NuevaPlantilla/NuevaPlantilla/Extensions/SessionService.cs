using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using System.Text.Json;

namespace NuevaPlantilla.Extensions
{
    public class SessionService : AuthenticationStateProvider, ISessionService
    {
        private readonly ISessionStorageService _sessionStorage;
        private readonly NavigationManager _navigationManager;
        //private bool _initialized = false;

        public SessionService(ISessionStorageService sessionStorage, NavigationManager navigationManager)
        {
            _sessionStorage = sessionStorage;
            _navigationManager = navigationManager;
        }


        public async Task<bool> IsAuthenticatedAsync()
        {
            var claimsJson = await _sessionStorage.GetItemAsync<string>("claims");
            return !string.IsNullOrEmpty(claimsJson);
        }
        public async Task<List<Claim>?> GetClaimsAsync()
        {
            try
            {
                if (_sessionStorage is null || _navigationManager is null || _navigationManager.Uri.Contains("_blazor"))
                {
                    // Si el _sessionStorage no está inicializado o estamos en un entorno de prerrenderizado estático, devuelve una lista vacía
                    return null;
                }

                var claimsJson = await _sessionStorage.GetItemAsync<string>("claims");
                if (string.IsNullOrEmpty(claimsJson))
                {
                    return new List<Claim>();
                }

                var claimModels = JsonSerializer.Deserialize<List<ClaimModel>>(claimsJson);
                var claims = new List<Claim>();
                foreach (var claimModel in claimModels)
                {
                    claims.Add(new Claim(claimModel.Type, claimModel.Value));
                }
                return claims;
            }
            catch (InvalidOperationException)
            {
                return null;
            }
        }



        public async Task SignInAsync(List<Claim> claims)
        {
            var claimModels = claims.Select(c => new ClaimModel { Type = c.Type, Value = c.Value }).ToList();
            var claimsJson = JsonSerializer.Serialize(claimModels);
            await _sessionStorage.SetItemAsync("claims", claimsJson);
            NotifyStateChanged();
        }

        public async Task SignOutAsync()
        {
            await _sessionStorage.RemoveItemAsync("claims");
            NotifyStateChanged();
        }

        public void NotifyStateChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var claims = await GetClaimsAsync();
            if (claims == null || !claims.Any())
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
            else
            {
                var identity = new ClaimsIdentity(claims, "claims");
                var user = new ClaimsPrincipal(identity);
                return new AuthenticationState(user);
            }
        }

    }
}
