namespace TheDogApp
{
    public class Message
    {
        private static int _nextId = 1; // static property for Id count (can be replaced by database integration at some point)
        public int MessageId {  get; set; }
        public int ConversationId { get; set; }
        public string SenderId {  get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public Message(int conversationId, string senderId, string text)
        {
            MessageId = _nextId++; // set messageid to the next available value
            ConversationId = conversationId;
            SenderId = senderId;
            Text = text;
            Timestamp = DateTime.UtcNow;
            IsRead = false;
        }
    }
}
