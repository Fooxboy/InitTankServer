using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DryIoc;
using InitTankServer.Models;
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

            _logger.Info($"Установка параметров сервера по ip: {ip}, порт: {port}...");

            _conectionListener = new SocketConnectListener(ip, port, _logger);
        }

        private IContainer _container;
        public void Run()
        {
            _logger.Info("Запуск сервера...");
            _logger.Trace("Подписка на события подключений...");
            _conectionListener.NewConnection += ConectionListener_NewConnection;
            _conectionListener.Start();
        }

        private void ConectionListener_NewConnection(string message, Socket socket)
        {
            Task.Run(() =>
            {
                var userIp = ((IPEndPoint)socket.RemoteEndPoint).Address;
                _logger.Info($"Новое подключение с ip: {userIp}");
                var requestArray = message.Split(";");
                if (requestArray[0] == "auth")
                {
                    if (requestArray.Length == 2)
                    {
                        
                    }else if (requestArray.Length == 3)
                    {
                        var nickname = requestArray[1];
                        var password = requestArray[2];

                        using (var db = new Database())
                        {
                            var user = db.Users.SingleOrDefault(u => u.Nickname == nickname);
                            if (user is null)
                            {
                                
                            }
                        }
                    }
                    //todo: auth.
                }else if (requestArray[0] == "reg")
                {
                    //todo: registration.
                }
            });

            
        }
    }
}
