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

namespace TomatoDBClient
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.environmentSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.argosEnvSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipDownloadPS = new System.Windows.Forms.ToolTip(this.components);
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSetKeyValue = new System.Windows.Forms.Button();
            this.btnDeleteKeyValue = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGetKeyValue = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.messageTextBox = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPerfTest1 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.picServerConnction = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.InstallStatusLabel = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listDatabases = new System.Windows.Forms.ListBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServerConnction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1760, 30);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.environmentSettingsToolStripMenuItem,
            this.argosEnvSettingsToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // environmentSettingsToolStripMenuItem
            // 
            this.environmentSettingsToolStripMenuItem.Name = "environmentSettingsToolStripMenuItem";
            this.environmentSettingsToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.environmentSettingsToolStripMenuItem.Text = "&GameHub Settings";
            // 
            // argosEnvSettingsToolStripMenuItem
            // 
            this.argosEnvSettingsToolStripMenuItem.Name = "argosEnvSettingsToolStripMenuItem";
            this.argosEnvSettingsToolStripMenuItem.Size = new System.Drawing.Size(240, 26);
            this.argosEnvSettingsToolStripMenuItem.Text = "Manually Edit Env Vars";
            // 
            // btnConnect
            // 
            this.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConnect.Location = new System.Drawing.Point(417, 27);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(139, 37);
            this.btnConnect.TabIndex = 43;
            this.btnConnect.Text = "Connect";
            this.toolTipDownloadPS.SetToolTip(this.btnConnect, "Connect to the database server.");
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCreate.Location = new System.Drawing.Point(417, 107);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(139, 31);
            this.btnCreate.TabIndex = 44;
            this.btnCreate.Text = "Create";
            this.toolTipDownloadPS.SetToolTip(this.btnCreate, "Create a database");
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSetKeyValue
            // 
            this.btnSetKeyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSetKeyValue.Location = new System.Drawing.Point(417, 163);
            this.btnSetKeyValue.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnSetKeyValue.Name = "btnSetKeyValue";
            this.btnSetKeyValue.Size = new System.Drawing.Size(139, 40);
            this.btnSetKeyValue.TabIndex = 45;
            this.btnSetKeyValue.Text = "Set KeyValue";
            this.toolTipDownloadPS.SetToolTip(this.btnSetKeyValue, "Set Key and Value");
            this.btnSetKeyValue.UseVisualStyleBackColor = true;
            this.btnSetKeyValue.Click += new System.EventHandler(this.btnSetKeyValue_Click);
            // 
            // btnDeleteKeyValue
            // 
            this.btnDeleteKeyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDeleteKeyValue.Location = new System.Drawing.Point(585, 163);
            this.btnDeleteKeyValue.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDeleteKeyValue.Name = "btnDeleteKeyValue";
            this.btnDeleteKeyValue.Size = new System.Drawing.Size(139, 40);
            this.btnDeleteKeyValue.TabIndex = 46;
            this.btnDeleteKeyValue.Text = "Delete KeyValue";
            this.toolTipDownloadPS.SetToolTip(this.btnDeleteKeyValue, "Delete Key and Value.");
            this.btnDeleteKeyValue.UseVisualStyleBackColor = true;
            this.btnDeleteKeyValue.Click += new System.EventHandler(this.btnDeleteKeyValue_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDelete.Location = new System.Drawing.Point(585, 107);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(139, 31);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Text = "Delete";
            this.toolTipDownloadPS.SetToolTip(this.btnDelete, "Delete database.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnGetKeyValue
            // 
            this.btnGetKeyValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGetKeyValue.Location = new System.Drawing.Point(417, 212);
            this.btnGetKeyValue.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnGetKeyValue.Name = "btnGetKeyValue";
            this.btnGetKeyValue.Size = new System.Drawing.Size(139, 40);
            this.btnGetKeyValue.TabIndex = 48;
            this.btnGetKeyValue.Text = "Get KeyValue";
            this.toolTipDownloadPS.SetToolTip(this.btnGetKeyValue, "Get Value of the Key");
            this.btnGetKeyValue.UseVisualStyleBackColor = true;
            this.btnGetKeyValue.Click += new System.EventHandler(this.btnGetKeyValue_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Location = new System.Drawing.Point(765, 24);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(0, 0);
            this.panel2.TabIndex = 10;
            // 
            // messageTextBox
            // 
            this.messageTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.messageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.messageTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.messageTextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.messageTextBox.Location = new System.Drawing.Point(0, 0);
            this.messageTextBox.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(1760, 479);
            this.messageTextBox.TabIndex = 15;
            this.messageTextBox.Text = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox5);
            this.panel1.Controls.Add(this.listDatabases);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1);
            this.panel1.Size = new System.Drawing.Size(1760, 649);
            this.panel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnPerfTest1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Location = new System.Drawing.Point(1004, 299);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(750, 118);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tests";
            // 
            // btnPerfTest1
            // 
            this.btnPerfTest1.Location = new System.Drawing.Point(10, 73);
            this.btnPerfTest1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPerfTest1.Name = "btnPerfTest1";
            this.btnPerfTest1.Size = new System.Drawing.Size(139, 32);
            this.btnPerfTest1.TabIndex = 50;
            this.btnPerfTest1.Text = "Test 1";
            this.btnPerfTest1.UseVisualStyleBackColor = true;
            this.btnPerfTest1.Click += new System.EventHandler(this.btnPerfTest_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(10, 33);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(723, 32);
            this.progressBar1.TabIndex = 35;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.txtServer);
            this.groupBox5.Controls.Add(this.btnGetKeyValue);
            this.groupBox5.Controls.Add(this.btnDelete);
            this.groupBox5.Controls.Add(this.btnDeleteKeyValue);
            this.groupBox5.Controls.Add(this.btnSetKeyValue);
            this.groupBox5.Controls.Add(this.btnCreate);
            this.groupBox5.Controls.Add(this.btnConnect);
            this.groupBox5.Controls.Add(this.picServerConnction);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.InstallStatusLabel);
            this.groupBox5.Controls.Add(this.txtValue);
            this.groupBox5.Controls.Add(this.txtDatabase);
            this.groupBox5.Controls.Add(this.label1);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.txtKey);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox5.Location = new System.Drawing.Point(1004, 8);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.groupBox5.Size = new System.Drawing.Size(750, 284);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Database";
            // 
            // txtServer
            // 
            this.txtServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtServer.Location = new System.Drawing.Point(93, 27);
            this.txtServer.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(250, 23);
            this.txtServer.TabIndex = 49;
            // 
            // picServerConnction
            // 
            this.picServerConnction.BackColor = System.Drawing.SystemColors.Control;
            this.picServerConnction.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.picServerConnction.Location = new System.Drawing.Point(361, 27);
            this.picServerConnction.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.picServerConnction.Name = "picServerConnction";
            this.picServerConnction.Size = new System.Drawing.Size(30, 30);
            this.picServerConnction.TabIndex = 42;
            this.picServerConnction.TabStop = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 31);
            this.label10.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Server";
            // 
            // InstallStatusLabel
            // 
            this.InstallStatusLabel.AutoSize = true;
            this.InstallStatusLabel.Location = new System.Drawing.Point(11, 166);
            this.InstallStatusLabel.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.InstallStatusLabel.Name = "InstallStatusLabel";
            this.InstallStatusLabel.Size = new System.Drawing.Size(33, 18);
            this.InstallStatusLabel.TabIndex = 39;
            this.InstallStatusLabel.Text = "Key";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtValue.Location = new System.Drawing.Point(93, 212);
            this.txtValue.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(250, 23);
            this.txtValue.TabIndex = 21;
            // 
            // txtDatabase
            // 
            this.txtDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDatabase.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDatabase.Location = new System.Drawing.Point(93, 109);
            this.txtDatabase.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(250, 23);
            this.txtDatabase.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(9, 116);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Database";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(528, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "Key";
            // 
            // txtKey
            // 
            this.txtKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtKey.Location = new System.Drawing.Point(93, 163);
            this.txtKey.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(250, 23);
            this.txtKey.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(14, 216);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value";
            // 
            // listDatabases
            // 
            this.listDatabases.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listDatabases.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listDatabases.FormattingEnabled = true;
            this.listDatabases.ItemHeight = 17;
            this.listDatabases.Location = new System.Drawing.Point(6, 8);
            this.listDatabases.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.listDatabases.Name = "listDatabases";
            this.listDatabases.Size = new System.Drawing.Size(986, 412);
            this.listDatabases.TabIndex = 1;
            this.listDatabases.SelectedIndexChanged += new System.EventHandler(this.listDatabases_SelectedIndexChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.messageTextBox);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(1760, 909);
            this.splitContainer1.SplitterDistance = 423;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 12;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1760, 939);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Tomato DB";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picServerConnction)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem environmentSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem argosEnvSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTipDownloadPS;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.PictureBox picServerConnction;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label InstallStatusLabel;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtDatabase;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listDatabases;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RichTextBox messageTextBox;
        private System.Windows.Forms.Button btnSetKeyValue;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnDeleteKeyValue;
        private System.Windows.Forms.Button btnGetKeyValue;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnPerfTest1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}