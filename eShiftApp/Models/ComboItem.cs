using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShiftApp.Models
{
    public class ComboItem
    {
        public int ID { get; set; }
        public string Display { get; set; }

        public ComboItem(int id, string display)
        {
            ID = id;
            Display = display;
        }

        public override string ToString()
        {
            return Display;
        }
    }
}
