using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class ValidationHelper
    {
        private const char QUOTATION_MARK = '"';
        public static List<string> splitTerms(string searchTerms)
        {
            List<string> splits = searchTerms.Split(' ').ToList();
            List<string> terms = new List<string>();
            string word = "";
            int countTotal = 0;
            bool quotationOpen = false;
            foreach (string token in splits)
            {
                countTotal++;
                if (token.Contains(QUOTATION_MARK) || quotationOpen)
                {
                    word += " " + token;
                    if ((token.Contains(QUOTATION_MARK) && quotationOpen) || countTotal == splits.Count)
                    {
                        terms.Add(word.Replace(QUOTATION_MARK + "", "").Trim());
                        word = "";
                        quotationOpen = false;
                    }
                    else
                    {
                        quotationOpen = true;
                    }
                }
                else
                {
                    word = token;
                    terms.Add(word.Trim());
                    word = "";
                }

            }
            return terms;
        }
    }
}
