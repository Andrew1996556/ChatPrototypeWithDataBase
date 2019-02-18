using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Reflection;
using System.Linq;

namespace Chat
{
    class WebServer
    {
        BaseProcessRequest baseProcessRequest = new BaseProcessRequest();
        HttpListener _listener;

        public WebServer(string prefixUrl)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefixUrl);
        }

        public async void Start()
        {
            _listener.Start();
            while (true)
            {
                HttpListenerContext context = await _listener.GetContextAsync();
                await MainProcessRequestAsync(context);
            }
        }

        public void Stop()
        {
            _listener.Stop();
        }

        public async Task MainProcessRequestAsync(HttpListenerContext context)
        {
            bool isProcessed = false;
            var resultSplit = Spliting.SplitUrl(context);

            isProcessed = await baseProcessRequest.ProcessRequestAsync(context, resultSplit);

            if (!isProcessed)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                await Helper.WriteConectAsync(context, "Not Found");
                isProcessed = true;
            }
        }
    }
}