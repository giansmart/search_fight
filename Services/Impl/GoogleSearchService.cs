using Entities;
using Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class GoogleSearchService : ISearchEngineService
    {
        string ISearchEngineService.NameEngine { get => "Google"; }
        public async Task<long> getTotalResutAsync(string term)
        {
            string request = ConfigHelper.GetConfigurationFile("Google.REQUEST")
                            .Replace("{key}", ConfigHelper.GetConfigurationFile("Google.API_KEY"))
                            .Replace("{instance}", ConfigHelper.GetConfigurationFile("Google.ID_INSTANCE_SEARCH"))
                            .Replace("{query}", term);
            var clientHttp = new HttpClient();
            var rsp = await clientHttp.GetAsync(request);
            if (!rsp.IsSuccessStatusCode)
                throw new Exception("There was an error.");
            GoogleResponse response = JsonHelper.Deserialize<GoogleResponse>(await rsp.Content.ReadAsStringAsync());
            long ntotalResults = long.Parse(response.SearchInformation.TotalResults);

            return ntotalResults;

        }
    }
}
