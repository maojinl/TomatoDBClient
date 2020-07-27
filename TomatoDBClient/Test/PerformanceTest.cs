using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using TomatoDBDriver;

namespace TomatoDBClient.Test
{
    class PerformanceTest
    {
		public const int TEST_ROUNDS = 10000;
		public const int TEST_THREADS = 10;
		public const int MAX_TEST_DATABASE = 20;
		public const int MAX_TEST_KEY = 10000;

		public DBConnection[] DBConn;
		public PerformanceTestWorker[] workers;

		public PerformanceTest()
        {
        }

		public void RunTest(string ipAddr, int port, string account, string password)
		{
			MessageMgr.Instance.ShowMessage("Starting performcance test with " + TEST_THREADS + "threads.",
				MessageMgr.MessageType.MessgeNormal);
			for (int i = 0; i < MAX_TEST_DATABASE; i++)
			{
				PerformanceTestWorker.DBNameIndex.Add(false);
			}

			workers = new PerformanceTestWorker[TEST_THREADS];
			DBConn = new DBConnection[TEST_THREADS];
			for (int i = 0; i < TEST_THREADS; i++)
			{
				DBConn[i] = new DBConnection(ipAddr, port, account, password);
				DBConn[i].Open();
				if (i < TEST_THREADS / 5)
				{
					workers[i] = new PerformanceTestWorker(i, 0, TEST_ROUNDS, DBConn[i]);
				}
				else if (i < TEST_THREADS / 4 * 2)
				{
					workers[i] = new PerformanceTestWorker(i, 1, TEST_ROUNDS, DBConn[i]);
				}
				else if (i < TEST_THREADS)
				{
					workers[i] = new PerformanceTestWorker(i, 2, TEST_ROUNDS, DBConn[i]);
				}
			}

			for (int i = 0; i < TEST_THREADS; i++)
			{
				ThreadStart threadDelegate = new ThreadStart(workers[i].Run);
				Thread newThread = new Thread(threadDelegate);
				newThread.Start();
			}

			while (true)
			{
				Thread.Sleep(2000);
				bool allDone = true;
				for (int i = 0; i < TEST_THREADS - 1; i++)
				{
					if (workers[i].Active)
					{
						allDone = false;
						break;
					}
				}
				if (allDone)
                {
					break;
                }
			}

			for (int i = 0; i < TEST_THREADS - 1; i++)
			{
				MessageMgr.Instance.ShowMessage("Thread " + i + "Failed Count is " + workers[i].FailedCount,
					MessageMgr.MessageType.MessageError);
			}

			for (int i = 0; i < MAX_TEST_DATABASE; i++)
			{
				string dbname = PerformanceTestWorker.DBNamePrefix + i;
				try
				{
					DBConn[0].DeleteDatabase(dbname);
				}
				catch
                {

                }
			}

			for (int i = 0; i < TEST_THREADS; i++)
			{
				DBConn[i].Close();
			}

			MessageMgr.Instance.ShowMessage("Finished performcance test.",
			MessageMgr.MessageType.MessageSuccessfullyFinished);
		}
	}
}
