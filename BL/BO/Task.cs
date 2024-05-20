using BlImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO;

public class Task
{
    public int Id { get; init; }
    public string Remarks { get; set; }

    public string Alias { get; set; }

    public string Description { get; set; }

    public TimeSpan? RequiredEffortTime { get; set; }

    public bool? IsMilestone { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ScheduledDate { get; set; }

    public DateTime? StartDate { get; set; }

    public DateTime? DeadLine { get; set; }

    public DateTime? CompliteDate { get; set; }

    public Status Status { get; set; }

    public string Deliverables {  get; set; }

    public int EngineerId {  get; set; }

    public Level Complexity { get; set; }

    public List<TaskInList> Dependencies { get; set; }
    public override string ToString() => this.ToStringProperty();


}

