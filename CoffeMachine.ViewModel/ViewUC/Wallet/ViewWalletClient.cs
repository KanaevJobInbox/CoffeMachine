using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC.Wallet
{
    public class ViewWalletClient : ViewWallet
    {
        public ViewWalletClient(Action<UInt32> PayOff)
        {
            payOff = PayOff;
            ReInitializeBanknotes(new BanknoteModel[0]);
        }


        public ViewWalletClient(IList<BanknoteModel> banknotes, Action<UInt32> PayOff)
        {
            payOff = PayOff;
            ReInitializeBanknotes(banknotes);
        }

        private Action<UInt32> payOff;

        public override void ReInitializeBanknotes(IList<BanknoteModel> banknotes)
        {
            List<IBanknote> viewBanknotes = new List<IBanknote>();

            foreach (var item in banknotes)
            {
                viewBanknotes.Add(new ViewBanknoteCanBuy(item, payOff));
            }

            Banknotes = new ReadOnlyCollection<IBanknote>(viewBanknotes);
        }


    }
}
