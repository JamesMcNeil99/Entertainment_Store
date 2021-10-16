using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    class Rental: IRental
    {
        List<IGame> games;
        int daysRented, maxDays;
        Customer c;

        public Rental(List<IGame> games, Customer c, int maxDays)
        {
            this.daysRented = 0;
            this.games = games;
            this.c = c;
            this.maxDays = maxDays;
        }
        public void addDay()
        {
            this.daysRented += 1;
        }

    }
}
