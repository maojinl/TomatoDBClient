using System;
using System.Collections.Generic;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    public class SCRetDBManipulate : Packet
    {
        public DB_MANIPULATE_TYPE OperationType;
        public ASKDBOPERATION_RESULT Result;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_SC_RETDBMANIPULATE;
        }

        public override uint GetPacketSize()
        {
            return sizeof(DB_MANIPULATE_TYPE)
                + sizeof(ASKDBOPERATION_RESULT);
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_MANIPULATE_TYPE);
            byte[] chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0,  l);
            OperationType = (DB_MANIPULATE_TYPE)BitConverter.ToUInt32(chars);

            pos += l;
            l = sizeof(ASKDBOPERATION_RESULT);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            Result = (ASKDBOPERATION_RESULT)BitConverter.ToUInt32(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            return true;
        }
    }
}
