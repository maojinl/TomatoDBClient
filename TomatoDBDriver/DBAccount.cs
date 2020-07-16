namespace TomatoDBDriver
{
    class DBAccount
    {
        public string Account;
        public string Title;
        public string UserName;
        public uint Level;

        public string Password;
        public DBAccount(string account, string pwd)
        {
            Account = account;
            Password = pwd;
        }
    }
}
