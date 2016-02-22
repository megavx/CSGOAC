namespace CSGOAC_Server
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Port = new System.Windows.Forms.TextBox();
            this.ServerStopBtn = new System.Windows.Forms.Button();
            this.ServerStartBtn = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.AllowLogViewchk = new System.Windows.Forms.CheckBox();
            this.StopWebBtn = new System.Windows.Forms.Button();
            this.StartWebBtn = new System.Windows.Forms.Button();
            this.SettingGroup = new System.Windows.Forms.GroupBox();
            this.Limitchk = new System.Windows.Forms.CheckBox();
            this.LogAutoSave = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.PlayerListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.LogBox = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIP = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.kickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SettingGroup.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(371, 224);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.SettingGroup);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(363, 198);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "메인";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Port);
            this.groupBox3.Controls.Add(this.ServerStopBtn);
            this.groupBox3.Controls.Add(this.ServerStartBtn);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(357, 54);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "KAC Server";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "PORT";
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(287, 22);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(59, 21);
            this.Port.TabIndex = 6;
            this.Port.Text = "26974";
            this.Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ServerStopBtn
            // 
            this.ServerStopBtn.Enabled = false;
            this.ServerStopBtn.Location = new System.Drawing.Point(132, 20);
            this.ServerStopBtn.Name = "ServerStopBtn";
            this.ServerStopBtn.Size = new System.Drawing.Size(100, 23);
            this.ServerStopBtn.TabIndex = 5;
            this.ServerStopBtn.Text = "서버 중단";
            this.ServerStopBtn.UseVisualStyleBackColor = true;
            this.ServerStopBtn.Click += new System.EventHandler(this.ServerStopBtn_Click);
            // 
            // ServerStartBtn
            // 
            this.ServerStartBtn.Location = new System.Drawing.Point(26, 20);
            this.ServerStartBtn.Name = "ServerStartBtn";
            this.ServerStartBtn.Size = new System.Drawing.Size(100, 23);
            this.ServerStartBtn.TabIndex = 3;
            this.ServerStartBtn.Text = "서버 시작";
            this.ServerStartBtn.UseVisualStyleBackColor = true;
            this.ServerStartBtn.Click += new System.EventHandler(this.ServerStartBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.AllowLogViewchk);
            this.groupBox2.Controls.Add(this.StopWebBtn);
            this.groupBox2.Controls.Add(this.StartWebBtn);
            this.groupBox2.Location = new System.Drawing.Point(3, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 56);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "웹서버 설정";
            // 
            // AllowLogViewchk
            // 
            this.AllowLogViewchk.AutoSize = true;
            this.AllowLogViewchk.Checked = true;
            this.AllowLogViewchk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AllowLogViewchk.Location = new System.Drawing.Point(246, 24);
            this.AllowLogViewchk.Name = "AllowLogViewchk";
            this.AllowLogViewchk.Size = new System.Drawing.Size(100, 16);
            this.AllowLogViewchk.TabIndex = 2;
            this.AllowLogViewchk.Text = "로그보기 허용";
            this.AllowLogViewchk.UseVisualStyleBackColor = true;
            // 
            // StopWebBtn
            // 
            this.StopWebBtn.Enabled = false;
            this.StopWebBtn.Location = new System.Drawing.Point(132, 20);
            this.StopWebBtn.Name = "StopWebBtn";
            this.StopWebBtn.Size = new System.Drawing.Size(100, 23);
            this.StopWebBtn.TabIndex = 1;
            this.StopWebBtn.Text = "웹서버 중단";
            this.StopWebBtn.UseVisualStyleBackColor = true;
            this.StopWebBtn.Click += new System.EventHandler(this.StopWebBtn_Click);
            // 
            // StartWebBtn
            // 
            this.StartWebBtn.Location = new System.Drawing.Point(26, 20);
            this.StartWebBtn.Name = "StartWebBtn";
            this.StartWebBtn.Size = new System.Drawing.Size(100, 23);
            this.StartWebBtn.TabIndex = 0;
            this.StartWebBtn.Text = "웹서버 시작";
            this.StartWebBtn.UseVisualStyleBackColor = true;
            this.StartWebBtn.Click += new System.EventHandler(this.StartWebBtn_Click);
            // 
            // SettingGroup
            // 
            this.SettingGroup.Controls.Add(this.Limitchk);
            this.SettingGroup.Controls.Add(this.LogAutoSave);
            this.SettingGroup.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SettingGroup.Location = new System.Drawing.Point(3, 125);
            this.SettingGroup.Name = "SettingGroup";
            this.SettingGroup.Size = new System.Drawing.Size(357, 70);
            this.SettingGroup.TabIndex = 3;
            this.SettingGroup.TabStop = false;
            this.SettingGroup.Text = "Setting";
            // 
            // Limitchk
            // 
            this.Limitchk.Checked = true;
            this.Limitchk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Limitchk.Location = new System.Drawing.Point(26, 20);
            this.Limitchk.Name = "Limitchk";
            this.Limitchk.Size = new System.Drawing.Size(168, 16);
            this.Limitchk.TabIndex = 0;
            this.Limitchk.Text = "10명접속시 추가 연결 거부";
            this.Limitchk.UseVisualStyleBackColor = true;
            // 
            // LogAutoSave
            // 
            this.LogAutoSave.Checked = true;
            this.LogAutoSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LogAutoSave.Enabled = false;
            this.LogAutoSave.Location = new System.Drawing.Point(26, 42);
            this.LogAutoSave.Name = "LogAutoSave";
            this.LogAutoSave.Size = new System.Drawing.Size(155, 22);
            this.LogAutoSave.TabIndex = 0;
            this.LogAutoSave.Text = "로그 자동저장 [AUTO]\r\n";
            this.LogAutoSave.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.PlayerListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(363, 198);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "서버";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // PlayerListView
            // 
            this.PlayerListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.PlayerListView.ContextMenuStrip = this.contextMenuStrip1;
            this.PlayerListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlayerListView.FullRowSelect = true;
            this.PlayerListView.GridLines = true;
            this.PlayerListView.Location = new System.Drawing.Point(3, 3);
            this.PlayerListView.Name = "PlayerListView";
            this.PlayerListView.Size = new System.Drawing.Size(357, 192);
            this.PlayerListView.TabIndex = 3;
            this.PlayerListView.UseCompatibleStateImageBehavior = false;
            this.PlayerListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "IP Adress";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "SteamID";
            this.columnHeader2.Width = 129;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "LastResponse";
            this.columnHeader3.Width = 105;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.LogBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(363, 198);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "로그";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // LogBox
            // 
            this.LogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LogBox.FormattingEnabled = true;
            this.LogBox.ItemHeight = 12;
            this.LogBox.Location = new System.Drawing.Point(0, 0);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(363, 198);
            this.LogBox.TabIndex = 2;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.ServerIP);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(363, 198);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "기타설정";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(223, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "ex) 127.0.0.1:1234 로 적어야 접속됩니다";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "서버주소";
            // 
            // ServerIP
            // 
            this.ServerIP.Location = new System.Drawing.Point(67, 20);
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.Size = new System.Drawing.Size(259, 21);
            this.ServerIP.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kickToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(97, 26);
            // 
            // kickToolStripMenuItem
            // 
            this.kickToolStripMenuItem.Name = "kickToolStripMenuItem";
            this.kickToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kickToolStripMenuItem.Text = "Kick";
            this.kickToolStripMenuItem.Click += new System.EventHandler(this.kickToolStripMenuItem_Click);
            // 
            // Tray
            // 
            this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
            this.Tray.Text = "notifyIcon1";
            this.Tray.Visible = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 224);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("돋움", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KAC Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.SettingGroup.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button ServerStopBtn;
        private System.Windows.Forms.Button ServerStartBtn;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox AllowLogViewchk;
        private System.Windows.Forms.Button StopWebBtn;
        private System.Windows.Forms.Button StartWebBtn;
        private System.Windows.Forms.GroupBox SettingGroup;
        private System.Windows.Forms.CheckBox Limitchk;
        private System.Windows.Forms.CheckBox LogAutoSave;
        private System.Windows.Forms.ListView PlayerListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kickToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ServerIP;
        private System.Windows.Forms.ListBox LogBox;
    }
}

