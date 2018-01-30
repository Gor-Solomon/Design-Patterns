using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverPattern.Classes;
using ObserverPattern.Interfaces;
using System.Threading;

namespace ObserverPattern.Classes
{
    class StatisticsDisplay : IObserver
    {
        public IObservebel observebel;
        public event showMethod ShowEvent;
        public WhetherData AvarageData;
        WhetherData whetherData;
        Dictionary<DateTime, WhetherData> history;
        object safeGard = new object();
        public int recordCount;
        public StatisticsDisplay(IObservebel observebel)
        {
            this.observebel = observebel;
            whetherData = new WhetherData();
            history = new Dictionary<DateTime, WhetherData>();
        }

        public void Show()
        {
            lock (safeGard)
            {
                recordCount = history.Count;

                if (recordCount > 1000)
                {
                    history.Clear();
                }

                AvarageData.humidety = history.Average(x => x.Value.humidety);
                AvarageData.presur = history.Average(x => x.Value.presur);
                AvarageData.temp = history.Average(x => x.Value.temp);
                ShowEvent.Invoke();
            }
        }

        public void Update()
        {
            observebel.GetData(out whetherData);
            history.Add(DateTime.Now, whetherData);
            Show();
        }

        public void Dispose()
        {
            observebel.UnSubscribe(this);
        }
    }
}
