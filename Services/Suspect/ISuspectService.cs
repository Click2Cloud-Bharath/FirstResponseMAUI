using FirstResponseMAUI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Suspect
{
    public interface ISuspectService
    {
        Task<IEnumerable<SuspectModel>> GetSuspectsAsync(string search);
    }
}
