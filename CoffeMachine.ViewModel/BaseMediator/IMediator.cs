

namespace CoffeMachine.ViewModel.BaseMediator
{
    public interface IMediator<TMessage>
    {
        Mediator<TMessage> Mediator
        {
            get;
            set;
        }
        void Send<TParameter>(TMessage message, TParameter parameter);

        void Send(TMessage message);

       // void Notify<TParameter>(TParameter parameter);
    }
}

