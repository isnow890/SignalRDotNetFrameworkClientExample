using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDotNetFrameworkClientExample
{
    public class NotificationHubHelper
    {
        private HubConnection connection;

        public static async void Connect(string connectUrl, string hspTpCd, string stfNo,string hubName= "NotificationHub", string methodName= "SendAsync")
        //public static async Task<HubConnection> Connect(string connectUrl, string hspTpCd, string stfNo)
        {
            try
            {
                var connection = new HubConnection(connectUrl);
                var notificationProxy = connection.CreateHubProxy(hubName);
                Console.WriteLine(DateTime.Now);
                Console.WriteLine("SignalR Started");

                //연결 끊겼을때 fire
                connection.Closed += async () =>
                {
                    try
                    {
                        Console.WriteLine("연결 끊김");
                        //5초있다가 다시 시도
                        await Task.Delay(5000);
                        await connection.Start();
                        Console.WriteLine("연결 다시 됨.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                };

                notificationProxy.On<string, string, string>(methodName,
                    (_hspTpCd, _stfNo, _message) =>
                    {
                        if (hspTpCd != _hspTpCd || stfNo != _stfNo) return;
                        Console.WriteLine(hspTpCd);
                        Console.WriteLine(stfNo);
                        Console.WriteLine(_message);
                    });
                await connection.Start();
                //return connection;
            }
            catch (Exception a)
            {
                Console.WriteLine(a);
                throw;
            }
        }
    }
}
