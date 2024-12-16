namespace TheDogApp.Components
{
    public class User
    {
        private int ID { get; init; }
        private string Username { get; set; }
        private string? Email { get; set; }
        private string Password { get; set; }

        public User(int id, string user, string? email, string psswd)
        {
            ID = id;
            Username = user;
            Email = email;
            Password = psswd;
        }
    }
}