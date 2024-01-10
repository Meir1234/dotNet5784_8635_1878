

namespace DalFacade.DO
{
    public record Engineer
    (
        int Id,
        string? name,
        string? Email,
        Enum? Level,
        double? Cost
    )
    {
        public static implicit operator Engineer(global::Dal.EngineerImplementation v)
        {
            throw new NotImplementedException();
        }
    }
}
