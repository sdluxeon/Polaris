using System;
using System.Collections.Concurrent;

namespace Polaris.WebForms.Models
{
    public class Observable<TState>
    {
        public TState State { get; private set; }

        private ConcurrentBag<Action<TState>> subscribers;

        public Observable(TState state)
        {
            this.State = state;
            this.subscribers = new ConcurrentBag<Action<TState>>();
        }

        private Observable(TState state, ConcurrentBag<Action<TState>> subscribers)
        {
            this.State = state;
            this.subscribers = subscribers;
            foreach (var item in subscribers)
            {
                item(state);
            }
        }

        public void OnChange(Action<TState> onChange)
        {
            subscribers.Add(onChange);
            onChange(State);
        }

        public Observable<TState> Change(TState newState)
        {
            return new Observable<TState>(newState, this.subscribers);
        }
    }
}
