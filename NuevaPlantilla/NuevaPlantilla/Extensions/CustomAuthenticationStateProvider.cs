////using System.Security.Claims;
////using System.Threading.Tasks;
////using Microsoft.AspNetCore.Authentication;
////using Microsoft.AspNetCore.Authentication.Cookies;
////using Microsoft.AspNetCore.Components;
////using Microsoft.AspNetCore.Components.Authorization;
////using Microsoft.AspNetCore.Http;
////using NuevaPlantilla.Client.Shared.Login;



////namespace NuevaPlantilla.Extensions
////{

////    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
////    {
////        private readonly ISessionService _sessionService;

////        public CustomAuthenticationStateProvider(ISessionService sessionService)
////        {
////            _sessionService = sessionService;
////        }

////        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
////        {
////            var isAuthenticated = await _sessionService.IsAuthenticatedAsync();
////            if (isAuthenticated)
////            {
////                var userClaims = await _sessionService.GetClaimsAsync();
////                var identity = new ClaimsIdentity(userClaims, "custom");
////                var user = new ClaimsPrincipal(identity);
////                return new AuthenticationState(user);
////            }
////            else
////            {
////                return new AuthenticationState(new ClaimsPrincipal());
////            }
////        }

////        public void NotifyAuthenticationStateChanged()
////        {
////            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
////        }
////    }

////}

//using Microsoft.AspNetCore.Components.Authorization;
//using NuevaPlantilla.Extensions;
//using System.Security.Claims;
//using System.Threading.Tasks;

//public class CustomAuthenticationStateProvider : AuthenticationStateProvider, ICustomAuthenticationStateProvider
//{
//    //private readonly ISessionService _sessionService;

//    //public CustomAuthenticationStateProvider(ISessionService sessionService)
//    //{
//    //    _sessionService = sessionService;
//    //}

//    public async Task NotifyStateChanged()
//    {
//        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
//    }

//    //public override async Task<AuthenticationState> GetAuthenticationStateAsync()
//    //{
//    //    // Implementa tu lógica aquí para obtener el estado de autenticación

//    //    // Obtener los claims del servicio de sesión
//    //    var claims = await _sessionService.GetClaimsAsync();

//    //    // Crear una identidad con los claims obtenidos
//    //    var identity = new ClaimsIdentity(claims, "custom");

//    //    // Crear un principal con la identidad creada
//    //    var user = new ClaimsPrincipal(identity);

//    //    // Devolver el estado de autenticación
//    //    return new AuthenticationState(user);
//    //}
//}

