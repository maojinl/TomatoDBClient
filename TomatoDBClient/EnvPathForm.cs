using System;
using System.Windows.Forms;

namespace TomatoDBClient.Env
{
    public partial class EnvPathForm : Form
    {
     

        private void LoadSettings(SettingsJsonData settings)
        {
            txtServerIP.Text = settings.ServerIP;
            txtServerPort.Text = settings.ServerPort.ToString();
        }

        private void btnOkey_Click(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
