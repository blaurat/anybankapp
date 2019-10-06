using SQLite;

namespace DejamobileSDK.Models
{
    public class UserProfile
    {
        [PrimaryKey]
        public string ClientNumber { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }
}
