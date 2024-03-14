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

    public DateTime? CreatedAtDate { get; init; }

    public TimeSpan RequiredEffortTime { get; set; }



    public Level Complexity { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime ScheduledDate { get; set; }

}
