

namespace DO;

public record Task  
(
    int Id,
    string? Alias,
    string? Description,
    DateTime? CreatedAtDate,
    TimeSpan RequiredEffortTime,
    bool? IsMilestone,
    DateTime StartDate,
    DateTime DeadlineDate,
    DateTime? CompleteDate,
    string? Deliverables,

    int Engineerld,
    Level Hardness
);



//    public object EngineerId { get; set; }
//    public object Hardness { get; set; }

//    public void createTasks()
//    {
//        throw new NotImplementedException();
//    }
//}
