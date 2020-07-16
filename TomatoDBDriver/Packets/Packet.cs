using System;
using System.Threading;

namespace TomatoDBDriver.Packets
{
    public abstract class Packet
    {
        PacketHeader header;
        byte m_Index;
        byte m_Status;
        byte m_RetFlag;
        uint m_ProcessTime;

        public Packet()
        {
            header = new PacketHeader();
            m_Status = 0;
            m_ProcessTime = 0;
        }

        public void PopulateHeader(uint timeStamp)
        {
            header.SetPacketId(GetPacketID());
            header.SetLength(GetPacketSize());
            header.SetTimestamp(timeStamp);
        }

        public bool Read(byte[] buf)
        {
            return ReadDetails(buf);
        }

		public bool Write(byte[] buf)
        {
            Array.Clear(buf, 0, buf.Length);
            PopulateHeader((uint)DateTime.Now.Ticks);
            if (!header.Write(buf))
            {
                return false;
            }
            return WriteDetails(buf);
        }
        public virtual void CleanUp()
        {
        }

        public uint GetFullPacketSize()
        {
            return GetPacketSize() + PacketHeader.PacketHeaderSize;
        }

        public static Packet Parse(byte[] buf)
        {
            PacketHeader header = PacketHeader.ParseHeader(buf);
            if (header != null)
            {
                Packet p = header.CreatePacket(buf);
                return p;
            }
            return null;
        }

        byte GetPacketIndex() { return m_Index; }
        void SetPacketIndex(byte Index) { m_Index = Index; }

        byte GetPacketStatus() { return m_Status ; }
        void SetPacketStatus(byte Status) { m_Status = Status; }

        byte GetPacketRetFlag() { return m_RetFlag ; }
        void SetPacketRetFlag(byte RetFlag) { m_RetFlag = RetFlag; }

        uint GetProcessTime() {return m_ProcessTime;}
        void SetProcessTime(uint ProcessTime) { m_ProcessTime = ProcessTime; }

        protected abstract bool ReadDetails(byte[] buf);

        protected abstract bool WriteDetails(byte[] buf);

        public abstract ushort GetPacketID();

        public abstract uint GetPacketSize();
    };

}
