
using Chat.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat
{
    public class ChatController
    {        
        public static List<Answer> Answers { get; set; } = new List<Answer>();



        public Task< byte[]> PostMessage(string message, string userName)
        {
            if (!String.IsNullOrEmpty(message) && !String.IsNullOrEmpty(userName))
            {
                Answers.Add(new Answer() { message = message, userName = userName });
                DBRequestsController.AddHistory(userName, message);
            }
            return Task.FromResult(new byte[0]);            
        }

        public Task<byte[]> GetSerializableAnswers()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Answers.ForEach(a => stringBuilder.AppendLine($"{a.userName.Replace("%20"," ")}: {a.message.Replace("%20"," ")}"));
            return Task.FromResult( Encoding.UTF8.GetBytes(stringBuilder.ToString()));
        }

        public Task<byte[]> HelloWorld()
        {
            return Task.FromResult( Encoding.UTF8.GetBytes("Hello World"));
        }
    }
}
