using System;

namespace TheDogApp
{
    public class Dog
    {
        
        public int ID { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int ShelterID { get; set; }
        public List<int> ImageIDs { get; set; }
        public DateTime DateAdded { get; set; }
        public string Sex { get; set; }

        public Dog(string name, string breed, DateTime birth, string descr, decimal cost,
        int shelter, List<int> images, DateTime added, string sex)
        {
            // Do stuff
        }

        // Add methods for altering image list?
    }
}
