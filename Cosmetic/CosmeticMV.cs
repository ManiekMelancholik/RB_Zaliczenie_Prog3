using RB_Zaliczenie_Prog3.DataBase.Querries;
using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Login;
using RB_Zaliczenie_Prog3.Utylities;
using RB_Zaliczenie_Prog3.x;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.Cosmetic
{
    public class CosmeticMV : IViewModel
    {
        public CosmeticMV() { }

        private CosmeticV _view;
        private CosmeticV view
        {
            get
            {
                if (_view == null)
                    _view = new CosmeticV();
                return _view;
            }
        }

       
        private static DataTable? result
        {
            get;
            set;
        }
        private static ObservableCollection<CosmeticM> _collection = new ObservableCollection<CosmeticM>();
        public static ObservableCollection<CosmeticM> collection
        {
            get
            {

                if (result == null)
                {
                    _collection = new ObservableCollection<CosmeticM>();
                    _collection.Add(new CosmeticM{ name = "No DB Data", mainChemName = "No DB Data"});
                }

                return _collection;

            }
            set
            {
                _collection = value;
            }
        }

        #region Commands
        private Action<object> _reloadCollction;
        private Action<object> reloadCollection
        {
            get
            {
                if (_reloadCollction == null)
                {
                    _reloadCollction =
                        reload =>
                        {
                            IQuerry GetAllCosmetics = new SelectAllCosmetics();
                            result = GetAllCosmetics.ExecuteQuerry();
                            CosmeticM.ConvertToObservableCollection((DataTable)result, collection, true);
                        };
                        
                }
                return _reloadCollction;
            }
        }


        private ICommand _getRaports;
        public ICommand getRaports
        {
            get
            {
                if (_getRaports == null)
                {
                    _getRaports = new ACC(
                        e =>
                        {

                            if (User.instance != null)
                            {
                                if (User.instance.privLvl.ToUpper() == "ADMIN")
                                {
                                    ReportWindow rpw = new ReportWindow();
                                    rpw.Show();
                                    rpw.rptViewer.ServerReport.ReportServerUrl = new Uri("http://laptop-k83qnn3g/ReportServer", System.UriKind.Absolute);
                                    rpw.rptViewer.ServerReport.ReportPath = "/ReportingCosmetics/Report4";
                                    rpw.rptViewer.RefreshReport();
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
                return _getRaports;
            }
        }

        #endregion


        #region IViewModel
        public IViewModel GetViewModel()
        {
            reloadCollection.Invoke(this);
            return this;
        }

        public UserControl GetView()
        {
            reloadCollection.Invoke(this);
            return view;
        }
        #endregion
    }
}
