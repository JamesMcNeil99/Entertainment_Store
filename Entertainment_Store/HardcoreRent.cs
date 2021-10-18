using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class HardcoreRent: IRentBehavior
    {
        public IRental rent(IInventory games, int numOfGames, Customer customer)
        {
            Random rand = new Random();
            int days = 7;
            List<IGame> selectedGames = new List<IGame>();

            while (selectedGames.Count < 3)
            {
                int index = rand.Next(games.amount());
                selectedGames.Add(games.retrieveItem(index));
            }
            return RentalGenerator.createRental(days, selectedGames, customer);
        }
    }
}
