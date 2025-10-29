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
            if(number>=0) 
            {
                return true;
            }
            return false;

        }

    }
}
