using calculate_final_price.Data.Models.PriceCalculation;
using calculate_final_price.Utilities;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace calculate_final_price.Domain.User_Cases
{
    public class CalculatePriceUseCase
    {
        public double CalculateSubtotal(double price, double quantity)
        {


            if (!Validate.IsValidPositiveNumber(price) || !Validate.IsValidPositiveNumber(quantity))
            {
                throw new ArgumentException("Price and Quantity must be positive numbers.");
            }

            return price * quantity;
        }
        public double CalculatePriceAfterDiscount(double subtotal, double discountPercentage)
        {
            return subtotal * (1 - discountPercentage / 100);
        }
        public double CalculateTax(double subtotal, double discountPercentage)
        {
            return subtotal * (discountPercentage / 100);
        }
        public PriceCalculationResponse CalculateDiscountBeforeTax(PriceCalculationRequest details
            )
        {
            isValidateDetails(details);
            var total = CalculateSubtotal(details.Price, details.Quantity);
            var fristDiscount = 0.0;
            var secondDiscount = 0.0;
            var thirdDiscount = 0.0;
            var tax = 0.0;
            var currentAmount = total;
            var resultAmountFristDiscount = ApplyFirstDiscount(currentAmount, details);
            fristDiscount = resultAmountFristDiscount.amount;
            currentAmount = resultAmountFristDiscount.finalTotal;

            var resultAmountSecondDiscount = ApplySecondDiscount(currentAmount, details);
            secondDiscount = resultAmountSecondDiscount.amount;
            currentAmount = resultAmountSecondDiscount.finalTotal;

            var resultAmountThirdDiscount = ApplyThirdDiscount(currentAmount, details);
            thirdDiscount = resultAmountThirdDiscount.amount;
            currentAmount = resultAmountThirdDiscount.finalTotal;

            var resultAmountTax = ApplyTax(currentAmount, details);
            tax = resultAmountTax.amount;
            currentAmount = resultAmountTax.finalTotal;

            PriceCalculationResponse response = new PriceCalculationResponse
            {
                FinalTotal = currentAmount,
                FristDiscountAmount = fristDiscount,
                SecondDiscountAmount = secondDiscount,
                ThirdDiscountAmount = thirdDiscount,
                TaxAmount = tax
            };
            return response;



        }
        public PriceCalculationResponse CalculateTaxBeforeDiscount(PriceCalculationRequest details
            )
        {
            isValidateDetails(details);
            var total = CalculateSubtotal(details.Price, details.Quantity);
            var currentAmount = total;
            var tax = 0.0;
            var fristDiscount = 0.0;
            var secondDiscount = 0.0;
            var thirdDiscount = 0.0;

            var resultAmountTax = ApplyTax(currentAmount, details);
            tax = resultAmountTax.amount;
            currentAmount = resultAmountTax.finalTotal;

            var resultAmountFristDiscount = ApplyFirstDiscount(currentAmount, details);
            fristDiscount = resultAmountFristDiscount.amount;
            currentAmount = resultAmountFristDiscount.finalTotal;

            var resultAmountSecondDiscount = ApplySecondDiscount(currentAmount, details);
            secondDiscount = resultAmountSecondDiscount.amount;
            currentAmount = resultAmountSecondDiscount.finalTotal;

            var resultAmountThirdDiscount = ApplyThirdDiscount(currentAmount, details);
            thirdDiscount = resultAmountThirdDiscount.amount;
            currentAmount = resultAmountThirdDiscount.finalTotal;

            PriceCalculationResponse response = new PriceCalculationResponse
            {
                FinalTotal = currentAmount,
                FristDiscountAmount = fristDiscount,
                SecondDiscountAmount = secondDiscount,
                ThirdDiscountAmount = thirdDiscount,
                TaxAmount = tax
            };
            return response;



        }

        private void isValidateDetails(PriceCalculationRequest details)
        {
            try
            {
                if (!Validate.IsValidPercentage(details.TaxPercentage) ||
                !Validate.IsValidPercentage(details.SecondDiscountPercentage) ||
                !Validate.IsValidPercentage(details.FirstDiscountPercentage) ||
                !Validate.IsValidPercentage(details.ThirdDiscountPercentage))
                {

                    throw new ArgumentException("All percentages must be between 0 and 1");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("error in percentages _________" + ex.Message);
            }




        }

        private (double amount, double finalTotal) ApplyFirstDiscount(double total, PriceCalculationRequest request)
        {
            var fristDiscount = 0.0;
            var currentAmount = total;
            if (request.FirstDiscountPercentage > 0)
            {
                fristDiscount = CalculatePriceAfterDiscount(currentAmount, request.FirstDiscountPercentage);
                currentAmount = fristDiscount;
            }
            return (fristDiscount, currentAmount);
        }
        private (double amount, double finalTotal) ApplySecondDiscount(double total, PriceCalculationRequest request)
        {
            var secondDiscount = 0.0;
            var currentAmount = total;

            if (request.SecondDiscountPercentage > 0)
            {

                secondDiscount = CalculatePriceAfterDiscount(currentAmount, request.SecondDiscountPercentage);
                currentAmount = secondDiscount;
            }
            return (secondDiscount, currentAmount);
        }
        private (double amount, double finalTotal) ApplyThirdDiscount(double total, PriceCalculationRequest request)
        {
            var thirdDiscount = 0.0;
            var currentAmount = total;
            if (request.ThirdDiscountPercentage > 0)
            {
                thirdDiscount = CalculatePriceAfterDiscount(currentAmount, request.ThirdDiscountPercentage);
                currentAmount = thirdDiscount;

            }
            return (thirdDiscount, currentAmount);
        }
        private (double amount, double finalTotal) ApplyTax(double total, PriceCalculationRequest request)
        {
            var tax = 0.0;
            var currentAmount = total;
            if (request.TaxPercentage > 0.0)
            {
                tax = CalculateTax(total, request.TaxPercentage);
                currentAmount += tax;

            }
            return (tax, currentAmount);
        }
    }
}

