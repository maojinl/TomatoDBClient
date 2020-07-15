using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TomatoDBDriver;

namespace TomatoDBClient
{
    public partial class Form1 : Form
    {
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
            DBConnection conn = new DBConnection(ip, port, acc, pass);
        }
    }
}
