namespace TheDogApp
{
    public class Conversation
    {
        private static int _nextId = 1; // static property for Id count (can be replaced by database integration at some point)
        public int ConversationId { get; set; }
        public string UserId { get; set; }
        public string ShelterId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public DateTime Updated { get; set; }

        public Conversation(string userId, string shelterId, List<Message> messages)
        {
            ConversationId = _nextId++;
            UserId = userId;
            ShelterId = shelterId;
            Messages = messages;
            Updated = DateTime.UtcNow;
        }
    }
}
