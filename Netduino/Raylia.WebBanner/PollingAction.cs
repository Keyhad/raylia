using System;
using Microsoft.SPOT;
using System.Threading;
using Toolbox.NETMF.NET;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware.NetduinoPlus;

namespace Raylia.WebBanner
{
    public class PollingAction
    {
        public delegate void DataUpdatedDelegate(object sender, EventArgs e);
        public event DataUpdatedDelegate DataUpdated;

        public PollingAction()
        {
            //ThreadStart threadStart = new ThreadStart(ThreadAction);
            //Thread pollingThread = new Thread(threadStart);

           // pollingThread.Start();
        }

        public string DateString { get; private set; }
        public bool IsConnecting { get; private set; }

        public void CheckTheMessage()
        {
            try
            {
                // Creates a new web session
                HTTP_Client WebSession = new HTTP_Client(new IntegratedSocket("www.netmftoolbox.com", 80));

                // Requests the latest source
                HTTP_Client.HTTP_Response Response = WebSession.Get("/helloworld/");
                Thread.Sleep(1000);

                // Did we get the expected response? (a "200 OK")
                if (Response.ResponseCode == 200)
                {
                    DateString = Response.ResponseHeader("date").Substring(16, 6);

                    if (DataUpdated != null)
                    {
                        //EthernetPower.Write(false);
                        DataUpdated.Invoke(null, EventArgs.Empty);
                    }
                }
                else
                {
                    //throw new ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString());
                }
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message + " " + ex.InnerException);
            }
        }

        private void ThreadAction()
        {

            while (true)
            {
                Thread.Sleep(1000);
                try
                {
                    //EthernetPower.Write(true);


                    Thread.Sleep(5000);
                    // Creates a new web session
                    HTTP_Client WebSession = new HTTP_Client(new IntegratedSocket("www.netmftoolbox.com", 80));

                    // Requests the latest source
                    HTTP_Client.HTTP_Response Response = WebSession.Get("/helloworld/");
                    Thread.Sleep(1000);

                    // Did we get the expected response? (a "200 OK")
                    if (Response.ResponseCode == 200)
                    {
                        DateString = Response.ResponseHeader("date").Substring(16, 6);

                        if (DataUpdated != null)
                        {
                            //EthernetPower.Write(false);
                            DataUpdated.Invoke(null, EventArgs.Empty);
                            Thread.Sleep(30000);
                        }
                    }
                    else
                    {
                        //throw new ApplicationException("Unexpected HTTP response code: " + Response.ResponseCode.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Debug.Print(ex.Message + " " + ex.InnerException);
                }
            }
        }

        private void NetworkConnected(object sender, EventArgs e)
        {
            IsConnecting = false;
        }
    }
}
