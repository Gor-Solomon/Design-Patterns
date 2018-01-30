using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Interfaces;
using System.Threading;

namespace ObserverPattern.Classes
{
    public class WhetherControler : IObservebel 
    {
        HashSet<IObserver> ObserversList;
        Random tempRand;
        Random humidityRand;
        Random pressurRand;
        WhetherData whetherData;
        Thread changeMesurmentsTread;
        object safeGard = new object();
        
        public WhetherControler()
        {
            ObserversList = new HashSet<IObserver>();
            tempRand = new Random();
            humidityRand = new Random(DateTime.Now.Millisecond - 1000);
            pressurRand = new Random(DateTime.Now.Millisecond + 1000);
            changeMesurmentsTread = new Thread(new ThreadStart(mesaurmentsChanged));
            changeMesurmentsTread.Start();
        }

        public void NotifyUpdate()
        {
            foreach (var observer in ObserversList)
            {
                observer.Update();
            }
        }

        public void Subscribe(IObserver observer)
        {
            lock (safeGard)
            {
                ObserversList.Add(observer);
            }
            
        }

        public void UnSubscribe(IObserver observer)
        {
            lock (safeGard)
            {
                if (ObserversList.Contains(observer))
                {
                    ObserversList.Remove(observer);
                }
            }
        }

        void mesaurmentsChanged()
        {
            while (true)
            {
                Thread.Sleep(1000);
                this.whetherData.temp = tempRand.NextDouble() * 10000;
                this.whetherData.humidety = humidityRand.NextDouble() * 10000;
                this.whetherData.presur = pressurRand.NextDouble() * 10000;
                lock (safeGard)
                {
                    NotifyUpdate();
                }
            }
        }

      

        public void Dispose()
        {
            changeMesurmentsTread.Abort();
        }

        public void GetData( out WhetherData whetherData)
        {
           whetherData.temp = this.whetherData.temp;
           whetherData.humidety = this.whetherData.humidety;
           whetherData.presur = this.whetherData.presur;
        }
    }
}
