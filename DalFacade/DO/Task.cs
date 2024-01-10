﻿

namespace DO;

public record Task
(
    int id,
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
    Level hardness
)
{

}
