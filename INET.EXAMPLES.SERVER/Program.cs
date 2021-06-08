using System;

using INET.NetworkServer;
using INET.NetworkPacket;

namespace INET.EXAMPLES.SERVER
{
    class Program
    {
        static void Main(string[] args)
        {
            r_DemoServer _server = new r_DemoServer();
            r_NetworkServer.InitializeServer(5555);

            while (true) { }
        }
    }
}
