using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    abstract class InventoryGenerator
    {
        public static IInventory create()
        {
            IInventory inv = new Inventory();

            return inv;
        }
    }
}
