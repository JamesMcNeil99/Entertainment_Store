using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class Inventory: IInventory
    {
        List<IGame> inv;

        public Inventory()
        {
            inv = new List<IGame>();
        }

        public int amount()
        {
            return inv.Count;
        }

        public void addItem(IGame g)
        {
            inv.Add(g);
        }

        public void removeItem(IGame g)
        {
            inv.Remove(g);
        }
        public IGame retrieveItem(int i)
        {
            IGame g = inv[i];
            removeItem(g);
            return g;
        }

    }
}
