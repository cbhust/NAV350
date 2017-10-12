using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

using ZedGraph;
using System.Collections;  //arraylist
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Core;

namespace NAV350Client
{
    public partial class Form1 : Form
    {
        #region 参数定义
        //网络参数
        Socket socketSend;
        public string ReceiveData=string.Empty ;
        public  static int ReceiveDataSize=0;
        Thread MyReceiveDataThread;
        //ZedGraph参数
        public System.Timers.Timer timer1;   //定时发送查询扫描结果
        int time =125;
        public GraphPane MyPane;
        public PointPairList list1;
        ArrayList DrawArrayList = new ArrayList();
        ArrayList CalculateArrayList = new ArrayList();
        Thread MyThread;
        //数据包参数
        public int RceivePackage = 0;                  //总接收包数
        public int Package = 0;                        //计算平均值的包数
        public int Package2 = 0;                        //在离散度范围内的包数
        public int Package3 = 0;                        //计算百分比的所有包数
        public int RealValue = 0;                   //实际值
        public int MaxValue = 0;                    //最大值
        public int MinValue = 0;                    //最小值
        public int SumValue = 0;                    //和
        public double AverageValue = 0;                //平均值
        public double Percent = 0;                     //百分比
        public int AngleNum = 0;                       //测量第几个点
        public int MeasureNum = 0;                     //计算平均值的包数，文本框输入
        public int Dispersion = 0;                     //离散度

        struct RecordStruct
        {
            public int m_int32max;
            public int m_int32min;
            public int m_int32ave;
            public int m_int32realdisc;
        };
        ArrayList list = new ArrayList();

        public Excel.Application excel;
        public Excel.Workbooks wbs;
        public Excel.Workbook wb;
        public Excel.Worksheets wss;
        public Excel.Worksheet ws;

        AutoSizeFormClass asc = new AutoSizeFormClass();        //1.声明自适应类实例 
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            asc.controllInitializeSize(this);//2.调用类的初始化方法，记录窗体和其控件的初始位置和大小
            //add描点作图
            MyPane = zedGraphControl1.GraphPane;
            list1 = new PointPairList();
            MyPane.CurveList.Clear();
            //设置图标标题和x、y轴标题
            MyPane.Title.Text = "极坐标";
            //曲线的操作
            zedGraphControl1.IsEnableHZoom = true;
            zedGraphControl1.IsEnableHZoom = true; //横向缩放
            zedGraphControl1.IsEnableVZoom = false;//纵向缩放
            zedGraphControl1.GraphPane.XAxis.Scale.MaxAuto = true;
            zedGraphControl1.GraphPane.YAxis.Scale.MinAuto = true;
            zedGraphControl1.IsShowPointValues = true;              //鼠标悬停事件，出现点坐标值
            zedGraphControl1.PanModifierKeys = Keys.None;           //直接可以用鼠标左键点击来拖拽
            zedGraphControl1.ZoomStepFraction = 0.1;                //滚动鼠标放大缩小
            //填充图表颜色
            LineItem myCurve = MyPane.AddCurve("", list1, Color.Red, SymbolType.None);

