using System.Diagnostics.Contracts;

namespace BO;
public enum Level
{
    Beginner,
    AdvancedBeginner,
    Intermediate,
    Advanced,
    Expert,
    All
}

public enum Status
{
  Unscheduled,
  Scheduled,
  OnTrack,
  InJeopardy,
  Done,
  All
}