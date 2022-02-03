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

namespace RB_Zaliczenie_Prog3.Visit
{
    public class MakeAppoitnmentMV : IViewModel
    {
        public MakeAppoitnmentMV() { }

        private MakeAppointmentV _view;
        private MakeAppointmentV view
        {
            get
            {
                if (_view == null)
                    _view = new MakeAppointmentV();
                return _view;
            }
        }
        // private string _appointmentHour;
        public string appointmentHour
        {
            get;
            set;
        }
        public DateTime appointmentDate
        {
            get;
            set;
        }


        #region Commands
        private ICommand _makeAppoitment;
        public ICommand makeAppointment
        {
            get
            {
                if (_makeAppoitment == null)
                {
                    _makeAppoitment = new ACC(
                        e =>
                        {


                            //data base make appintment;
                            if (appointmentHour != "null")
                            {
                                //MessageBox.Show(appointmentHour);
                                IQuerry makeAppointment = new DataBase.Querries.MakeApointment(appointmentHour, appointmentDate);
                                makeAppointment.ExecuteQuerry();
                                MV_Control.SetView(new VisitMV());
                            }
                            //return to visitV
                        },
                        ce =>
                        {
                            return true;
                        }
                     );
                }
                return _makeAppoitment;
            }
        }
        #endregion


        #region IViewModel
        public UserControl GetView()
        {
            return view;
        }

        public IViewModel GetViewModel()
        {
            return this;
        }
        #endregion
    }
}
