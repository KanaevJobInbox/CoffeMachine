using System;

using CoffeMachine.Model;
using CoffeMachine.Model.Setting;

namespace CoffeMachine.ViewModel.ViewUC.ViewSetting
{
   public class ViewMainsSetting
    {


        private ViewClient viewClient;
        private ViewCoffeMachine viewCoffeMachine;

        private MainSettingsModel setting = new MainSettingsModel();




        public ViewMainsSetting(ViewClient viewClient, ViewCoffeMachine viewCoffeMachine)
        {
            this.viewClient = viewClient;
            this.viewCoffeMachine = viewCoffeMachine;
        }
        


        public void Load()
        {

            setting.Load();

            viewClient.ReInitialize(setting.BanknotesClient);
            viewCoffeMachine.ReInitialize(setting.Products, setting.BanknotesCF);

            
        }

        public void Save()
        {
           // setting.Save();
            throw new NotImplementedException();
        }

    }
}
