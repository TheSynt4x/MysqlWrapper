using MySqlWrapper.MySql.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace MySqlWrapper.Models
{
    class User : IObjectQuery
    {
        public string Name { get; set; }

        public void Construct(MySqlDataReader reader)
        {
            Name = reader.GetString("name"); 
        }
    }
}
