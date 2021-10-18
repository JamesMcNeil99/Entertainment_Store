using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class Inventory: IInventory
    {
        List<IGame> games;

        public Inventory(List<IGame> games)
        {
            this.games = games;
        }

        public int amount()
        {
            return games.Count;
        }

        public void addItem(IGame g)
        {
            games.Add(g);
        }

        public void removeItem(IGame g)
        {
            games.Remove(g);
        }
        public IGame retrieveItem(int i)
        {
            IGame g = games[i];
            removeItem(g);
            return g;
        }

    }
}
