

namespace DalTest;
using DalFacade.DalApi;
using DalFacade.DO;
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
    }
    private static void createDependencys()
    {


    }
}