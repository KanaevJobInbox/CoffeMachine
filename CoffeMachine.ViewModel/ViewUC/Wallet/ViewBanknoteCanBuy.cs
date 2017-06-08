using System;
using System.Windows.Input;

using CoffeMachine.ViewModel.BaseCommands;
using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC.Wallet
{
    public class ViewBanknoteCanBuy : ViewBanknote, IBanknote
    {


        public ViewBanknoteCanBuy(BanknoteModel Banknote, Action<UInt32> PayOff)
           :base(Banknote)
        {
           payOff = PayOff;
        }


        private Action<UInt32> payOff; 


        #region Commands

        #region Command PayOffCommand


       private DelegateCommand _payOffCommandCommand;
       public ICommand PayOffCommand
        {
            get
            {
                if (_payOffCommandCommand == null)
                { _payOffCommandCommand = new DelegateCommand(this.PayOffCommand_Execute, this.PayOffCommand_CanExecute); }
                return _payOffCommandCommand;
            }
        }

       private void PayOffCommand_Execute()
        {
            Count--;
            payOff(this.Nominal);
        }

       private bool PayOffCommand_CanExecute()
       {
          return Count > 0;
       }

        #endregion


        #endregion

    }
}
