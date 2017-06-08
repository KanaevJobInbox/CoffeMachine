using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC.Wallet
{
    public class ViewWallet : BaseViewModel
    {
        public ViewWallet()
        {
            ReInitializeBanknotes(new BanknoteModel[0]);
        }


        public ViewWallet(IList<BanknoteModel> banknotes)
        {
            ReInitializeBanknotes(banknotes);
        }


        public virtual void ReInitializeBanknotes(IList<BanknoteModel> banknotes)
        {
            List<IBanknote> viewBanknotes = new List<IBanknote>();

            foreach (var item in banknotes)
            {
                viewBanknotes.Add(new ViewBanknote(item));
            }

            Banknotes = new ReadOnlyCollection<IBanknote>(viewBanknotes);
        }



        private ReadOnlyCollection<IBanknote> banknotes;
        public ReadOnlyCollection<IBanknote> Banknotes
        {
            get {return banknotes;}
            protected set { banknotes = value; OnPropertyChanged("Banknotes"); }
        }


        public UInt32 TotalAmountMoney
        {
            get
            {      
                return (UInt32)Banknotes.Sum(x => x.Count * x.Nominal);
            }

        }

        public void UpdeteTotalAmount()
        {
            OnPropertyChanged("TotalAmountMoney");
        }




        public void AddMoney(IEnumerable<IBanknote> returnMoney)
        {
            foreach (var addedBanknote in returnMoney)
            {
                var foundBanknote = Banknotes.FirstOrDefault(o => o.Nominal == addedBanknote.Nominal);

                if (foundBanknote != null)
                {
                    foundBanknote.Count += addedBanknote.Count; 
                }
            }

            UpdeteTotalAmount();
        }

        

    }
}


