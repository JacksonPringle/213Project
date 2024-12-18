namespace TheDogApp
{
    public class Message
    {
        public int MessageId {  get; set; }
        public int Conversation { get; set; }
        public int SenderId {  get; set; }
        public string? Text { get; set; }
        public DateTime Timestamp { get; set; }
        public Message() { }
    }
}