            timer1 = new System.Timers.Timer(time);     //更新主界面 ； 
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);//到达时间的时候执行事件； 
            timer1.AutoReset = true;                    //设置是执行一次（false）还是一直执行(true)； 
            timer1.Enabled = false;
        }

        #region 连接
        private void btn_connect_Click(object sender, EventArgs e)
        {
            if (btn_connect.Text == "断开")
            {
                btn_connect.Text = "连接";
                socketSend.Close();
                MyReceiveDataThread.Abort();
                timer1.Enabled = false;
            }

            else
            {
                try
                {
                    //创建负责通信的Socket
                    socketSend = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                    if (txt_ip.Text != "" || txt_port.Text != "")
                    {
                            IPAddress ip = IPAddress.Parse(txt_ip.Text);
                            IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(txt_port.Text));
                            socketSend.Connect(point);
                    }

                    if (socketSend != null)
                    {
                        //MessageBox.Show("连接成功");
                        btn_connect.Text = "断开";
                        //开启一个新的线程不停的接收服务端发来的消息
                        MyReceiveDataThread = new Thread(Recive);
                        MyReceiveDataThread.IsBackground = true;
                        MyReceiveDataThread.Start();

                        MeasureNum = Convert.ToInt32(txt_measureinterval.Text);
                        AngleNum = Convert.ToInt32(txt_AngleNum.Text);
                        Dispersion = Convert.ToInt32(txt_DISPERSION.Text);

                        RceivePackage = 0;
                        Package = 0;
                        Package2 = 0;
                        Package3 = 0;
                        DrawArrayList.Clear();
                        CalculateArrayList.Clear();
                        RealValue = 0;                   //实际值
                        MaxValue = 0;                    //最大值
                        MinValue = 0;                    //最小值
                        SumValue = 0;                    //和
                        AverageValue = 0;                //平均值
                        Percent = 0;                     //百分比

                        txt_MAXDISTANCE.Text = "0";
                        txt_MINDISTANCE.Text = "0";
                        txt_AVERAGEDISTANCE.Text = "0";
                        txt_VALREF.Text = "0";
                        txt_RECVNUM.Text = "0";
                        txt_PROBABILITY.Text = "0";
                        timer1.Enabled = false;
                        //txt_DRAWNUM.Text = "";
                    }
     
                }
                catch(Exception ex)
                {
                    MessageBox.Show("服务器连接失败。。。");
                    return;
                }

            }
        }
        #endregion

        #region 接收函数
        void Recive()
        {
            while (true)
            {
                try
                {
                    ReceiveDataSize = socketSend.Available;//查看接收的字节数
                    byte[] buffer = new byte[ReceiveDataSize];
                    if (ReceiveDataSize > 0)
                    {
                        socketSend.Receive(buffer);//将数据接收到buffer中
                        ReceiveData = Encoding.UTF8.GetString(buffer, 0, ReceiveDataSize);
                        string[] ary1 = ReceiveData.Split(' ');
                        if (ary1[0] == "sAN" && ary1[1]=="mNLMDGetData")
                        {
                            if (ary1.Length <= 1458)
                            {
                                DrawArrayList.AddRange(ary1);
                                CalculateArrayList.AddRange(ary1);
                                RceivePackage++;//统计总共接收的包数
                                Package++;
                                //MethodInvoker MaxMin = new MethodInvoker(MaxMinCalculate);
                                //this.BeginInvoke(MaxMin);
                                MyThread = new Thread(MaxMinCalculate);
                                MyThread.IsBackground = true;
                                MyThread.Start();
                                MethodInvoker UPUI = new MethodInvoker(UpdateUI);
                                this.BeginInvoke(UPUI);
                                MethodInvoker DDraw = new MethodInvoker(Draw);
                                this.BeginInvoke(DDraw);
                                //MethodInvoker mi = new MethodInvoker(ShowReceiveData);
                                //this.BeginInvoke(mi);
                            }


                        }

                    }
                   
                }
                catch { }

            }
        }
        #endregion

        #region 发送函数（landmarkasy）
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (socketSend .Connected ==true)
            {
                string str = "02 73 4D 4E 20 6D 4E 45 56 41 43 68 61 6E 67 65 53 74 61 74 65 20 33 03 ";//切换到状态3 landmark
                byte[] buffer = strToHexByte(str);
                socketSend.Send(buffer);
                timer1.Enabled = true;
            }
            else
            {
                MessageBox.Show("请先连接服务器");
                return;
            }
        }
        #endregion

        #region standby 
        private void btn_standby_Click(object sender, EventArgs e)
        {
            if (socketSend.Connected == true)
            {

                string str1 = "02 73 4D 41 20 6D 4E 45 56 41 43 68 61 6E 67 65 53 74 61 74 65 03  "; //standby模式
                byte[] buffer1 = strToHexByte(str1);
                socketSend.Send(buffer1);
            }
            else
            {
                MessageBox.Show("请先连接服务器");
                return;
            }
        }
        #endregion

        #region 字符串转换为字节数组
        private static byte[] strToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2).Trim(), 16);
            return returnBytes;
        }
        #endregion

        /// <summary>   
        /// 字节数组转16进制字符串   
        /// </summary>   
        /// <param name="bytes"></param>   
        /// <returns></returns>   
        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr = "";
            if (bytes != null)
            {
                for (int i = 0; i < ReceiveDataSize; i++)
                {
                    //returnStr += bytes[i].ToString("X2");
                    returnStr += Convert.ToString(bytes[i], 16) + " ";
                }
            }
            return returnStr;
        }

        #region 显示函数
        public void ShowReceiveData()
        {
            MaxMinCalculate();
            UpdateUI();
            Draw();

        }
        #endregion

        #region 作图函数
        private void Draw()
        {
            //描点 画图
            list1.Clear();
            int j = 0;
            try
            {
                for (int i = 16; i < DrawArrayList.Count - 1; i++)//DrawArrayList .Count-1
                {
                    int x = j++;
                    Int32 y1 = Convert.ToInt32(DrawArrayList[i].ToString(), 16);
                    list1.Add(x, y1); //添加一组数据
                    if (Convert.ToString(DrawArrayList[i]) == "sAN" && Convert.ToString( DrawArrayList[i + 1]) == "mNLMDGetData")
                        break;
                }
                MyPane.AxisChange();
                zedGraphControl1.Refresh();
                //Refresh();// 此处应该用zedGraphControl1.Refresh();否则界面将会变得卡死；
                DrawArrayList.Clear();
            }
            catch
            {
                return;
            }

        }
        #endregion

        #region 定时器定时发送查询扫描数据
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (socketSend.Connected == true)
            {
                string str1 = "02 73 4D 4E 20 6D 4E 4C 4D 44 47 65 74 44 61 74 61 20 31 20 31 03 "; //Get landmark Data asy(异步接收)
                //string str1 = "02 73 4D 4E 20 6D 4E 4C 4D 44 47 65 74 44 61 74 61 20 30 20 31 03 "; //Get landmark Data syn(同步)
                byte[] buffer1 = strToHexByte(str1);
                socketSend.Send(buffer1);
            }
            else
            {
                //MessageBox.Show("请先连接服务器");
                return;
            }
        }
        #endregion

        #region 更新主界面
        private void UpdateUI()
        {
            txt_RECVNUM.Text = RceivePackage.ToString();

            if (Package >= MeasureNum)
            {
                AverageValue = (SumValue / Package3);
                Percent = (float)Package2 / Package3;
                Percent = Percent * 100;

                txt_PROBABILITY.Text = Percent.ToString();
                txt_MAXDISTANCE.Text = MaxValue.ToString();
                txt_MINDISTANCE.Text = MinValue.ToString();
                txt_AVERAGEDISTANCE.Text = AverageValue.ToString();
                txt_VALREF.Text = AverageValue.ToString();

                Package = 0;
                Package3 = 0;
                Package2 = 0;
                SumValue = 0;

            }
        }
        #endregion

        #region 计算最大值最小值
        private void MaxMinCalculate()
        {
            try
            {
                Package3++;
                int n = 0;        //=AngleNum -1;
                if (AngleNum > 0)
                    n = AngleNum - 1;
                else
                    n = 0;
                if (Package3 == 1)
                {
                    MaxValue = Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);
                    MinValue = Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);
                    AverageValue = Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);
                }
                else
                {
                    if (Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16) > MaxValue)
                    {
                        MaxValue = Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);
                    }
                    if (Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16) < MinValue)
                    {
                        MinValue = Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);
                    }
                }
                SumValue += Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16);

                if ((AverageValue - Dispersion) <= Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16))
                {
                    if (Convert.ToInt32(CalculateArrayList[n + 16].ToString(), 16) <= (AverageValue + Dispersion))
                        Package2++;
                }
                CalculateArrayList.Clear();
            }
            catch
            {
                return;
            }

        }
        #endregion

        #region 记录数据
        private void btnrecord_Click(object sender, EventArgs e)
        {
            RealValue = Convert.ToInt32(txt_RELDISC.Text);
            richTextBox1.AppendText("第" + list.Count + "组数据" + "\n" + "最大值" + MaxValue.ToString() + "\n" +
                                    "最小值" + MinValue.ToString() + "\n" + "平均值" + AverageValue.ToString() + "\n"+
                                    "实际值" + RealValue.ToString()+ "\r\n");
            RecordStruct l_sRecordData = new RecordStruct();
            l_sRecordData.m_int32max = (Int32)MaxValue;
            l_sRecordData.m_int32min = (Int32)MinValue;
            l_sRecordData.m_int32ave = (Int32)AverageValue;
            l_sRecordData.m_int32realdisc = (Int32)RealValue;
            list.Add(l_sRecordData);
        }
        #endregion

        #region 删除记录数据
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (list.Count >= 1)
            {
                richTextBox1.Text += "删除第" + (list.Count - 1) + "组数据\n";
                list.RemoveAt(list.Count - 1);
            }
            else
            {
                richTextBox1.Text += "已经是第0组数据\n";
            }
        }
        #endregion

        #region 保存数据
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                btn_connect.Text = "连接";
                socketSend.Close();
                MyReceiveDataThread.Abort();
                timer1.Enabled = false;

                excel = new Excel.Application();
                wbs = excel.Workbooks;
                wb = wbs.Add(true);
                ws = wb.Worksheets.get_Item(1);                     //更改sheet的名称
                ws.Name = "NAV350测试数据";
                excel.Visible = true;                              //使Excel可视。有兴趣的，设置为false看看效果。                     excel.Cells[3,8] = "BEA测试数据";
                excel.Cells[7, 1] = "实际值";
                excel.Cells[7, 2] = "最大值";
                excel.Cells[7, 3] = "最小值";
                excel.Cells[7, 4] = "平均值";
                for (int i = 0; i < list.Count; i++)
                {
                    excel.Cells[i + 8, 1] = ((RecordStruct)list[i]).m_int32realdisc;
                    excel.Cells[i + 8, 2] = ((RecordStruct)list[i]).m_int32max;
                    excel.Cells[i + 8, 3] = ((RecordStruct)list[i]).m_int32min;
                    excel.Cells[i + 8, 4] = ((RecordStruct)list[i]).m_int32ave;
                }
                excel.Cells.EntireColumn.AutoFit();          //列宽自适应大小
                excel.Visible = true;                       //使excel表格可视，否则将不能弹出excel表格
                excel.DisplayAlerts = false;                //保存Excel的时候，不弹出是否保存的窗口直接进行保存
                wb.SaveAs(Environment.CurrentDirectory.ToString() + "\\" + "NAV350测试数据");
            }
            catch
            { 
                return;
            }
            GC.Collect();                           //调用excel后垃圾进行回收，否则，任务管理其中会发现有多个excel进程；
        }
        #endregion

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            asc.controlAutoSize(this);
        }
    }
}
