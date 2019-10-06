using DejamobileSDK.Models;
using System;
using System.Collections.Generic;

namespace DejamobileSDK.Services
{
    public interface IDigitizedCardService
    {
        void Initialise();

        void Delete(DigitizedCard digitizedCard);

        void Delete(List<DigitizedCard> digitizedCards);

        List<DigitizedCard> GetAll(string clientNumber);

        void AddCard();
    }
}
