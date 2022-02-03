using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using RB_Zaliczenie_Prog3.Utylities;
using RB_Zaliczenie_Prog3.x;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.SidePanel
{
    public class SidePanelMV : IViewModel
    {
        public SidePanelMV() { }

        private SidePanelV _view;
        private SidePanelV view
        {
            get
            {
                if (_view == null)
                    _view = new SidePanelV();
                return _view;
            }
        }

        #region Commands
        private ICommand _login;
        public ICommand login
        {
            get
            {
                if (_login == null)
                {
                    _login = new ACC(
                        e =>
                        {
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


        private ICommand _visits;
        public ICommand visits
        {
            get
            {
                if (_visits == null)
                {
                    _visits = new ACC(
                        e =>
                        {
                            if (User.instance == null)
                                ErrorPanels.ErrorPanelsMenager.GetInstance().ErrorSet("notLoggedIn");
                            else
                                MV_Control.SetView(new Visit.VisitMV());
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }

                return _visits;
            }
        }

        private ICommand _userDaatRaport;
        public ICommand userDaatRaport
        {
            get
            {
                if (_userDaatRaport == null)
                {
                    _userDaatRaport = new ACC(
                        e =>
                        {
                            ReportWindow rw = new ReportWindow();
                            rw.Show();
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }
                return _userDaatRaport;
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
