using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.

            while (true)
            {
                Console.WriteLine("Loading...");
                ServiceReference1.Service1Client proxy = new ServiceReference1.Service1Client();

                var gamelist = proxy.GetGameList();
                Console.Clear();
                int counter = 0;
                foreach (var game in gamelist)
                {
                    counter++;
                    Console.WriteLine(counter + ". " + game.Title + ": " + game.Rating + "/10");
                }

                Console.WriteLine("\n1. Create New Entry");
                Console.WriteLine("2. Update Entry");
                Console.WriteLine("3. Delete Entry");

                string val = Console.ReadLine();

                switch (val)
                {
                    case "1":
                        Console.WriteLine("Enter Title");
                        var title = Console.ReadLine();
                        Console.WriteLine("Enter Rating (1-10)");
                        var rating = Console.ReadLine();
                        int ratingNumber;
                        var res = Int32.TryParse(rating, out ratingNumber);
                        if (res == false)
                        {
                            Console.WriteLine("Not A number");
                            Console.ReadKey();
                            break;
                        }
                        if(ratingNumber <0 || ratingNumber > 10)
                        {
                            Console.WriteLine("rating must be between 1 and 10");
                            Console.ReadKey();
                            break;
                        }
                        proxy.CreateNewGame(title, ratingNumber);

                        break;
                    case "2":
                        Console.WriteLine("Enter the lederboard placement of The Game");
                        var placement = Console.ReadLine();
                        int placementNumber = 0;
                        res = Int32.TryParse(placement, out placementNumber);
                        if (res == false)
                        {
                            Console.WriteLine("Not A number");
                            Console.ReadKey();
                            break;
                        }
                        if (placementNumber < 0 || placementNumber>gamelist.Count())
                        {
                            Console.WriteLine("Thats not on the leaderboard");
                            Console.ReadKey();
                            break;
                        }

                        Console.WriteLine("Enter New Title");
                        title = Console.ReadLine();
                        Console.WriteLine("Enter New Rating (1-10)");
                        rating = Console.ReadLine();
                         ratingNumber = 0;
                         res = Int32.TryParse(rating, out ratingNumber);
                        if (res == false)
                        {
                            Console.WriteLine("Not A number");
                            Console.ReadKey();
                            break;
                        }
                        if (ratingNumber < 0 || ratingNumber > 10)
                        {
                            Console.WriteLine("rating must be between 1 and 10");
                            Console.ReadKey();
                            break;
                        }
                        proxy.UpdateGame(Int32.Parse(placement), title, ratingNumber);

                        break;
                    case "3":
                        Console.WriteLine("Enter the lederboard placement of The Game");
                        placement = Console.ReadLine();
                        placementNumber = 0;
                        res = Int32.TryParse(placement, out placementNumber);
                        if (res == false)
                        {
                            Console.WriteLine("Not A number");
                            Console.ReadKey();
                            break;
                        }
                        if (placementNumber < 0 || placementNumber > gamelist.Count())
                        {
                            Console.WriteLine("Thats not on the leaderboard");
                            Console.ReadKey();
                            break;
                        }
                        proxy.DeleteGame(placementNumber);
                        break;
                    default:
                        Console.WriteLine("Not A Valid Command");
                        break;
                }



            }
            
        }

    }
}
