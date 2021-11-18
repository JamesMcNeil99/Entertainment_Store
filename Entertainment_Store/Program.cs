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
                Console.WriteLine($"-------------------------------Day {day}-------------------------------");
                //Cameron's portion
                //---------------------------Morning Portion (Before Open for Business)---------------------
                if(day != 0)
                    foreach (Customer c in customers)
                    {
                        //customers need to return due rentals
                        store.returnRentals(c);
                    }


                //Tyler's portion
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

                //Cameron's portion
                //---------------------------Night Portion (After Closed for Business)---------------------
                //Loop through active rentals, increment day count to check before 
                store.updateRentals();
                Console.WriteLine("");

            }

            //Cameron's portion
            //print out Games in inventory
            Console.WriteLine("Store inventory amount: " + store.inv.count());
            List<IGame> gamesInStore = store.inv.getGames();
            Console.WriteLine("List of games currently available in the inventory: ");
            foreach(IGame game in gamesInStore)
            {
                Console.WriteLine(game.getTitle());
            }
            Console.WriteLine();

            // amount of money the store made in the 35 days
            Console.WriteLine("Store's earnings in the past 35 days: $" + String.Format("{0:#,0.00}", store.profit));
            Console.WriteLine();

            //Tyler's portion
            //print out past rentals with customer name, number of days, total price
            Console.WriteLine("--------------Past Rentals--------------");
            foreach (IRental r in store.getPastRentals())
            {
                Console.Write($"{r.getCustomer().name} rented ");
                for (int game = 0; game < r.getGames().Count - 1; game++)
                {
                    Console.Write(r.getGames()[game].getTitle() + ", ");
                }
                Console.Write(r.getGames()[r.getGames().Count - 1].getTitle() + $" for {r.getMaxDays()} days with a total cost of $" + String.Format("{0:#,0.00}", r.getTotal()) + "\n");
            }

            //print out current rentals
            Console.WriteLine("--------------On Going Rentals--------------");
            foreach(IRental r in store.getCurrentRentals())
            {
                Console.Write($"{r.getCustomer().name} is renting ");
                    for(int game = 0; game<r.getGames().Count -1; game++)
                    {
                    Console.Write(r.getGames()[game].getTitle() + ", ");
                    }
                Console.Write(r.getGames()[r.getGames().Count - 1].getTitle() + $" for {r.getMaxDays()} days with a total cost of $" + String.Format("{0:#,0.00}",r.getTotal())+ "\n");
            }


        }



        //Tyler's portion
        //Helper method to create array of customers. Each customer is randomly assigned to be casual, hardcore, or professional.
        //Uses CustomerGenerator class to handle dependencies
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
