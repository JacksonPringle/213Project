
using TheDogApp.Data;

namespace TheDogApp
{
    public class MessageService
    {
        private readonly TheDogAppContext _context;


        public MessageService(TheDogAppContext context)
        {
            _context = context;
        }

        public List<Message> GetMessageList()
        {
            return _context.Message.ToList();
        }


    }
}
