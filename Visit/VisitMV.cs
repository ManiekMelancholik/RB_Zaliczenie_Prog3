using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Utylities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.Visit
{
    class VisitMV : IViewModel
    {
        public VisitMV() { }

        private VisitV _view;
        private VisitV view
        {
            get
            {
                if (_view == null)
                    _view = new VisitV();
                return _view;
            }
        }

        //public ObservableCollection<Visit> collection
        //{
        //    get
        //    {

        //        return Visit.collection;

        //    }
        //}


        private static DataTable? result
        {
            get;
            set;
        }
        private static ObservableCollection<VisitM> _collection = new ObservableCollection<VisitM>();
        public static ObservableCollection<VisitM> collection
        {
            get
            {
                return _collection;
                //if (result == null)
                //    _collection = new ObservableCollection<VisitM>();
                //else
                //{
                //    _collection = VisitM.ConvertToObservableCollection((DataTable)result);
                //   // MessageBox.Show(@$"{_collection[0].date}");
                //}
                //return _collection;
               
            }
            set
            {
                _collection = value;
            }
        }
       

        #region Commands

        private ICommand _refresh;

        public ICommand refresh
        {
            get
            {
                if (_refresh == null)
                {
                    _refresh = new ACC(
                        e =>
                        {
                            IQuerry getAppointments = new DataBase.Querries.GetApointments();
                            result = getAppointments.ExecuteQuerry();
                            collection = VisitM.ConvertToObservableCollection((DataTable)result);
                            this.view.listView.ItemsSource = collection;
                            //Visit.ConvertToObservableCollection(GetAppointments.ExecuteQuerry());
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }
                return _refresh;
            }
        }
        #endregion

        #region IVIewModel
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

