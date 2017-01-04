using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DNSServer {
    public class DNSServer
    {
        private UdpClient udpClient = new UdpClient();

        private long id = 0L;

        private string[] rootServers = new[]
        {
            "198.41.0.4",
            "192.228.79.201",
            "192.33.4.12",
            "199.7.91.13",
            "192.203.230.10",
            "192.5.5.241",
            "192.112.36.4",
            "198.97.190.53",
            "192.36.148.17",
            "192.58.128.30",
            "193.0.14.129",
            "199.7.83.42",
            "202.12.27.33"
        };

        public void foo()
        {
            Interlocked.Increment(ref id);
            var x = new DNSDatagram();
            foreach (var rootServer in rootServers) { 
                Console.WriteLine(rootServer);
                var ep = new IPEndPoint(IPAddress.Parse(rootServer), 53);
                Console.WriteLine(ep);
                udpClient.Connect(ep);
                udpClient.Send(x.asByteArray(), x.asByteArray().Length);
                var rc = udpClient.Receive(ref ep);
                Console.WriteLine(rc.Length);
                foreach (var b in rc) {
                    Console.WriteLine(b);
                }
                udpClient.Close();
                Thread.Sleep(20);
            }
           
            Console.ReadKey();
        }
}
}
