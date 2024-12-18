namespace TheDogApp
{
    public class SiteUser
    {
        public int Id { get; init; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public string? PhoneNumber { get; set; }

        public bool ? IsAdmin { get; set; }

        public SiteUser() { }

        public SiteUser(int id, string username, string? email, string password, string? phoneNumber, bool? isAdmin)
        {
            Id = id;
            Username = username;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            IsAdmin = isAdmin;
        }
    }
}
