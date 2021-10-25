//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public abstract class Customer
    {
        public string name { get; }
        protected IRentBehavior r;
        public List<IRental> rentals { get; set; }
        public Customer(IRentBehavior r, string name)
        {
            rentals = new List<IRental>();
            this.name = name;
            this.r = r;
        }

        //Creates an IRental object using the Customer's rental behavior, r. Adds created rental to list of rentals and finally returns rental. 
        public IRental createRental(IInventory games, Dictionary<Genre, double> prices)
        {
            IRental rental = r.rent(games, getNumOfGamesRented(), this, prices);
            rentals.Add(rental);
            return rental;
         
        }

        //Gets number of games currently rented by customer.
        public int getNumOfGamesRented()
        {
            int x = 0;
            foreach (IRental rental in rentals)
            {
                x += rental.count();
            }
            return x;
        }

        //Uses number of games currently rented to determine if customer can rent another game (Store policy is 3 per customer). 
        public bool getIsEligible()
        {
            int x = getNumOfGamesRented();
            if (x == 3)
                return false;
            else
                return true;
        }
    }
}
