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
        public DataTable ExcuteQuery(string query, Dictionary<string, object> paramaters = null)
        {
            using(SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                using(SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    if (paramaters != null)
                    {
                        foreach (var param in paramaters)
                        {
                            sqlCommand.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                        DataTable dataTable = new DataTable();
                        using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            sqlDataAdapter.Fill(dataTable);
                        }

                        return dataTable;
                    
                }
            }
        }

        public int ExcuteNonQuery(string query)
        {
            int rowsAffected = 0;
            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    rowsAffected = sqlCommand.ExecuteNonQuery();
                }

                return rowsAffected;
            }
        }

        public object ExcuteScalar(string query)
        {
            object data = 0;

            using (SqlConnection sqlConnection = new SqlConnection(strConnection))
            {
                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                {
                    data = sqlCommand.ExecuteScalar();
                }
                return data;
            }
               
        }
    }
}
