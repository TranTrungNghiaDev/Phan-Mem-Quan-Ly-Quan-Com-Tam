﻿using Phan_Mem_Quan_Ly_Quan_Com_Tam.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Quan_Com_Tam
{
    public partial class fAdmin: Form
    {
        public fAdmin()
        {
            InitializeComponent();

            LoadAccoutList();
        }


        public void LoadAccoutList()
        {
            string query = "EXEC USP_GetAllAccounts";
            dgvAccounts.DataSource = DataProvider.Instance.ExcuteQuery(query);
        }
    }
}
