

namespace DalTest;

using DalApi;
using DalFacade.DalApi;
using DO;
public static class Initialization
{
    private static IEngineer? s_dalEngineer; //stage 1
    private static ITask? s_dalTask; //stage 1
    private static IDependency? s_dalDependency; //stage 1

    private static readonly Random s_rand = new();

    private static void CreateEngineers()
    {
        string[] EngineerNames =
        {
        "Dani Levi", "Eli Amar", "Yair Cohen",
        "Ariela Levin", "Dina Klein", "Shira Israelof"
        };

        string[] Username =
        {
            "DaniLevi", "EliAmar", "YairCohen",
            "ArielaLevin", "DinaKlein", "ShiraIsraelof"
        };

        static string GenerateRandomEmail()   // Method to generate a random email address
        {
            // Array of possible domain options
            string[] domainOptions = { "gmail.com", "yahoo.com", "hotmail.com", "example.com" };

            // Generate a username by appending "user" to a unique GUID
           


            // Choose a random domain from the list
            Random rand = new Random();
            string randomDomain = domainOptions[rand.Next(domainOptions.Length)];

            // Create the final email address
            string randomEmail = $"{Username}@{randomDomain}";

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

            double _cost = s_rand.NextDouble() * 200 + 200;

            Engineer newEng = new(_id, _name, _email, _level, _cost);

            s_dalEngineer!.Create(newEng);
        }
    }

    private static Guid NewMethod()
    {
        return Guid.NewGuid();
    }

    private static void createDependencies()
    {
        // Function to add random dependencies for a task
        for (int i = 1; i < 5; i++)
        {
            int j = i * 5;
            for (int k = 0; k < 2; k++)
            {
                Dependency newDep = new(1, j - k - 1, j - k);

                s_dalDependency!.Create(newDep);
            }

            for (int k = 1; k < 3; k++)
            {
                Dependency newDep = new(1, j - 2 - k, j - 2);

                s_dalDependency!.Create(newDep);
            }
        }
    }
    private static void createTasks()
    {
        static DateTime GenerateRandomDate()
        {
            Random random = new Random();

            // Define a range of days, for example, the difference between 2000-01-01 and today
            int days = (new DateTime(2024, 1, 1) - new DateTime(2000, 1, 1)).Days;

            // Generate a random date within the specified range
            DateTime startDate = new DateTime(2000, 1, 1);
            DateTime randomDate = startDate.AddDays(random.Next(days));

            return randomDate;
        }
        static TimeSpan GenerateRandomDuration()
        {
            Random random = new Random();

            int randomDays = random.Next(1, 8); // מספרים רנדומליים בין 1 ל-7
            TimeSpan randomTimeSpan = TimeSpan.FromDays(randomDays);
            return randomTimeSpan;

        }


        string[] Alias = { "code", "examination", "combination", "Brainstorming", "Summary", "learning", "requirements", "problems", "bugs", "deep", "keep", "update", "match", "tech",
            "Collaborate", "design", "analyze", "check", "market", "fix" };
        string[] Description = { "writing code", "Code inspection", "Joining programs", "General thinking about work", " Drawing conclusions and drawing lessons", "Structure the requirements in an agreed and logical way", "Solving general problems in the project", "Debugging", "Broadening horizons and deepening knowledge",
            "Ensure that software applications remain functional and up-to-date", "Software update",
            "Ensure that software solutions meet the specific requirements and needs of the organization.", "Stay up-to-date on the latest technologies and trends in the industry.", "You will work closely with designers, project managers and other professionals to successfully complete projects,",
            "Collaborate with cross-functional teams", "Analyze user needs", "check the quality and integrity of the software", "Marketing the software to the customer base", "Make sure the problem is fixed" };


        string[] Deliverables = {
            "Functional and modular code components", "High-quality code with enhanced safety measures", "Integrated and cohesive applications", "Creative and innovative problem-solving approaches",
            "Improved workflows and processes based on insights gained", "Comprehensive and clear requirement documents", "Successful completion of advanced projects",
            "Resolved software issues and improved stability", "Enhanced skills and in-depth expertise", "Robust and updated software applications", "Updated and advanced software versions", "Tailored and maintained software solutions", "Current and informed approach towards industry trends and technologies", "Efficient project completion through collaboration with diverse professionals", "Effective teamwork across varied disciplines", "Customized and user-oriented products or solutions", "High-quality and robust software", "Successfully marketed software with appealing features and benefits", "Resolved issues leading to improved software functionality", "Refined processes and workflows based on experiences and lessons learned" };
        for (int i = 0; i < 20; i++)
        {
            string? _alias = Alias[i];
            string? _description = Description[i];
            DateTime StartDate = GenerateRandomDate();
            TimeSpan RequiredEffortTime = GenerateRandomDuration();
            DateTime DeadlineDate = StartDate + RequiredEffortTime;
            bool? IsMilestone = false;
            Level _level = (Level)s_rand.Next(1, 5);
            DateTime? CompleteDate = null;
            string? _deliverables = Deliverables[i];

            Task newTask = new(0, _alias, _description, null, RequiredEffortTime, IsMilestone,
             StartDate, DeadlineDate, null, _deliverables, 0, _level);

            s_dalTask!.Create(newTask);
        };
    }

    public static void Do(IEngineer? dalEngineer, ITask? dalTask, IDependency? dalDependency)
    { 
        s_dalEngineer = dalEngineer ?? throw new NullReferenceException("DAL can not be null!");
        s_dalTask = dalTask ?? throw new NullReferenceException("DAL can not be null!");
        s_dalDependency = dalDependency ?? throw new NullReferenceException("DAL can not be null!");

        CreateEngineers();
        createTasks();
        createDependencies();
    }

}








