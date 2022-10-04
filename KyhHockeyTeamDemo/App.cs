using System.Runtime.InteropServices;
using KyhHockeyTeamDemo.Models;

namespace KyhHockeyTeamDemo;

public class App
{
    public void Run()
    {
        var team = new HockeyTeam();
        team.ShortName = "AIK";
        team.Name = "Allmänna Idrottsklubben";
        team.City = "Solna";
        Console.WriteLine(team.Name);

        var team2 = new HockeyTeam();
        team2.ShortName = "DIF";
        team2.Name = "Djurgården";
        team2.City = "Stockholm";

        int i = 12;

    }
}