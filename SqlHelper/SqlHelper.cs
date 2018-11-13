using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Sql_Browser
{
    public class SqlHelper
    {
        public SqlConnection Connection { get; private set; }
        public SqlCommand Command { get; private set; }

        public SqlHelper(string connectString)
        {
            this.Connection = new SqlConnection(connectString);
            this.Command = Connection.CreateCommand();
        }

        public List<string> GetDataList()
        {
            List<string> value = new List<string>();

            this.Connection.Open();

            SqlDataReader reader = this.Command.ExecuteReader();
            while (reader.Read())
            {
                value.Add(reader.GetString(0));
            }
            reader.Close();
            reader.Dispose();

            this.Connection.Close();

            return value;

        }

        public DataTable GetDataTable()
        {

            DataTable myTable = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(this.Command);
            adapter.Fill(myTable);

            return myTable;
        }
    }
}
