using System;

namespace TheDogApp
{
    public class AdoptApp
    {


        public int ID { get; set; }
        public string? Name { get; set; }
        public string? ApplicationParagraph { get; set; }
        public DateTime AppDate { get; set; }
        public decimal MonthlyIncome { get; set; }
        public int UserId { get; set; }
        public string? Username { get; set; }

        public int DogId { get; set; }

        public string? Status { get; set; }


        public AdoptApp() { }


        

        public int TimeSinceApp()
        {
            return (DateTime.Now - AppDate).Days;
        }
        public override string ToString()
        {
            
            return $"Name: {Name}";
        }

    }
}
