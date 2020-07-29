using System;
using System.Collections.Generic;
using System.ComponentModel;
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
		public const int TEST_ROUNDS = 100;
		public const int TEST_THREADS = 100;
		public const int MAX_TEST_DATABASE = 20;
		public const int MAX_TEST_KEY = 10000;

		public DBConnection[] DBConn;
		public PerformanceTestWorker[] workers;
		ProgressBar probar;
		string Addr;
		int Port;
		string Account;
		string Password;

        public BackgroundWorker TestWorker { get; private set; } = new BackgroundWorker();

        public PerformanceTest(ProgressBar bar, string ipAddr, int port, string account, string password)
		{
			probar = bar;
            probar.Maximum = int.MaxValue;
            Addr = ipAddr;
			Port = port;
			Account = account;
			Password = password;
            InitBackgroundWorker();

        }

        public void InitBackgroundWorker()
        {
            TestWorker.WorkerSupportsCancellation = true;
            TestWorker.WorkerReportsProgress = true;
            TestWorker.ProgressChanged += testWorker_ProgressChanged;
            TestWorker.DoWork += RunTest;
            TestWorker.RunWorkerCompleted += testWorker_RunWorkerCompleted;
        }

        protected virtual void RunTest(object sender, DoWorkEventArgs e)
        {
            DateTime dt = DateTime.Now;
            MessageMgr.Instance.ShowMessage("Starting performcance test with " + TEST_THREADS + " connections.",
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
            TestWorker.ReportProgress(-1, maxTotalRounds);
            while (true)
            {
                Thread.Sleep(1000);
                bool allDone = true;
                int totalRounds = 0;
                for (int i = 0; i < TEST_THREADS; i++)
                {
                    totalRounds += workers[i].TestRound;
                    if (workers[i].TestRound >= TEST_ROUNDS)
                    {
                        workers[i].Active = false;
                    }
                }

                for (int i = 0; i < TEST_THREADS; i++)
                {
                    if (workers[i].Active)
                    {
                        allDone = false;
                        break;
                    }
                }
                TestWorker.ReportProgress(totalRounds);
                if (allDone)
                {
                    Thread.Sleep(1000);
                    break;
                }
            }

            for (int i = 0; i < TEST_THREADS; i++)
            {
                MessageMgr.Instance.ShowMessage("Thread " + i + "Failed Count is " + workers[i].FailedCount,
                    MessageMgr.MessageType.MessageWarning);
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
            TimeSpan ts = DateTime.Now - dt;
            MessageMgr.Instance.ShowMessage("Finished performcance test for " + TEST_ROUNDS + " with " + ts.TotalMilliseconds.ToString()  + "ms.",
            MessageMgr.MessageType.MessageSuccessfullyFinished);
        }

        protected virtual void testWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            probar.Value = 0;
        }

        protected virtual void testWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == -1)
                probar.Maximum = Convert.ToInt32(e.UserState);
            else
            {
                int p = e.ProgressPercentage < probar.Maximum ? e.ProgressPercentage : probar.Maximum;
                probar.Value = p;
            }
        }
	}
}
