using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace RB_Zaliczenie_Prog3.x
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        public ReportWindow()
        {
            InitializeComponent();
           
            rptViewer.ServerReport.ReportServerUrl = new Uri("http://laptop-k83qnn3g/ReportServer", System.UriKind.Absolute);
            rptViewer.ServerReport.ReportPath = "/Report3";
            rptViewer.RefreshReport();
        }
    }
}
