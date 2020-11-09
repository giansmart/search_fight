using Entities;
using Services.Impl;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Manager
{
    public class SearchBL
    {
        public static async Task<List<Search>> getSearchResults(List<string> terms)
        {
            List<ISearchEngineService> engines = new List<ISearchEngineService>();
            engines.Add(new GoogleSearchService());
            engines.Add(new BingSearchService());
            //add another engine, if you want

            var listResults = new List<Search>();
            foreach (ISearchEngineService eng in engines)
            {
                foreach (string term in terms)
                {
                    Search search = new Search();
                    search.Engine = eng.NameEngine;
                    search.TextSearch = term;
                    search.NumberResults = await eng.getTotalResutAsync(term);
                    listResults.Add(search);
                }
            }
            return listResults;
        }
    }
}
