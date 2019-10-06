namespace AnyBankApp.Models
{
    public enum MenuItemType
    {
        DigitizedCards,
        UserProfile
    }

    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
