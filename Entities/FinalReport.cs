using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class FinalReport
    {
        public List<TermSearchResults> SearchResults { set; get; }
        public List<Winner> WinnersByEngine { set; get; }
        public string WinnerTerm { set; get; }
        public bool statusTaskOK { set; get; }
    }
}
