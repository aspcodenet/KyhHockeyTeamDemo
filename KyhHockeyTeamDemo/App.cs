using System.Runtime.InteropServices;
using KyhHockeyTeamDemo.Models;

namespace KyhHockeyTeamDemo;

public class App
{
    public void Run()
    {
        //ABSOLUT   
        //string path = "C:\\SQL2019\\garmin\\systementor\\2022-05-29_garmin_connect_export\\Teams.txt";


        //RELATIV      
        //string path = "Teams.txt";


        var allTeams = new List<HockeyTeam>();

        allTeams = ReadTeamsFromFile();

        while (true)
        {
            Console.WriteLine("1. Registrera match");
            Console.WriteLine("0. Avsluta");
            Console.Write("Age val:");
            var sel = Console.ReadLine();
            if (sel == "0")
                break;
            if (sel == "1")
            {
                GameRegistration(allTeams);
            }
        }


        //1 - läs in alla team -> lista
        //if(File.Exists("Teams.txt"))


        //2 använd listan när vi kör

        //REPETITION FILER
    }

    private HockeyTeam FindTeamFromShortName(List<HockeyTeam> allTeams, string? lag1)
    {
        foreach (var team in allTeams)
        {
            if (team.ShortName.ToLower() == lag1.ToLower()) return team;
        }

        return null; // NULL  
    }

    private void GameRegistration(List<HockeyTeam> allTeams)
    {
        HockeyTeam team1;
        while (true)
        {
            Console.Write("Ange hemmalag:"); //Shoprtname        400 4
            var lag1 = Console.ReadLine();
            // Om vi har matat in en VALID shortname så break
            team1 = FindTeamFromShortName(allTeams, lag1);
            if (team1 == null)
                Console.WriteLine("Ogiltig shortname");
            else
                break;
        }

        HockeyTeam team2;
        while (true)
        {
            Console.Write("Ange bortalag:"); //Shoprtname        400 4
            var lagKod = Console.ReadLine();
            // Om vi har matat in en VALID shortname så break
            team2 = FindTeamFromShortName(allTeams, lagKod);
            if (team2 == null) 
                Console.WriteLine("Ogiltig shortname");
            else
                break;
        }




        Console.Write($"Ange antal mål som {team1.Name} gjorde:");
        var goal1 = Convert.ToInt32(Console.ReadLine());
        Console.Write($"Ange antal mål som {team2.Name} gjorde:");
        var goal2 = Convert.ToInt32(Console.ReadLine());

        var filename = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
        // Björklöven - AIK 4-4
        var line = $"{team1.Name} - {team2.Name}       {goal1}-{goal2}";
        File.AppendAllText( filename, line +  Environment.NewLine ) ;

        //var lines = new List<string>();
        //lines.Add(line);
        //File.AppendAllLines(filename, lines);
        // File.AppendAllLines(filename, new []{line});


    }


    private List<HockeyTeam> ReadTeamsFromFile()
    {
        var result = new List<HockeyTeam>();
        //Läs fil rad för rad        

        foreach (var line in File.ReadLines("Teams.txt"))
        {
            var parts = line.Split(';'); // DIF;Djurgårdens IF;Stockholm;12.50
            //var team = new HockeyTeam();
            //team.Name = parts[1];
            //team.ShortName = parts[0];
            //team.City = parts[2];
            var team = new HockeyTeam
            {
                City = parts[2],
                ShortName = parts[0],
                Name = parts[1],
            };
            result.Add(team);
        }
        return result;
    }
}