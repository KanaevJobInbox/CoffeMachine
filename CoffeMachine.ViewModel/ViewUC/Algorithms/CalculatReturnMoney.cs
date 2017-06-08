using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using CoffeMachine.ViewModel.ViewUC.Wallet;
using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC.Algorithms
{
    class CalculatReturnMoney
    {
        public IEnumerable<IBanknote> GetReturnMoney(ViewWallet Wallet, UInt32 retCount)
        {


            var SortBanknotes = Wallet.Banknotes.OrderByDescending(o => o.Nominal).ToArray();


            // Список необходимых банкнот
            List<IBanknote> requiredBanknotes = new List<IBanknote>();


            int IndexCounter = 0;
            while (retCount >= 1)
            {
                if (IndexCounter >= SortBanknotes.Length)
                {
                    MessageBox.Show(String.Format("В Актомате недостаточно денег. \nОбратитесь к администратору за получением {0} руб.", retCount));
                    break;
                }

                if (SortBanknotes[IndexCounter].Count == 0)
                {
                    IndexCounter++;
                    continue;
                }

                UInt32 currNominal = SortBanknotes[IndexCounter].Nominal;
                if (currNominal <= retCount)
                {
                    var currrequiredBanknote = requiredBanknotes.FirstOrDefault(o => o.Nominal == currNominal);
                    if (currrequiredBanknote != null)
                    {
                        currrequiredBanknote.Count++;
                    }
                    else
                    { requiredBanknotes.Add(new BanknoteModel(SortBanknotes[IndexCounter].Nominal, 1)); }

                    retCount -= currNominal;
                    SortBanknotes[IndexCounter].Count--;
                }
                else
                {
                    IndexCounter++;
                }

            }

            string myMessage = "";

            foreach (var item in requiredBanknotes)
            {
                myMessage += "\nNom " + item.Nominal + " Count " + item.Count; 
            }


            Wallet.UpdeteTotalAmount();
            MessageBox.Show("Возврат монетами: " + myMessage);

            return requiredBanknotes;
        }
             

    }
}
