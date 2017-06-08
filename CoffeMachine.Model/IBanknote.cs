using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model
{
    public interface IBanknote
    {

        UInt32 Nominal
        {get;}

        UInt32 Count
        {
            get;
            set;
        }
    }
}
