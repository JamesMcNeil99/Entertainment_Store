using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class Rental: IRental
    {
        public List<IGame> games { get; set; }
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
        public int amount()
        {
            return games.Count;
        }

        public double getPrice(Dictionary<Genre, double> prices)
        {
            double price = 0;
            foreach( IGame g in games)
            {
                price += prices[g.getGenre()];
            }
            return price;
        }

        // will check to see if the rental is due and return true
        // if it is due, false otherwise
        public bool isDue()
        {
            if (this.daysRented == this.maxDays)
                return true;
            else
                return false;
        }

    }
}
