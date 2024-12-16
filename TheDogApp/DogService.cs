using TheDogApp.Data;

namespace TheDogApp
{
    public class DogService
    {
        private readonly TheDogAppContext _context;


        public DogService(TheDogAppContext context)
        {
            _context = context;
        }

        public List<Dog> GetDogList()
        {
            return _context.Dog.ToList();
        }


    }
}
