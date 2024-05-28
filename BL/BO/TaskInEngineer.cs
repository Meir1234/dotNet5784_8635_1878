using BlImplementation;

namespace BO;

public class TaskInEngineer
{
    public int Id { get; set; }
    public string Alias { get; set; }

    public Status status { get; set; }
    public override string ToString() => this.ToStringProperty();

}
