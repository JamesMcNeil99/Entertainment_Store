using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    abstract class InventoryGenerator
    {
        static string[] gameNames = { "Back 4 Blood", "Halo Infinite", "Far Cry 6", "Battlefield 6", "Deathloop", "Riders Republic", "Marvel's Guardians of the Galaxy", "Resident Evil Village", "Metroid Dread", "Call of Duty Vanguard", "Hitman 3", "Forza Horizon 5", "Psychonauts 2", "House of Ashes", "Jurassic World Evolved", "Ratchet & Clank: Rift Apart", "Outriders", "Monster Hunter Rise", "Age of Empires IV", "Stray", "Kena: Bridge of Spirits" };
        public static IInventory create()
        {
            List<IGame> games = createGames();
            IInventory inv = new Inventory(games);

            return inv;
        }
        public static List<IGame> createGames()
        {
            List<IGame> games = new List<IGame>();

            for(int game = 0; game < 20; game++)
            {
                Random rand = new Random();
                int genre = rand.Next(1, 6);
                if (genre == 1)
                    games.Add(new Game(Genre.ACTION, gameNames[game]));
                else if (genre == 2)
                    games.Add(new Game(Genre.ADVENTURE, gameNames[game]));
                else if (genre == 3)
                    games.Add(new Game(Genre.BOARDGAME, gameNames[game]));
                else if (genre == 4)
                    games.Add(new Game(Genre.CASUAL, gameNames[game]));
                else
                    games.Add(new Game(Genre.NEW_RELEASE, gameNames[game]));
            }
            return games;
        }
    }
}
