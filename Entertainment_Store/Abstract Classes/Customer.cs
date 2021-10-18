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

        public IRental createRental(IInventory games)
        {
            IRental rental = r.rent(games, getNumOfGamesRented(), this);
            rentals.Add(rental);
            return rental;
         
        }

        public int getNumOfGamesRented()
        {
            int x = 0;
            foreach (IRental rental in rentals)
            {
                x += rental.amount();
            }
            return x;
        }

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
