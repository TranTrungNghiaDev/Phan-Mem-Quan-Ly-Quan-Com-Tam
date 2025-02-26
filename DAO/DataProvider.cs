using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Phan_Mem_Quan_Ly_Quan_Com_Tam.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;

        public static DataProvider Instance { 
            get {
                if(instance == null)
                {
                    instance = new DataProvider();
                }
                return instance;
            } 
            private set {
                instance = value;
                    } 
        }

        private DataProvider() { }

        string strConnection = @"Data Source=.\SQLEXPRESS;Initial Catalog=quanlyquancom_db;Integrated Security=True";
        public DataTable ExcuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            
            if(parameters != null)
            {
                foreach(var param in parameters)
                {
                    sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                }
            }
            DataTable dataTable = new DataTable();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();

            return dataTable;
        }

        public int ExcuteNonQuery(string query)
        {
            int rowsAffected = 0;
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            rowsAffected = sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();

            return rowsAffected;
        }

        public object ExcuteScalar(string query)
        {
            object data = 0;
            SqlConnection sqlConnection = new SqlConnection(strConnection);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);

            data = sqlCommand.ExecuteScalar();
            sqlConnection.Close();

            return data;
        }
    }
}
