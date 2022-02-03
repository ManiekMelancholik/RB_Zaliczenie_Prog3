using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Utylities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RB_Zaliczenie_Prog3.ErrorPanels
{
    public class ErrorPanelsMenager
    {
        private UserControl[] errorPannels;
        private string[] errorTypes;
        private static ErrorPanelsMenager _instance;
        private ErrorPanelsMenager()
        {
            int ammount = 2;
            errorPannels = new UserControl[ammount];
            errorTypes = new string[ammount];

            //e0 - not logged in
            errorPannels[0] = new NotLoggedInError();
            errorTypes[0] = "notLoggedIn";


        }

        public static ErrorPanelsMenager GetInstance()
        {
            if (_instance == null)
                _instance = new ErrorPanelsMenager();
            return _instance;
        }

       public void ErrorSet(string error)
        {
            MV_Control.ErrorView(errorPannels[Array.IndexOf(errorTypes, error)]);
        }
    }
}
