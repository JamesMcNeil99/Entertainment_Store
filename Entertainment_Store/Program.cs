using System;
using System.Collections.Generic;

namespace Entertainment_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = makeCustomers();
            Store store = new Store();



            //main loop:
            for(int day = 0; day < 35; day++)
            {
                //---------------------------Morning Portion (Before Open for Business)---------------------
                foreach (Customer c in customers)
                {
                    //customers need to return due rentals
                    store.returnRentals(c);
                }
                
                
                
                //---------------------------Day Portion (Open for Business)---------------------
                
                Random rand = new Random();
                int customersToday = rand.Next(1, 11);
                int servicedCustomers = 0;

                //send in eligible customers
                foreach (Customer c in customers)
                {
                    {
                        //Checks for hardcore customers -> if store has games (hardcore needs more than 3 ?) && Customer c is eligible (aka no more than 3 currently rented games)
                        if (c is HardcoreCustomer && c.getIsEligible() && store.gamesAvailable() >= 3)
                        {
                            store.serviceCustomer(c);
                            servicedCustomers++;
                        }
                        //Checks for not hardcore and at least one game 
                        else if (!(c is HardcoreCustomer) && c.getIsEligible() && store.gamesAvailable() > 0)
                        {
                            store.serviceCustomer(c);
                            servicedCustomers++;
                        }
                        //if customers serviced reaches random allotment for current day, breaks out and continues to next day. 
                        if(customersToday == servicedCustomers)
                        {
                            break;
                        }
                    }
                }


                //---------------------------Night Portion (After Closed for Business)---------------------
                //Loop through active rentals, increment day count to check before 
                store.updateRentals();

            }

            //print out past rentals, current rentals,  and money made.
            Console.WriteLine("Store inventory amount: " + store.inv.amount());
            List<IGame> gamesInStore = store.inv.getGames();
            Console.WriteLine("List of games currently available in the inventory: ");
            foreach(IGame game in gamesInStore)
            {
                Console.WriteLine(game);
            }
            Console.WriteLine();

            // amount of money the store made in the 35 days
            Console.WriteLine("Store's earnings in the past 35 days: " + store.profit);
            Console.WriteLine();


        }
        
        
        
        
        public static Customer[] makeCustomers()
        {
            Customer[] customers = new Customer[10];

            Random rand = new Random();

            for(int x = 0; x < customers.Length; x++)
            {
                int y = rand.Next(1, 4);

                if (y == 1)
                    customers[x] = CustomerGenerator.createCasualCustomer();
                else if(y == 2)
                    customers[x] = CustomerGenerator.createHardcoreCustomer();
                else
                    customers[x] = CustomerGenerator.createProfessionalCustomer();

            }
            return customers;
        }
    }
}
