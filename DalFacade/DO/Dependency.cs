
namespace DO;

public record Dependency
(
    int Id,
    int DependentTask,
    int DependsOnTask
)
{
    // בנאי ריק עם אתחול פרמטרים ברירת מחדל
    public Dependency()
        : this(
              Id: 0,
              DependentTask: 0,
              DependsOnTask: 0
          )
    {
    }
}





