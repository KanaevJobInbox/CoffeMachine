using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model.Setting
{
   public class MainSettingsModel 
    {

       public ISettingsOperation operation = new xmlSettingsOperation();
       public ISettingsOperation Operation
       {
           get { return operation; }
           set { operation = value; }
       }



        public void Load()
        {
          var settings =  operation.Load();

          BanknotesClient = settings.BanknotesClient;
          BanknotesCF = settings.BanknotesCF;
          Products = settings.Products;
        }

        public void Save(ISettingsModel setting)
        {
            operation.Save(setting);
        }



        private BanknoteModel[] banknotesClient = new BanknoteModel[0];
        public BanknoteModel[] BanknotesClient
        {
            get { return banknotesClient; }
            private set { banknotesClient = value; }
        }


        private BanknoteModel[] banknotesCF = new BanknoteModel[0];
        public BanknoteModel[] BanknotesCF
        {
            get { return banknotesCF; }
            private set { banknotesCF = value; }
        }

        private ProductModel[] products = new ProductModel[0];
        public ProductModel[] Products
        {
            get { return products; }
            private set { products = value; }
        }

    }
}
