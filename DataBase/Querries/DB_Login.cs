using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using RB_Zaliczenie_Prog3.Utylities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_Zaliczenie_Prog3.DataBase.Querries
{


    public class DB_Login : IQuerry
    {
        private string password;
        private string login;

        //private User user;

        public DB_Login(string p, string l)
        {
            password = HashFunction.HashString(p);
            login = l;
            //user = u;
        }


        public DataTable? ExecuteQuerry()
        {
            SqlConnection con = DataBaseMenagement.connection;
            con.Open();
            if (ValidateQuerry())
            {
                string result = "";
                string dbRole = "";
                string name = "";
                bool gotCredentials = false;

                using (SqlCommand procedure = new SqlCommand("Login", con))
                {
                    procedure.CommandType = CommandType.StoredProcedure;

                    SqlParameter userLogin = new SqlParameter("@userLogin", login);
                    SqlParameter userPassword = new SqlParameter("@userPassword", password);
                    procedure.Parameters.Add(userLogin);
                    procedure.Parameters.Add(userPassword);

                    if (procedure.ExecuteScalar() != null)
                    {
                        dbRole = procedure.ExecuteScalar().ToString();
                        gotCredentials = true;
                    }


                }
                if (gotCredentials)
                {
                    if (dbRole == "admin")
                    {
                        User.SetNewUser(login, dbRole);
                        con.Close();
                        return null;
                    }

                    using (SqlCommand procedure = new SqlCommand("GetUserID", con))
                    {
                        procedure.CommandType = CommandType.StoredProcedure;

                        SqlParameter userLogin = new SqlParameter("@userLogin", login);
                        SqlParameter userPassword = new SqlParameter("@userPassword", password);
                        procedure.Parameters.Add(userLogin);
                        procedure.Parameters.Add(userPassword);
                        result = procedure.ExecuteScalar().ToString();
                    }
                    string querry = $"SELECT name FROM[Zaliczenie].[dbo].[clients] WHERE (ID={int.Parse(result)})";
                    using (SqlCommand command = new SqlCommand(querry, con))
                    {
                        command.CommandType = System.Data.CommandType.Text;
                        name = command.ExecuteScalar().ToString();
                    }

                    User.SetNewUser(name, dbRole, int.Parse(result));
                    con.Close();
                    return null;
                }
            }
            con.Close();
            return new DataTable();


        }

        public bool ValidateQuerry()
        {

            string bannedChars = "#/\\|<>@";
            foreach (char c in password)
            {
                if (bannedChars.Contains(c))
                    return false;
            }
            foreach (char c in login)
            {
                if (bannedChars.Contains(c))
                    return false;
            }

            return true;
        }
    }
}

