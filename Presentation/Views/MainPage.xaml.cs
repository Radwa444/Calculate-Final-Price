using calculate_final_price.Presentation.ViewModels;

using System.Globalization;



namespace calculate_final_price
{
    public partial class MainPage : ContentPage
    {
        private readonly CalculatePriceViewModel _viewModel;

        public MainPage(CalculatePriceViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            _viewModel = viewModel;
        }
        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LanguagePicker.SelectedIndex == 0)
            {
                SetLanguage("en");
            }
            else if (LanguagePicker.SelectedIndex == 1)
            {
                SetLanguage("ar");
            }
            Application.Current.MainPage = new MainPage(_viewModel);



        }
        private void SetLanguage(string languageCode)
        {


            var culture = new CultureInfo(languageCode);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;

           
        }
    }

}
