using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Search
    {
        public string Engine { set; get; }
        public string TextSearch { set; get; }
        public long NumberResults { set; get; }
    }
}
