namespace DejamobileBackEnd.Messages
{
    public class NewDigitizedCardRequest
    {
        public string PrimaryAccountNumber { get; set; }

        public string ClientNumber { get; set; }
    }
}
