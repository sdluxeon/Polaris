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

        public NamedStatus CreateNamedStatus(string name)
        {
            return new NamedStatus(name, this);
        }

        public static ProgramStatus Global = new ProgramStatus();

        public class NamedStatus
        {
            private string name;
            private ProgramStatus status;
            public NamedStatus(string name, ProgramStatus status)
            {
                this.status = status;
                this.name = name;
            }
            public void Change(string status)
            {
                this.status.Change($"{this.name} ({status})");
            }
        }
    }
}
