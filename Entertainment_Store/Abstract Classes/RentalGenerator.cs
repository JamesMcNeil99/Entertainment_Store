//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class RentalGenerator
    {

        //method to create IRental objects, handles dependency 
        public static IRental createRental(int numOfDays, List<IGame> games, Customer customer, Dictionary<Genre, double> prices)
        {
            return new Rental(games, customer, numOfDays, prices);
        }
    }
}
