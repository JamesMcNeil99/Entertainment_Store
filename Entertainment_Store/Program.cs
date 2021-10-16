using System;

namespace Entertainment_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer[] customers = makeCustomers();
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
