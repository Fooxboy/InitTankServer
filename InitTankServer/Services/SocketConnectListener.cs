using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace InitTankServer.Services
{
    public class SocketConnectListener
    {
        private Socket _serverSocket;
        private IPEndPoint _ipPoint;
        private LoggerService _logger;
        public event NewConnection NewConnection;

        public SocketConnectListener(string ip, int port, LoggerService logger)
        {
            this._logger = logger;
            var address = ip == "localhost" ? Dns.GetHostEntry(ip).AddressList[0] : IPAddress.Parse(ip);
            _ipPoint = new IPEndPoint(address, port);
            _serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            _logger.Info("Запуск Socket Connect Listener...");
            try
            {
                _serverSocket.Bind(_ipPoint);
                _serverSocket.Listen(10);
                StartListenRequests();
            }
            catch (Exception e)
            {
                _logger.Error($"Произошла ошибка при получении запроса: {e.Message}");

            }
        }

        private void StartListenRequests()
        {
            _logger.Trace("Запуск прослушивания подключений...");

            while (true)
            {
                try
                {
                    var handler = _serverSocket.Accept();
                    var builder = new StringBuilder();
                    int bytes = 0;
                    byte[] data = new byte[256];

                    do
                    {
                        bytes = handler.Receive(data);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (handler.Available > 0);

                    _logger.Trace("Новое подключение...");

                    var message = builder.ToString();
                    NewConnection?.Invoke(message, handler);

                }
                catch (Exception e)
                {
                    _logger.Error($"Произошла ошибка при получении запроса: {e.Message}");
                }

            }
        }
    }

    public delegate void NewConnection(string message, Socket socket); 
}
