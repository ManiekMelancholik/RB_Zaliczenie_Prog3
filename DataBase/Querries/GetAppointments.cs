using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RB_Zaliczenie_Prog3.DataBase.Querries
{
    public class GetApointments : IQuerry
    {
        public GetApointments()
        {

        }

        public DataTable? ExecuteQuerry()
        {
            SqlConnection con = DataBaseMenagement.connection;
            DataTable table = new DataTable();
            con.Open();
            if (ValidateQuerry())
            {
                using (SqlCommand procedure = new SqlCommand("GetApointments", con))
                {
                    procedure.CommandType = CommandType.StoredProcedure;

                    SqlParameter userId = new SqlParameter("@userId", User.instance.userIndex.ToString());
                    procedure.Parameters.Add(userId);

                    if (procedure.ExecuteScalar() != null)
                    {

                        SqlDataAdapter adapter = new SqlDataAdapter();
                        adapter.SelectCommand = procedure;
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
            return (User.instance.userIndex != null);
        }
    }
}
