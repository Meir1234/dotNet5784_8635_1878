

namespace DO;

public record Task  
(
    int Id,
    string Remarks,
    string? Alias,
    string? Description,
    DateTime CreatedDate,
    DateTime? DeadlineDate,
    TimeSpan? RequiredEffortTime,
    bool? IsMilestone,
    DateTime? StartDate,
    DateTime? ScheduledDate,
    DateTime? CompleteDate,
    string? Deliverables,
    int EngineerId,
    Level Copmlexity
)
{
    // בנאי ריק עם אתחול פרמטרים ברירת מחדל
    public Task()
        : this(
              Id: 0,
              Remarks:null,
              Alias: null,
              Description: null,
              CreatedDate: DateTime.Now,
              DeadlineDate:null,
              RequiredEffortTime: TimeSpan.Zero,
              IsMilestone: false,
              StartDate: DateTime.Now,
              ScheduledDate: DateTime.Now,
              CompleteDate: null,
              Deliverables: null,
              EngineerId: 0,
              Copmlexity: Level.Beginner
          )
    {
    }
}






