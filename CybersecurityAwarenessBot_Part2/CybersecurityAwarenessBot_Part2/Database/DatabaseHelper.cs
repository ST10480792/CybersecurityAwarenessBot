using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CybersecurityAwarenessBot_Part2.Database
{
    public class DatabaseHelper
    {
        private readonly string connectionString =
            "server=localhost;" +
            "database=cybersecuritychatbotdb;" +
            "uid=root;" +
            "pwd=Mxunyelwa_2006$;";

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}
