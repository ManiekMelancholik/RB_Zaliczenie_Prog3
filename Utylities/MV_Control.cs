using RB_Zaliczenie_Prog3.Interfaces;
using RB_Zaliczenie_Prog3.Visit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RB_Zaliczenie_Prog3.Utylities
{
    public class MV_Control
    {
        //private static List<Tuple<string, UserControl>> registeredViews;

        //private MainWindow _mw;
        public MV_Control() { }
        public static IViewModel _currentViewModel;
        public static IViewModel currentViewModel
        {
            get
            { 
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
            }

        }
        public static ObservableCollection<VisitM> _collection = new ObservableCollection<VisitM>();
        public static ObservableCollection<VisitM> visitCollection
        {
            get
            {
                
                    return VisitMV.collection;
                
               
            }
            
        }

        //private static MV_Control _instance;



        //public static MV_Control CTRL
        //{
        //    get
        //    {
        //        Generate();

        //        //return _instance;
        //    }
        //}
        //private MV_Control(MainWindow mw) 
        //{
        //    //_mw = mw;
        //    MessageBox.Show("MV_COntrol is beeing generated");
        //}

        //private static void Generate()
        //{
        //    if (_instance == null)
        //        _instance = new MV_Control(MainWindow.GetInstance());

        //    //MessageBox.Show("Generated MV_COntrol");

        //}

        //public static void RegisterView()
        //{

        //}
        public static void SetView(IViewModel view)
        {
            
            
            currentViewModel = view;
            
            MainWindow.GetInstance().MainWindowContent.Child = currentViewModel.GetView();

        }
        public static IViewModel GetModelView()
        {
            return currentViewModel;
        }
        public static void ErrorView(UserControl c)
        {
            MainWindow.GetInstance().MainWindowContent.Child = c;
        }
        //    private ICommand _startup;
        //    public ICommand startup
        //    {
        //        get
        //        {
        //            if (_startup == null)
        //            {
        //                _startup = new ACC(
        //                    e =>
        //                    {
        //                       // MV_Control.Generate();
        //                    },
        //                    ce =>
        //                    {
        //                        return true;
        //                    }
        //                    );
        //            }
        //            return _startup;
        //        }
        //    }

    }
}
