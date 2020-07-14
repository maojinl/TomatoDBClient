namespace TomatoDBDriver.Packets
{
    class CSAskLogin : Packet
    {
        public string accout;
        public string password;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKLOGIN;
        }

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
            password = new string(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_ACCOUNT + 1;
            char[] chars = accout.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos,  l);

            pos = pos + PacketDefines.MAX_ACCOUNT + 1;
            chars = password.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
