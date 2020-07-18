using System;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    class CSAskDBManipulate : Packet
    {
        public DB_MANIPULATE_TYPE OperationType;
        public byte DatabaseNameSize;
        public string DatabaseName;
        public uint KeySize;
        public string Key;
        public byte ValueSize;
        public string Value;
        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKDBMANIPULATE;
        }

        public override uint GetPacketSize()
        {
            DatabaseNameSize = (byte)Math.Min(PacketDefines.MAX_DATABASE_NAME + 1, DatabaseName.Length);
            KeySize = (uint)Math.Min(PacketDefines.MAX_DATABASE_VALUE + 1, Key.Length);
            ValueSize = (byte)Math.Min(PacketDefines.MAX_DATABASE_VALUE + 1, Value.Length);
            return sizeof(DB_MANIPULATE_TYPE)
                + sizeof(byte)
                + sizeof(byte) * (uint)DatabaseNameSize
                + sizeof(uint)
                + sizeof(byte) * (uint)KeySize
                 + sizeof(byte)
                + sizeof(byte) * (uint)ValueSize;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_MANIPULATE_TYPE);
            byte[] chars = BitConverter.GetBytes((int)OperationType);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            DatabaseNameSize = (byte)Math.Min(PacketDefines.MAX_DATABASE_NAME + 1, DatabaseName.Length);
            pos += l;
            l = sizeof(byte);
            chars = BitConverter.GetBytes(DatabaseNameSize);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = DatabaseNameSize;
            chars = Encoding.ASCII.GetBytes(DatabaseName);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            KeySize = (uint)Math.Min(PacketDefines.MAX_DATABASE_VALUE + 1, DatabaseName.Length);
            pos += l;
            l = sizeof(uint);
            chars = BitConverter.GetBytes(KeySize);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = (int)KeySize;
            chars = Encoding.ASCII.GetBytes(Value);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            ValueSize = (byte)Math.Min(PacketDefines.MAX_DATABASE_VALUE + 1, DatabaseName.Length);
            pos += l;
            l = sizeof(byte);
            chars = BitConverter.GetBytes(ValueSize);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos += l;
            l = ValueSize;
            chars = Encoding.ASCII.GetBytes(Value);
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            return true;
        }
    }
}
