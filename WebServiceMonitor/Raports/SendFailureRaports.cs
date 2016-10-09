using System;
using System.Linq;
using System.Collections.Generic;

namespace WebServiceMonitor
{
    class SendFailureRaports : ISubject
    {
        private List<IObserver> observers = new List<IObserver>();

        public List<WebService> Services { get; private set; }

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObservers(IEnumerable<WebService> webServices)
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

