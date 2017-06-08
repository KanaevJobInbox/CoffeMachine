using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

using CoffeMachine.ViewModel.BaseMediator;
using CoffeMachine.ViewModel.ViewUC.Algorithms;
using CoffeMachine.ViewModel.ViewUC.Wallet;
using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC
{
    public class ViewCoffeMachine : BaseViewModel, IMediator<enumTypeNotify>
    {
        private CalculatReturnMoney calculatReturnMoney = new CalculatReturnMoney();


        public ViewCoffeMachine()
        {
            Products = new ReadOnlyCollection<ViewProductCanBuy>(new ViewProductCanBuy[0]);
            WalletCF = new ViewWallet();
        }


        public void ReInitialize(IList<ProductModel> products, IList<BanknoteModel> banknotes )
        {

            List<ViewProductCanBuy> viewProducts = new List<ViewProductCanBuy>();

            foreach (var item in products)
            {
                viewProducts.Add(new ViewProductCanBuy(item, BuyProduct, GetCreditCount));
            }

            Products = new ReadOnlyCollection<ViewProductCanBuy>(viewProducts);
            WalletCF.ReInitializeBanknotes(banknotes);

        }









        #region Notify


        private UInt32 creditCount = 0;
        public UInt32 CreditCount 
        {
            get { return creditCount; }
            set { creditCount = value; OnPropertyChanged("CreditCount"); }
        }

        private UInt32 GetCreditCount()
        { return CreditCount; }



        private ReadOnlyCollection<ViewProductCanBuy> products;
        public ReadOnlyCollection<ViewProductCanBuy> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged("Products"); }
        }



        public ViewWallet WalletCF
        { get; private set; }

        #endregion


        #region Methods

        public void AddBanknoteToCredit(UInt32 banknoteNominal)
        {
           
            var banknote = WalletCF.Banknotes.FirstOrDefault(o => o.Nominal == banknoteNominal);

            if (banknote != null)
            {

                var Index = WalletCF.Banknotes.IndexOf(banknote);

                WalletCF.Banknotes[Index].Count++;
                WalletCF.UpdeteTotalAmount();
                CreditCount += banknoteNominal;
            }

        }

        public void GiveOutMoney()
        {
            if (CreditCount > 0)
            {
                var returnMoney = calculatReturnMoney.GetReturnMoney(WalletCF, CreditCount);


                CreditCount = 0;

                mediator.Send(enumTypeNotify.ReturnMoneyClient, returnMoney);

                MessageBox.Show("Сдача перенесена Вам в кошелек.");
            }
        }

        private void BuyProduct(ViewProductCanBuy product)
        {
            if (CreditCount >= product.Cost)
            {
                CreditCount = CreditCount - product.Cost;

                MessageBox.Show("Товар в лотке для выдачи. \tЗаберите товар.");

                //Выдать сдачу
                GiveOutMoney();
            }
        }

        #endregion


        #region Mediator

        private Mediator<enumTypeNotify> mediator;
        public Mediator<enumTypeNotify> Mediator
        {
            get
            {
               if(mediator == null)
               { throw new ArgumentNullException("Mediator"); }
   
                return mediator;
            }
            set
            {
                mediator = value;
            }
        }

        public void Send<TParameter>(enumTypeNotify message, TParameter parameter)
        {
            Mediator.Send(message, parameter);
        }


        public void Send(enumTypeNotify message)
        {
            Mediator.Send(message);
        }


        #endregion
    }
}
