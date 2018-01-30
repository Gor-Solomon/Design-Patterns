using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Interfaces
{
    public delegate void showMethod();

    public interface IObserver : IDisposable
    {
        void Update();
        void Show();
        event showMethod ShowEvent;
    }
}
