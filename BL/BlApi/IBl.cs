using BlImplementation;

namespace BlApi;

/// <summary>
/// Represents the main BL layer interface, providing access to engineer and task-related operations.
/// </summary>
public interface IBl
{
    /// <summary>
    /// Gets the interface for engineer-related operations.
    /// </summary>
    IEngineer Engineer { get; }

    /// <summary>
    /// Gets the interface for task-related operations.
    /// </summary>
    ITask Task { get; }

    /// <summary>
    /// Gets or sets the start date used for filtering tasks.
    /// </summary>
    DateTime? StartDate { get; set; }

    /// <summary>
    /// Gets or sets the end date used for filtering tasks.
    /// </summary>
    DateTime? EndDate { get; set; }

    DateTime Clock { get; set; }
}
