using System;
using System.ComponentModel;
using Xamarin.Forms;
using DejamobileSDK.Services;
using GalaSoft.MvvmLight.Messaging;
using DejamobileSDK.Messages;

namespace AnyBankApp.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewCardPage : ContentPage
    {
        public string ReadButtonText { get; set; }

        public bool ReadCardEnabled { get; set; }

        public NewCardPage()
        {
            InitializeComponent();

            BindingContext = this;

            ReadButtonText = "Click to read your card, please";
            OnPropertyChanged("ReadButtonText");

            ReadCardEnabled = true;
            OnPropertyChanged("ReadCardEnabled");

            Messenger.Default.Register<NewDigitizedCard>(this, OnNewDigitizedCard);
        }

        private async void OnNewDigitizedCard(NewDigitizedCard newCard)
        {
            Messenger.Default.Unregister<NewDigitizedCard>(this, OnNewDigitizedCard);
            await Navigation.PopModalAsync();
        }

        private void ReadButton_Clicked(object sender, EventArgs e)
        {
            ReadCardEnabled = false;
            OnPropertyChanged("ReadCardEnabled");

            ReadButtonText = "Connecting Bank, please wait...";
            OnPropertyChanged("ReadButtonText");

            DependencyService.Get<IDigitizedCardService>().AddCard();
        }
    }
}