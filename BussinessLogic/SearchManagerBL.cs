using BussinessLogic.Manager;
using Entities;
using Services;
using Services.Impl;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
    public class SearchManagerBL
    {

        public static async Task<FinalReport> playFigthSearchEngines(List<string> terms)
        {
            FinalReport report = new FinalReport();
            try
            {
                List<Search> searchResults = await SearchBL.getSearchResults(terms);

                List<TermSearchResults> searchesByTerm = WinnerBL.getSearchesByTerm(searchResults);
                List<Winner> winnerTerms = WinnerBL.getTermWinnerByEngine(searchResults);
                string termTotalWinner = WinnerBL.getTermTotalWinner(winnerTerms);

                report.SearchResults = searchesByTerm;
                report.WinnersByEngine = winnerTerms;
                report.WinnerTerm = termTotalWinner;
                report.statusTaskOK = true;
            }
            catch(Exception ex)
            {
                report.statusTaskOK = false;
            }
            return report;
        }
    }
}
