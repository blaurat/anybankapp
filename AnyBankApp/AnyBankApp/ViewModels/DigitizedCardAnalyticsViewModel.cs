using DejamobileSDK.Models;
using System.Collections.ObjectModel;
using System.Linq;

namespace AnyBankApp.ViewModels
{
    public class DigitizedCardAnalyticsViewModel : BaseViewModel
    {
        public ObservableCollection<DigitizedCardAnalytic> DigitizedCardAnalytics { get; set; }
        public DigitizedCardAnalyticsViewModel(DigitizedCard card)
        {
            Title = $"Payments for {card.PrimaryAccountNumber} account";
            DigitizedCardAnalytics = new ObservableCollection<DigitizedCardAnalytic>(card.DigitizedCardAnalytics.OrderByDescending(x => x.Date));
            OnPropertyChanged("DigitizedCardAnalytics");
        }
    }
}
