using System;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    class CSAskDBQuery : Packet
    {
        public DB_QUERY_TYPE QueryType;
        public byte DatabaseNameSize;
        public string DatabaseName;
        byte KeySize;
        public string Key;
        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKDBQUERY;
        }

        public override uint GetPacketSize()
        {
            return sizeof(DB_QUERY_TYPE)
                + sizeof(byte)
                + sizeof(byte) * (uint)DatabaseNameSize
                + sizeof(byte)
                + sizeof(byte) * (uint)KeySize;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_QUERY_TYPE);
            byte[] chars = BitConverter.GetBytes((int)QueryType);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = sizeof(byte);
            chars = BitConverter.GetBytes(DatabaseNameSize);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = DatabaseNameSize;
            chars = Encoding.ASCII.GetBytes(DatabaseName);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = sizeof(byte);
            chars = BitConverter.GetBytes(KeySize);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = KeySize;
            chars = Encoding.ASCII.GetBytes(Key);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
