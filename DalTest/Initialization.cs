

namespace DalTest;
using DalFacade.DalApi;
using DalFacade.DO;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

public static class Initialization
{
    private static IEngineer? s_dalEngineer; //stage 1
    private static ITask? s_dalTask; //stage 1
    private static IDependency? s_dalDependency; //stage 1

    private static readonly Random s_rand = new();

    private static void createEngineers()
    {
        string[] EngineerNames =
        {
        "Dani Levi", "Eli Amar", "Yair Cohen",
        "Ariela Levin", "Dina Klein", "Shira Israelof"
        };

        static string GenerateRandomEmail()   // Method to generate a random email address
        {
            // Array of possible domain options
            string[] domainOptions = { "gmail.com", "yahoo.com", "hotmail.com", "example.com" };

            // Generate a random username by appending "user" to a unique GUID
            string randomUsername = "user" + Guid.NewGuid().ToString().Substring(0, 8);

            // Choose a random domain from the list
            Random rand = new Random();
            string randomDomain = domainOptions[rand.Next(domainOptions.Length)];

            // Create the final email address
            string randomEmail = $"{randomUsername}@{randomDomain}";

            return randomEmail;
        }

        foreach (var _name in EngineerNames)
        {
            int _id;
            do
                _id = s_rand.Next(200000000, 400000000);
            while (s_dalEngineer!.Read(_id) != null);

            string? _email = GenerateRandomEmail();

            Level _level = (Level)s_rand.Next(1, 5);

            double _cost = s_rand.NextDouble()*200 + 200;

            Engineer newEng = new(_id, _name, _email, _level, _cost);

            s_dalEngineer!.Create(newEng);
        }
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
        };
    private static void createDependencys()
    {
    // Function to add random dependencies for a task
        for (int i = 0; i < 40; i++)
        {
            int _id = s_rand.Next(200000000, 400000000);
        while (randomDependsOnTaskId == dependentTaskId) // Ensure not dependent on itself
        {
            randomDependsOnTaskId = tasks[random.Next(tasks.Count)].Id;
        }

        var dependency = new Dependency
        {
            Id = tasks.Count + 1,
            DependentTask = dependentTaskId,
            DependsOnTask = randomDependsOnTaskId
        };

        dependentTask?.Dependencies.Add(dependency);
    }
}

