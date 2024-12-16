namespace TheDogApp.Components
{
    public class User
    {
        public int ID { get; init; }
        public string Username { get; set; }
        public string? Email { get; set; }
        public string Password { get; set; }

        public User(int id, string user, string? email, string psswd)
        {
            ID = id;
            Username = user;
            Email = email;
            Password = psswd;
        }
    }
}