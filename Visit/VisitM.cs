using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RB_Zaliczenie_Prog3.Visit
{
    public class VisitM
    {
        public VisitM() { }
        private string _date;
        public string date
        {
            get
            {
                return _date;
            }
            set
            {

                _date = value.Substring(0, 8);
            }
        }
        private string _hour;
        public string hour
        {
            get
            {

                return _hour;
            }
            set
            {

                _hour = value;
            }
        }
       
        public static ObservableCollection<VisitM> ConvertToObservableCollection(DataTable table)
        {
            ObservableCollection<VisitM> _collection = new ObservableCollection<VisitM>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i].ItemArray;

                _collection.Add(new VisitM { date = row[0].ToString(), hour = row[1].ToString() });
            }

            return _collection;

        }
    }
}
