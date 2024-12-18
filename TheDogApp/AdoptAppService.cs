using TheDogApp.Data;

namespace TheDogApp
{
    public class AdoptAppService
    {
        private readonly TheDogAppContext _context;


        public AdoptAppService(TheDogAppContext context)
        {
            _context = context;
        }

        public List<AdoptApp> GetAdoptAppList()
        {
            return _context.AdoptApp.ToList();
        }


    }
}
