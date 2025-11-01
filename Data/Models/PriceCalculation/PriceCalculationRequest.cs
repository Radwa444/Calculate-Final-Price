using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_final_price.Data.Models.PriceCalculation
{
   public class PriceCalculationRequest
    {
        public double Price { get; set; }
        public double Quantity { get; set; }
        public double FirstDiscountPercentage { get; set; }
        public double SecondDiscountPercentage { get; set; }
        public double ThirdDiscountPercentage { get; set; }
        public double TaxPercentage { get; set; }
    }
}
