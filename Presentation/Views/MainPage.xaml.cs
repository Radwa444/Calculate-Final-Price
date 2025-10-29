using calculate_final_price.Presentation.ViewModels;

namespace calculate_final_price
{
    public partial class MainPage : ContentPage
    {
     

        public MainPage(CalculatePriceViewModel vewModel)
        {
            InitializeComponent();
            BindingContext = vewModel;
        }

      
    }

}
