using System.Runtime.InteropServices;
using KyhHockeyTeamDemo.Models;

namespace KyhHockeyTeamDemo;

public class App
{
    public void Run()
    {
        //ABSOLUT
        //string path = "C:\\SQL2019\\garmin\\systementor\\2022-05-29_garmin_connect_export\\Teams.txt";


        var allTeams = new List<HockeyTeam>();
        //1 - läs in alla team -> lista
        if(File.Exists("Teams.txt"))
            allTeams = ReadTeamsFromFile();

        //2 använd listan när vi kör

        //REPETITION FILER


    }
}