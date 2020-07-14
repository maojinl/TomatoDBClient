using TomatoDBDriver.Packets;

namespace TomatoDBDriver
{
    public class DBConnection
    {
        SocketObj socketObj;

        // "ConnectionString": "Server=tcp:127.0.0.1,5433;Initial Catalog=Microsoft.eShopOnContainers.Services.MarketingDb;User Id=sa;Password=Pass@word",
        public DBConnection(string ipAddr, int port, string account, string password)
        {
            socketObj = new SocketObj(ipAddr, port);
            socketObj.Connect();
            CSAskLogin loginPacket = new CSAskLogin();
            loginPacket.accout = account;
            loginPacket.password = password;
            byte[] buf = new byte[loginPacket.GetFullPacketSize()];
            loginPacket.Write(buf);
            byte[] recvBuf = new byte[100];
            socketObj.Send(buf, recvBuf);
            PacketHeader header = PacketHeader.ParseHeader(recvBuf);
            if (header != null)
            {
                Packet p = header.CreatePacket(buf);
                if (p != null)
                {
                    SCRetLogin login = (SCRetLogin)p;
                    if (login.Result == LOGIN_RESULT.LOGINR_SUCCESS)
                    {

                    }
                }
            }
        }
    }
}
