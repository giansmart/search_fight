using Entities;
using Helpers;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Impl
{
    public class BingSearchService : ISearchEngineService
    {
        string ISearchEngineService.NameEngine { get => "Bing"; }

        private const string QUERY_PARAMETER = "?q=";  // Required
        private const string MKT_PARAMETER = "&mkt=";  // Strongly suggested
        private const string TEXT_DECORATIONS_PARAMETER = "&textDecorations=";

        private static string _clientIdHeader = null;

        async public Task<long> getTotalResutAsync(string term)
        {

            var queryString = QUERY_PARAMETER + Uri.EscapeDataString(term);
            queryString += MKT_PARAMETER + "en-us";
            queryString += TEXT_DECORATIONS_PARAMETER + Boolean.TrueString;

            HttpResponseMessage rsp = await MakeRequestAsync(queryString);
            _clientIdHeader = rsp.Headers.GetValues("X-MSEdge-ClientID").FirstOrDefault();
            //string contentString = await rsp.Content.ReadAsStringAsync();
            if (!rsp.IsSuccessStatusCode)
                throw new Exception("There was an error.");
            BingResponse response = JsonHelper.Deserialize<BingResponse>(await rsp.Content.ReadAsStringAsync());
            long ntotalResults = long.Parse(response.WebPages.TotalEstimatedMatches);

            return ntotalResults;

        }

        static async Task<HttpResponseMessage> MakeRequestAsync(string queryString)
        {
            string key = ConfigHelper.GetConfigurationFile("Bing.API_KEY");
            string baseUri = ConfigHelper.GetConfigurationFile("Bing.REQUEST");
            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
            return (await client.GetAsync(baseUri + queryString));
        }

       
    }
}
