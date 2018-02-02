using ConsoleApplication3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication3.Classes
{
    abstract class Beverage : ICost
    {
        public string Description { get; set; }

        Dictionary< Type ,CondimentListType> condimentList;

        public Beverage()
        {
            Description = "Beverage";
            condimentList = new Dictionary<Type, CondimentListType>();
        }
        private class CondimentListType
        {
            public int Count = 1;
            public CondimentDecorator Decorator;
            public CondimentListType(CondimentDecorator decorator)
            {
                this.Decorator = decorator;
            }
        }
       
        public void AddCondiment<T>() where T : CondimentDecorator, new()
        {
            if (condimentList.ContainsKey(typeof(T)))
            {
                condimentList[typeof(T)].Count++;
            }
            else
            {
                condimentList.Add(typeof(T), new CondimentListType(new T()));
            }
             
        }

        public void RemoveCondiment<T>() where T : CondimentDecorator, new()
        {
            if (condimentList.ContainsKey(typeof(T)))
            {
                if(condimentList[typeof(T)].Count == 1)
                {
                    condimentList.Remove(typeof(T));
                }
                else
                {
                    condimentList[typeof(T)].Count--;
                }
                
            }

        }

        public virtual double GetCost()
        {
            double result = 0;

            foreach(var item in condimentList)
            {
                result += item.Value.Count * item.Value.Decorator.GetCost();
            }

            return result;
        }
    }
}
