﻿//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class CasualRent: IRentBehavior
    {

        //Creates rental object using specified rental behavior (1 to 2 games, if available, for 1 to 2 days)
        public IRental rent(IInventory games, int numOfGames, Customer customer, Dictionary<Genre, double> prices)
        {
            Random rand = new Random();
            int days = rand.Next(1, 3);
            List<IGame> selectedGames = new List<IGame>();
            int gamesWanted = rand.Next(1, 3 - numOfGames);
            while (selectedGames.Count < gamesWanted && games.count() > 0)
            {
                int index = rand.Next(games.count());
                selectedGames.Add(games.retrieveItem(index));
            }
            return RentalGenerator.createRental(days, selectedGames, customer, prices);
        }
    }
}
