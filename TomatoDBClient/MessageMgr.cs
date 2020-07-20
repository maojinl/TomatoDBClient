using System.Drawing;
using System.Windows.Forms;

namespace TomatoDBClient.Msg
{
    public sealed class MessageMgr
    {
        public enum MessageType
        {
            MessgeNormal,
            MessageError,
            MessageWarning,
            MessageSuccessfullyFinished,
        }

        /// <summary>
        /// Text box for output message.
        /// </summary>
        private RichTextBox messageTextBox;

        private MainForm mainForm;

        private MessageMgr()
        {
        }

        private static readonly MessageMgr instance = new MessageMgr();
        public static MessageMgr Instance
        {
            get
            {
                return instance;
            }
        }

        public void InitMessageMgr(MainForm mainForm, RichTextBox textBox)
        {
            this.mainForm = mainForm;
            this.messageTextBox = textBox;
        }

        private delegate void MessageWriteLineCallback(string text, MessageType messageType);
        private const string lineEnd = "\r\n";
        public void ShowMessage(string output, MessageType messageType = MessageType.MessgeNormal)
        {
            if (messageTextBox.InvokeRequired)
            {
                MessageWriteLineCallback d = new MessageWriteLineCallback(ShowMessage);
                if (mainForm.Disposing || mainForm.IsDisposed)
                {
                    return;
                }
                mainForm.Invoke(d, new object[] { output, messageType });
            }
            else
            {
                if (messageTextBox.Disposing || messageTextBox.IsDisposed)
                {
                    return;
                }

                switch (messageType)
                {
                    case MessageType.MessageError:
                        messageTextBox.SelectionStart = messageTextBox.TextLength;
                        messageTextBox.SelectionLength = 0;
                        messageTextBox.SelectionColor = Color.Red;
                        output = "[ERROR]:" + output;
                        break;
                    case MessageType.MessageSuccessfullyFinished:
                        messageTextBox.SelectionStart = messageTextBox.TextLength;
                        messageTextBox.SelectionLength = 0;
                        messageTextBox.SelectionColor = Color.Green;
                        break;
                    case MessageType.MessageWarning:
                        messageTextBox.SelectionStart = messageTextBox.TextLength;
                        messageTextBox.SelectionLength = 0;
                        messageTextBox.SelectionColor = Color.Orange;
                        output = "[WARNING]:" + output;
                        break;
                    case MessageType.MessgeNormal:
                        output = "[INFO]:" + output;
                        break;
                    default:
                        break;
                }

                if (!output.EndsWith("\r\n"))
                    messageTextBox.AppendText(output + lineEnd);
                else
                    messageTextBox.AppendText(output);

                if (messageType == MessageType.MessageError || messageType == MessageType.MessageSuccessfullyFinished)
                {
                    messageTextBox.SelectionColor = messageTextBox.ForeColor;
                }

                messageTextBox.ScrollToCaret();
                Application.DoEvents();
            }
        }
    }
}
