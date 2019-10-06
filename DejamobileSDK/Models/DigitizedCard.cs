using SQLite;
using System;
using System.Collections.Generic;

namespace DejamobileSDK.Models
{
    public class DigitizedCard
    {
        [PrimaryKey]
        public Guid Id { get; set; }

        [Ignore]
        public string IdString 
        { 
            get { return Id.ToString(); }
        }

        public string ClientNumber { get; set; }

        public string CardSchemeName { get; set; }

        [Ignore]
        public List<DigitizedCardAnalytic> DigitizedCardAnalytics { get; set; }

        public string PrimaryAccountNumber { get; set; }
    }
}
