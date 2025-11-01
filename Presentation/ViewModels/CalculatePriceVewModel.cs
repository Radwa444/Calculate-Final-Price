using calculate_final_price.Data.Models.PriceCalculation;
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
        private double secondDiscountPercentage = 0.0;

        [NotifyPropertyChangedFor(nameof(Total))]
        [ObservableProperty]
        private double firstDiscountPercentage = 0.0;


        [NotifyPropertyChangedFor(nameof(Total))]
        [ObservableProperty]
        private double thirdDiscountPercentage = 0.0;


        [NotifyPropertyChangedFor(nameof(TaxAmount))]
        [ObservableProperty]
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
        [NotifyPropertyChangedFor(nameof(IsTaxFirst))]
        [ObservableProperty]
        private bool isDiscountFirst = true;

        public bool IsTaxFirst => !IsDiscountFirst;



        [ObservableProperty]
        private double total = 0.0;

        private readonly CalculatePriceUseCase  userCase;
       public CalculatePriceViewModel(CalculatePriceUseCase  userCase)
        {
            this.userCase = userCase;
       
        }
        partial void OnIsDiscountFirstChanged(bool value) => CalTotal();
        partial void OnPriceChanged(double value) => CalTotal();
        partial void OnQuantityChanged(double value) => CalTotal();
        partial void OnSecondDiscountPercentageChanged(double value) => CalTotal();
        partial void OnFirstDiscountPercentageChanged(double value) => CalTotal();
        partial void OnThirdDiscountPercentageChanged(double value) => CalTotal();
        partial void OnTaxPercentageChanged(double value) => CalTotal();
        partial void OnThirdDiscountAmountChanged(double value) => CalTotal();
        partial void OnTaxAmountChanged(double value) => CalTotal();

        void CalTotal()
        {
          

          


            PriceCalculationRequest request = new PriceCalculationRequest
            {
                Price = this.Price,
                Quantity = this.Quantity,
                SecondDiscountPercentage = this.SecondDiscountPercentage,
                FirstDiscountPercentage = this.FirstDiscountPercentage,
                ThirdDiscountPercentage = this.ThirdDiscountPercentage ,
                TaxPercentage = this.TaxPercentage 


            };
            PriceCalculationResponse response;
            
       

            if (IsDiscountFirst)
            {
                 response = userCase.CalculateDiscountBeforeTax(request);
            }
            else
            {
                response = userCase.CalculateTaxBeforeDiscount(request);
            }

            Total = response.FinalTotal;
            FristDiscountAmount = response.FristDiscountAmount;
            ThirdDiscountAmount = response.ThirdDiscountAmount;
            SecondDiscountAmount = response.SecondDiscountAmount;
            TaxAmount = response.TaxAmount;




        }
    }
}
