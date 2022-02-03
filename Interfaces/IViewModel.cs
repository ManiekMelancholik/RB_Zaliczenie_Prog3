using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace RB_Zaliczenie_Prog3.Interfaces
{
    public interface IViewModel
    {
        public abstract IViewModel GetViewModel();
        public abstract UserControl GetView();
    }
}
