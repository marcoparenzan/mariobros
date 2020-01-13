using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LcdGames
{
    public struct LcdGamePin
    {
        private int _value;

        public LcdGamePin(int value)
        {
            _value = value;
        }

        public static implicit operator int(LcdGamePin pin)
        {
            return pin._value;
        }
    }
}
