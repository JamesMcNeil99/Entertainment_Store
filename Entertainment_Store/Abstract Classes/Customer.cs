using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public abstract class Customer
    {
        string name;
        IRentBehavior r;
        public Customer(IRentBehavior r, string name)
        {
            this.name = name;
            this.r = r;
        }

        public abstract List<IGame> selectGames(List<IGame> inv);
    }
}
