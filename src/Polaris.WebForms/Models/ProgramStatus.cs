using System;
using System.Collections.Concurrent;

namespace Polaris.WebForms.Models
{
    public class ProgramStatus
    {
        public ConcurrentBag<Action<string>> observers = new ConcurrentBag<Action<string>>();

        public void AddObserver(Action<string> observer)
        {
            observers.Add(observer);
        }

        public void Change(string text)
        {
            foreach (var observer in observers)
            {
                observer(text);
            }
        }

        public static ProgramStatus Global = new ProgramStatus();
    }
}
