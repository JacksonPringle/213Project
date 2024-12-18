namespace TheDogApp
{
    public class Conversation
    {
        public int ConversationId { get; set; }
        public string? UserId { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public Conversation() { }
    }
}
