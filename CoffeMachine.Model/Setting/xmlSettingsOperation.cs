using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.Model.Setting
{
   public class xmlSettingsOperation : ISettingsOperation
    {
        public ISettingsModel Load()
        {
            xmlSettingsModel settings = new xmlSettingsModel();


            BanknoteModel[] banknotesClient = new BanknoteModel[4];
            banknotesClient[0] = new BanknoteModel(1, 10);
            banknotesClient[1] = new BanknoteModel(2, 23);
            banknotesClient[2] = new BanknoteModel(5, 16);
            banknotesClient[3] = new BanknoteModel(10, 15);



            BanknoteModel[] banknotesCF = new BanknoteModel[4];
            banknotesCF[0] = new BanknoteModel(1, 99);
            banknotesCF[1] = new BanknoteModel(2, 107);
            banknotesCF[2] = new BanknoteModel(5, 103);
            banknotesCF[3] = new BanknoteModel(10, 99);

            ProductModel[] products = new ProductModel[4];
            products[0] = new ProductModel("Чай", 13, 10 );
            products[1] = new ProductModel("Кофе", 18, 19);
            products[2] = new ProductModel("Кофе с молоком", 21, 20);
            products[3] = new ProductModel("Сок", 35, 15);

            settings.BanknotesClient = banknotesClient;
            settings.BanknotesCF = banknotesCF;

            settings.Products = products;

            return settings;

        }

        public void Save(ISettingsModel settings)
        {
            throw new NotImplementedException();
        }
    }
}
