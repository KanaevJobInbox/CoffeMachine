using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;


using CoffeMachine.ViewModel.ViewUC;
using CoffeMachine.ViewModel.ViewUC.ViewSetting;
using CoffeMachine.ViewModel.ViewUC.Wallet;
using CoffeMachine.ViewModel.BaseMediator;
using CoffeMachine.Model;
 

namespace CoffeMachine.ViewModel
{
   public class ViewMainWindow : BaseViewModel
    {

       public ViewMainWindow()
       {
           try
           {
               viewClient = new ViewClient();
               viewCoffeMachine = new ViewCoffeMachine();

               mediator = new Mediator<enumTypeNotify>();

               mediator.Register<UInt32>(enumTypeNotify.AddBanknoteToCredit, viewCoffeMachine, viewCoffeMachine.AddBanknoteToCredit);
               mediator.Register(enumTypeNotify.GiveOutMoney, viewCoffeMachine, viewCoffeMachine.GiveOutMoney);
               mediator.Register<IEnumerable<IBanknote>>(enumTypeNotify.ReturnMoneyClient, viewCoffeMachine, viewClient.ReturnMoneyClient);


               viewClient.Mediator = mediator;
               viewCoffeMachine.Mediator = mediator;

               MainsSetting = new ViewMainsSetting(viewClient, viewCoffeMachine);
               MainsSetting.Load();

           }
           catch (Exception e)
           {
               MessageBox.Show(e.Message);
           }
       }






       private Mediator<enumTypeNotify> mediator
       { get; set; }



       public ViewClient viewClient
       { get; private set; }


       public ViewCoffeMachine viewCoffeMachine
       { get; private set; }

       public ViewMainsSetting MainsSetting
       { get; private set; }


    }
}
