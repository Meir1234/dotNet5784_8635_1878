

namespace DalTest;


using DalApi;
using DO;
public static class Initialization
{
    //private static IEngineer? s_dalEngineer; //stage 1
    //private static ITask? s_dalTask; //stage 1
    //private static IDependency? s_dalDependency; //stage 1
    private static IDal? s_dal; //stage 2


    private static readonly Random s_rand = new();

    private static void CreateEngineers()
    {
        string[] EngineerNames =
        {
    "Dani Levi", "Eli Amar", "Yair Cohen",
    "Ariela Levin", "Dina Klein", "Shira Israelof"
    };


        string GenerateEmails(string name)
        {
            // המרת שם המהנדס לכתובת מייל בפורמט קבוע
            string email = $"{name.Replace(" ", "_")}@gmail.com";
            return email;
        };


        foreach (var engineerName in EngineerNames)
        {
            int engineerId;
            do
            {
                engineerId = s_rand.Next(200000000, 400000000);
            }
            while (s_dal!.Engineer.Read(engineerId) != null);

            string engineerEmail = GenerateEmails(engineerName);

            Level engineerLevel = (Level)s_rand.Next(1, 5);

            double engineerCost = s_rand.Next(20000, 40000) / 100.0;

            Engineer newEngineer = new(engineerId, engineerName, engineerEmail, engineerLevel, engineerCost);

            s_dal!.Engineer!.Create(newEngineer);
        }
    }
    private static void CreateDependencies()
    {
        int depend = 0;
        int dependon = 0;
        List<Task> tasks = s_dal.Task.ReadAll().ToList();
        HashSet<Dependency> dependencies = new HashSet<Dependency>();
        for (int i = 5; i < tasks.Count() * 2; i++)
        {
            switch (i)
            {
                case int x when x < 10:
                    dependon = s_rand.Next(0, 5);
                    depend = s_rand.Next(5, 11);
                    dependon = tasks[dependon].Id;
                    depend = tasks[depend].Id;
                    break;

                case int x when x < 20:
                    dependon = s_rand.Next(5, 11);
                    depend = s_rand.Next(11, 16);
                    dependon = tasks[dependon].Id;
                    depend = tasks[depend].Id;
                    break;

                case int x when x < 40:
                    dependon = s_rand.Next(11, 16);
                    depend = s_rand.Next(16, 20);
                    dependon = tasks[dependon].Id;
                    depend = tasks[depend].Id;
                    break;

                default:
                    return;

            }
            Dependency dep = new Dependency(
                    Id: 0,
                    DependentTask: depend,
                    DependsOnTask: dependon);

            if (depend != dependon && !dependencies.Contains(dep))
            {
                s_dal.Dependency.Create(dep);
                dependencies.Add(dep);
            }
            else
                i--;
        }
    }
    private static void CreateTasks()
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
        "Collaborate", "design", "analyze", "check", "market", "fix" , ""};
        string[] Description = { "writing code", "Code inspection", "Joining programs", "General thinking about work", " Drawing conclusions and drawing lessons", "Structure the requirements in an agreed and logical way", "Solving general problems in the project", "Debugging", "Broadening horizons and deepening knowledge",
        "Ensure that software applications remain functional and up-to-date", "Software update",
        "Ensure that software solutions meet the specific requirements and needs of the organization.", "Stay up-to-date on the latest technologies and trends in the industry.", "You will work closely with designers, project managers and other professionals to successfully complete projects,",
        "Collaborate with cross-functional teams", "Analyze user needs", "check the quality and integrity of the software", "Marketing the software to the customer base", "Make sure the problem is fixed", "" };
        string[] Deliverables = {
        "Functional and modular code components", "High-quality code with enhanced safety measures", "Integrated and cohesive applications", "Creative and innovative problem-solving approaches",
        "Improved workflows and processes based on insights gained", "Comprehensive and clear requirement documents", "Successful completion of advanced projects",
        "Resolved software issues and improved stability", "Enhanced skills and in-depth expertise", "Robust and updated software applications", "Updated and advanced software versions",
        "Tailored and maintained software solutions", "Current and informed approach towards industry trends and technologies", "Efficient project completion through collaboration with diverse professionals",
        "Effective teamwork across varied disciplines", "Customized and user-oriented products or solutions", "High-quality and robust software", "Successfully marketed software with appealing features and benefits",
        "Resolved issues leading to improved software functionality", "Refined processes and workflows based on experiences and lessons learned", "" };
        for (int i = 0; i < 20; i++)
        {
            string? _alias = Alias[i];
            string? _description = Description[i];
            DateTime StartDate = GenerateRandomDate();
            TimeSpan RequiredEffortTime = GenerateRandomDuration();
            bool? IsMilestone = false;
            Level _level = (Level)s_rand.Next(1, 5);
            string? _deliverables = Deliverables[i];

            Task newTask = new(0,"", _alias, _description, DateTime.Now,null, RequiredEffortTime, IsMilestone,
             null, null, null, _deliverables, 0, _level);

            //s_dalTask!.Create(newTask);
            s_dal!.Task!.Create(newTask);
        };
    }
    public static void Do()
    {
       
        s_dal = DalApi.Factory.Get;
        s_dal.StartDate = null;
        s_dal.EndDate = null;
        s_dal.Dependency.Clear();
        s_dal.Engineer.Clear();
        s_dal.Task.Clear();
        CreateEngineers();
        CreateTasks();
        CreateDependencies();
    }

    public static void Reset()
    {
        ClearXml.Do();
    }

}