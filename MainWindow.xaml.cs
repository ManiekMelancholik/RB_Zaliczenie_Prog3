using RB_Zaliczenie_Prog3.Utylities;
using RB_Zaliczenie_Prog3.Visit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RB_Zaliczenie_Prog3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static MainWindow _instance;

        //public ObservableCollection<VisitM> collection
        //{

        //    get;
        //    set;
            
            
              
            
        //}
        public MainWindow()
        {
            InitializeComponent();
           // collection = new ObservableCollection<VisitM>();
            _instance = this;
            //rep.ReportServer.ReportServerUrl = new Uri(@"http://laptop-k83qnn3g", System.UriKind.Absolute).ToString();
            // rep.ReportServer.ReportPath = @"/Reports/report/Report3";
            // rep.RefreshReport();
            //MV_Control.collection = new ObservableCollection<VisitM>();

        }
        public static MainWindow GetInstance()
        {
            if (_instance == null)
                _instance = new MainWindow();
            return _instance;
        }
    }
}

