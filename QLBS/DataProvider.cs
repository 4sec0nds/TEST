using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBS
{
    public class DataProvider
    {
        private string connecString = "";
        public DataTable execQuery(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection conn = new SqlConnection(connecString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);
                conn.Close();

            }
            return data;
        }

        public int execNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connecString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;

        }

        public object execScaler(string query)
        {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(connecString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                data = cmd.ExecuteScalar();
                conn.Close();

            }
            return data;
        }
    }
}
