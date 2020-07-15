using System;
using System.Text;

namespace TomatoDBDriver.Packets
{
    public class SCRetLogin : Packet
    {
        public LOGIN_RESULT Result;
        public string charName;
        public string titleName;
        public uint level;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKLOGIN;
        }

        public override uint GetPacketSize()
        {
            return sizeof (LOGIN_RESULT) 
                + sizeof(char) * (PacketDefines.MAX_CHARACTER_NAME + 1) 
                + sizeof(char) * (PacketDefines.MAX_CHARACTER_TITLE + 1)
                + sizeof(uint);
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(LOGIN_RESULT);
            byte[] chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            Result = (LOGIN_RESULT)BitConverter.ToUInt32(chars);

            pos = pos + l;
            l = PacketDefines.MAX_CHARACTER_NAME + 1;
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            charName = Encoding.ASCII.GetString(chars);

            pos = pos + l;
            l = PacketDefines.MAX_CHARACTER_TITLE + 1;
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            titleName = Encoding.ASCII.GetString(chars);

            pos = pos + l;
            l = sizeof(uint);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            level = BitConverter.ToUInt32(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = Math.Min(PacketDefines.MAX_CHARACTER_NAME + 1, charName.Length);
            byte[] chars = Encoding.ASCII.GetBytes(charName.Substring(0, l));
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos = pos + PacketDefines.MAX_CHARACTER_NAME + 1;
            l = Math.Min(PacketDefines.MAX_CHARACTER_TITLE + 1, titleName.Length);
            chars = Encoding.ASCII.GetBytes(titleName.Substring(0, l));
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
