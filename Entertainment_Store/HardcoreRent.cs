//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class HardcoreRent: IRentBehavior
    {

        //Creates rental object using specified rental behavior (3 games for 7 days)
        public IRental rent(IInventory games, int numOfGames, Customer customer, Dictionary<Genre, double> prices)
        {
            Random rand = new Random();
            int days = 7;
            List<IGame> selectedGames = new List<IGame>();

            while (selectedGames.Count < 3)
            {
                int index = rand.Next(games.count());
                selectedGames.Add(games.retrieveItem(index));
            }
            return RentalGenerator.createRental(days, selectedGames, customer, prices);
        }
    }
}
