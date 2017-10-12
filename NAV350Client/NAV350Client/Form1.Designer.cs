namespace NAV350Client
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_ip = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_connect = new System.Windows.Forms.Button();
            this.txt_port = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_send = new System.Windows.Forms.Button();
            this.btn_standby = new System.Windows.Forms.Button();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_RECVNUM = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnrecord = new System.Windows.Forms.Button();
            this.btnsave = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.txt_AVERAGEDISTANCE = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_MINDISTANCE = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_MAXDISTANCE = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_RELDISC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_AngleNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_measureinterval = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.txt_PROBABILITY = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_DISPERSION = new System.Windows.Forms.TextBox();
            this.txt_VALREF = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ServerIP:";
            // 
            // txt_ip
            // 
            this.txt_ip.Location = new System.Drawing.Point(81, 20);
            this.txt_ip.Name = "txt_ip";
            this.txt_ip.Size = new System.Drawing.Size(100, 21);
            this.txt_ip.TabIndex = 1;
            this.txt_ip.Text = "192.168.2.10";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_connect);
            this.groupBox1.Controls.Add(this.txt_port);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txt_ip);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 330);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(404, 56);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "网络信息";
            // 
            // btn_connect
            // 
            this.btn_connect.Location = new System.Drawing.Point(309, 20);
            this.btn_connect.Name = "btn_connect";
            this.btn_connect.Size = new System.Drawing.Size(75, 23);
            this.btn_connect.TabIndex = 3;
            this.btn_connect.Text = "连接";
            this.btn_connect.UseVisualStyleBackColor = true;
            this.btn_connect.Click += new System.EventHandler(this.btn_connect_Click);
            // 
            // txt_port
            // 
            this.txt_port.Location = new System.Drawing.Point(241, 20);
            this.txt_port.Name = "txt_port";
            this.txt_port.Size = new System.Drawing.Size(53, 21);
            this.txt_port.TabIndex = 3;
            this.txt_port.Text = "2111";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(131, 20);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(88, 23);
            this.btn_send.TabIndex = 3;
            this.btn_send.Text = "LandmarkaAsy";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // btn_standby
            // 
            this.btn_standby.Location = new System.Drawing.Point(18, 20);
            this.btn_standby.Name = "btn_standby";
            this.btn_standby.Size = new System.Drawing.Size(88, 23);
            this.btn_standby.TabIndex = 6;
            this.btn_standby.Text = "Standby";
            this.btn_standby.UseVisualStyleBackColor = true;
            this.btn_standby.Click += new System.EventHandler(this.btn_standby_Click);
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(12, 12);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(404, 298);
            this.zedGraphControl1.TabIndex = 11;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_send);
            this.groupBox2.Controls.Add(this.btn_standby);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.txt_RECVNUM);
            this.groupBox2.Location = new System.Drawing.Point(12, 392);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(404, 58);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模式选择";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(239, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 32;
            this.label16.Text = "接收包数：";
            // 
            // txt_RECVNUM
            // 
            this.txt_RECVNUM.Enabled = false;
            this.txt_RECVNUM.Location = new System.Drawing.Point(315, 23);
            this.txt_RECVNUM.Name = "txt_RECVNUM";
            this.txt_RECVNUM.ReadOnly = true;
            this.txt_RECVNUM.Size = new System.Drawing.Size(75, 21);
            this.txt_RECVNUM.TabIndex = 33;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnrecord);
            this.groupBox3.Controls.Add(this.btnsave);
            this.groupBox3.Controls.Add(this.btndelete);
            this.groupBox3.Controls.Add(this.txt_AVERAGEDISTANCE);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.txt_MINDISTANCE);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txt_MAXDISTANCE);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txt_RELDISC);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.txt_AngleNum);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txt_measureinterval);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(12, 456);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(404, 102);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "测量选项";
            // 
            // btnrecord
            // 
            this.btnrecord.Location = new System.Drawing.Point(309, 73);
            this.btnrecord.Name = "btnrecord";
            this.btnrecord.Size = new System.Drawing.Size(64, 23);
            this.btnrecord.TabIndex = 14;
            this.btnrecord.Text = "记录";
            this.btnrecord.UseVisualStyleBackColor = true;
            this.btnrecord.Click += new System.EventHandler(this.btnrecord_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(31, 73);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(64, 23);
            this.btnsave.TabIndex = 13;
            this.btnsave.Text = "保存";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btndelete
            // 
            this.btndelete.Location = new System.Drawing.Point(170, 73);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(64, 23);
            this.btndelete.TabIndex = 12;
            this.btndelete.Text = "删除";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // txt_AVERAGEDISTANCE
            // 
            this.txt_AVERAGEDISTANCE.Enabled = false;
            this.txt_AVERAGEDISTANCE.Location = new System.Drawing.Point(322, 43);
            this.txt_AVERAGEDISTANCE.Name = "txt_AVERAGEDISTANCE";
            this.txt_AVERAGEDISTANCE.ReadOnly = true;
            this.txt_AVERAGEDISTANCE.Size = new System.Drawing.Size(75, 21);
            this.txt_AVERAGEDISTANCE.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(265, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "平均值：";
            // 
            // txt_MINDISTANCE
            // 
            this.txt_MINDISTANCE.Enabled = false;
            this.txt_MINDISTANCE.Location = new System.Drawing.Point(176, 43);
            this.txt_MINDISTANCE.Name = "txt_MINDISTANCE";
            this.txt_MINDISTANCE.ReadOnly = true;
            this.txt_MINDISTANCE.Size = new System.Drawing.Size(75, 21);
            this.txt_MINDISTANCE.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(129, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 8;
            this.label7.Text = "最小值：";
            // 
            // txt_MAXDISTANCE
            // 
            this.txt_MAXDISTANCE.Enabled = false;
            this.txt_MAXDISTANCE.Location = new System.Drawing.Point(52, 43);
            this.txt_MAXDISTANCE.Name = "txt_MAXDISTANCE";
            this.txt_MAXDISTANCE.ReadOnly = true;
            this.txt_MAXDISTANCE.Size = new System.Drawing.Size(75, 21);
            this.txt_MAXDISTANCE.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 46);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 6;
            this.label8.Text = "最大值：";
            // 
            // txt_RELDISC
            // 
            this.txt_RELDISC.Location = new System.Drawing.Point(322, 16);
            this.txt_RELDISC.Name = "txt_RELDISC";
            this.txt_RELDISC.Size = new System.Drawing.Size(75, 21);
            this.txt_RELDISC.TabIndex = 5;
            this.txt_RELDISC.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "实际距离：";
            // 
            // txt_AngleNum
            // 
            this.txt_AngleNum.Location = new System.Drawing.Point(176, 16);
            this.txt_AngleNum.Name = "txt_AngleNum";
            this.txt_AngleNum.Size = new System.Drawing.Size(75, 21);
            this.txt_AngleNum.TabIndex = 3;
            this.txt_AngleNum.Text = "721";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "测量点：";
            // 
            // txt_measureinterval
            // 
            this.txt_measureinterval.Location = new System.Drawing.Point(52, 16);
            this.txt_measureinterval.Name = "txt_measureinterval";
            this.txt_measureinterval.Size = new System.Drawing.Size(75, 21);
            this.txt_measureinterval.TabIndex = 1;
            this.txt_measureinterval.Text = "100";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "间隔：";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.richTextBox1);
            this.groupBox6.Location = new System.Drawing.Point(433, 4);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(234, 624);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "数据显示";
            // 
            // richTextBox1
            // 
            this.richTextBox1.EnableAutoDragDrop = true;
            this.richTextBox1.HideSelection = false;
            this.richTextBox1.Location = new System.Drawing.Point(16, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(201, 582);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.txt_PROBABILITY);
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.label9);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Controls.Add(this.txt_DISPERSION);
            this.groupBox7.Controls.Add(this.txt_VALREF);
            this.groupBox7.Location = new System.Drawing.Point(11, 558);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(404, 70);
            this.groupBox7.TabIndex = 17;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "离散度概率";
            // 
            // txt_PROBABILITY
            // 
            this.txt_PROBABILITY.Enabled = false;
            this.txt_PROBABILITY.Location = new System.Drawing.Point(322, 27);
            this.txt_PROBABILITY.Name = "txt_PROBABILITY";
            this.txt_PROBABILITY.ReadOnly = true;
            this.txt_PROBABILITY.Size = new System.Drawing.Size(75, 21);
            this.txt_PROBABILITY.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(138, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 17;
            this.label10.Text = "离散度：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(279, 30);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 19;
            this.label9.Text = "概率:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 30);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 12);
            this.label11.TabIndex = 15;
            this.label11.Text = "参考值：";
            // 
            // txt_DISPERSION
            // 
            this.txt_DISPERSION.Location = new System.Drawing.Point(189, 27);
            this.txt_DISPERSION.Name = "txt_DISPERSION";
            this.txt_DISPERSION.Size = new System.Drawing.Size(75, 21);
            this.txt_DISPERSION.TabIndex = 18;
            this.txt_DISPERSION.Text = "15";
            // 
            // txt_VALREF
            // 
            this.txt_VALREF.Enabled = false;
            this.txt_VALREF.Location = new System.Drawing.Point(57, 27);
            this.txt_VALREF.Name = "txt_VALREF";
            this.txt_VALREF.ReadOnly = true;
            this.txt_VALREF.Size = new System.Drawing.Size(75, 21);
            this.txt_VALREF.TabIndex = 16;
            this.txt_VALREF.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 643);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_connect;
        private System.Windows.Forms.TextBox txt_port;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.Button btn_standby;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnrecord;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.TextBox txt_AVERAGEDISTANCE;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_MINDISTANCE;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_MAXDISTANCE;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_RELDISC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_AngleNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_measureinterval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_RECVNUM;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.TextBox txt_PROBABILITY;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_DISPERSION;
        private System.Windows.Forms.TextBox txt_VALREF;
    }
}

