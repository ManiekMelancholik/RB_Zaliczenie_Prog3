using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_Zaliczenie_Prog3.Interfaces
{
    public interface IQuerry
    {
        public abstract DataTable? ExecuteQuerry();

        public abstract bool ValidateQuerry();

    }
}
