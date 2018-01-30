using ObserverPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern.Classes
{
    class CuurentConditionsDisplay : IObserver
    {
        public IObservebel observebel;
        public WhetherData whetherData;
        
        public CuurentConditionsDisplay(IObservebel observebel)
        {
            this.observebel = observebel;
            whetherData = new WhetherData();
        }

        public event showMethod ShowEvent;

        public void Show()
        {
            ShowEvent.Invoke();
        }

        public void Update()
        {
            observebel.GetData( out whetherData);
            Show();
        }

        public void Dispose()
        {
            observebel.UnSubscribe(this);
        }
    }
}
