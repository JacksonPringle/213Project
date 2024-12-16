namespace TheDogApp
{
    public class Event
    {
        private static int _nextId = 1; // static property for Id count (can be replaced by database integration at some point)
        public int EventId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Name {  get; set; }
        public string Description { get; set; }
        public Event(DateTime startTime, DateTime endTime, string name, string description)
        {
            EventId = _nextId++;
            StartTime = startTime;
            EndTime = endTime;
            Name = name;
            Description = description;
        }
    }
}
