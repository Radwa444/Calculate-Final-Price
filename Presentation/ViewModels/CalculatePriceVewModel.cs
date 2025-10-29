using calculate_final_price.Domain.User_Cases;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculate_final_price.Presentation.ViewModels
{
    public partial class CalculatePriceViewModel : BaseViewModel
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double price ;
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(Total))]
        private double quantity ;
        [ObservableProperty]
        private double total = 0.0;

        private readonly CalculatePriceUseCase  userCase;
       public CalculatePriceViewModel(CalculatePriceUseCase  userCase)
        {
            this.userCase = userCase;
            CalTotal();
        }
        partial void OnPriceChanged(double value) => CalTotal();
        partial void OnQuantityChanged(double value) => CalTotal();
        void CalTotal()
        {
            Total = userCase.CalculateSubtotal(Price, Quantity);
        }
    }
}
