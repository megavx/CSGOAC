namespace CSGOAC_Client
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.steamTheme1 = new SteamTheme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ServerIP = new SteamTextBox();
            this.steamButton1 = new SteamButton();
            this.Continue = new SteamButton();
            this.steamMinimize1 = new SteamMinimize();
            this.UID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.steamClose1 = new SteamClose();
            this.steamTheme1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // steamTheme1
            // 
            this.steamTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.steamTheme1.Colors = new Bloom[0];
            this.steamTheme1.Controls.Add(this.panel1);
            this.steamTheme1.Controls.Add(this.label3);
            this.steamTheme1.Controls.Add(this.label2);
            this.steamTheme1.Controls.Add(this.ServerIP);
            this.steamTheme1.Controls.Add(this.steamButton1);
            this.steamTheme1.Controls.Add(this.Continue);
            this.steamTheme1.Controls.Add(this.steamMinimize1);
            this.steamTheme1.Controls.Add(this.UID);
            this.steamTheme1.Controls.Add(this.label1);
            this.steamTheme1.Controls.Add(this.steamClose1);
            this.steamTheme1.Customization = "";
            this.steamTheme1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.steamTheme1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.steamTheme1.Image = null;
            this.steamTheme1.Location = new System.Drawing.Point(0, 0);
            this.steamTheme1.Movable = true;
            this.steamTheme1.Name = "steamTheme1";
            this.steamTheme1.NoRounding = false;
            this.steamTheme1.Sizable = true;
            this.steamTheme1.Size = new System.Drawing.Size(345, 180);
            this.steamTheme1.SmartBounds = true;
            this.steamTheme1.TabIndex = 0;
            this.steamTheme1.Text = "KAC For CSGO";
            this.steamTheme1.TransparencyKey = System.Drawing.Color.Empty;
            this.steamTheme1.Transparent = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(9, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(333, 106);
            this.panel1.TabIndex = 11;
            this.panel1.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(70, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "You Are Connected To Server";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(6, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(312, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "글옵이외의 타프로그램실행시 영구차단조치될수있음\r\n";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(312, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "글옵이외의 타프로그램실행시 영구차단조치될수있음\r\n";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(38, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Server IP";
            // 
            // ServerIP
            // 
            this.ServerIP.BackColor = System.Drawing.Color.Transparent;
            this.ServerIP.Colors = new Bloom[0];
            this.ServerIP.Customization = "";
            this.ServerIP.Font = new System.Drawing.Font("Verdana", 8F);
            this.ServerIP.Image = null;
            this.ServerIP.Location = new System.Drawing.Point(95, 30);
            this.ServerIP.MaxCharacters = 0;
            this.ServerIP.Name = "ServerIP";
            this.ServerIP.NoRounding = false;
            this.ServerIP.Size = new System.Drawing.Size(215, 22);
            this.ServerIP.TabIndex = 8;
            this.ServerIP.Text = "127.0.0.1";
            this.ServerIP.Transparent = true;
            this.ServerIP.UsePasswordMask = false;
            // 
            // steamButton1
            // 
            this.steamButton1.Activated = SteamButton._Options._true;
            this.steamButton1.Colors = new Bloom[0];
            this.steamButton1.Customization = "";
            this.steamButton1.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.steamButton1.Image = null;
            this.steamButton1.Location = new System.Drawing.Point(197, 113);
            this.steamButton1.Name = "steamButton1";
            this.steamButton1.NoRounding = false;
            this.steamButton1.Size = new System.Drawing.Size(113, 23);
            this.steamButton1.TabIndex = 7;
            this.steamButton1.Text = "홈페이지";
            this.steamButton1.Transparent = false;
            this.steamButton1.Click += new System.EventHandler(this.steamButton1_Click);
            // 
            // Continue
            // 
            this.Continue.Activated = SteamButton._Options._true;
            this.Continue.Colors = new Bloom[0];
            this.Continue.Customization = "";
            this.Continue.Enabled = false;
            this.Continue.Font = new System.Drawing.Font("Verdana", 7.25F);
            this.Continue.Image = null;
            this.Continue.Location = new System.Drawing.Point(41, 113);
            this.Continue.Name = "Continue";
            this.Continue.NoRounding = false;
            this.Continue.Size = new System.Drawing.Size(113, 23);
            this.Continue.TabIndex = 4;
            this.Continue.Text = "서버 접속";
            this.Continue.Transparent = false;
            this.Continue.Click += new System.EventHandler(this.Continue_Click);
            // 
            // steamMinimize1
            // 
            this.steamMinimize1.BackColor = System.Drawing.Color.Transparent;
            this.steamMinimize1.Location = new System.Drawing.Point(297, 3);
            this.steamMinimize1.Name = "steamMinimize1";
            this.steamMinimize1.Size = new System.Drawing.Size(12, 12);
            this.steamMinimize1.TabIndex = 1;
            this.steamMinimize1.Text = "steamMinimize1";
            // 
            // UID
            // 
            this.UID.AutoSize = true;
            this.UID.BackColor = System.Drawing.Color.Transparent;
            this.UID.ForeColor = System.Drawing.Color.White;
            this.UID.Location = new System.Drawing.Point(92, 66);
            this.UID.Name = "UID";
            this.UID.Size = new System.Drawing.Size(26, 13);
            this.UID.TabIndex = 6;
            this.UID.Text = "UID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(128, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "KAC For CSGO";
            // 
            // steamClose1
            // 
            this.steamClose1.BackColor = System.Drawing.Color.Transparent;
            this.steamClose1.Location = new System.Drawing.Point(315, 3);
            this.steamClose1.Name = "steamClose1";
            this.steamClose1.Size = new System.Drawing.Size(12, 12);
            this.steamClose1.TabIndex = 0;
            this.steamClose1.Text = "steamClose1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 180);
            this.Controls.Add(this.steamTheme1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KAC CSGO";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.steamTheme1.ResumeLayout(false);
            this.steamTheme1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SteamTheme steamTheme1;
        private SteamMinimize steamMinimize1;
        private SteamClose steamClose1;
        private SteamButton steamButton1;
        private SteamButton Continue;
        private System.Windows.Forms.Label UID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private SteamTextBox ServerIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
    }
}

