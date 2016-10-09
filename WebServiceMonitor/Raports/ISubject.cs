using System;
using System.Collections.Generic;

namespace WebServiceMonitor
{
    public interface ISubject
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(IEnumerable<WebService> webServices);
    }
}

