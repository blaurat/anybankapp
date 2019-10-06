using System.Collections.ObjectModel;
using Xamarin.Forms;
using DejamobileSDK.Models;
using DejamobileSDK.Services;
using GalaSoft.MvvmLight.Ioc;
using DejamobileSDK.Messages;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Input;

namespace AnyBankApp.ViewModels
{
    public class DigitizedCardsViewModel : BaseViewModel
    {
        public ObservableCollection<DigitizedCard> DigitizedCards { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ICommand DeleteCardCommand
        {
            get
            {
                return new Command((e) =>
                {
                    DigitizedCard card = (e as DigitizedCard);
                    ExecuteDeleteCardCommand(card);
                });
            }
        }

        public DigitizedCardsViewModel()
        {
            Title = "Digitized Cards";
            DigitizedCards = new ObservableCollection<DigitizedCard>();
            LoadItemsCommand = new Command(() => ExecuteLoadItemsCommand());

            Messenger.Default.Register<NewDigitizedCard>(this, OnNewDigitizedCard);
        }

        private void OnNewDigitizedCard(NewDigitizedCard newCard)
        {
            LoadItemsCommand.Execute(null);
        }

        void ExecuteLoadItemsCommand()
        {
            DigitizedCards.Clear();
            var cards = DependencyService.Get<IDigitizedCardService>().GetAll(SimpleIoc.Default.GetInstance<UserProfile>().ClientNumber);
            foreach (var card in cards)
            {
                DigitizedCards.Add(card);
            }

            OnPropertyChanged("DigitizedCards");
        }

        void ExecuteDeleteCardCommand(DigitizedCard digitizedCard)
        {
            DependencyService.Get<IDigitizedCardService>().Delete(digitizedCard);

            LoadItemsCommand.Execute(null);
        }
    }
}