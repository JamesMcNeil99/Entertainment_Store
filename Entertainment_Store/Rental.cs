//Cameron's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class Rental: IRental
    {
        List<IGame> games;
        int daysRented, maxDays;
        Customer c;
        double total;

        public Rental(List<IGame> games, Customer c, int maxDays, Dictionary<Genre, double> prices)
        {
            this.daysRented = 0;
            this.games = games;
            this.c = c;
            this.maxDays = maxDays;
            this.total = getPrice(prices);
        }

        //Increments the Rental's daysRented by 1
        public void addDay()
        {
            this.daysRented += 1;
        }

        //Returns the number of games contained in the Rental
        public int count()
        {
            return games.Count;
        }

        //Using passed dictionary of game prices per genre, calculates price of rental and returns that value.
        public double getPrice(Dictionary<Genre, double> prices)
        {
            double price = 0;
            foreach( IGame g in games)
            {
                price += prices[g.getGenre()];
            }
            this.total = price;
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

        // returns list of games
        public List<IGame> getGames()
        {
            return this.games;
        }

        //returns Customer associated with Rental
        public Customer getCustomer()
        {
            return this.c;
        }

        //returns number of days the rental was purchased for
        public int getMaxDays()
        {
            return maxDays;
        }

        //returns the calculated price
        public double getTotal()
        {
            return total;
        }

    }
}
