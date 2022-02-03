using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_Zaliczenie_Prog3.DataBase.Querries
{
    public class MakeApointment : IQuerry
    {
        private string _hour;
        private DateTime _date;
        public MakeApointment(string h, DateTime d)
        {
            _hour = h;
            _date = d;
        }


        public DataTable? ExecuteQuerry()
        {
            SqlConnection con = DataBaseMenagement.connection;
            con.Open();
            
            if (ValidateQuerry())
            {
               
               

                using (SqlCommand procedure = new SqlCommand("MakeApointment", con))
                {
                    procedure.CommandType = CommandType.StoredProcedure;

                    SqlParameter clientId = new SqlParameter("@clientIdentyficationNumber", User.instance.userIndex);
                    SqlParameter date = new SqlParameter("@visitDate", _date);
                    SqlParameter userPassword = new SqlParameter("@visitHour", _hour);
                    procedure.Parameters.Add(clientId);
                    procedure.Parameters.Add(date);
                    procedure.Parameters.Add(userPassword);

                    procedure.ExecuteNonQuery();


                }
               
            }
            con.Close();
            return null;


        }

        public bool ValidateQuerry()
        {
            if (User.instance == null || User.instance.userIndex == null)
            {
                return false;
            }
            if (_date == null)
            {
                return false;
            }
            if (_hour == null)
            {
                return false;
            }
            if (_hour.Length > 5)
            {
                return false;
            }

            return true;
        }
    }
}
