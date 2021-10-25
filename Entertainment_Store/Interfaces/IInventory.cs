//Cameron's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public interface IInventory
    {
        public int count();

        public void addItem(IGame g);

        public void removeItem(IGame g);

        public IGame retrieveItem(int i);

        public List<IGame> getGames();
    }
        
}
