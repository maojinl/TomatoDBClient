using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomatoDBDriver;

namespace TomatoDBClient.Test
{
    class PerformanceTest
    {
		public const int TEST_ROUNDS = 1000;
		public const int TEST_THREADS = 10;
		public const int MAX_TEST_DATABASE = 20;
		public const int MAX_TEST_KEY = 10000;

		public DBConnection[] DBConn;
		public PerformanceTestWorker[] workers;
		ProgressBar probar;
		string Addr;
		int Port;
		string Account;
		string Password;

		public PerformanceTest(ProgressBar bar, string ipAddr, int port, string account, string password)
		{
			probar = bar;
			Addr = ipAddr;
			Port = port;
			Account = account;
			Password = password;
		}

		public async Task RunTest()
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
				DBConn[i] = new DBConnection(Addr, Port, Account, Password);
				DBConn[i].Open();
				if (i < TEST_THREADS / 5)
				{
					workers[i] = new PerformanceTestWorker(i, 0, DBConn[i]);
				}
				else if (i < TEST_THREADS / 4 * 2)
				{
					workers[i] = new PerformanceTestWorker(i, 1, DBConn[i]);
				}
				else if (i < TEST_THREADS)
				{
					workers[i] = new PerformanceTestWorker(i, 2, DBConn[i]);
				}
			}

			for (int i = 0; i < TEST_THREADS; i++)
			{
				ThreadStart threadDelegate = new ThreadStart(workers[i].Run);
				Thread newThread = new Thread(threadDelegate);
				newThread.Start();
			}

			int maxTotalRounds = TEST_THREADS * TEST_ROUNDS;
			while (true)
			{
				Thread.Sleep(1000);
				bool allDone = true;
				int totalRounds = 0;
				for (int i = 0; i < TEST_THREADS - 1; i++)
				{
					totalRounds += workers[i].TestRound;
					if (workers[i].TestRound >= TEST_ROUNDS)
                    {
						workers[i].Active = false;
					}
				}
				
				for (int i = 0; i < TEST_THREADS - 1; i++)
				{
					if (workers[i].Active)
					{
						allDone = false;
						break;
					}
				}
				ProgressChanged(totalRounds, maxTotalRounds);
				if (allDone)
                {
					Thread.Sleep(1000);
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

		protected virtual void ProgressChanged(int value, int total)
		{
			//long totalPercent = value / total;
			//if (totalPercent > int.MaxValue)
			//{
			//	totalPercent = int.MaxValue;
			//}
			probar.Maximum = total;
			probar.Value = value;
		}
	}
}
