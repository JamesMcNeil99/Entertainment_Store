using System;

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
                    //store.check(c)
                }
                
                
                
                //---------------------------Day Portion (Open for Business)---------------------
                
                Random rand = new Random();
                int customersToday = rand.Next(1, 10);
                
                //send in eligible customers
                foreach (Customer c in customers)
                {
                    int servicedCustomers = 0;
                    while (servicedCustomers < customersToday)
                    {
                        //if store has games (hardcore needs more than 3 ?) && Customer c is eligible (aka no more than 3 currently rented games)
                        if (c is HardcoreCustomer && c.getIsEligible() && store.gamesAvailable() >= 3)
                        {
                            store.serviceCustomer(c);
                            servicedCustomers++;
                        }
                        else if (!(c is HardcoreCustomer) && c.getIsEligible() && store.gamesAvailable() > 0)
                        {
                            store.serviceCustomer(c);
                            servicedCustomers++;
                        }
                    }
                }


                //---------------------------Night Portion (After Closed for Business)---------------------
                //Loop through active rentals, increment day count to check before 
                store.updateRentals();

            }

            //print out past rentals, current rentals,  and money made.


        }
        
        
        
        
        public static Customer[] makeCustomers()
        {
            Customer[] customers = new Customer[10];

            Random rand = new Random();

            for(int x = 0; x < customers.Length; x++)
            {
                int y = rand.Next(1, 3);

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
