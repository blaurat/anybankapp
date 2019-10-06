using System;

namespace DejamobileBackEnd.Models
{
    public class DigitizedCardAnalytic
    {
        public long Id { get; set; }

        public Guid DigitizedCardId { get; set; }

        public DateTime Date { get; set; }

        public decimal Amount { get; set; }
    }
}
