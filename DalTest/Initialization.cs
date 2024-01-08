

namespace DalTest;
using DalFacade.DalApi;
using DalFacade.DO;
using System.Security.Cryptography;

public static class Initialization
{
    private static IEngineer? s_dalEngineer; //stage 1
    private static ITask? s_dalTask; //stage 1
    private static IDependency? s_dalDependency; //stage 1

    private static readonly Random s_rand = new();

    private static void createEngineers()
    {
    }
    private static void createTasks()
    {

        string[] Alias = { "code", "examination", "combination", "Brainstorming", "Summary",  "learneing", "requirements", "problems", "bugs", "deep", "keep","update", "match","tech",
            "Collaborate", "design", "analyze", "check", "market", "fix" };
        string[] Description = { "writing code", "Code inspection", "Joining programs", "General thinking about work", " Drawing conclusions and drawing lessons", "Structure the requirements in an agreed and logical way", "Solving general problems in the project", "Debugging", "Broadening horizons and deepening knowledge",
            "Ensure that software applications remain functional and up-to-date", "Software update",
            "Ensure that software solutions meet the specific requirements and needs of the organization.","Stay up-to-date on the latest technologies and trends in the industry.", "You will work closely with designers, project managers and other professionals to successfully complete projects," };
        "Collaborate with cross-functional teams", "Analyze user needs", "check the quality and integrity of the software","Marketing the software to the customer base", "Make sure the problem is fixed"};
 foreach (var _name in Alias)
    {


        string? Description,
    DateTime? CreatedAtDate,
            
        TimeSpan RequiredEffortTime = s_rand.Next(1,7);

    bool ? IsMilestone = false;
    DateTime StartDate,
    DateTime DeadlineDate,
    DateTime CompleteDate,
    string? Deliverables,
    string? Remarks,
    int Engineerld
    }
    private static void createDependencys()
    {


    }
}