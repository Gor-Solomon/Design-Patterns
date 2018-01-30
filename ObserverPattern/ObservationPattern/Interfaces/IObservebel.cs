using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Classes;

namespace ObserverPattern.Interfaces
{
  public  interface IObservebel : IDisposable
    {
        void NotifyUpdate();
        void Subscribe(IObserver observer);
        void UnSubscribe(IObserver observer);

        void GetData(out WhetherData whetherData);
    }
}
