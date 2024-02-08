using GamesDataAccess;
using GamesDataAccess.Criterias;
using GamesDataAccess.DbItems;
using GamesTests.Output;
using System.Data.SQLite;

internal class Program
{
    private static void Main(string[] args)
    {
        string dbFile = @"..\..\Data\test.db";
        string dbFilePath = Path.GetDirectoryName(dbFile)!;
        if (!Directory.Exists(dbFilePath))
        {
            Directory.CreateDirectory(dbFilePath);
        }

        string connStr = $@"Data Source={dbFile}; Version=3;Foreign Keys=True";

        GamesDao gamesDao =
        new GamesDao
        (
            connectionFactory: () => new SQLiteConnection(connStr),
            strConcatOperator: "||",
            parameterPrefix: ":"
        );

        gamesDao.DropAllTables();

        gamesDao.CreateAllTables();

        DataPopulator dataPopulator = new DataPopulator(gamesDao);

        dataPopulator.AddSomeData();

        Func.PrintLine("Start");
        bool isSessionOpen = true;

        while (isSessionOpen)
        {

            Menus.MainMenu(ref isSessionOpen, gamesDao);

        }


        Func.PrintLine("End");

        //PrintLine("All games");

        //GameDbItem[] games = gamesDao.GetAllGames();

        //foreach (var game in games)
        //{
        //    Console.WriteLine(game);
        //}

        //PrintLine("All stores");

        //StoreDbItem[] stores = gamesDao.GetAllStores();

        //foreach (var store in stores)
        //{
        //    Console.WriteLine(store);
        //}

        //PrintLine("All platforms");

        //PlatformDbItem[] platforms = gamesDao.GetAllPlatforms();

        //foreach (var platform in platforms)
        //{
        //    Console.WriteLine(platform);
        //}

        //PrintLine("Owned games");

        //var ownedGames =
        //    gamesDao
        //    .GetOwnedGamesByCriteria
        //    (
        //        new GamesCriteria
        //        {
        //            PurchaseDateFrom = new DateOnly(2022, 1, 1),
        //            StoreName = "me",
        //            StoreDescription = "resto",
        //            PlatformName = "Play",
        //            GameName = "zelda",
        //            GameTags = "adv"
        //        }
        //    );

        //foreach (var tx in ownedGames)
        //{
        //    Console.WriteLine(tx);
        //}

    }

    

    





    


}