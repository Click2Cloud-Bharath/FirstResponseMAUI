using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System;
using System.Linq;
// using FirstResponseMAUI.Data.Base;
// using FirstResponseMAUI.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstResponseMAUI.Helpers;

namespace FirstResponseMAUI.Services.Heatmap
{
    public class HeatmapService : IHeatmapService
    {
        // private readonly IRequestProvider _requestProvider;

        public HeatmapService(/*IRequestProvider requestProvider*/)
        {
            // _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<Geoposition>> GetHeatmapPointsAsync()
        {
            /*
            UriBuilder builder = new UriBuilder(Settings.ServiceEndpoint);
            builder.Path = $"api/city/{Settings.SelectedCity}/heatmap";

            string uri = builder.ToString();

            try
            {
                IEnumerable<Geoposition> heatPoints = 
                    await _requestProvider.GetAsync<IEnumerable<Geoposition>>(uri);

                if (heatPoints != null)
                {
                    return heatPoints.ToObservableCollection();
                }
                else
                {
                    return default(ObservableCollection<Geoposition>);
                }
            }
            catch
            {
                return default(ObservableCollection<Geoposition>);
            }
            */
            return await Task.FromResult(new ObservableCollection<Geoposition>());
        }
    }
}
