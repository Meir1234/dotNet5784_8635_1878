

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
              CreatedAtDate: null,
              RequiredEffortTime: TimeSpan.Zero,
              IsMilestone: null,
              StartDate: DateTime.Now,
              DeadlineDate: DateTime.Now,
              CompleteDate: null,
              Deliverables: null,
              EngineerId: 0,
              Hardness: Level.Beginner
          )
    {
    }
}//empty ctor for stage 3









//    public object EngineerId { get; set; }
//    public object Hardness { get; set; }

//    public void createTasks()
//    {
//        throw new NotImplementedException();
//    }
//}
