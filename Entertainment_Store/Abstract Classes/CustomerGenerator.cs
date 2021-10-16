using System;
using System.Collections.Generic;
using System.Text;
using Unity;

namespace Entertainment_Store
{
    abstract class CustomerGenerator
    {

        static string[] name = { "John", "James", "Daniel", "David", "Joe", "Matthew", "Michael", "Nick", "Andrew", "Adam" } ;
        static int count = 0;
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
