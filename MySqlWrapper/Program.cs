using MySql.Data.MySqlClient;
using MySqlWrapper.Models;
using MySqlWrapper.MySql;
using MySqlWrapper.MySql.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlWrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectQuery.Instance.Execute("SELECT * FROM users");
            var users = ObjectQuery.Instance.ReaderToList<User>();

            foreach (var user in users)
            {
                Console.WriteLine(user.Name);
            }
            
            /*
            var ResultSet = ReaderQuery.Instance.Execute("SELECT *, COUNT(*) AS SUM FROM users WHERE name = @name", 
                new Dictionary<string, object>()
                {
                    { "@name", "rudy" }
                }
            );

            try
            {
                while (ResultSet.Read())
                {
                    Console.WriteLine(ResultSet.GetString("name"));
                    Console.WriteLine(ResultSet.GetInt32("SUM"));
                }
            } finally
            {
                ResultSet.Dispose();
            }
            */

            /*
            int Rows = NonQuery.Instance.Execute("UPDATE users SET name = @updated WHERE name = @name",
                new Dictionary<string, object>()
                {
                    { "@name", "harry"},
                    { "@updated", "rudy" }
                }
            );

            Console.WriteLine(Rows);
            */
        }
    }
}
