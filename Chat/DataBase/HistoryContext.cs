using Chat.DataBase;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Chat
{  
    public  class HistoryContext : DbContext
    {        
            public HistoryContext(): base("DbConnection"){}

            public DbSet<HistoryInfo> Users { get; set; }
        }
    }


