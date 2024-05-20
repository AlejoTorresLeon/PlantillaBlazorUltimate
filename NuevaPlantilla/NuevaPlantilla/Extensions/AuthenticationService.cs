//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Http;
//using NuevaPlantilla.Client.Shared.Login;


//namespace NuevaPlantilla.Extensions
//{

//    public class AuthenticationServiceCustom
//    {
//        private readonly IHttpContextAccessor _httpContextAccessor;

//        public AuthenticationServiceCustom(IHttpContextAccessor httpContextAccessor)
//        {
//            _httpContextAccessor = httpContextAccessor;
//        }

//        public async Task SignInAsync(SesionDTO sesionUsuario)
//        {
//            var claims = new List<Claim>
//        {
//            new Claim(ClaimTypes.Name, sesionUsuario.Nombre),
//            new Claim(ClaimTypes.Role, sesionUsuario.Rol)
//        };

//            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
//            var principal = new ClaimsPrincipal(identity);

//            // Use the default scheme and no additional properties
//            await _httpContextAccessor.HttpContext.SignInAsync(
//                CookieAuthenticationDefaults.AuthenticationScheme,principal,new AuthenticationProperties());
//        }

//        public async Task SignOutAsync()
//        {
//            await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        }
//    }

//}
