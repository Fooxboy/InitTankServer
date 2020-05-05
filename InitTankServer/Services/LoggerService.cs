using System;
using System.Collections.Generic;
using System.Text;

namespace InitTankServer.Services
{
    public class LoggerService
    {
        public void Trace(object msg)
        {
            Console.WriteLine(msg.ToString());
        }

        public void Error(object msg)
        {
            Console.WriteLine(msg.ToString());

        }

        public void Info(object msg)
        {
            Console.WriteLine(msg.ToString());

        }
    }
}
