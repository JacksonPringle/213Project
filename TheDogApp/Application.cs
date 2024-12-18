namespace TheDogApp
{
    public class Application
    {
        public enum StatusEnum
        {
            Submitted,
            UnderReview,
            InterviewScheduled,
            Accepted,
            Rejected
        }

        public class ApplicationStatus
        {
            public int StatusId { get; set; }
            public required string StatusName { get; set; }
        }

        public class StatusHistory
        {
            public Guid HistoryId { get; private set; }
            public ApplicationStatus Status { get; set; }
            public DateTime ChangedAt { get; set; }
            public string ChangedBy { get; set; }

            public StatusHistory(ApplicationStatus initialStatus, string changedBy = "System")
            {
                HistoryId = Guid.NewGuid();
                Status = initialStatus ?? throw new ArgumentNullException(nameof(initialStatus), "Initial status cannot be null.");
                ChangedAt = DateTime.Now;
                ChangedBy = changedBy ?? throw new ArgumentNullException(nameof(changedBy), "ChangedBy cannot be null.");
            }

            public void RecordChange(ApplicationStatus status, string changedBy)
            {
                Status = status ?? throw new ArgumentNullException(nameof(status));
                ChangedAt = DateTime.Now;
                ChangedBy = changedBy ?? throw new ArgumentNullException(nameof(changedBy));

            }
        }

        public class StatusManager
        {
            private readonly Dictionary<StatusEnum, List<StatusEnum>> _allowedTransitions = new()
        {
            { StatusEnum.Submitted, new List<StatusEnum> { StatusEnum.UnderReview, StatusEnum.Rejected } },
            { StatusEnum.UnderReview, new List<StatusEnum> { StatusEnum.InterviewScheduled, StatusEnum.Rejected } },
            { StatusEnum.InterviewScheduled, new List<StatusEnum> { StatusEnum.Accepted, StatusEnum.Rejected } },
            { StatusEnum.Accepted, new List<StatusEnum>() },
            { StatusEnum.Rejected, new List<StatusEnum>() }
        };

            public void ChangeStatus(SubApplication application, ApplicationStatus newStatus, string changedBy)
            {
                if (application == null || newStatus == null || string.IsNullOrWhiteSpace(changedBy))
                    throw new ArgumentException("Invalid input provided.");

                if (application.CurrentStatus == null)
                    throw new InvalidOperationException("Current status is not initialized.");

                if (!ValidateTransition(application.CurrentStatus, newStatus))
                    throw new InvalidOperationException($"Cannot change status from '{application.CurrentStatus.StatusName}' to '{newStatus.StatusName}'.");

                var history = new StatusHistory(newStatus, changedBy);
                application.StatusHistory.Add(history);
                application.UpdateCurrentStatus(newStatus);

                Console.WriteLine($"Status changed to '{newStatus.StatusName}' by {changedBy}.");
            }

            public bool ValidateTransition(ApplicationStatus currentStatus, ApplicationStatus newStatus)
            {
                return Enum.TryParse<StatusEnum>(currentStatus.StatusName, out var currentEnum) &&
                       Enum.TryParse<StatusEnum>(newStatus.StatusName, out var newEnum) &&
                       _allowedTransitions.TryGetValue(currentEnum, out var validTransitions) &&
                       validTransitions.Contains(newEnum);
            }
        }

        public class SubApplication
        {
            public Guid Id { get; private set; }
            public string CandidateName { get; set; }
            public string Position { get; set; }
            public ApplicationStatus CurrentStatus { get; private set; }
            public List<StatusHistory> StatusHistory { get; private set; }

            public SubApplication(string candidateName, string position)
            {
                Id = Guid.NewGuid();
                CandidateName = candidateName;
                Position = position;
                CurrentStatus = new ApplicationStatus
                {
                    StatusId = (int)StatusEnum.Submitted,
                    StatusName = StatusEnum.Submitted.ToString()
                };
                StatusHistory = new List<StatusHistory>
            {
                new StatusHistory(CurrentStatus, "System")
                {
                    Status = CurrentStatus,
                    ChangedAt = DateTime.Now,
                    ChangedBy = "System"
                }
            };
            }

            public void Submit()
            {
                Console.WriteLine($"Application for {CandidateName} submitted for position: {Position}.");
            }

            public void UpdateCurrentStatus(ApplicationStatus newStatus)
            {
                CurrentStatus = newStatus ?? throw new ArgumentNullException(nameof(newStatus));
            }
            public class ApplicationForm
            {
                public static SubApplication FillForm()
                {
                    Console.WriteLine("Please fill out the adoption application:");

                    Console.Write("Candidate Name: ");
                    string candidateName = Console.ReadLine() ?? throw new ArgumentNullException("Candidate name cannot be null or empty.");

                    Console.Write("Position: ");
                    string position = Console.ReadLine() ?? throw new ArgumentNullException("Position cannot be null or empty.");

                    return new SubApplication(candidateName, position);
                }
            }

            public class SentApplications
            {
                private List<SubApplication> Applications { get; } = new();

                public void AddApplication(SubApplication application)
                {
                    Applications.Add(application);
                    Console.WriteLine($"Application for {application.CandidateName} has been saved.");
                }

                public void ShowApplications()
                {
                    if (Applications.Count == 0)
                    {
                        Console.WriteLine("No applications found.");
                        return;
                    }

                    Console.WriteLine("Submitted Applications:");
                    foreach (var app in Applications)
                    {
                        Console.WriteLine($"- Candidate: {app.CandidateName}, Position: {app.Position}, Status: {app.CurrentStatus.StatusName}");
                    }
                }
            }
        }
    }
}
