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
                + sizeof(byte)
                + sizeof(ASKDBOPERATION_RESULT)
                + sizeof(byte) * (uint)DatabaseNameSize;
        }

        protected override bool ReadDetails(byte[] buf)
        {
             return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            return true;
        }
    }
}
