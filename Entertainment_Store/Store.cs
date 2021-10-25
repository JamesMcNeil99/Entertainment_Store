//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class Store
    {
        List<IRental> pastRentals;
        List<IRental> currRentals;
        public IInventory inv { get; set; }
        public double profit { get; set; }
        Dictionary<Genre, double> prices;
        public Store()
        {
            pastRentals = new  List<IRental>();
            currRentals = new List<IRental>();
            inv = InventoryGenerator.create();
            prices = setPrices();
        }


        //returns number of games available to rent.
        public int gamesAvailable()
        {
            return inv.count();
        }
        

        //Receives an eligible customer, lets them select games for a rental, and adds total for rental to total profits
        public void serviceCustomer(Customer c)
        {
            IRental rental = c.createRental(this.inv, prices);
            this.currRentals.Add(rental);
            profit += rental.getTotal();

        }

        //Sets the prices to rent a game based on genre, returns dictionary of prices per genre
        public Dictionary<Genre, double> setPrices()
        {
            Dictionary<Genre, double> d = new Dictionary<Genre, double>();

            d.Add(Genre.ACTION, 5.00);
            d.Add(Genre.NEW_RELEASE, 8.00);
            d.Add(Genre.BOARDGAME, 3.99);
            d.Add(Genre.ADVENTURE, 6.75);
            d.Add(Genre.CASUAL, 2.50);

            return d;

        }

        //adds 1 day to all active rentals 
        public void updateRentals()
        {
            foreach(IRental r in currRentals)
            {
                r.addDay();
            }
        }

        //Checks customers for due rentals, adds rental to past rental list if it is due, and returns games to inventory
        public void returnRentals(Customer c)
        {
            List<IRental> customersRentals = c.rentals;
            List<IRental> rentalsToRemove = new List<IRental>();

            if (!(customersRentals.Count == 0))
            {
                foreach (IRental rental in customersRentals)
                {
                    if (rental.isDue())
                    {
                        //update current and past rentals
                        currRentals.Remove(rental);
                        pastRentals.Add(rental);

                        //Get list of games in rental
                        List<IGame> gamesInRental = rental.getGames();

                        //Use foreach on returned list and add to inv
                        foreach (IGame g in gamesInRental)
                        {
                            this.inv.addItem(g);
                        }

                        //remove rental from customer
                        rentalsToRemove.Add(rental);
                    }
                }

                // removes rentals from customer's rental
                foreach(IRental rental in rentalsToRemove)
                {
                    customersRentals.Remove(rental);
                }
            }
        }
        public List<IRental> getCurrentRentals()
        {
            return this.currRentals;
        }
        public List<IRental> getPastRentals()
        {
            return this.pastRentals;
        }
    }
}
