using System;
using System.Data;
using System.Net;
using System.Net.Sockets;

namespace TomatoDBDriver
{
    public class SocketObj : IDisposable
    {
        bool _disposed;
        int iPort;
        IPAddress ipAddress;
        IPEndPoint remoteEP;

        // Create a TCP/IP  socket.  
        Socket socket;

        public bool Connected { get; private set; }
        public SocketObj(string addr, int port)
        {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(addr);
            ipAddress = IPAddress.Parse(addr);
            iPort = port;
            _disposed = false;
            Connected = false;
        }

        public void Connect()
        {
            if (!Connected)
            {
                try
                {
                    remoteEP = new IPEndPoint(ipAddress, iPort);
                    socket = new Socket(ipAddress.AddressFamily,
                        SocketType.Stream, ProtocolType.Tcp);
                    socket.Connect(remoteEP);
                }
                catch (Exception ex)
                {
                    throw new TomatoDBException("Network connection error!", ex);
                }
                Connected = true;
            }
        }
        
        public int Send(byte[] msg)
        {
            return socket.Send(msg);
        }

        public int Receive(byte[] returnMsg)
        {
            return socket.Receive(returnMsg);
        }

        public bool Disconnect()
        {
            if (Connected)
            {
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
                Connected = false;
            }
            return !Connected;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                Disconnect();
            }

            _disposed = true;
        }
    }
}
