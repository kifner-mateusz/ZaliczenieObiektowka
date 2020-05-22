using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zaliczenie
{
    class Fine
    {
        public int Amount { get; set; }
        public String Desc { get; set; }

        public Fine() { }
        public Fine(int amount,String desc) {
            Amount = amount;
            Desc = desc;
        }

    }
}
