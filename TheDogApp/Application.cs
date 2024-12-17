namespace TheDogApp
{
    public class Application
    {  public enum StatusEnum
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

      public StatusHistory()
      {
          HistoryId = Guid.NewGuid();
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

          var history = new StatusHistory();
          history.RecordChange(newStatus, changedBy);
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
              new StatusHistory
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
  }
    }
}
