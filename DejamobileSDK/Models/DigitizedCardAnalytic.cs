using SQLite;
using System;

namespace DejamobileSDK.Models
{
    public class DigitizedCardAnalytic
    {
        [AutoIncrement]
        [PrimaryKey]
        [NotNull]
        [Unique]
        public long Id { get; set; }

        public Guid DigitizedCardId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
