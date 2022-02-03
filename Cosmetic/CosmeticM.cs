using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB_Zaliczenie_Prog3.Cosmetic
{
    public class CosmeticM
    {
        public CosmeticM() { }

        public string name { get; set; }
        public float price { get; set; }
        public string producerName { get; set; }
        public string mainActive { get; set; }
        public string mainChemName { get; set; }
        public string description { get; set; }
        public string contactMail
        {
            get;
            set;
        }


        public static void ConvertToObservableCollection(DataTable table, ObservableCollection<CosmeticM> col, bool clear = false)
        {

            if (col == null)
                col = new ObservableCollection<CosmeticM>();

            if (clear)
                col.Clear();
            //ObservableCollection<VisitM> _collection = new ObservableCollection<VisitM>();

            for (int i = 0; i < table.Rows.Count; i++)
            {
                var row = table.Rows[i].ItemArray;

                col.Add(new CosmeticM
                {
                    //price, name, substanceName, description, Expr1 FROM CosmeticView
                    name = row[1].ToString(),
                    price = float.Parse(row[0].ToString()),
                    producerName = row[4].ToString(),
                    mainActive = row[2].ToString(),
                    description = row[3].ToString(),
                    
                });
            }

            //return _collection;

        }


    }
}
