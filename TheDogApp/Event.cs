namespace TheDogApp
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Name {  get; set; }
        public string? Description { get; set; }
        public Event() { }
        public Event(int eventId, DateTime startTime, DateTime endTime, string name, string description)
        {
            EventId = eventId;
            StartTime = startTime;
            EndTime = endTime;
            Name = name;
            Description = description;
        }
    }
}
