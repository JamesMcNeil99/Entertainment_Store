using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class ProfessionalRent: IRentBehavior
    {
        public IRental rent(IInventory games, int numOfGames, Customer customer)
        {
            Random rand = new Random();
            int days = rand.Next(3, 6);
            List<IGame> selectedGames = new List<IGame>();
            int gamesWanted = rand.Next(1, 4 - numOfGames);
            while (selectedGames.Count < gamesWanted && games.amount() > 0)
            {
                int index = rand.Next(games.amount());
                selectedGames.Add(games.retrieveItem(index));
            }
            return RentalGenerator.createRental(days, selectedGames, customer);
        }
    }
}
