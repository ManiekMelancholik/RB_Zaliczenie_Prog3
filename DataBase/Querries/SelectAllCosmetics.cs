using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;
using RB_Zaliczenie_Prog3.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_Zaliczenie_Prog3.DataBase.Querries
{
    public class SelectAllCosmetics : IQuerry
    {
        private static string _dbquerry = "SELECT price, name, substanceName, description, Expr1 FROM CosmeticView";
        public SelectAllCosmetics()
        {

        }

        public DataTable? ExecuteQuerry()
        {
            SqlConnection con = DataBaseMenagement.connection;
            DataTable table = new DataTable();
            con.Open();

            if (ValidateQuerry())
            {
                using (SqlCommand querry = new SqlCommand(_dbquerry, con))
                {
                    querry.CommandType = CommandType.Text;


                    if (querry.ExecuteScalar() != null)
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = querry;
                        // MessageBox.Show("doing stuff");
                        //adapter.SelectCommand.Parameters.Add(userId);
                        adapter.Fill(table);

                    }


                }
            }
            con.Close();
            return table;
        }

        public bool ValidateQuerry()
        {
           // if (Login.User.instance.privLvl.ToUpper() == "ADMIN")
               return true;

        }
    }
}

