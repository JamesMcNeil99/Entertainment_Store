﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entertainment_Store
{
    public interface IRentBehavior
    {
        public IRental rent(IInventory games);
        
    }
}
