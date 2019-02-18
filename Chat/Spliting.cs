using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public static class Spliting
    {
        public static ClassMethodInfo SplitUrl(HttpListenerContext context)
        {
        
            var split = context.Request.RawUrl.Split(new char[] { '&', '=', '?', '/' });
            if (split.Length<5)
            {
                return new ClassMethodInfo($"{split[1]}Controller", split[2], null);
            }
            return new ClassMethodInfo($"{split[1] }Controller", split[2], GetParameters(split[4], split[6]));
        }

        public static object[] GetParameters(string str1, string str2)
        {
            return new[] { str1, str2 };
        }
    }
}
