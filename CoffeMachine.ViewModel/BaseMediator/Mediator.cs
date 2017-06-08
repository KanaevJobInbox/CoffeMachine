using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoffeMachine.ViewModel.BaseMediator
{
    public class Mediator<TMessage>
    {
        private Dictionary<TMessage, List<WeakReferenceWrapper>> actions =
             new Dictionary<TMessage, List<WeakReferenceWrapper>>();

        public Mediator()
        {
        }

        public void Register<TParameter>(TMessage message, IMediator<TMessage> receiver, Action<TParameter> action)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            lock (this.actions)
            {
                if (!this.actions.ContainsKey(message))
                {
                    this.actions[message] = new List<WeakReferenceWrapper>();
                }

                this.actions[message].Add(new WeakReferenceWrapper(receiver, action));
            }
        }



        public void Register(TMessage message, IMediator<TMessage> receiver, Action action)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            lock (this.actions)
            {
                if (!this.actions.ContainsKey(message))
                {
                    this.actions[message] = new List<WeakReferenceWrapper>();
                }

                this.actions[message].Add(new WeakReferenceWrapper(receiver, action));
            }
        }


        public void Unregister<TParameter>(TMessage message, IMediator<TMessage> receiver, Action<TParameter> action)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            lock (this.actions)
            {
                if (this.actions.ContainsKey(message))
                {
                    List<WeakReferenceWrapper> actionlist = this.actions[message];

                    actionlist.Remove(new WeakReferenceWrapper(receiver, action));

                    if (actionlist.Count == 0)
                    {
                        this.actions.Remove(message);
                    }
                }
            }
        }

        public void Send<TParameter>(TMessage message, TParameter parameter)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            lock (this.actions)
            {
                if (this.actions.ContainsKey(message))
                {
                    List<WeakReferenceWrapper> actionslist = this.actions[message];

                    foreach (var action in actionslist)
                    {
                        action.Action.DynamicInvoke(parameter);
                    }
                }
            }
        }


        public void Send(TMessage message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            lock (this.actions)
            {
                if (this.actions.ContainsKey(message))
                {
                    List<WeakReferenceWrapper> actionslist = this.actions[message];

                    foreach (var action in actionslist)
                    {
                        action.Action.DynamicInvoke(new object[0]);
                    }
                }
            }
        }






    }
}
