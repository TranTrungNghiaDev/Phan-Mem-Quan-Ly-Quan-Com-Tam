using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phan_Mem_Quan_Ly_Quan_Com_Tam.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get {
                if(instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            } 
            private set => instance = value; }
    
        private AccountDAO() { }

        public bool Login(string username, string password)
        {
            string query = @"EXEC USP_GetAccountByUsernameAndPassword @username , @password ";
            DataTable dataTable = DataProvider.Instance.ExcuteQuery(query, new Dictionary<string, object>
            {
                {"@username", username},
                {"@password", password }
            });

            if(dataTable.Rows.Count > 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

    }
}
