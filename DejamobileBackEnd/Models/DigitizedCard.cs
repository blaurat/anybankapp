using System;
using System.Collections.Generic;

namespace DejamobileBackEnd.Models
{
    public class DigitizedCard
    {
        public Guid Id { get; set; }

        public string ClientNumber { get; set; }

        public CardScheme CardScheme { get; set; }

        public string PrimaryAccountNumber { get; set; }

        public List<DigitizedCardAnalytic> DigitizedCardAnalytics { get; set; }
    }
}
