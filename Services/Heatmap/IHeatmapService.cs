using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Heatmap
{
    public interface IHeatmapService
    {
        Task<ObservableCollection<Geoposition>> GetHeatmapPointsAsync();
    }
}
