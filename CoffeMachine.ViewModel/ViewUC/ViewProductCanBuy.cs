using System;
using System.Windows.Input;

using CoffeMachine.ViewModel.BaseCommands;
using CoffeMachine.Model;

namespace CoffeMachine.ViewModel.ViewUC
{
   public class ViewProductCanBuy : BaseViewModel
    {
       public ViewProductCanBuy(ProductModel product, Action<ViewProductCanBuy> BuyProduct,  Func<UInt32> GetCreditCount)
       {

           this.product = product;
           this.buyProduct = BuyProduct;
           this.getCreditCount = GetCreditCount;

       }

       private ProductModel product;
       private Action<ViewProductCanBuy> buyProduct;
       private Func<UInt32> getCreditCount;

        public string Name
        {
            get {return product.Name;}
        }

        public UInt32 Cost
        {
           get {return product.Cost;}
        }

        public UInt32 Count
        {
            get { return product.Count; }
            set { product.Count = value; OnPropertyChanged("Count"); }
        }

        #region Commands

        #region Command BuyProductCommand


        private DelegateCommand _buyProductCommand;
        public ICommand BuyProductCommand
        {
            get
            {
                if (_buyProductCommand == null)
                { _buyProductCommand = new DelegateCommand(this.BuyProductCommand_Execute, this.BuyProductCommand_CanExecute); }
                return _buyProductCommand;
            }
        }

        private void BuyProductCommand_Execute()
        {
            Count--;
            buyProduct(this);
        }

        private bool BuyProductCommand_CanExecute()
        {
            return Cost <= getCreditCount() && Count > 0;
        }

        #endregion


        #endregion


        
    }
}
