using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class ClassMethodInfo
    {
        public object[] parametrs;

        public ClassMethodInfo(string className, string methodName, object[] parametrs)
        {
            ClassName = className;
            MethodName = methodName;
            this.parametrs = parametrs;
        }

        public string ClassName { get; set; }
        public string MethodName { get; set; }
    }
}
