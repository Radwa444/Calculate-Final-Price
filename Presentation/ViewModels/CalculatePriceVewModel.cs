using Calculate.Domain.Models;
using calculate_final_price.Domain.User_Cases;
using CommunityToolkit.Mvvm.ComponentModel;


namespace calculate_final_price.Presentation.ViewModels
{
    public partial class CalculatePriceViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double price =0.0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double quantity =0.0;

        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double firstDiscountPercentage = 0.0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double secondDiscountPercentage = 0.0;

        
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double thirdDiscountPercentage = 0.0;

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double taxPercentage = 0.0;

     
        [ObservableProperty]
        private double fristDiscountAmount = 0.0;

        [ObservableProperty]
        private double secondDiscountAmount = 0.0;

        
        [ObservableProperty]
        private double thirdDiscountAmount = 0.0;

        [ObservableProperty]
        private double taxAmount = 0.0;


        [NotifyPropertyChangedFor(nameof(Total))]
        
        [ObservableProperty]
        private bool isDiscountFirst = true;
        private bool isCalcul = false;
        private bool isUserInput = true;
        [ObservableProperty]
        private bool isTaxFirst = false;
        
       // public bool IsTaxFirst => !IsDiscountFirst;



        [ObservableProperty]
        private double total = 0.0;

        private readonly CalculatePriceUseCase  userCase;
       public CalculatePriceViewModel(CalculatePriceUseCase  userCase)
        {
            this.userCase = userCase;
       
        }

        
        partial void OnIsDiscountFirstChanged(bool value)
        {
            IsTaxFirst = !value;

            CalTotal();
        }
        partial void OnIsTaxFirstChanged(bool value)
        {
            IsDiscountFirst = !value;
            CalTotal();
        }

        partial void OnPriceChanged(double value) => CalTotal();
        partial void OnQuantityChanged(double value) => CalTotal();
        partial void OnFirstDiscountPercentageChanged(double value)
        {       
            if (!isUserInput) return;
            if(value>=0)
            {
                isUserInput = false;
                FristDiscountAmount = 0.0;
                isUserInput = true;
            }
            CalTotal();
        }
        partial void OnFristDiscountAmountChanged(double value) {
            if (!isUserInput) return;
            if(value>=0)
            {
                isUserInput = false;
                FirstDiscountPercentage = 0.0;
                isUserInput = true;
            }
            CalTotal();
        }
        partial void OnSecondDiscountPercentageChanged(double value)
        {
            if (!isUserInput) return;
            if (value >=0)
            {
                isUserInput = false;
                SecondDiscountAmount = 0.0;
                isUserInput = true;

            }
            CalTotal();
        }
        partial void OnSecondDiscountAmountChanged(double value)
        {
            if (!isUserInput) return;
            if (value >= 0)
            {
                isUserInput = false;
                SecondDiscountPercentage = 0.0;
                isUserInput = true;

            }
            CalTotal();
        }

        partial void OnThirdDiscountPercentageChanged(double value) {
            if (!isUserInput) return;
            if (value >= 0)
            {
                isUserInput = false;
                ThirdDiscountAmount = 0.0;
                isUserInput = true;
            }
            CalTotal();

        }
        partial void OnThirdDiscountAmountChanged(double value)
        {
            if (!isUserInput) return;
            if (value >= 0)
            {
                isUserInput = false;
                ThirdDiscountPercentage = 0.0;
                isUserInput = true;
            }
            CalTotal();
        }
        partial void OnTaxPercentageChanged(double value)
        {
            if (!isUserInput) return;
            if (value >= 0)
            {
                isUserInput = false;
                TaxAmount = 0.0;
                isUserInput = true;
            }
            CalTotal();
        }
        partial void OnTaxAmountChanged(double value)
        {
            if (!isUserInput) return;
            if (value >= 0)
            {
                isUserInput = false;
                TaxPercentage = 0.0;
                isUserInput = true;
            }
            CalTotal();

        }

