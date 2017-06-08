using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model
{
    public class BanknoteModel : IBanknote
    {
       public BanknoteModel(UInt32 nominal, UInt32 count)
       {
           Nominal = nominal;
           Count = count;
       }

        public UInt32 Nominal
        { get; private set; }

        public  UInt32 Count
        { get; set; }
    }
}
