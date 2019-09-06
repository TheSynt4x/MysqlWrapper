using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySqlWrapper.MySql.Query
{
    class ObjectQuery
    {
        public static ObjectQuery Instance { get; set; } = new ObjectQuery();

        MySqlDataReader reader;

        public void Execute(string sql, Dictionary<string, object> parameters = null)
        {
            if (parameters == null)
                parameters = new Dictionary<string, object>();

            Connection con = new Connection();

            MySqlCommand cmd = new MySqlCommand(sql, con.MySqlConnection);

            foreach (var parameter in parameters)
            {
                cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
            }

            cmd.Prepare();

            reader = cmd.ExecuteReader();
        }

        public T ReaderToObject<T>() where T : IObjectQuery, new()
        {
            T t = new T();

            while (reader.Read())
            {
                t.Construct(reader);
            }

            return t;
        }

        public List<T> ReaderToList<T>() where T : IObjectQuery, new()
        {
            List<T> list = new List<T>();

            while (reader.Read())
            {
                T t = new T();
                t.Construct(reader);
                list.Add(t);
            }

            return list;
        }
    }
}
