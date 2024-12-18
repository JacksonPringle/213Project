using System;

namespace TheDogApp
{
    public class Dog
    {

        
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Breed { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Description { get; set; }
        public decimal Cost { get; set; }
        public int ShelterID { get; set; }

        public int ImageID { get; set; }
        public DateTime DateAdded { get; set; }
        public string? Sex { get; set; }

        public string? ImagePath { get; set; }

        public Dog() { }


        public Dog(int id, string name, string breed, DateTime birth, string descr, decimal cost,
        int shelter, DateTime added, string sex, int imageID, string? imagePath)
        {
            ID = id;
            Name = name;
            Breed = breed;
            Birthdate = birth;
            Description = descr;
            Cost = cost;
            ShelterID = shelter;
            DateAdded = added;
            Sex = sex;
            ImageID = imageID;
            ImagePath = imagePath;
        }

        public int getAgeInDays()
        {
            return (DateTime.Now - Birthdate).Days;
        }
        public override string ToString()
        {
            int daysOld = (DateTime.Now - Birthdate).Days;
            return ($"{Name} is a {daysOld} day old {Sex} {Breed}");
        }

    }
}
