using RB_Zaliczenie_Prog3.DataBase.Querries;
using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Utylities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.Login
{
    class LoginMV : IViewModel
    {

        public LoginMV() { }
        private LoginV _view;
        private LoginV view
        {
            get
            {
                if (_view == null)
                    _view = new LoginV();
                return _view;
            }
        }
        #region properties
        private string _login;
        private string _password;
        public string login
        {
            get
            {
                if (_login == null)
                    return "null";
                return _login;

            }
            set
            {
                _login = value;
            }
        }
        public string password
        {
            get
            {
                LoginV v = (LoginV)MV_Control._currentViewModel.GetView();
                string a = v.passwordBox.Password.ToString();
                if (a == null || a == "")
                    _password = "null";
                else
                    _password = a;
                return _password;
            }

        }
        #endregion


        private ICommand _enter;
        public ICommand enter
        {
            get
            {
                if (_enter == null)
                {
                    _enter = new ACC(
                        exec =>
                        {
                            // User.SetNewUser(login,"ADMIN");


                            IQuerry q = new DB_Login(password, login);
                            if (q.ExecuteQuerry() != null)
                            {
                                //MessageBox.Show($"loging as\n\n{login}\n\n{password}");
                                // MV_Control.SetView(new LogedInView());
                                MessageBox.Show("WRONG \n LOGIN \n CREDENTIALS");
                            }

                        },
                        canExec =>
                        {
                            return true;
                        });
                }

                return _enter;
            }

        }

        public IViewModel GetViewModel()
        {
            return this;
        }

        public UserControl GetView()
        {
            
            return view;
        }
    }


}
