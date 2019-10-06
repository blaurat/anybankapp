using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DejamobileBackEnd.Messages;
using DejamobileSDK.Messages;
using DejamobileSDK.Models;
using GalaSoft.MvvmLight.Messaging;
using Xamarin.Forms;

namespace DejamobileSDK.Services
{
    public class DigitizedCardService : IDigitizedCardService
    {
        public void Initialise()
        {
            Messenger.Default.Register<DejamobileBackEnd.Models.DigitizedCard>(this, OnDigitizedCardReceived);
        }

        private void OnDigitizedCardReceived(DejamobileBackEnd.Models.DigitizedCard digitizedCard)
        {
            DigitizedCard card = new DigitizedCard()
            {
                Id = digitizedCard.Id,
                CardSchemeName = digitizedCard.CardScheme.Name,
                ClientNumber = digitizedCard.ClientNumber,
                DigitizedCardAnalytics = (from analytic in digitizedCard.DigitizedCardAnalytics
                                         select new DigitizedCardAnalytic()
                                         {
                                             Amount = analytic.Amount,
                                             Date = analytic.Date,
                                             DigitizedCardId = analytic.DigitizedCardId
                                         }).ToList(),
                PrimaryAccountNumber = digitizedCard.PrimaryAccountNumber
            };

            Add(card);

            Messenger.Default.Send(new NewDigitizedCard());
        }

        internal void Add(DigitizedCard digitizedCard)
        {
            try
            {
                DependencyService.Get<LocalStorage>().Connection.BeginTransaction();

                DependencyService.Get<LocalStorage>().Connection.InsertOrReplace(digitizedCard);

                DependencyService.Get<LocalStorage>().Connection.InsertAll(digitizedCard.DigitizedCardAnalytics);

                DependencyService.Get<LocalStorage>().Connection.Commit();
            }
            catch
            {
                DependencyService.Get<LocalStorage>().Connection.Rollback();
            }
        }

        internal void Add(List<DigitizedCard> digitizedCards)
        {
            foreach (DigitizedCard digitizedCard in digitizedCards)
                Add(digitizedCard);
        }

        public void Delete(DigitizedCard digitizedCard)
        {
            List<DigitizedCardAnalytic> analytics = DependencyService.Get<LocalStorage>().Connection.Table<DigitizedCardAnalytic>().Where(x => x.DigitizedCardId.Equals(digitizedCard.Id)).ToList();

            try
            {
                DependencyService.Get<LocalStorage>().Connection.BeginTransaction();

                foreach (DigitizedCardAnalytic analytic in analytics)
                    DependencyService.Get<LocalStorage>().Connection.Delete(analytic);

                DependencyService.Get<LocalStorage>().Connection.Delete(digitizedCard);

                DependencyService.Get<LocalStorage>().Connection.Commit();
            }
            catch
            {
                DependencyService.Get<LocalStorage>().Connection.Rollback();
            }
        }

        public void Delete(List<DigitizedCard> digitizedCards)
        {
            foreach (DigitizedCard digitizedCard in digitizedCards)
                Delete(digitizedCard);
        }

        public List<DigitizedCard> GetAll(string clientNumber)
        {
            List<DigitizedCard> digitizedCards = DependencyService.Get<LocalStorage>().Connection.Table<DigitizedCard>().Where(x => x.ClientNumber.Equals(clientNumber)).ToList();

            foreach (DigitizedCard card in digitizedCards)
                card.DigitizedCardAnalytics = DependencyService.Get<LocalStorage>().Connection.Table<DigitizedCardAnalytic>().Where(x => x.DigitizedCardId.Equals(card.Id)).ToList();

            return digitizedCards;
        }

        public void AddCard()
        {
            Task.Run(() => ClaimNewDigitizedCard("2365 2452 3652 2258", DependencyService.Get<LocalStorage>().Connection.Table<UserProfile>().First().ClientNumber));
        }

        internal async Task ClaimNewDigitizedCard(string realCardNumber, string clientNumber)
        {
            // Send request to the bank backend. To mock, wait 3s and send a message directly to Dejamobile Backend
            await Task.Delay(3000);

            Messenger.Default.Send(new NewDigitizedCardRequest() { PrimaryAccountNumber = new Random().Next(1000000, 9999999).ToString(), ClientNumber = clientNumber });
        }
    }
}
