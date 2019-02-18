using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Chat
{
    public class BaseProcessRequest
    {
        private static readonly Dictionary<string, Type> currentTypes = Assembly.GetExecutingAssembly().GetTypes().ToDictionary(t => t.Name);

        private readonly byte[] _notFound = Encoding.UTF8.GetBytes("Found");
        public object[] GetParameters(string str1, string str2)
        {
            if (str1.Equals(null))
            {
                return new[] { str1, str2 };
            }
            return null;
        }

        public async Task<bool> ProcessRequestAsync(HttpListenerContext context, ClassMethodInfo classMethodInfo)
        {
            bool isProcessed = false;

            byte[] result = null;

            if (currentTypes.TryGetValue(classMethodInfo.ClassName, out Type typeClass))
            {
                Object instance = Activator.CreateInstance(typeClass);

                Task<byte[]> task = typeClass.GetMethod(classMethodInfo.MethodName)?.Invoke(instance, classMethodInfo.parametrs) as Task<byte[]>;
                result = await task ?? _notFound;
                await Helper.WriteConectAsync(context, result);
                isProcessed = true;
            }
            return isProcessed;
        }
    }
}
