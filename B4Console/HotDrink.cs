using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B4
{
    public abstract class HotDrink
    {
        protected int Milk { get; set; } = 3;
        protected int Sugar { get; set; } = 3;

        public abstract void stringDrink();
        public abstract void AddMilk(int milk);
        public abstract void AddSugar(int sugar);
    }
}