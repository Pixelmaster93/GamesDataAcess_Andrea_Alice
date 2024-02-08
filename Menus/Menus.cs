using GamesDataAccess;
using GamesTests.Console;
using System;

namespace Menus
{
    public class Menus
    {
        public static void MainMenu(ref bool isSessionOpen, GamesDao gamesDao)
        {
            bool isGamesMenuOpen;

            Console.WriteLine("What are you looking for?");
            Console.WriteLine("1. Games \n" +
                                "2. Stores \n" +
                                "3. Platforms \n" +
                                "4. Nothing, exit \n");

            switch ((Console.ReadLine() ?? "").Trim())
            {
                case "1":
                    {
                        isGamesMenuOpen = true;
                        while (isGamesMenuOpen)
                        {
                            GamesMenu(ref isSessionOpen, ref isGamesMenuOpen, gamesDao);
                        }
                        break;
                    }
                case "2":
                    {
                        //will ask for the search criteria for stores
                        Func.PrintLine("STORE");
                        break;
                    }
                case "3":
                    {
                        //will ask for the search criteria for platforms
                        Func.PrintLine("PIATTAFORME");
                        break;
                    }
                case "4":
                    {
                        //nothing to do here
                        isSessionOpen = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There was an error, try again writing " +
                            "only the number for the desired functionality");
                        break;
                    }

            };
        }

        public static void GamesMenu(ref bool isSessionOpen, ref bool isGamesMenuOpen, GamesDao gamesDao)
        {
            bool isGameFound = false;

            Console.WriteLine("How would you like to look it up?");
            Console.WriteLine("1. By Id \n" +
                                "2. By Name \n" +
                                "3. By Description \n" +
                                "4. By Tag \n" +
                                "5. Go back \n" +
                                "6. Exit \n");

            switch ((Console.ReadLine() ?? "").Trim())
            {
                case "1":
                    {
                        while (!isGameFound)
                        {
                            Console.Write("\nEnter the ID of the game: ");
                            var filterValue = (Console.ReadLine() ?? "").Trim().ToLower();
                            Func.LookupGameByFilter(gamesDao,
                                                ref isSessionOpen,
                                                ref isGameFound,
                                                ref isGamesMenuOpen,
                                                idFilter: filterValue);
                        }

                        break;
                    }
                case "2":
                    {
                        while (!isGameFound)
                        {
                            Console.Write("\nEnter the Name of the game: ");
                            var filterValue = (Console.ReadLine() ?? "").Trim().ToLower();
                            Func.LookupGameByFilter(gamesDao,
                                                ref isSessionOpen,
                                                ref isGameFound,
                                                ref isGamesMenuOpen,
                                                nameFilter: filterValue);
                        }

                        break;
                    }
                case "3":
                    {
                        while (!isGameFound)
                        {
                            Console.Write("\nEnter the Description of the game: ");
                            var filterValue = (Console.ReadLine() ?? "").Trim().ToLower();
                            Func.LookupGameByFilter(gamesDao,
                                                ref isSessionOpen,
                                                ref isGameFound,
                                                ref isGamesMenuOpen,
                                                descFilter: filterValue);
                        }

                        break;
                    }
                case "4":
                    {
                        while (!isGameFound)
                        {
                            Console.Write("\nEnter the Tag of the game: ");
                            var filterValue = (Console.ReadLine() ?? "").Trim().ToLower();
                            Func.LookupGameByFilter(gamesDao,
                                                ref isSessionOpen,
                                                ref isGameFound,
                                                ref isGamesMenuOpen,
                                                tagFilter: filterValue);
                        }

                        break;
                    }
                case "5":
                    {
                        //go back
                        isGamesMenuOpen = false;
                        break;
                    }
                case "6":
                    {
                        //exit
                        isGamesMenuOpen = false;
                        isSessionOpen = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There was an error, try again writing " +
                            "only the number for the desired functionality");

                        break;
                    }
            }
        }

        public static void NewSearchAfterSuccessMenu(ref bool isSessionOpen, ref bool isGamesMenuOpen)
        {
            Console.WriteLine("Want to do another lookup? (Y/N)");
            switch ((Console.ReadLine() ?? "").Trim().ToLower())
            {
                case "y":
                    isGamesMenuOpen = false;
                    break;
                case "n":
                    isGamesMenuOpen = false;
                    isSessionOpen = false;
                    break;
            }
        }

        public static void NotFoundExceptionMenu(ref bool isSessionOpen, ref bool isGameFound, ref bool isGamesMenuOpen)
        {
            Console.WriteLine($"No results found! \n" +
                                $"1. Retry \n" +
                                $"2. Go Back \n" +
                                $"3. Return to Main Menu \n" +
                                $"4. Exit");

            switch ((Console.ReadLine() ?? "").Trim())
            {
                case "1":
                    {
                        //retry
                        isGameFound = false;
                        break;
                    }
                case "2":
                    {
                        //Go Back
                        isGameFound = true;
                        break;
                    }
                case "3":
                    {
                        //Return to Main Menu
                        isGamesMenuOpen = false;
                        isGameFound = true;
                        break;
                    }
                case "4":
                    {
                        //Exit
                        isGameFound = true;
                        isGamesMenuOpen = false;
                        isSessionOpen = false;
                        break;
                    }
                default:
                    {
                        Console.WriteLine("There was an error, try again writing only the number for the desire functionality");
                        break;
                    }
            }
        }
    }
}
