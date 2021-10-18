﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public class Store
    {
        List<IRental> pastRentals;
        List<IRental> currRentals;
        IInventory inv;
        double profit;
        Dictionary<Genre, double> prices;
        public Store()
        {
            pastRentals = new  List<IRental>();
            currRentals = new List<IRental>();
            inv = InventoryGenerator.create();
            prices = setPrices();
        }

        public int gamesAvailable()
        {
            return inv.amount();
        }
        
        public void serviceCustomer(Customer c)
        {
            IRental rental = c.createRental(this.inv);
            this.currRentals.Add(rental);
            profit += rental.getPrice(prices);

        }
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

        public void updateRentals()
        {
            foreach(IRental r in currRentals)
            {
                r.addDay();
            }
        }

        public void returnRentals(Customer c, int day)
        {
            List<IRental> customersRentals = c.rentals;
            
            foreach(IRental r in customersRentals)
            {
                if (r.isDue())
                {
                    //update current and past rentals
                    currRentals.Remove(r);
                    pastRentals.Add(r);

                    //Get list of games in r
                    //Use foreach on returned list and add to inv
                    foreach (IGame g in r.games)
                    //remove r from customer
                }
            }
        }
    }
}
