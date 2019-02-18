using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.DataBase
{
    public class DBRequestsController
    {
        public static void AddHistory(string userName, string message)
        {
            using (HistoryContext db = new HistoryContext())
            {
                HistoryInfo history = new HistoryInfo { userName = userName, Message = message };

                db.Users.Add(history);
                db.SaveChanges();
                
                Console.WriteLine("New record in data base...");
            }
        }

        public static async Task<byte[]> DeleteHistory()
        {
            using (HistoryContext db = new HistoryContext())
            {                
                await db.Database.ExecuteSqlCommandAsync("TRUNCATE TABLE [HistoryInfoes]");
                db.SaveChanges();
                Console.WriteLine("Clear data base...");
                return await Task.FromResult(new byte[0]);
            }
        }

        public static async Task<byte[]> GetHistoryMessage()
        {
            using (HistoryContext db = new HistoryContext())
            {
                StringBuilder stringBuilder = new StringBuilder();
                await db.Users.ForEachAsync(a=>stringBuilder.AppendLine($"{a.userName}: {a.Message}"));
               
                return Encoding.UTF8.GetBytes(stringBuilder.ToString()); 
            }           
        }
    }
}


