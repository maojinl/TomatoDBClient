namespace TomatoDBDriver.Packets
{
    public enum LOGIN_RESULT
    {
        LOGINR_SUCCESS = 1,
        LOGINR_AUTH_FAIL,
        LOGINR_VERSION_FAIL,
        LOGINR_STOP_SERVICE,
        LOGINCR_FULL,
        LOGINCR_STOP_SERVICE,
    }
    public enum PACKET_ID_DEFINE
    {
        PACKET_NONE = 0,

        /* ID:1 */
        PACKET_GC_TEST,
        PACKET_SS_CONNECT,
        PACKET_WG_SYSTEMMSG,
        PACKET_GW_SYSTEMMSG,
        PACKET_GW_ASKMAIL,
        PACKET_WG_MAIL,
        PACKET_GC_SYSTEMMSG,
        PACKET_CS_ASKLOGIN,                             //Ask Login
        PACKET_SC_RETLOGIN,                             //Ret Login

        PACKET_CS_ASKDBDEFINITION,
        PACKET_SC_RETDBDEFINITION,

        PACKET_CS_ASKDBMANIPULATE,
        PACKET_SC_RETDBMANIPULATE,

        PACKET_CS_ASKDBQUERY,
        PACKET_SC_RETDBQUERY,
        PACKET_MAX
    }
    public static class PacketDefines
    {
        public const int MAX_ACCOUNT = 15;
        public const int MAX_CHARACTER_NAME = 31;
        public const int MAX_CHARACTER_TITLE = 31;
    }
}
