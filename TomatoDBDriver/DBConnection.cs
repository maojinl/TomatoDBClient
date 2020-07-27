using System.Collections.Generic;

namespace TomatoDBDriver
{
    public class DBConnection
    {

        NetworkManager networkMgr;
        DBAccount dbAccount;

        public bool Connected { get; private set; }
        //should use DbConnectionStringBuilder
        // "ConnectionString": "Server=tcp:127.0.0.1,5433;Initial Catalog=Microsoft.eShopOnContainers.Services.MarketingDb;User Id=sa;Password=Pass@word",
        public DBConnection(string ipAddr, int port, string account, string password)
        {
            networkMgr = new NetworkManager(ipAddr, port);
            dbAccount = new DBAccount(account, password);
            Connected = false;
        }

        public void Open()
        {
            networkMgr.Connect(dbAccount);
            Connected = true;
        }

        public void Close()
        {
            networkMgr.Disconnect();
            Connected = false;
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
