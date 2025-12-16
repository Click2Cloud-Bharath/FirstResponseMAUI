using FirstResponseMAUI.Models;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<UserRole> LoginAsync(string userName, string password);

        Task<bool> LogoutAsync();
    }
}
