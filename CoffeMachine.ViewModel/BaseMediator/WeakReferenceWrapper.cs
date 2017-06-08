using System;


namespace CoffeMachine.ViewModel.BaseMediator
{
    public class WeakReferenceWrapper
    {
        private WeakReference weakReference;

        public WeakReferenceWrapper(object receiever, Delegate action)
        {
            weakReference = new WeakReference(receiever);
            this.Action = action;
        }

        public Delegate Action
        { get; set; }
    }
}