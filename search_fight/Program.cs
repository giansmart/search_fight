using BussinessLogic;
using Entities;
using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace search_fight
{
    class Program
    {
        private SearchManagerBL searchBL;
        
        Program()
        {
            searchBL = new SearchManagerBL();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter text to search: ");
            String search_term = Console.ReadLine();
            if(search_term.Trim().Count() > 0)
            {
                List<string> terms = ValidationHelper.splitTerms(search_term);
                playSearchFight(terms).GetAwaiter().GetResult();
                Console.WriteLine("\nPress any key to quit the application");
            }
            else
            {
                Console.WriteLine("\nEnter a valid search term");
            }
           
            Console.ReadKey();
        }
        
        

        static async Task playSearchFight(List<string> terms)
        {
            Console.WriteLine("\nSearching {0} terms...",terms.Count);
            FinalReport report = await SearchManagerBL.playFigthSearchEngines(terms);

            if (report.statusTaskOK)
            {
                Console.WriteLine();
                foreach (TermSearchResults s in report.SearchResults)
                    Console.WriteLine("{0} -> {1}", s.TermSearch, s.FlattedResults);
                Console.WriteLine("------------------------------------------");
                foreach (Search w in report.WinnersByEngine)
                    Console.WriteLine("{0} winner -> {1}", w.Engine, w.TextSearch);
                Console.WriteLine("------------------------------------------");
                Console.WriteLine("Total Winner: {0}", report.WinnerTerm);
                
            }
            else
            {
                Console.WriteLine("Ooops! Sorry. There was an error. Try again, please");
            }
            
        }

        
    }
}
