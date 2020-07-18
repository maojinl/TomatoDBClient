using System;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    class CSAskLogin : Packet
    {
        public string accout;
        public string password;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKLOGIN;
        }

        public override uint GetPacketSize()
        {
            return sizeof(byte) * (PacketDefines.MAX_ACCOUNT + 1) * 2;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_ACCOUNT + 1;
            byte[] chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            accout = Encoding.ASCII.GetString(chars);

            pos += l;
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            password = Encoding.ASCII.GetString(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = Math.Min(PacketDefines.MAX_ACCOUNT + 1, accout.Length);
            byte[] chars = Encoding.ASCII.GetBytes(accout.Substring(0, l));
            System.Buffer.BlockCopy(chars, 0, buf, pos,  l);

            pos = pos + PacketDefines.MAX_ACCOUNT + 1;
            l = Math.Min(PacketDefines.MAX_ACCOUNT + 1, password.Length);
            chars = Encoding.ASCII.GetBytes(password.Substring(0, l));
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
