using System;
using System.Collections.Generic;
using System.Windows.Forms;

using TomatoDBDriver;

namespace TomatoDBClient
{
    public partial class Form1 : Form
    {
        DBConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string ip = "192.128.1.200";
            //int port = 8880;
            string ip = "127.0.0.1"; //"10.7.96.155";
            int port = 7377;
            string acc = "root";
            string pass = "password";
            conn = new DBConnection(ip, port, acc, pass);
            conn.Open();
            listBox1.Items.Clear();
            List<string> dbList = conn.GetDatabaseList();
            foreach (string db in dbList)
            {
                listBox1.Items.Add(db);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn.CreateDatabase(textBox1.Text);
            listBox1.Items.Clear();
            List<string> dbList = conn.GetDatabaseList();
            foreach (string db in dbList)
            {
                listBox1.Items.Add(db);
            }
        }

        private void btnSetKeyValue_Click(object sender, EventArgs e)
        {
            conn.SetKey(listBox1.SelectedItem.ToString(), textBox2.Text, textBox3.Text);
            listBox1.Items.Clear();
            List<string> dbList = conn.GetDatabaseList();
            foreach (string db in dbList)
            {
                listBox1.Items.Add(db);
            }
        }
    }
}
