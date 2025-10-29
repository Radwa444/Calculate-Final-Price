using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_final_price.Utilities
{
    public class Validate
    {
        public static bool IsValidPositiveNumber(double number )
        {
            return number >= 0;

        }
        public static bool IsValidPercentage(double percentage)
        {
            return percentage >= 0 && percentage<=1;

        }


    }
}
