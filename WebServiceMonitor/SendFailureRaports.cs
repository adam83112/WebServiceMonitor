using System;
using System.Linq;
using System.Collections.Generic;

namespace WebServiceMonitor
{
    class SendFailureRaports : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public List<WebService> Services { get; private set; }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers(List<WebService> webServices)
        {
            Services = webServices.Where(service => !service.IsOk).ToList();
            if (Services.Any())
            {
                foreach(var item in observers)
                {
                    item.Notify();
                }
            }
                
        }
    }
}

