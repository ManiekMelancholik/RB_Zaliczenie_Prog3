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
                            if (User.instance != null)
                                User.ResetUser();
                                
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
                            if (User.instance != null)
                                if (User.instance.privLvl.ToUpper() == "ADMIN")
                                    ErrorPanels.ErrorPanelsMenager.GetInstance().ErrorSet("notClient");
                                else
                                    MV_Control.SetView(new Visit.VisitMV());
                            else
                                ErrorPanels.ErrorPanelsMenager.GetInstance().ErrorSet("notLoggedIn");
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
                            if (User.instance != null)
                            {
                                if (User.instance.privLvl.ToUpper() == "ADMIN")
                                {
                                    ReportWindow rw = new ReportWindow();
                                    rw.Show();

                                    rw.rptViewer.ServerReport.ReportServerUrl = new Uri("http://laptop-k83qnn3g/ReportServer", System.UriKind.Absolute);
                                    rw.rptViewer.ServerReport.ReportPath = "/Report3";
                                    rw.rptViewer.RefreshReport();
                                }
                                else
                                    ErrorPanels.ErrorPanelsMenager.GetInstance().ErrorSet("notAdmin");
                            }
                            else
                                ErrorPanels.ErrorPanelsMenager.GetInstance().ErrorSet("notAdmin");

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

        private ICommand _cosmetics;
        public ICommand cosmetics
        {
            get
            {
                if (_cosmetics == null)
                {
                    _cosmetics = new ACC(
                        e =>
                        {

                            MV_Control.SetView(new Cosmetic.CosmeticMV());
                                
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }
                return _cosmetics;
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
