using System.Security.Claims;

namespace NuevaPlantilla.Extensions
{
    public interface ISessionService
    {
        Task<bool> IsAuthenticatedAsync();
        Task<List<Claim>> GetClaimsAsync();
        Task SignInAsync(List<Claim> claims);
        Task SignOutAsync();
    }

}
