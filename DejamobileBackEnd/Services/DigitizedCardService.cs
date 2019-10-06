using DejamobileBackEnd.Messages;
using DejamobileBackEnd.Models;
using GalaSoft.MvvmLight.Messaging;
using System;
using Xamarin.Forms;

namespace DejamobileBackEnd.Services
{
    public class DigitizedCardService : IDigitizedCardService
    {
        public void Initialise()
        {
            Messenger.Default.Register<NewDigitizedCardRequest>(this, OnNewDigitizedCardRequest);
        }

        internal void OnNewDigitizedCardRequest(NewDigitizedCardRequest newDigitizedCardRequest)
        {
            int cardSchemeNumber = new Random().Next(100, 200) % 2;

            DigitizedCard digitizedCard = new DigitizedCard()
            {
                ClientNumber = newDigitizedCardRequest.ClientNumber,
                PrimaryAccountNumber = newDigitizedCardRequest.PrimaryAccountNumber,
                Id = Guid.NewGuid(),
                CardScheme = DependencyService.Get<ICardSchemeService>().GetAll().ToArray()[cardSchemeNumber],
                DigitizedCardAnalytics = new System.Collections.Generic.List<DigitizedCardAnalytic>()
            };

            Random generator = new Random();
            int analyticCount = (generator.Next(100, 200) % 5) + 1;
            for (int i = 0; i < analyticCount; i++)
            {
                digitizedCard.DigitizedCardAnalytics.Add(new DigitizedCardAnalytic()
                {
                    DigitizedCardId = digitizedCard.Id,
                    Date = new DateTime(2019, (generator.Next(100, 200) % 8) + 1, (generator.Next(100, 200) % 28) + 1),
                    Amount = decimal.Parse((generator.NextDouble() * (1000 - 1) + 1).ToString("N2"))
                });
            }

            Messenger.Default.Send(digitizedCard);
        }
    }
}
