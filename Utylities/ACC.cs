using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RB_Zaliczenie_Prog3.Utylities
{
    public class ACC : ICommand
    {
        private Action<object> e;


        private Func<object, bool> ce;


        public ACC(Action<object> e, Func<object, bool> ce)
        {
            if (e == null)
            {
                throw new NotImplementedException();
            }
            else
            {
                this.e = e;
                this.ce = ce;

            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter)
        {
            if (ce == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            e(parameter);
        }
    }
}
