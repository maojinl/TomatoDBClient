// ***********************************************************************
//                                NOTICE
//
//      THIS DOCUMENT REPRESENTS CONFIDENTIAL PROPRIETARY PROGRAM
//      PRODUCTS AND PROPRIETARY INFORMATION AND COPYRIGHTABLE MATERIAL
//      OWNED BY BALLY GAMING, INC. OR ITS AFFILIATED COMPANIES.
//      NEITHER RECEIPT NOR POSSESSION OF THIS DOCUMENT CONFERS ANY RIGHT
//      TO REPRODUCE, COPY, PREPARE DERIVATIVE WORKS, USE, OR DISCLOSE,
//      IN WHOLE OR IN PART, ANY PROGRAM, PRODUCT OR INFORMATION CONTAINED
//      HEREIN WITHOUT WRITTEN AUTHORIZATION FROM BALLY GAMING, INC.
//
//              COPYRIGHT 2017-2019 BALLY GAMING, INC.
//                        ALL RIGHTS RESERVED.
//
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

using TomatoDBClient.Const;
using TomatoDBClient.Env;
using TomatoDBClient.Msg;

using Microsoft.Win32;
using TomatoDBDriver;

namespace TomatoDBClient
{
    public partial class MainForm : Form
    {
        SettingsJsonData settings;
        List<string> m_consoleErrorPool = new List<string>();
        List<string> m_databases = new List<string>();
        private Dictionary<Control, ToolTip> toolTips = new Dictionary<Control, ToolTip>();
        private EnvPathForm envForm;
        DBConnection conn;

        public MainForm()
        {
            InitializeComponent();
            InitSettings();
            InitMessageMgr();
            InitEnvForm();
            InitToolTips();
            //this.Text = AssemblyInfo.Title + "  " + AssemblyInfo.Version;
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.txtServer.Text = settings.ServerIP + ":" + settings.ServerPort;
        }

        private void InitSettings()
        {
            settings = new SettingsJsonData();
            settings.ReadSettingsJsonData(@".\cfg");
            conn = new DBConnection(settings.ServerIP, settings.ServerPort, "account", "pass");
        }


        private void InitToolTips()
        {
            toolTips.Add(picServerConnction, new ToolTip());
        }


        private void InitEnvForm()
        {
            envForm = new EnvPathForm();
        }

        private void InitMessageMgr()
        {
            MessageMgr.Instance.InitMessageMgr(this, messageTextBox);
        }

        /// <summary>
        /// Install status label update.
        /// </summary>
        /// <param name="status"></param>
        public void UpdateInstallStatusLabel(string status)
        {
            InstallStatusLabel.Text = status;
        }

      
        private void SetupImageHint(TextBox textBox, PictureBox pictureBox, bool downloaded, string versionInRegistry)
        {
            ToolTip tt = null;
            if (toolTips.TryGetValue(pictureBox, out tt))
            {
               // pictureBox.BackgroundImage = Properties.Resources.downloaded;
                tt.SetToolTip(pictureBox, "This path is ready for selected game.");
            }
        }

        private void LoadDatabases()
        {
            m_databases = conn.GetDatabaseList();
            listDatabases.Items.Clear();
            foreach (var db in m_databases)
            {
                listDatabases.Items.Add(db);
            }
        }

        void SetControlsEnableState(bool enabled)
        {
            listDatabases.Enabled = enabled;
           
            btnConnect.Enabled = enabled;
         

        }

        private void listGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (listDatabases.SelectedItem != null)
                {
                    txtDatabase.Text = listDatabases.SelectedItem.ToString();
                }
            }
            catch(Exception ex)
            {
                MessageMgr.Instance.ShowMessage("Exception: " + ex.ToString());
            }
        }


      
        public void ProcessOutputHandler(object sender, DataReceivedEventArgs e)
        {
            MessageMgr.Instance.ShowMessage(e.Data);
        }

        public void ProcessErrorHandler(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && e.Data.Length > 0)
            {
                m_consoleErrorPool.Add(e.Data);
            }
        }

        public void OnCommandStart()
        {
            m_consoleErrorPool.Clear();
        }

        public bool ShouldFinishCommand()
        {
            return this.IsDisposed || this.Disposing;
        }

        public void OnCommandEnd(int exitCode)
        {
            foreach (var errorLine in m_consoleErrorPool)
            {
                MessageMgr.Instance.ShowMessage(errorLine, MessageMgr.MessageType.MessageError);
            }
            m_consoleErrorPool.Clear();
            MessageMgr.Instance.ShowMessage("Command end with exit code = " + exitCode.ToString());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            conn.Open();
            LoadDatabases();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            conn.CreateDatabase(txtDatabase.Text);
            LoadDatabases();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            conn.DeleteDatabase(txtDatabase.Text);
            LoadDatabases();
        }

        private void btnSetKeyValue_Click(object sender, EventArgs e)
        {
            conn.SetKey(txtDatabase.Text, txtKey.Text, txtValue.Text);
        }

        private void btnDeleteKeyValue_Click(object sender, EventArgs e)
        {
            conn.DeleteKey(txtDatabase.Text, txtKey.Text);
        }

        private void btnGetKeyValue_Click(object sender, EventArgs e)
        {
            txtValue.Text = conn.GetKeyValue(txtDatabase.Text, txtKey.Text);
        }
    }
}

