using System;
using System.Net;
using System.Collections.Generic;
using System.Threading;


namespace WebServiceMonitor
{
    public static class Checker
    {
        private static readonly object locker = new object();

        private static List<WebService> webServiceList;

        public static List<WebService> WebServiceList
        {
            get
            {
                lock (locker)
                {
                    return webServiceList;
                }
            }
            set
            {
                lock (locker)
                {
                    webServiceList = value;
                }
            }
        }

        private static void CheckAll()
        {
            foreach (var webService in WebServiceList)
            {
                webService.Status = CheckStatus(webService.Url);
            }
        }

        private static void SendRaport()
        {
            var sendRaports = new SendFailureRaports();
            var sendRaportByEmail = new SendRaportByEmail(sendRaports);
            sendRaports.AddObserver(sendRaportByEmail);
            sendRaports.NotifyObservers(Checker.WebServiceList);
        }

        public static void Start()
        {
            var webServicesConfig = new WebServicesConfig("listofservices.xml");
            WebServiceList = webServicesConfig.GetWebServices();

            var thread = new Thread(() =>
                {
                    while (true)
                    {
                        lock(locker)
                        {
                            CheckAll();
                        }
                        SendRaport();
                        Thread.Sleep(60 * 1000);//One minute.
                    }
                });
            thread.Start();
        }

        private static HttpStatusCode CheckStatus(string url)
        {
            try
            {
                var myRequest = (HttpWebRequest)WebRequest.Create(url);
                var response = (HttpWebResponse)myRequest.GetResponse();
                return response.StatusCode;
            }
            catch (Exception)
            {
                return HttpStatusCode.NotFound;
            }
        }
    }
}

