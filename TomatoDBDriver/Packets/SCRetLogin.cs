namespace TomatoDBDriver.Packets
{
    public class SCRetLogin : Packet
    {
        public LOGIN_RESULT Result;
        public string charName;
        public string titleName;
        public uint level;

        public override ushort GetPacketID()
        {
            return (ushort)PACKET_ID_DEFINE.PACKET_CS_ASKLOGIN;
        }

        public override uint GetPacketSize()
        {
            return sizeof (LOGIN_RESULT) 
                + sizeof(char) * (PacketDefines.MAX_CHARACTER_NAME + 1) 
                + sizeof(char) * (PacketDefines.MAX_CHARACTER_TITLE + 1)
                + sizeof(uint);
        }

        protected override bool ReadDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_CHARACTER_NAME + 1;
            char[] chars = new char[l];
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            charName = new string(chars);

            pos = pos + PacketDefines.MAX_CHARACTER_NAME + 1;
            l = PacketDefines.MAX_CHARACTER_TITLE + 1;
            System.Buffer.BlockCopy(buf, pos, chars, 0, l);
            titleName = new string(chars);

            return true;
        }

        protected override bool WriteDetails(byte[] buf)
        {
            int pos = PacketHeader.PacketHeaderSize;
            int l = PacketDefines.MAX_CHARACTER_NAME + 1;
            char[] chars = charName.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);

            pos = pos + PacketDefines.MAX_CHARACTER_NAME + 1;
            l = PacketDefines.MAX_CHARACTER_TITLE + 1;
            chars = titleName.Substring(0, l).ToCharArray();
            System.Buffer.BlockCopy(chars, 0, buf, pos, l);
            return true;
        }
    }
}
