// See https://aka.ms/new-console-template for more information
using LINQ_Lamdas;


class Program
{
    static Random _random = new Random();
    static void Main(string[] args)
    {

        // var myNumbers = new List<int> { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 };


        // Example without Lambdas
        //var numbersOver5 = new List<int>();

        //foreach (var number in myNumbers)
        //{
        //    if (number > 5) numbersOver5.Add(number);
        //}


        // Using Lamdas
        // var numbersOver5 = myNumbers.Where(n => n > 5);


        var gameList = new List<Game>
        {
            new Game { Name = "Deth Stranding", ReleaseDate = new DateTime(2019,11,8), SteamScore = 9 },
            new Game { Name = "Dark Souls 3", ReleaseDate = new DateTime(2015,3,24), SteamScore = 9 },
            new Game { Name = "Cjyberpunk 2077", ReleaseDate = new DateTime(2020,9,17), SteamScore = 7 },
            new Game { Name = "Valheim", ReleaseDate = new DateTime(2021,2,2), SteamScore = 10 },
            new Game { Name = "Loop Hero", ReleaseDate = new DateTime(2021,3,4), SteamScore = 9 },
            new Game { Name = "The Forest", ReleaseDate = new DateTime(2014,5,30), SteamScore = 8 },
            new Game { Name = "Factorio", ReleaseDate = new DateTime(2016,2,21), SteamScore = 10 },
            new Game { Name = "Mass Effect 3", ReleaseDate = new DateTime(2021,3,6), SteamScore = 7 },
        };

        bool allHave9ScoreOrbetter = gameList.All(g => g.SteamScore >= 9);

        // Collection interface offers lazy loading
        IEnumerable<string> gameNames = gameList.Select(g => g.Name);

        //   Game gameWithScoreOf2 = gameList.FirstOrDefault(g => g.SteamScore == 2);

        var suggestedGames = gameList
            .Where(g => g.SteamScore >= 9 && g.ReleaseDate.Year > 2018)
            .OrderBy(g => _random.Next())
            .Take(3)
            .AddReatingToNames();
    }
}

// Create your own Lamda function
public static class Helpers
{
    public static IEnumerable<Game> AddReatingToNames(this IEnumerable<Game> games)
    {
        foreach (var game in games)
        {
            game.Name = $"{game.Name} - {game.SteamScore}";
        }

        return games;
    }
}





