using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B4
{
    public interface ICup
    {
        string Volume { get; set; }
        double Capacity { get; set; }

        void Refill();
        void Wash();
    }
}