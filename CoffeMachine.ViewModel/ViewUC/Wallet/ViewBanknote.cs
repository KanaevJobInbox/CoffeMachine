using System;

using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC.Wallet
{
   public class ViewBanknote : BaseViewModel, IBanknote
    {

        private BanknoteModel banknote;

        public ViewBanknote(BanknoteModel Banknote)
        {
            banknote = Banknote;
        }




        public UInt32 Nominal
        {
            get { return banknote.Nominal; }
        }

        public UInt32 Count
        {
            get { return banknote.Count; }
            set { banknote.Count = value; OnPropertyChanged("Count"); }
        }

    }
}
