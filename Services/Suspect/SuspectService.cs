// using FirstResponseMAUI.Data.Base;
using FirstResponseMAUI.Helpers;
using FirstResponseMAUI.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FirstResponseMAUI.Services.Suspect
{
    public class SuspectService : ISuspectService
    {
        // private readonly IRequestProvider _requestProvider;
        public SuspectService(/*IRequestProvider requestProvider*/)
        {
            // _requestProvider = requestProvider;
        }

        public async Task<IEnumerable<SuspectModel>> GetSuspectsAsync(string search)
        {
            /*
            UriBuilder builder = new UriBuilder(Settings.ServiceEndpoint);
            builder.Path = "api/person/suspects";
            builder.Query = "searchText=" + search;

            string uri = builder.ToString();

            try
            {
                var suspects = await _requestProvider.GetAsync<IEnumerable<SuspectModel>>(uri);
                if (suspects != null)
                {
                    return suspects;
                }
                else
                {
                    return default(IEnumerable<SuspectModel>);
                }
            }
            catch
            {
                return default(IEnumerable<SuspectModel>);
            }
            */
            return await Task.FromResult<IEnumerable<SuspectModel>>(null);
        }
    }
}
