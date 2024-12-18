namespace TheDogApp
{
    public class Message
    {
        public int MessageId {  get; set; }
        public int ConversationId { get; set; }
        public string SenderId {  get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }
        public bool IsRead { get; set; }
        public Message(int messageId, int conversationId, string senderId, string text)
        {
            MessageId = messageId;
            ConversationId = conversationId;
            SenderId = senderId;
            Text = text;
            Timestamp = DateTime.UtcNow;
            IsRead = false;
        }
    }
}
