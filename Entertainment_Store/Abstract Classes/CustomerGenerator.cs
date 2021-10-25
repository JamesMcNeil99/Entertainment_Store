//Tyler's Portion

using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    abstract class CustomerGenerator
    {
        //Array of unique names to be used when creating customers. 
        static string[] name = { "John", "James", "Daniel", "David", "Joe", "Matthew", "Michael", "Nick", "Andrew", "Adam" } ;
        static int count = 0;

        //Static methods to be used for creating Casual, Hardcore, and Professional Customers.
        //Handles dependencies for the created customer, creates appropriate IRentalBehavior object and passed to constructor.
        public static Customer createCasualCustomer()
        {
            count++;
            CasualRent r = new CasualRent();
            return new CasualCustomer(r, name[count -1]);
        }
        public static Customer createHardcoreCustomer()
        {
            count++;
            HardcoreRent r = new HardcoreRent();
            return new HardcoreCustomer(r, name[count - 1]);
        }
        public static Customer createProfessionalCustomer()
        {
            count++;
            ProfessionalRent r = new ProfessionalRent();
            return new ProfessionalCustomer(r, name[count - 1]);
        }
    }
}
