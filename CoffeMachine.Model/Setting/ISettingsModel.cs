using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model.Setting
{
   public interface ISettingsModel
    {
        BanknoteModel[] BanknotesClient
        { get; }

        BanknoteModel[] BanknotesCF
        { get; }

         ProductModel[] Products
        { get; }
    }
}
