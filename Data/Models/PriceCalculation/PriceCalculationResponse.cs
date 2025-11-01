using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_final_price.Data.Models.PriceCalculation
{
    public class PriceCalculationResponse
    {
        public double FinalTotal { get; set; } = 0.0;
        public double FristDiscountAmount { get; set; }= 0.0;
        public double SecondDiscountAmount { get; set; } = 0.0;
        public double ThirdDiscountAmount { get; set; } = 0.0;
        public double TaxAmount { get; set; } = 0.0;
    }
}
