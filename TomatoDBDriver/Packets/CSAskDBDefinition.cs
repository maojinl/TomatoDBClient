using System;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    class CSAskDBDefinition : Packet
    {
        public DB_OPERATION_TYPE OperationType;
        public byte DatabaseNameSize;
        public string DatabaseName;	//database name
        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKDBDEFINITION;
        }

        public override uint GetPacketSize()
        {
            DatabaseNameSize = (byte)Math.Min(PacketDefines.MAX_DATABASE_NAME + 1, DatabaseName.Length);
            return sizeof(DB_OPERATION_TYPE)
                + sizeof(byte)
                + sizeof(byte) * (uint)DatabaseNameSize;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_OPERATION_TYPE);
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

            return true;
        }
    }
}
