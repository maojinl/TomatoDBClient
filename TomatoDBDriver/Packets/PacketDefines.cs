namespace TomatoDBDriver.Packets.Defines
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

    public enum DB_OPERATION_TYPE
    {
        DB_OPERATION_TYPE_NONE = 0,
        DB_OPERATION_TYPE_CREATE,
        DB_OPERATION_TYPE_DELETE,
    };

    public enum DB_MANIPULATE_TYPE
    {
        DB_MANIPULATE_TYPE_NONE = 0,
        DB_MANIPULATE_TYPE_INSERT,
        DB_MANIPULATE_TYPE_DELETE,
    };

    public enum DB_QUERY_TYPE
    {
        DB_QUERY_TYPE_NONE = 0,
        DB_QUERY_TYPE_DB_LIST,
        DB_QUERY_TYPE_KEY_VALUE,
    }

    public enum ASKDBOPERATION_RESULT
    {
        ASK_DB_OPERATION_R_SUCCESS,         //
        ASK_DB_OPERATION_R_SERVER_BUSY,     //server busy
        ASK_DB_OPERATION_R_OP_TIMES,        //operations too much
        ASK_DB_OPERATION_R_DB_FULL,         //max tables full
        ASK_DB_OPERATION_R_SAME_DB_NAME,    //same db name
        ASK_DB_OPERATION_R_INVALID_NAME,    //invalid db name
        ASK_DB_OPERATION_R_INTERNAL_ERROR,  //internal error
    };
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
        public const int MAX_DATABASE_NAME = 63;
        public const int MAX_DATABASE_KEY = 127;
        public const int MAX_DATABASE_VALUE = 1048575;
    }
}
