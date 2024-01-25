

namespace DO
{
    public record Engineer
    (
        int Id,
        string? Name,
        string? Email,
        Level Level,
        double? Cost
    )
    {
    // בנאי ריק עם אתחול פרמטרים ברירת מחדל
    public Engineer()
        : this(
              Id: 0,
              Name: null,
              Email: null,
              Level: Level.Beginner,
              Cost: null
          )
    {
    }
}
 }
