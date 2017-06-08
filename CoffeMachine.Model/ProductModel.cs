using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model
{
    public class ProductModel
    {
        public ProductModel(string name, UInt32 cost, UInt32 count = 0)
        {
            Name = name;
            Cost = cost;
            Count = count;
        }

        public  string Name
        { get; private set; }

        public UInt32 Cost
        { get; private set; }

        public UInt32 Count { get; set; }

    }
}
