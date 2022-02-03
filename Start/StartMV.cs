using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using RB_Zaliczenie_Prog3.Utylities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.Start
{
    public class Start_MV : IViewModel
    {
        public Start_MV() { }
        private StartrV _view;
        private StartrV view
        {
            get
            {
                if (_view == null)
                    _view = new StartrV();
                return _view;
            }
        }


        #region Commands
        private ICommand _noLogin;
        private ICommand _login;
        private ICommand _exit;

        public ICommand noLogin
        {
            get
            {
                if (_noLogin == null)
                {
                    _noLogin = new ACC(
                        e =>
                        {
                            MessageBox.Show("Start without logging in");
                            //MV_Control.SetView(new GuestView());

                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }

                return _noLogin;
            }
        }

        public ICommand login
        {
            get
            {
                if (_login == null)
                {
                    _login = new ACC(
                        e =>
                        {
                         //  MessageBox.Show("Starting LOGING IN");
                           MV_Control.SetView(new LoginMV());
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }

                return _login;
            }
        }

        public ICommand exit
        {
            get
            {
                if (_exit == null)
                {
                    _exit = new ACC(
                        e =>
                        {
                           MessageBox.Show("EXITING APPLICATION");
                           MainWindow.GetInstance().Close();
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }

                return _exit;
            }
        }

        #endregion

        #region IViewModel
        public IViewModel GetViewModel()
        {
            return this;
        }

        public UserControl GetView()
        {
            return view;
        }
        #endregion
    }
}
