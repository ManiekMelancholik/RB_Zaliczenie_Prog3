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
              
                if (result == null)
                {
                    _collection = new ObservableCollection<VisitM>();
                    _collection.Add(new VisitM { date = "No DB Data", hour = "No DB Data" });
                }
                
                return _collection;

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
                            VisitM.ConvertToObservableCollection((DataTable)result, collection, true);
                            this.view.listView.ItemsSource = collection;
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

        private ICommand _makeAppointment;
        public ICommand makeAppointment
        {
            get
            {
                if (_makeAppointment == null)
                {
                    _makeAppointment = new ACC(
                        e=>
                        {
                            MV_Control.SetView(new MakeAppoitnmentMV());
                        },
                        ce =>
                        {
                            return true;
                        }
                        );
                }
                return _makeAppointment;
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

