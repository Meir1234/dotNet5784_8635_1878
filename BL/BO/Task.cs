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

    DateTime CreatedAtDate { get; init; }

    TimeSpan RequiredEffortTime { get; set; }



    Level  Copmlexity { get; set; }

    DateTime StartDate { get; set; }

    DateTime ScheduledDate { get; set; }

}
