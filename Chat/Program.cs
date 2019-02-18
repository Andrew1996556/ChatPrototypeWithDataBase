using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    class BusicWaitHandle
    {
        static void Main()
        {
            WebServer server = new WebServer(@"http://localhost:51111/");
            try
            {
                server.Start();
                Console.WriteLine("Server runing, press any key to stop");
                Console.ReadLine();
            }
            finally
            {
                server.Stop();
            }
        }
    }
}
