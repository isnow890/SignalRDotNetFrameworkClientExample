using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRDotNetFrameworkClientExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectUrl = "http://localhost:58608/signalr";
            var hspTpCd = args.Any() ? args[0] : "01";
            var stfNo = args.Length>0 ? args[1] : "30430";

            NotificationHubHelper.Connect(connectUrl: connectUrl, hspTpCd: hspTpCd,
                stfNo: stfNo);


            Console.WriteLine($"hspTpCd :{hspTpCd}");
            Console.WriteLine($"stfNo :{stfNo}");

            while (true)
            {
            }
        }
    }
}
