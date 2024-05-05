using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public int Id { get; init; }

    public string Alias { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAtDate { get; init; }

    public TimeSpan RequiredEffortTime { get; set; }

    public bool? IsMilestone { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime DeadlineDate { get; set; }


    public string Deliverables {  get; set; }

    public int EngineerId {  get; set; }

    public Level Complexity { get; set; }

    public Task(int id, string alias, string description, DateTime createdAtDate, TimeSpan requiredEffortTime, bool? isMilestone, DateTime startDate, DateTime deadlineDate, string deliverables, int engineerId, Level complexity)
    {
        Id = id;
        Alias = alias;
        Description = description;
        CreatedAtDate = createdAtDate;
        RequiredEffortTime = requiredEffortTime;
        IsMilestone = isMilestone;
        StartDate = startDate;
        DeadlineDate = deadlineDate;
        Deliverables = deliverables;
        EngineerId = engineerId;
        Complexity = complexity;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Alias: {Alias}, Description: {Description}, CreatedAtDate: {CreatedAtDate}, RequiredEffortTime: {RequiredEffortTime}, IsMilestone: {IsMilestone?.ToString() ?? "null"}, StartDate: {StartDate}, DeadlineDate: {DeadlineDate}, Deliverables: {Deliverables}, EngineerId: {EngineerId}, Complexity: {Complexity}";
    }

}

