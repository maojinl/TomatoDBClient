using TomatoDBDriver.Packets;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver
{
    class NetworkManager
    {
        SocketObj socketObj;
        byte[] recvBuf;
        const int MAX_BUFF_SIZE = 1024 * 1024;
        public NetworkManager(string ipAddr, int port)
        {
            socketObj = new SocketObj(ipAddr, port);
            recvBuf = new byte[MAX_BUFF_SIZE];
        }

        public void Connect(DBAccount dbAccount)
        {
            socketObj.Connect();
            CSAskLogin loginPacket = new CSAskLogin();
            loginPacket.accout = dbAccount.Account;
            loginPacket.password = dbAccount.Password;
            byte[] buf = new byte[loginPacket.GetFullPacketSize()];
            loginPacket.Write(buf);
            byte[] recvBuf = new byte[100];
            int nSent = socketObj.Send(buf);
            if (nSent != buf.Length)
            {
                throw new TomatoDBException("Socket send error.");
            }
            int nRecv = socketObj.Receive(recvBuf);
            if (nRecv > 0)
            {
                Packet p = Packet.Parse(recvBuf);
                if (p != null)
                {
                    SCRetLogin login = (SCRetLogin)p;
                    if (login.Result == LOGIN_RESULT.LOGINR_SUCCESS)
                    {
                        dbAccount.UserName = login.CharName;
                        dbAccount.Title = login.Title;
                        dbAccount.Level = login.Level;
                        return;
                    }
                    else
                    {
                        throw new TomatoDBException("Login error error.", (int)login.Result);
                    }
                }
            }
            else
            {
                throw new TomatoDBException("Socket receive error.");
            }
        }
    }
}
