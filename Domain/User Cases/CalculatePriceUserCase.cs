using calculate_final_price.Data.Models;
using calculate_final_price.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_final_price.Domain.User_Cases
{
    public class CalculatePriceUseCase 
    {
        public double CalculateSubtotal(double price, double quantity)
        {
          

            if(!Validate.IsValidPositiveNumber(price) || !Validate.IsValidPositiveNumber(quantity))
            {
                throw new ArgumentException("Price and Quantity must be positive numbers.");
            }

            return price * quantity;
        }
        public double CalculatePriceAfterDiscount(double subtotal,double discountPercentage)
        {
            return subtotal * (1 - discountPercentage);
        }
        public double CalculateTax(double subtotal, double discountPercentage)
        {
            return subtotal * discountPercentage;
        }
        public double CalculateDiscountBeforeTax( Details details
            )
        {
            isValidateDetails(details);

            //total before operations
            var total = CalculateSubtotal(details.Price,details.Quantity);
            //frist discount = total * (1- first discount percentage)
            var fristDiscount = CalculatePriceAfterDiscount(total,  details.FirstDiscountPercentage);
            //second discount = frist discount * (1 - second discount percentage)
            var secondDiscount = CalculatePriceAfterDiscount(fristDiscount, details.SecondDiscountPercentage);
            //third discount = second discount * (1 - third discount percentage)
            var thirdDiscount = CalculatePriceAfterDiscount(secondDiscount,details.ThirdDiscountPercentage);
            // tax = third discount * TaxPercentage
            var tax = CalculateTax(thirdDiscount,details.TaxPercentage);
            //final Total = thirdDiscount + tax
            var finalTotal = thirdDiscount + tax;

            return finalTotal;



        }
        public double CalculateTaxBeforeDiscount( Details details
            )
        {
            isValidateDetails(details);
            //total before operations
            var total = CalculateSubtotal(details.Price, details.Quantity);
            //tax=total * TaxPercentage
            var tax = CalculateTax(total, details.TaxPercentage);
            //total before discount = total + tax
            var totalBeforeDiscount = total + tax;
            //frist discount = before discount * (1- first discount percentage)
            var fristDiscount = CalculatePriceAfterDiscount(totalBeforeDiscount, details.FirstDiscountPercentage);
            //second discount = frist discount * (1 - second discount percentage)
            var secondDiscount = CalculatePriceAfterDiscount(fristDiscount, details.SecondDiscountPercentage);
            //third discount = second discount * (1 - third discount percentage)
            var thirdDiscount = CalculatePriceAfterDiscount(secondDiscount, details.ThirdDiscountPercentage);
            return thirdDiscount;


        }
      private void isValidateDetails(Details details)
        {
            if(!Validate.IsValidPercentage(details.TaxPercentage)&&
                !Validate.IsValidPercentage(details.SecondDiscountPercentage) &&
                ! Validate.IsValidPercentage(details.FirstDiscountPercentage) &&
                !Validate.IsValidPercentage(details.ThirdDiscountPercentage)) 
            {
               
                throw new ArgumentException("All percentages must be between 0 and 1");
            }
          


        }
    }
}
