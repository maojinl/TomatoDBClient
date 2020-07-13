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
        int m_ProcessTime;

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

        //·µ»ØÖµÎª£ºPACKET_EXE ÖÐµÄÄÚÈÝ£»
        //PACKET_EXE_ERROR ±íÊ¾³öÏÖÑÏÖØ´íÎó£¬µ±Ç°Á¬½ÓÐèÒª±»Ç¿ÖÆ¶Ï¿ª
        //PACKET_EXE_BREAK ±íÊ¾·µ»ØºóÊ£ÏÂµÄÏûÏ¢½«²»ÔÚµ±Ç°´¦ÀíÑ­»·Àï´¦Àí
        //PACKET_EXE_CONTINUE ±íÊ¾¼ÌÐøÔÚµ±Ç°Ñ­»·ÀïÖ´ÐÐÊ£ÏÂµÄÏûÏ¢
        //PACKET_EXE_NOTREMOVE ±íÊ¾¼ÌÐøÔÚµ±Ç°Ñ­»·ÀïÖ´ÐÐÊ£ÏÂµÄÏûÏ¢,µ«ÊÇ²»»ØÊÕµ±Ç°ÏûÏ¢
        virtual UINT Execute(Player* pPlayer);
	
	virtual PacketID_t GetPacketID() const = 0;

        virtual UINT GetPacketSize() const = 0;

        virtual BOOL CheckPacket() { return TRUE; }

        BYTE GetPacketIndex() const { return m_Index ; };
    VOID SetPacketIndex(BYTE Index) { m_Index = Index; };

    BYTE GetPacketStatus() const { return m_Status ; };
VOID SetPacketStatus(BYTE Status) { m_Status = Status; };

BYTE GetPacketRetFlag() const { return m_RetFlag ; } ;
	VOID SetPacketRetFlag(BYTE RetFlag) { m_RetFlag = RetFlag; };

UINT GetProcessTime() const {return m_ProcessTime;} ;
	VOID SetProcessTime(UINT ProcessTime) { m_ProcessTime = ProcessTime; };
};
    }
}
