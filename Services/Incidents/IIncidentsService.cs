using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Incidents
{
    public interface IIncidentsService
    {
        Task<ObservableCollection<IncidentModel>> GetIncidentsAsync();

        Task<SearchAreaModel> GetSearchAreaForIncidentAsync(int incidentId);
    }
}
