

namespace DO;

public record Task  
(
    int Id,
    string? Alias,
    string? Description,
    DateTime CreatedAtDate,
    TimeSpan RequiredEffortTime,
    bool? IsMilestone,
    DateTime StartDate,
    DateTime DeadlineDate,
    DateTime? CompleteDate,
    string? Deliverables,
    int EngineerId,
    Level Hardness
)
{
    // בנאי ריק עם אתחול פרמטרים ברירת מחדל
    public Task()
        : this(
              Id: 0,
              Alias: null,
              Description: null,
              CreatedAtDate: DateTime.Now,
              RequiredEffortTime: TimeSpan.Zero,
              IsMilestone: false,
              StartDate: DateTime.Now,
              DeadlineDate: DateTime.Now,
              CompleteDate: null,
              Deliverables: null,
              EngineerId: 0,
              Hardness: Level.Beginner
          )
    {
    }
}






