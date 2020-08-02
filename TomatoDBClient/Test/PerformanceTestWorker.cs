using System;
using System.Collections.Generic;
using System.Threading;
using TomatoDBDriver;

namespace TomatoDBClient.Test
{
    class PerformanceTestWorker
    {
		public int TestType; //0 create delete database; 1 insert or delete Data; 2 get data;
		public int TestRound;
		public bool Active { get; set; }
		DBConnection conn;
		Random rand;
		int Id;
		public int FailedCount { get; private set; }

		public static List<bool> DBNameIndex = new List<bool>();
		public static readonly Mutex myLock = new Mutex();
		public static string DBNamePrefix = "PerfTestDB";

		public PerformanceTestWorker(int id, int type, DBConnection dbconn)
		{
			Id = id;
			TestType = type;
			TestRound = 0;
			conn = dbconn;
			rand = new Random();
			FailedCount = 0;
			Active = true;
		}

		public void Run()
		{
			switch (TestType)
			{
				case 0:
					CreateOrDeleteDB();
					break;
				case 1:
					InsertOrDeleteData();
					break;
				case 2:
					GetKey();
					break;
				default:
					break;
			};
			Active = false;
			return;
		}

		void CreateOrDeleteDB()
		{
			bool ret = false;
			while(Active)
			{
				int idx = rand.Next(0, PerformanceTest.MAX_TEST_DATABASE - 1);
				string dbname = DBNamePrefix + idx;
				if (DBNameIndex[idx])
				{
					ret = true;
					if (idx > 3)
					{
						try
						{
							conn.DeleteDatabase(dbname);
						}
						catch
                        {
							ret = false;
                        }
					}
				}
				else
				{
					try
					{
						conn.CreateDatabase(dbname);
					}
					catch
                    {
						ret = false;
                    }
				}

				myLock.WaitOne();
				DBNameIndex[idx] = !DBNameIndex[idx];
				myLock.ReleaseMutex();

				if (!ret)
				{
					FailedCount++;
				}
				TestRound++;
			}

			return;
		}

		void InsertOrDeleteData()
		{
			List<string> dblist;
			string dbname;
			string key;
			string value = "value";
			bool ret = false;
			while (Active)
			{
                dblist = conn.GetDatabaseList();
                if (dblist.Count != 0)
                {
                    int n = rand.Next(0, dblist.Count - 1);
                    dbname = dblist[n];
                    n = rand.Next(0, PerformanceTest.MAX_TEST_KEY);
					//int idx = rand.Next(0, PerformanceTest.MAX_TEST_DATABASE - 1);
					//dbname = DBNamePrefix + idx;
					//int n = rand.Next(0, PerformanceTest.MAX_TEST_KEY); 

					key = n.ToString();
					n = rand.Next(0, 4);
					ret = true;
					if (n == 0)
					{
						try
						{
							conn.DeleteKey(dbname, key);
						}
						catch
                        {
							ret = false;
                        }
					}
					else
					{
						try
						{
							conn.SetKey(dbname, key, value);
						}
						catch
						{
							ret = false;
						}
					}
					if (!ret)
					{
						FailedCount++;
					}
					TestRound++;
				}
			}
			return;
		}

		void GetKey()
		{
			List<string> dblist;
			string dbname;
			string key;
			string value = "value";
			bool ret = false;
			while (Active)
			{
				dblist = conn.GetDatabaseList();
				if (dblist.Count != 0)
				{
					int n = rand.Next(0, dblist.Count - 1);
					dbname = dblist[n];
					n = rand.Next(0, PerformanceTest.MAX_TEST_KEY);
					//int idx = rand.Next(0, PerformanceTest.MAX_TEST_DATABASE - 1);
					//dbname = DBNamePrefix + idx;
					//int n = rand.Next(0, PerformanceTest.MAX_TEST_KEY); 

					key = n.ToString();
					ret = true;
					try
					{
						value = conn.GetKeyValue(dbname, key);
					}
					catch
					{
						ret = false;
					}
					if (!ret)
					{
						FailedCount++;
					}

					TestRound++;
				}
			}
			return;
		}
	}
}
