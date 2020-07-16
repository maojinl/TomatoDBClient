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
            networkMgr.Connect(dbAccount.Account, dbAccount.Password);
        }
    }
}
