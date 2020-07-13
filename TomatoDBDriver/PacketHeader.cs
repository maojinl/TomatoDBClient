using System;
using System.Collections.Generic;
using System.Text;

namespace TomatoDBDriver
{
    class PacketHeader
    {
        public byte action;
        public byte control;
        private byte[] ts = { 0, 0, 0, 0 };
        public byte index;
        private byte[] length = { 0, 0, 0, 0 };
        public byte flag;

        // packageId action & control
        ushort GetPackageId() 
        {
            return BitConverter.ToUInt16(new byte[] {action, control});
        }
        void SetPackageId(ushort val) 
        {
            byte[] ret = BitConverter.GetBytes(val);
            action = ret[0];
            control = ret[1];
        }

        // timestamp
        Int32 GetTimestamp() { return BitConverter.ToInt32(ts); }
        void SetTimestamp(Int32 val)
        {
            byte[] ret = BitConverter.GetBytes(val);
            for (int i = 0; i < ts.Length; i++)
            {
                ts[i] = ret[i];
            }
        }

        // length
        Int32 GetLength()
        {
            return BitConverter.ToInt32(length);
        }
        void SetLength(Int32 val)
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
    }
}
