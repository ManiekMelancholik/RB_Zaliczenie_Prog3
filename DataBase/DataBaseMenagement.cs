using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RB_Zaliczenie_Prog3.DataBase
{
    public class DataBaseMenagement
    {
        #region connection Data
        private static string _device = "LAPTOP-K83QNN3G";
        private static string _dbName = "Zaliczenie";
        private static string _dbUser = "ProgZaliczenie";
        private static string _dbPassword = "ProgZaliczenie";
        private static string _dbConnectionData = $"Data Source={_device};Initial Catalog={_dbName};User ID={_dbUser};Password={_dbPassword}";
        #endregion

        private static SqlConnection _connection;
        public static SqlConnection connection
        {
            get
            {
                if (_connection == null)
                {
                    try
                    {
                        _connection = new SqlConnection(_dbConnectionData);
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
                //  _connection.Open();
                return _connection;
            }
        }

        //private SqlDataAdapter dataAdapter;

        //private static DataBaseMenagement _instance;
        //private DataBaseMenagement() 
        //{

        //}

        //public static DataBaseMenagement GetInstance()
        //{
        //    if (_instance == null)
        //        _instance = new DataBaseMenagement();
        //    return _instance;
        //}

        public static bool Login(ref string role)
        {
            connection.Open();
            SqlCommand c = new SqlCommand();
            return false;

        }
        public static DataTable ExecuteQuerry(string querry)
        {
            connection.Open();
            SqlCommand c = new SqlCommand(querry);
            SqlDataAdapter dA = new SqlDataAdapter(c);
            DataTable tab = new DataTable();

            dA.Fill(tab);
            connection.Close();
            return tab;
        }



    }
}
