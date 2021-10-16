using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class CasualCustomer : Customer
    {
        public CasualCustomer(IRentBehavior r, string name) : base(r, name)
        {

        }

        public override List<IGame> selectGames(List<IGame> inv)
        {

        }

    }
}
