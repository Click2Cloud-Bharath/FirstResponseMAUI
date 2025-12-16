using FirstResponseMAUI.Models;
using System.Collections.ObjectModel;
using System;
using System.Linq;
// using FirstResponseMAUI.Data.Base;
// using FirstResponseMAUI.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FirstResponseMAUI.Helpers;

namespace FirstResponseMAUI.Services.Incidents
{
    public class IncidentsService : IIncidentsService
    {
        // private readonly IRequestProvider _requestProvider;

        public IncidentsService(/*IRequestProvider requestProvider*/)
        {
            // _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<IncidentModel>> GetIncidentsAsync()
        {
            /*
            UriBuilder builder = new UriBuilder(Settings.ServiceEndpoint);
            builder.Path = $"api/city/{Settings.SelectedCity}/incidents";

            string uri = builder.ToString();

            try
            {
                IEnumerable<IncidentModel> incidents = 
                    await _requestProvider.GetAsync<IEnumerable<IncidentModel>>(uri);

                if (incidents != null)
                {
                    return incidents.OrderByDescending(q => q.IsHighPriority).ToObservableCollection();
                }
                else
                {
                    return new ObservableCollection<IncidentModel>();
                }
            }
            catch
            {
                return new ObservableCollection<IncidentModel>();
            }
            */
            return await Task.FromResult(new ObservableCollection<IncidentModel>());
        }

        public async Task<SearchAreaModel> GetSearchAreaForIncidentAsync(int incidentId)
        {
            /*
            UriBuilder builder = new UriBuilder(Settings.ServiceEndpoint);
            builder.Path = $"api/city/{Settings.SelectedCity}/incidents/{incidentId}/search-area";

            string uri = builder.ToString();

            try
            {
                SearchAreaModel searchArea = await _requestProvider.GetAsync<SearchAreaModel>(uri);

                if (searchArea != null)
                {
                    return new SearchAreaModel()
                    {
                        Polygon = searchArea.Polygon.ToPolygonConvexHull().ToArray(),
                        //Tickets = jsonSearchArea.Tickets
                    };
                }

                return default(SearchAreaModel);
            }
            catch
            {
                return default(SearchAreaModel);
            }
            */
            return await Task.FromResult<SearchAreaModel>(null);
        }

        class JsonSearchArea {
            public SearchAreaModel SearchArea;

            public TicketModel[] Tickets;
        }
    }
}
