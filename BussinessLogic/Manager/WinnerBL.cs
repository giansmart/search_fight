using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic.Manager
{
    public class WinnerBL
    {
        public static List<TermSearchResults> getSearchesByTerm(List<Search> listResults)
        {
            List<TermSearchResults> termsSearch = new List<TermSearchResults>();
            var terms = listResults.GroupBy(x => x.TextSearch).ToList();
            foreach(var term in terms)
            {
                TermSearchResults search = new TermSearchResults()
                {
                    TermSearch = term.Key,
                    FlattedResults = string.Join("   ", listResults.Where(x => x.TextSearch == term.Key)
                                                            .Select(x => $"{x.Engine} : {x.NumberResults}")
                                                            .ToList())
                };
                termsSearch.Add(search);
            }
            return termsSearch;
        }
        public static List<Winner> getTermWinnerByEngine(List<Search> listResults)
        {
            List<Winner> winnersList = new List<Winner>();
            var engines = listResults.GroupBy(x => x.Engine).ToList();
            foreach (var e in engines)
            {
                var listByEngine = listResults.Where(x => x.Engine == e.Key).OrderByDescending(x => x.NumberResults);
                var itemEngine = listByEngine.FirstOrDefault();
                Winner winner = new Winner()
                {
                    Engine = itemEngine.Engine,
                    TextSearch = itemEngine.TextSearch,
                    NumberResults = itemEngine.NumberResults
                };
                winnersList.Add(winner);

            }
            return winnersList;
        }
       
        public static string getTermTotalWinner(List<Winner> listByEngine)
        {
            var searchWinner = listByEngine.OrderByDescending(x => x.NumberResults).FirstOrDefault();
            return searchWinner.TextSearch;
        }
    }
}
