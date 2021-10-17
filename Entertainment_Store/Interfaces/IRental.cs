using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public interface IRental
    {
        public void addDay();
        public int amount();

        public double getPrice(Dictionary<Genre, double> prices);
    }
}
