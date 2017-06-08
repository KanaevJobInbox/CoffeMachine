using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;


using CoffeMachine.ViewModel.BaseMediator;
using CoffeMachine.ViewModel.BaseCommands;
using CoffeMachine.ViewModel.ViewUC.Wallet;
using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC
{
    public class ViewClient : IMediator<enumTypeNotify>
    {

        public ViewClient()
        {
            WalletClient = new ViewWalletClient(AddBanknoteToCredit);
        }

        public void ReInitialize(IList<BanknoteModel> banknotes)
        {
            WalletClient = new ViewWalletClient(banknotes, AddBanknoteToCredit);
        }



        public ViewWalletClient WalletClient
        { get; private set; }


        public void ReturnMoneyClient(IEnumerable<IBanknote> returnMoney)
        {
            WalletClient.AddMoney(returnMoney);

            MessageBox.Show("Кошелек пополнился.");
        }

        private void AddBanknoteToCredit(UInt32 banknoteNominal)
        {
            Send<UInt32>(enumTypeNotify.AddBanknoteToCredit, banknoteNominal);
            WalletClient.UpdeteTotalAmount();
        }

        #region Mediator

        private Mediator<enumTypeNotify> mediator;
        public Mediator<enumTypeNotify> Mediator
        {
            get
            {
                if (mediator == null)
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


        #region Commands

        #region Command ReturnMoneyCommand




        private DelegateCommand _returnMoneyCommand;
        public ICommand ReturnMoneyCommand
        {
            get
            {
                if (_returnMoneyCommand == null)
                { _returnMoneyCommand = new DelegateCommand(this.ReturnMoneyCommand_Execute); }
                return _returnMoneyCommand;
            }
        }

        private void ReturnMoneyCommand_Execute()
        {
            Send(enumTypeNotify.GiveOutMoney);
        }



        #endregion


        #endregion


    }
}
