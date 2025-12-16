using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Cities
{
    public interface ICitiesService
    {
        Task<ObservableCollection<EventModel>> GetEventsAsync();

        EventModel GetDefaultEvent(int cityId);
    }
}
