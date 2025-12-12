using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorHelper
{
    public class Converters
    {
        public int AlphaToPercentage(int value255)
        {
            return (value255 * 100) / 255;
        }

        public int PercentageToAlpha(int percent)
        {
            return (percent * 255) / 100;
        }
    }
}
