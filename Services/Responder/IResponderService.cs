using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Responder
{
    public interface IResponderService
    {
        Task<ObservableCollection<RouteModel>> GetRoutesAsync();

        Task<ObservableCollection<ResponderModel>> GetRespondersAsync();
    }
}
