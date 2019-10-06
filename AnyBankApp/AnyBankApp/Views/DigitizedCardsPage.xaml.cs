using System;
using System.ComponentModel;
using Xamarin.Forms;
using AnyBankApp.ViewModels;
using DejamobileSDK.Models;

namespace AnyBankApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class DigitizedCardsPage : ContentPage
    {
        DigitizedCardsViewModel viewModel;

        public DigitizedCardsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DigitizedCardsViewModel();
        }

        private void DigitizedCardsPage_Appearing(object sender, EventArgs e)
        {
            viewModel.LoadItemsCommand.Execute(null);
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var card = args.SelectedItem as DigitizedCard;
            if (card == null)
                return;

            await Navigation.PushAsync(new DigitizedCardAnalyticsPage(new DigitizedCardAnalyticsViewModel(card)));

            // Manually deselect item.
            DigitizedCardsListView.SelectedItem = null;
        }

        async void AddCard_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new NewCardPage()));
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.DigitizedCards.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}