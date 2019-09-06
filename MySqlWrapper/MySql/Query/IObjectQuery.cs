using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlWrapper.MySql.Query
{
    interface IObjectQuery
    {
        void Construct(MySqlDataReader reader);
    }
}
