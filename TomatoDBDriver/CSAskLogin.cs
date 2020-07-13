using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TomatoDBDriver
{
    class CSAskLogin : Packet
    {
        string accout;
        string passWord;
        public override uint GetPacketSize()
        {
            return sizeof(char) * (PacketDefines.MAX_ACCOUNT + 1) * 2;
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_ACCOUNT + 1;
            char[] chars = new char[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            accout = new string(chars);

            pos = pos + PacketDefines.MAX_ACCOUNT + 1;
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            passWord = new string(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_ACCOUNT + 1;
            char[] chars = accout.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos,  l);

            pos = pos + PacketDefines.MAX_ACCOUNT + 1;
            chars = passWord.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
