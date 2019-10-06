using System.ComponentModel;
using Xamarin.Forms;
using AnyBankApp.ViewModels;

namespace AnyBankApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DigitizedCardAnalyticsPage : ContentPage
    {
        DigitizedCardAnalyticsViewModel viewModel;

        public DigitizedCardAnalyticsPage(DigitizedCardAnalyticsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DigitizedCardAnalyticsPage()
        {
            InitializeComponent();

            BindingContext = viewModel;
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            DigitizedCardAnalyticsListView.SelectedItem = null;
        }
    }
}