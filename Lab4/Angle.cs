using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A4
{
    public class Angle
    {
        int degrees;
        float minutes;
        char direction
        {
            get => direction;
            set
            {
                switch (value)
                {
                    case 'N'or'S'or'E'or'W': direction = value; break;
                    default: throw new ArgumentException();
                }
            }
        }

        public Angle()
        {
            degrees = 0;
            minutes = 0;
            direction = 'S';
        }
        public Angle(int degrees, float minutes, char direction)
        {
            this.degrees = degrees;
            this.minutes = minutes;
            this.direction = direction;
        }
    }
}
