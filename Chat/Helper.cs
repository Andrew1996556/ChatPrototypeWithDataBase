using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public static class Helper
    {
        public static async Task WriteConectAsync(HttpListenerContext context, string msg)
        {
            context.Response.ContentLength64 = msg.Length;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            using (Stream s = context.Response.OutputStream)
            {
                await s.WriteAsync(Encoding.UTF8.GetBytes(msg), 0, msg.Length);
            }
        }

        public static async Task WriteConectAsync(HttpListenerContext context, byte[] msg)
        {
            context.Response.ContentLength64 = msg.Length;
            context.Response.AddHeader("Access-Control-Allow-Origin", "*");
            using (Stream s = context.Response.OutputStream)
            {
                await s.WriteAsync(msg, 0, msg.Length);
            }
        }
    }
}
