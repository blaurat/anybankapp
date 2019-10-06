using System.Collections.Generic;
using DejamobileBackEnd.Models;

namespace DejamobileBackEnd.Services
{
    public class CardSchemeService : ICardSchemeService
    {
        public List<CardScheme> GetAll()
        {
            List<CardScheme> cardSchemes = new List<CardScheme>();
            cardSchemes.Add(new CardScheme() { Name = "Mastercard" });
            cardSchemes.Add(new CardScheme() { Name = "Visa" });

            return cardSchemes;
        }
    }
}
