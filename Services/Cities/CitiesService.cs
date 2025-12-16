// using FirstResponseMAUI.Data.Base;
using FirstResponseMAUI.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
// using FirstResponseMAUI.Extensions;
using System.Threading.Tasks;
using FirstResponseMAUI.Helpers;
// using FirstResponseMAUI.Data;
using System.Linq;

namespace FirstResponseMAUI.Services.Cities
{
    public class CitiesService : ICitiesService
    {
        // private readonly IRequestProvider _requestProvider;

        public CitiesService(/*IRequestProvider requestProvider*/)
        {
            // _requestProvider = requestProvider;
        }

        public async Task<ObservableCollection<EventModel>> GetEventsAsync()
        {
            /*
            UriBuilder builder = new UriBuilder(Settings.ServiceEndpoint);
            builder.Path = $"api/cities";

            string uri = builder.ToString();

            try
            {
                IEnumerable<EventModel> incidents =
                    await _requestProvider.GetAsync<IEnumerable<EventModel>>(uri);

                if (incidents != null)
                {
                    return incidents.ToObservableCollection();
                }
                else
                {
                    return new ObservableCollection<EventModel>();
                }
            }
            catch
            {
                return new ObservableCollection<EventModel>();
            }
            */
            return await Task.FromResult(new ObservableCollection<EventModel>());
        }

        public EventModel GetDefaultEvent(int cityId)
        {
            // var events = DataRepository.LoadEventsData();

            // return events.FirstOrDefault(q => q.CityId == cityId);
            return null;
        }
    }
}
