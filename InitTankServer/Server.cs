using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using InitTankServer.Services;

namespace InitTankServer
{
    public class Server
    {

        private readonly SocketConnectListener _conectionListener;
        private readonly LoggerService _logger;
        public Server(string ip, int port)
        {
            //
            _container = new Container();
            _container.Register<LoggerService>(Reuse.Singleton);
            _logger = _container.Resolve<LoggerService>();


            _conectionListener = new SocketConnectListener(ip, port, _logger);
        }

        private IContainer _container;
        public void Run()
        {
            _conectionListener.NewConnection += ConectionListener_NewConnection;
            _conectionListener.Start();
        }

        private void ConectionListener_NewConnection(string message, Socket socket)
        {
            Task.Run(() =>
            {
                var userIp = ((IPEndPoint)socket.RemoteEndPoint).Address;
                var requestArray = message.Split(";");

                if (requestArray[0] == "auth")
                {
                    //todo: auth.
                }else if (requestArray[0] == "reg")
                {
                    //todo: registration.
                }
            });

            
        }
    }
}
