using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4С
{
    internal struct orders
    {
        public string itemname;  //наименование
        public int unitCount;       //числоединиц
        public double unitCost; //стоимостьоднойединицы
        public double Cost { get => unitCost * unitCount; }
    }
}
