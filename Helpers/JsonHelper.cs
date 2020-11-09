using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Helpers
{
    public static class JsonHelper
    {
        public static T Deserialize<T>(this string json)
        {
            var serializer = new JavaScriptSerializer();
            return serializer.Deserialize<T>(json);
        }
    }
}
