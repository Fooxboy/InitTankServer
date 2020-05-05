using System;

namespace InitTankServer.Shell
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var server = new Server("127.0.0.1", 2021);
                server.Run();
                Console.ReadLine();
            }
        }
    }
}
