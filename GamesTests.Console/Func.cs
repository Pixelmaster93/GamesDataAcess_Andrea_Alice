using GamesDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesTests.Output
{
    public class Func
    {
        public static void PrintLine(string? title = null)
        {
            const int maxLen = 100;

            if ((title?.Length ?? 0) > maxLen)
            {
                System.Console.WriteLine(title);
                return;
            }

            int halfLen = (maxLen - (title?.Length ?? 0)) / 2;
            string halfLine = new string('-', halfLen);
            System.Console.WriteLine($"{halfLine} {title ?? ""} {halfLine}");
        }

        public static void LookupGameByFilter(
                                GamesDao gamesDao,
                                ref bool isSessionOpen,
                                ref bool isGameFound,
                                ref bool isGamesMenuOpen,
                                string? idFilter = null,
                                string? nameFilter = null,
                                string? descFilter = null,
                                string? tagFilter = null
                                )
        {
            var list = "";
            var gamespart = gamesDao.GetGamesByPartialValue(idFilter, nameFilter, descFilter, tagFilter);

            foreach (var game in gamespart)
                list = $"\n" +
                        $"GAME ID: {game.GameId}, \n" +
                        $"NAME: {game.GameName}, \n" +
                        $"DESCRIPRION: {game.GameDescription}, \n" +
                        $"TAGS: {game.GameTags} \n";

            System.Console.WriteLine(list);

            if (gamespart.Count() == 0)
            {
                Menus.NotFoundExceptionMenu(ref isSessionOpen, ref isGameFound, ref isGamesMenuOpen);
            }
            else
            {
                isGameFound = true;

                Menus.NewSearchAfterSuccessMenu(ref isSessionOpen, ref isGamesMenuOpen);
            }
        }
    }
}
