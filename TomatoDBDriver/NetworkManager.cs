using System.Collections.Generic;
using TomatoDBDriver.Packets;
using TomatoDBDriver.Packets.Defines;

namespace TomatoDBDriver
{
    class NetworkManager
    {
        SocketObj socketObj;
        byte[] recvBuf;
        const int MAX_BUFF_SIZE = 1024 * 1024;
        public NetworkManager(string ipAddr, int port)
        {
            socketObj = new SocketObj(ipAddr, port);
            recvBuf = new byte[MAX_BUFF_SIZE];
        }

        private Packet SendCommand(Packet outPacket)
        {
            byte[] buf = new byte[outPacket.GetFullPacketSize()];
            outPacket.Write(buf);
            int nSent = socketObj.Send(buf);
            if (nSent != buf.Length)
            {
                throw new TomatoDBException("Socket send error.");
            }
            int nRecv = socketObj.Receive(recvBuf);
            if (nRecv > 0)
            {
                Packet p = Packet.Parse(recvBuf);
                if (p != null)
                {
                    return p;
                }
                else
                {
                    throw new TomatoDBException("Packet parse error.");
                }
            }
            else
            {
                throw new TomatoDBException("Socket receive error.");
            }
        }

        public void Connect(DBAccount dbAccount)
        {
            socketObj.Connect();
            CSAskLogin loginPacket = new CSAskLogin();
            loginPacket.accout = dbAccount.Account;
            loginPacket.password = dbAccount.Password;
            Packet p = SendCommand(loginPacket);
            SCRetLogin login = (SCRetLogin)p;
            if (login.Result == LOGIN_RESULT.LOGINR_SUCCESS)
            {
                dbAccount.UserName = login.CharName;
                dbAccount.Title = login.Title;
                dbAccount.Level = login.Level;
                return;
            }
            else
            {
                throw new TomatoDBException("Login error.", (int)login.Result);
            }
        }

        public void Disconnect()
        {
            socketObj.Disconnect();
        }

        public List<string> GetDatabaseList()
        {
            CSAskDBQuery query = new CSAskDBQuery();
            query.QueryType = DB_QUERY_TYPE.DB_QUERY_TYPE_DB_LIST;
            Packet p = SendCommand(query);
            SCRetDBQuery queryRet = (SCRetDBQuery)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return queryRet.Values;
            }
            else
            {
                throw new TomatoDBException("GetDatabaseList error.", (int)queryRet.Result);
            }
        }

        public string GetKeyValue(string database, string key)
        {
            CSAskDBQuery query = new CSAskDBQuery();
            query.QueryType = DB_QUERY_TYPE.DB_QUERY_TYPE_KEY_VALUE;
            query.DatabaseName = database;
            query.Key = key;
            Packet p = SendCommand(query);
            SCRetDBQuery queryRet = (SCRetDBQuery)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return queryRet.Values[0];
            }
            else
            {
                throw new TomatoDBException("GetKeyValue error.", (int)queryRet.Result);
            }
        }

        public void SetKey(string database, string key, string value)
        {
            CSAskDBManipulate man = new CSAskDBManipulate();
            man.OperationType = DB_MANIPULATE_TYPE.DB_MANIPULATE_TYPE_INSERT;
            man.DatabaseName = database;
            man.Key = key;
            man.Value = value;
            Packet p = SendCommand(man);
            SCRetDBManipulate queryRet = (SCRetDBManipulate)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return;
            }
            else
            {
                throw new TomatoDBException("SetKey error.", (int)queryRet.Result);
            }
        }

        public void DeleteKey(string database, string key)
        {
            CSAskDBManipulate man = new CSAskDBManipulate();
            man.OperationType = DB_MANIPULATE_TYPE.DB_MANIPULATE_TYPE_DELETE;
            man.DatabaseName = database;
            man.Key = key;
            Packet p = SendCommand(man);
            SCRetDBManipulate queryRet = (SCRetDBManipulate)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return;
            }
            else
            {
                throw new TomatoDBException("DeleteKey error.", (int)queryRet.Result);
            }
        }

        public void CreateDatabase(string database)
        {
            CSAskDBDefinition def = new CSAskDBDefinition();
            def.OperationType = DB_OPERATION_TYPE.DB_OPERATION_TYPE_CREATE;
            def.DatabaseName = database;
            Packet p = SendCommand(def);
            SCRetDBDefinition queryRet = (SCRetDBDefinition)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return;
            }
            else
            {
                throw new TomatoDBException("CreateDatabase error.", (int)queryRet.Result);
            }
        }

        public void DeleteDatabase(string database)
        {
            CSAskDBDefinition def = new CSAskDBDefinition();
            def.OperationType = DB_OPERATION_TYPE.DB_OPERATION_TYPE_DELETE;
            def.DatabaseName = database;
            Packet p = SendCommand(def);
            SCRetDBDefinition queryRet = (SCRetDBDefinition)p;
            if (queryRet.Result == ASKDBOPERATION_RESULT.ASK_DB_OPERATION_R_SUCCESS)
            {
                return;
            }
            else
            {
                throw new TomatoDBException("DeleteDatabase error.", (int)queryRet.Result);
            }
        }
    }
}
