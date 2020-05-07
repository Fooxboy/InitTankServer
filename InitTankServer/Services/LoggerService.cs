using System;
using System.Collections.Generic;
using System.Text;

namespace InitTankServer.Services
{
    public class LoggerService
    {
        public void Trace(object msg)
        {
            this.Log(msg, 1);
        }

        public void Error(object msg)
        {
            this.Log(msg, 2);
        }

        public void Info(object msg)
        {
            this.Log(msg, 3);
        }

        private void Log(object msg, int type)
        {
            if (type == 1)
            {
                Console.WriteLine($"({DateTime.Now})=> [TRACE]: {msg}");
            }else if (type == 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"({DateTime.Now})=> [ERROR]: {msg}");
                Console.ResetColor();
            }else if (type == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"({DateTime.Now})=> [INFO]: {msg}");
                Console.ResetColor();
            }
        }
    }
}
