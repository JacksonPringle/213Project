
using TheDogApp.Data;

namespace TheDogApp
{
    public class EventService
    {
        private readonly TheDogAppContext _context;


        public EventService(TheDogAppContext context)
        {
            _context = context;
        }

        public List<Event> GetEventList()
        {
            return _context.Event.ToList();
        }


    }
}
