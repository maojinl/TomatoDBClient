using System;
using System.Collections.Generic;
using System.Text;

namespace TomatoDBDriver
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
            m_Status = 0;
            m_ProcessTime = 0;
        }

        public virtual void CleanUp()
        {
        }

        public bool Read(byte[] buf)
        {

            return true;
        }

		public bool Write(byte[] buf)
        {
            if (!header.Write(buf))
            {
                return false;
            }
            return true;
        }

        protected abstract bool ReadDetails(byte[] buf);

        protected abstract bool WriteDetails(byte[] buf);

        public ushort GetPacketID() { return header.GetPacketId(); }

        public abstract uint GetPacketSize();

        byte GetPacketIndex() { return m_Index; }
        void SetPacketIndex(byte Index) { m_Index = Index; }

        byte GetPacketStatus() { return m_Status ; }
        void SetPacketStatus(byte Status) { m_Status = Status; }

        byte GetPacketRetFlag() { return m_RetFlag ; }
        void SetPacketRetFlag(byte RetFlag) { m_RetFlag = RetFlag; }

        uint GetProcessTime() {return m_ProcessTime;}
        void SetProcessTime(uint ProcessTime) { m_ProcessTime = ProcessTime; }
    };

}
