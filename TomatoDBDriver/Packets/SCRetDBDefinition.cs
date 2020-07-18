using System;
using System.Collections.Generic;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    public class SCRetDBDefinition : Packet
    {
        public DB_OPERATION_TYPE OperationType;
        public ASKDBOPERATION_RESULT Result;
        public byte DatabaseNameSize;
        public string DatabaseName;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_SC_RETDBDEFINITION;
        }

        public override uint GetPacketSize()
        {
            return sizeof(DB_OPERATION_TYPE)
                + sizeof(ASKDBOPERATION_RESULT)
                + sizeof(byte)
                + sizeof(byte) * (uint)DatabaseNameSize;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_OPERATION_TYPE);
            byte[] chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0,  l);
            OperationType = (DB_OPERATION_TYPE)BitConverter.ToUInt32(chars);

            pos += l;
            l = sizeof(ASKDBOPERATION_RESULT);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            Result = (ASKDBOPERATION_RESULT)BitConverter.ToUInt32(chars);

            pos += l;
            l = sizeof(byte);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            DatabaseNameSize = chars[0];

            pos = pos + l;
            l = (int)DatabaseNameSize;
            chars = new byte[DatabaseNameSize];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            DatabaseName = Encoding.ASCII.GetString(chars);
            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            return true;
        }
    }
}
