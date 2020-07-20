using System.Collections.Generic;
using TomatoDBDriver.Packets;

namespace TomatoDBDriver
{
    public class DBConnection
    {

        NetworkManager networkMgr;
        DBAccount dbAccount;
        //should use DbConnectionStringBuilder
        // "ConnectionString": "Server=tcp:127.0.0.1,5433;Initial Catalog=Microsoft.eShopOnContainers.Services.MarketingDb;User Id=sa;Password=Pass@word",
        public DBConnection(string ipAddr, int port, string account, string password)
        {
            networkMgr = new NetworkManager(ipAddr, port);
            dbAccount = new DBAccount(account, password);
        }

        public void Open()
        {
            networkMgr.Connect(dbAccount);
        }

        public void Close()
        {
            networkMgr.Disconnect();
        }

        public List<string> GetDatabaseList()
        {
            return networkMgr.GetDatabaseList();
        }

        public void CreateDatabase(string database)
        {
            networkMgr.CreateDatabase(database);
        }

        public void DeleteDatabase(string database)
        {
            networkMgr.DeleteDatabase(database);
        }

        public void SetKey(string database, string key, string value)
        {
            networkMgr.SetKey(database, key, value);
        }

        public void DeleteKey(string database, string key)
        {
            networkMgr.DeleteKey(database, key);
        }

        public string GetKeyValue(string database, string key)
        {
            return networkMgr.GetKeyValue(database, key);
        }
    }
}
