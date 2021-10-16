using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    interface IInventory
    {
        public int amount();

        public void addItem(IGame g);

        public void removeItem(IGame g);

        public IGame retrieveItem(int i);
    }
        
}
