using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class RentalGenerator
    {
        public static IRental createRental(int numOfDays, List<IGame> games, Customer customer)
        {
            return new Rental(games, customer, numOfDays);
        }
    }
}
