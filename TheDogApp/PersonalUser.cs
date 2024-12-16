namespace TheDogApp.Components
{
    public class PersonalUser : User
    {
        public string? Phone { get; set; }
        public List<int> HeartedDogs { get; set; }
        public PersonalUser(int id, string user, string? email, string psswd,
            string? phone, List<int> heartedDogs) : base(id, user, email, psswd)
        {
            Phone = phone;
            HeartedDogs = heartedDogs;
        }
    }
}