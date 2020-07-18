using System;
using System.Collections.Generic;
using System.Text;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver.Packets
{
    public class SCRetDBQuery : Packet
    {
        public DB_QUERY_TYPE QueryType;
        public ASKDBOPERATION_RESULT Result;
        public uint ValuesSize;
        public List<string> Values;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_SC_RETDBQUERY;
        }

        public override uint GetPacketSize()
        {
            uint sz = sizeof(DB_QUERY_TYPE)
                + sizeof(ASKDBOPERATION_RESULT)
                + sizeof(uint);
            for (int i = 0; i < ValuesSize; i++)
            {
                sz = (uint)(sz + sizeof(uint)
                    + sizeof(byte) * Values[i].Length);
            }
            return sz;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = sizeof(DB_QUERY_TYPE);
            byte[] chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            QueryType = (DB_QUERY_TYPE)BitConverter.ToUInt32(chars);

            pos = pos + l;
            l = sizeof(ASKDBOPERATION_RESULT);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            Result = (ASKDBOPERATION_RESULT)BitConverter.ToUInt32(chars);

            pos = pos + l;
            l = sizeof(uint);
            chars = new byte[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            ValuesSize = BitConverter.ToUInt32(chars);
            Values = new List<string>();
            for (int i = 0; i < ValuesSize; i++)
            {
                pos = pos + l;
                l = sizeof(uint);
                chars = new byte[l];
                System.Buffer.BlockCopy(buf, pos, chars, 0, l);
                uint valueSize = BitConverter.ToUInt32(chars);

                pos = pos + l;
                l = (int)valueSize;
                chars = new byte[valueSize];
                System.Buffer.BlockCopy(buf, pos, chars, 0, l);
                string s = Encoding.ASCII.GetString(chars);
                Values.Add(s);
            }

             return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            return true;
        }
    }
}
