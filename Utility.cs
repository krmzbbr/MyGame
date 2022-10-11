using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeekSixFallTuesday
{
    internal static class Utility
    {
        //Relative path to save game data to harddrive
        static string gameJsonPath = $"{AppDomain.CurrentDomain.BaseDirectory}\\game.json";
        
        public static string ReadFromFile(string path)
        {
            string result = String.Empty;
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null)
                {
                    result += s;
                }
            }
            return result;
        }

        //Saves a JSON version of the game to the harddrive
        public static void SaveGameToHardDrive(Game game)
        {
            //Create a string representation of the game
            string gameJson = JsonSerializer.Serialize(game);

            //Write it to the    harddrive         
            File.WriteAllText(gameJsonPath, gameJson);
        }

        public static Game LoadGameFromHardDrive()
        {
            //Create new game instance
            Game game;
            
            string gameJson = String.Empty;

            //Check to see if the file exists
            if (File.Exists(gameJsonPath))
            {
                //Read the file and convert the contents into a Game instance
                gameJson = File.ReadAllText(gameJsonPath);
                game = JsonSerializer.Deserialize<Game>(gameJson);
            }
            else
            {
                //File does not exist, create a new game instance
                game = new Game()
                {
                    Score = 0,
                    Name = "My new game",
                    NumberOfTimeGamePlayed = 0
                };
            }
            return game;
        }

    }
}
