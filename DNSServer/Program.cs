using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DNSServer {
    class Program {
        static void Main(string[] args)
        {
            var k = new DNSServer();
            k.foo();
        }
    }
}
