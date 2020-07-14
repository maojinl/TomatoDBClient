using System;

namespace TomatoDBDriver.Packets
{
    class PacketHeader
    {
        public byte action;
        public byte control;
        private byte[] ts = { 0, 0, 0, 0 };
        public byte index;
        private byte[] length = { 0, 0, 0, 0 };
        public byte flag;
        public const int PacketHeaderSize = 12;
        
        // packageId action & control
        public ushort GetPacketId() 
        {
            return BitConverter.ToUInt16(new byte[] {action, control});
        }
        public void SetPacketId(ushort val) 
        {
            byte[] ret = BitConverter.GetBytes(val);
            action = ret[0];
            control = ret[1];
        }

        // timestamp
        public uint GetTimestamp() { return BitConverter.ToUInt32(ts); }
        public void SetTimestamp(uint val)
        {
            byte[] ret = BitConverter.GetBytes(val);
            for (int i = 0; i < ts.Length; i++)
            {
                ts[i] = ret[i];
            }
        }

        // length
        public uint GetLength()
        {
            return BitConverter.ToUInt32(length);
        }
        public void SetLength(uint val)
        {
            byte[] ret = BitConverter.GetBytes(val);
            for (int i = 0; i < length.Length; i++)
            {
                length[i] = ret[i];
            }
        }

        public bool Read(byte[] buf)
        {
            int pos = 0;
            action = buf[pos++];
            control = buf[pos++];
            for (int i = 0; i < 4; i++)
            {
                ts[i] = buf[pos++];
            }
            index = buf[pos++];
            for (int i = 0; i < 4; i++)
            {
                length[i] = buf[pos++];
            }
            flag = buf[pos];
            return true;
        }

        public bool Write(byte[] buf)
        {
            int pos = 0;
            buf[pos++] = action;
            buf[pos++] = control;
            for (int i = 0; i < 4; i++)
            {
                buf[pos++] = ts[i];
            }
            buf[pos++] = index;
            for (int i = 0; i < 4; i++)
            {
                buf[pos++] = length[i];
            }
            buf[pos] = flag;
            return true;
        }

        public Packet CreatePacket(byte[] buf)
        {
            Read(buf);
            ushort pid = GetPacketId();
            switch (pid)
            {
                case
                    (ushort)PACKET_ID_DEFINE.PACKET_SC_RETLOGIN:
                    {
                        SCRetLogin loginRet = new SCRetLogin();
                        loginRet.Read(buf);
                        return loginRet;
                    }
                default:
                    {
                        return null;
                    }
            }

        }

        public static PacketHeader ParseHeader(byte[] buf)
        {
            if (buf.Length > PacketHeaderSize)
            {
                PacketHeader header = new PacketHeader();
                header.Read(buf);
                return header;
            }
            return null;
        }
    }
}