        void CalTotal()
        {
            if (isCalcul) return;
            isCalcul = true;
            try
            {
                PriceCalculationRequest request = new PriceCalculationRequest
                {
                    Price = this.Price,
                    Quantity = this.Quantity,
                    SecondDiscountPercentage = this.SecondDiscountPercentage,
                    FirstDiscountPercentage = this.FirstDiscountPercentage,
                    ThirdDiscountPercentage = this.ThirdDiscountPercentage,
                    TaxPercentage = this.TaxPercentage,
                    FristDiscountAmount = this.FristDiscountAmount,
                    SecondDiscountAmount=this.SecondDiscountAmount,
                    ThirdDiscountAmount=this.ThirdDiscountAmount,
                    TaxAmount=this.TaxAmount


                };
                PriceCalculationResponse response;



                if (IsDiscountFirst)
                {
                    
                    response = userCase.CalculateDiscountBeforeTax(request);
                   UpdateValue(response);
                    
                }

                else
                {
                    
                    response = userCase.CalculateTaxBeforeDiscount(request);
                    UpdateValue(response);
                }


                if (FirstDiscountPercentage == 0 && response.FirstDiscountPercentage > 0)
                {
                    isUserInput = false;
                    FirstDiscountPercentage = Math.Round(response.FirstDiscountPercentage, 3);
                    isUserInput = true;

                }


                if (FristDiscountAmount == 0 && response.FristDiscountAmount > 0)
                {
                    isUserInput = false;
                    FristDiscountAmount = Math.Round(response.FristDiscountAmount, 3);
                    isUserInput = true;


                }

                if (SecondDiscountPercentage == 0 && response.SecondDiscountPercentage > 0)
                {
                    isUserInput = false;
                    SecondDiscountPercentage =Math.Round(response.SecondDiscountPercentage,3);
                    isUserInput = true;

                }
                if (SecondDiscountAmount == 0 && response.SecondDiscountAmount > 0)
                {
                    isUserInput = false;
                    SecondDiscountAmount = Math.Round(response.SecondDiscountAmount, 3);
                    isUserInput = true;

                }

                if (ThirdDiscountPercentage == 0 && response.ThirdDiscountPercentage > 0)
                {
                    isUserInput = false;
                    ThirdDiscountPercentage = Math.Round(response.ThirdDiscountPercentage, 3);
                    isUserInput = true;
                }

                if(ThirdDiscountAmount == 0 && response.ThirdDiscountAmount > 0)
                {
                    isUserInput = false;

                    ThirdDiscountAmount = Math.Round(response.ThirdDiscountAmount, 3);
                    isUserInput = true;
                }
                if (TaxPercentage == 0 && response.TaxPercentage > 0)
                {
                    isUserInput = false;
                    TaxPercentage = Math.Round(response.TaxPercentage, 3);
                    isUserInput = true;
                }

                if (TaxAmount == 0 && response.TaxAmount > 0)
                {
                    isUserInput = false;

                   TaxAmount = Math.Round(response.TaxAmount, 3);
                    isUserInput = true;
                }

                Total = Math.Round(response.FinalTotal, 3);

            }
            finally
            {
                isCalcul = false;
            }







        }
        


        private void UpdateValue(PriceCalculationResponse response)
        {
            FirstDiscountPercentage = Math.Round(response.FirstDiscountPercentage, 3);
            FristDiscountAmount = Math.Round(response.FristDiscountAmount, 3);
            SecondDiscountPercentage = Math.Round(response.SecondDiscountPercentage, 3);
            SecondDiscountAmount = Math.Round(response.SecondDiscountAmount, 3);
            ThirdDiscountPercentage = Math.Round(response.ThirdDiscountPercentage, 3);
            ThirdDiscountAmount = Math.Round(response.ThirdDiscountAmount, 3);
            TaxPercentage = Math.Round(response.TaxPercentage, 3);
            TaxAmount = Math.Round(response.TaxAmount, 3);

            Total = Math.Round(response.FinalTotal, 3);
        }
    }
}
