using System;
using System.Xml.Serialization;

namespace CoffeMachine.Model.Setting
{
     [XmlRoot(ElementName = "Setting")]
    class xmlSettingsModel : ISettingsModel
    {
         private BanknoteModel[] banknotesClient = new BanknoteModel[0];
        [XmlArray(ElementName = "BanknotesClient")]
        [XmlArrayItem(ElementName = "BanknotesClient")]
        public BanknoteModel[] BanknotesClient
         {
             get { return banknotesClient; }
             set { banknotesClient = value; }
         }


        private BanknoteModel[] banknotesCF = new BanknoteModel[0];
        [XmlArray(ElementName = "BanknotesCF")]
        [XmlArrayItem(ElementName = "BanknotesCF")]
        public BanknoteModel[] BanknotesCF
        {
            get { return banknotesCF; }
            set { banknotesCF = value; }
        }


        private ProductModel[] products = new ProductModel[0];
        [XmlArray(ElementName = "Products")]
        [XmlArrayItem(ElementName = "Product")]
        public ProductModel[] Products
        {
            get { return products; }
            set { products = value; }
        }



    }
}
