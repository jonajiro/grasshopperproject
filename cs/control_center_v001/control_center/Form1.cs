using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO.Ports;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Kitware.VTK;



namespace control_center
{
    public partial class Form1 : Form
    {
        delegate void timer1Delegate();

        

        
        //Serial
        /****************************************************************************/
        /*!
		 *	@brief	ボーレート格納用のクラス定義.
		 */
        private class BuadRateItem : Object
        {
            private string m_name = "";
            private int m_value = 0;

            // 表示名称
            public string NAME
            {
                set { m_name = value; }
                get { return m_name; }
            }

            // ボーレート設定値.
            public int BAUDRATE
            {
                set { m_value = value; }
                get { return m_value; }
            }

            // コンボボックス表示用の文字列取得関数.
            public override string ToString()
            {
                return m_name;
            }
        }

        /****************************************************************************/
        /*!
		 *	@brief	制御プロトコル格納用のクラス定義.
		 */
        private class HandShakeItem : Object
        {
            private string m_name = "";
            private Handshake m_value = Handshake.None;

            // 表示名称
            public string NAME
            {
                set { m_name = value; }
                get { return m_name; }
            }

            // 制御プロトコル設定値.
            public Handshake HANDSHAKE
            {
                set { m_value = value; }
                get { return m_value; }
            }

            // コンボボックス表示用の文字列取得関数.
            public override string ToString()
            {
                return m_name;
            }
        }

        private delegate void Delegate_RcvDataToTextBox(string data);

        public Form1()
        {
            InitializeComponent();

            START_BUTTON.Enabled = false; //無効にする
            STOP_BUTTON.Enabled = false; //無効にする
            //! 利用可能なシリアルポート名の配列を取得する.
            string[] PortList = SerialPort.GetPortNames();

            COMPORT_BOX.Items.Clear();

            //! シリアルポート名をコンボボックスにセットする.
            foreach (string PortName in PortList)
            {
                COMPORT_BOX.Items.Add(PortName);
            }
            if (COMPORT_BOX.Items.Count > 0)
            {
                COMPORT_BOX.SelectedIndex = 0;
            }

            BAUDRATE_BOX.Items.Clear();

            // ボーレート選択コンボボックスに選択項目をセットする.
            BuadRateItem baud;
            baud = new BuadRateItem();
            baud.NAME = "4800bps";
            baud.BAUDRATE = 4800;
            BAUDRATE_BOX.Items.Add(baud);

            baud = new BuadRateItem();
            baud.NAME = "9600bps";
            baud.BAUDRATE = 9600;
            BAUDRATE_BOX.Items.Add(baud);

            baud = new BuadRateItem();
            baud.NAME = "19200bps";
            baud.BAUDRATE = 19200;
            BAUDRATE_BOX.Items.Add(baud);

            baud = new BuadRateItem();
            baud.NAME = "115200bps";
            baud.BAUDRATE = 115200;
            BAUDRATE_BOX.Items.Add(baud);
            BAUDRATE_BOX.SelectedIndex = 1;

            CON_BOX.Items.Clear();

            // フロー制御選択コンボボックスに選択項目をセットする.
            HandShakeItem ctrl;
            ctrl = new HandShakeItem();
            ctrl.NAME = "なし";
            ctrl.HANDSHAKE = Handshake.None;
            CON_BOX.Items.Add(ctrl);

            ctrl = new HandShakeItem();
            ctrl.NAME = "XON/XOFF制御";
            ctrl.HANDSHAKE = Handshake.XOnXOff;
            CON_BOX.Items.Add(ctrl);

            ctrl = new HandShakeItem();
            ctrl.NAME = "RTS/CTS制御";
            ctrl.HANDSHAKE = Handshake.RequestToSend;
            CON_BOX.Items.Add(ctrl);

            ctrl = new HandShakeItem();
            ctrl.NAME = "XON/XOFF + RTS/CTS制御";
            ctrl.HANDSHAKE = Handshake.RequestToSendXOnXOff;
            CON_BOX.Items.Add(ctrl);
            CON_BOX.SelectedIndex = 0;

            // 送受信用のテキストボックスをクリアする.
            SEND_DATA_TEXTBOX.Clear();
            RECEVED_DATA_TEXTBOX.Clear();


        }

        private void Form1_Load(object sender, EventArgs e)
        {

            

        }

        /****************************************************************************/
        /*!
		 *	@brief	ダイアログの終了処理.
		 *
		 *	@param	[in]	sender	イベントの送信元のオブジェクト.
		 *	@param	[in]	e		イベント情報.
		 *
		 *	@retval	なし.
		 */
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            timer4.Enabled = false;
            //! シリアルポートをオープンしている場合、クローズする.
            if (GETDATA1_SERIALPORT.IsOpen)
            {
                GETDATA1_SERIALPORT.Close();
            }
        }

        /****************************************************************************/
        /*!
		 *	@brief	[接続]/[切断]ボタンを押したときにシリアルポートのオープン/クローズを行う.
		 *
		 *	@param	[in]	sender	イベントの送信元のオブジェクト.
		 *	@param	[in]	e		イベント情報.
		 *
		 *	@retval	なし.
		 */
        private void COMPORT_SET_BUTTON_Click(object sender, EventArgs e)
        {

            if (GETDATA1_SERIALPORT.IsOpen == true)
            {
                //! シリアルポートをクローズする.
                GETDATA1_SERIALPORT.Close();

                //! ボタンの表示を[切断]から[接続]に変える.
                COMPORT_SET_BUTTON.Text = "CONNECT";
                START_BUTTON.Enabled = true; //有効にする
            }
            else
            {
                //! オープンするシリアルポートをコンボボックスから取り出す.
                GETDATA1_SERIALPORT.PortName = COMPORT_BOX.SelectedItem.ToString();

                //! ボーレートをコンボボックスから取り出す.
                BuadRateItem baud = (BuadRateItem)BAUDRATE_BOX.SelectedItem;
                GETDATA1_SERIALPORT.BaudRate = baud.BAUDRATE;

                //! データビットをセットする. (データビット = 8ビット)
                GETDATA1_SERIALPORT.DataBits = 8;

                //! パリティビットをセットする. (パリティビット = なし)
                GETDATA1_SERIALPORT.Parity = Parity.None;

                //! ストップビットをセットする. (ストップビット = 1ビット)
                GETDATA1_SERIALPORT.StopBits = StopBits.One;

                //! フロー制御をコンボボックスから取り出す.
                HandShakeItem ctrl = (HandShakeItem)CON_BOX.SelectedItem;
                GETDATA1_SERIALPORT.Handshake = ctrl.HANDSHAKE;

                //! 文字コードをセットする.
                GETDATA1_SERIALPORT.Encoding = Encoding.ASCII;

                GETDATA1_SERIALPORT.DtrEnable = true;
                GETDATA1_SERIALPORT.RtsEnable = true;

                try
                {
                    //! シリアルポートをオープンする.
                    GETDATA1_SERIALPORT.Open();

                    //! ボタンの表示を[接続]から[切断]に変える.
                    COMPORT_SET_BUTTON.Text = "DISCONNECT";
                    START_BUTTON.Enabled = true; //有効にする
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        /****************************************************************************/
        /*!
		 *	@brief	データ受信が発生したときのイベント処理.
		 *
		 *	@param	[in]	sender	イベントの送信元のオブジェクト.
		 *	@param	[in]	e		イベント情報.
		 *
		 *	@retval	なし.
		 */
        const int read_data_size = 25 - 4;
        const int get_data_size_init = 9;
        float[] get_data = new float[get_data_size_init];
        double mpu_t = 0.0;
        int statusmpu = 0;
        int cnt_r = 0;
        byte[] buffer_data = new byte[4096];
        int buffer_data_size = 0;

        private void GETDATA1_SERIALPORT_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //! シリアルポートをオープンしていない場合、処理を行わない.
            if (GETDATA1_SERIALPORT.IsOpen == false)
            {

                return;
            }

            try
            {

                int get_data_size = GETDATA1_SERIALPORT.BytesToRead;
                byte[] rdat = new byte[get_data_size];
                GETDATA1_SERIALPORT.Read(rdat, 0, rdat.Length);

                byte[] mergedArray = new byte[rdat.Length + buffer_data_size];

                Array.Copy(buffer_data, mergedArray, buffer_data_size);

                Array.Copy(rdat, 0, mergedArray, buffer_data_size, rdat.Length);

                buffer_data_size = mergedArray.Length;

                Array.Copy(mergedArray, buffer_data, buffer_data_size);

                if (buffer_data_size >= read_data_size + 4)
                {                //! 受信データを読み込む.
                    int flag0 = 999;
                    int flag1 = 999;
                    int flag2 = 999;
                    int flag3 = 999;
                    byte[] idata = new byte[4096];
                    byte[] idata2 = new byte[4096];
                    Array.Copy(buffer_data, idata, buffer_data_size);
                    Array.Clear(buffer_data, 0, buffer_data_size);
                    //buffer_data_size = 0;
                    int i = 0;
                    for (i = 0; i < 4096 ; i++) {
                        if (idata[i] == 0xa5 && flag0 == 999)
                        {
                            flag0 = i;
                        }
                        if (idata[i] == 0x5a && flag0 + 1 == i)
                        {
                            flag1 = i;
                        }
                        if (idata[i] == 0x0d && flag1 + 1 + read_data_size == i)
                        {
                            flag2 = i;
                        }
                        if (idata[i] == 0x0a && flag2 + 1 == i)
                        {
                            flag3 = i;
                            buffer_data_size = buffer_data_size - (flag3 + 1);
                            Array.Copy(idata, flag3 + 1, buffer_data, 0, buffer_data_size);

                            break;
                        }
                    }
                    if (flag1 == 999 || flag3 == 999)
                    {
                        //skip_this_data
                    }
                    else
                    {
                        Array.Copy(idata, flag1 + 1, idata2, 0, flag2 - 1);
                        ushort ushTmp;
                        string data = "";

                        //statusmpu
                        statusmpu = (int)idata2[0];

                        //mpu_t
                        ushTmp = (ushort)(((idata2[1] << 8) & 0xff00) | (ushort)(idata2[2] & 0x00ff));
                        mpu_t = (double)(ushTmp / 65535.0 * 600.0);

                        //acc_data
                        ushTmp = (ushort)(((idata2[3] << 8) & 0xff00) | (idata2[4] & 0x00ff));
                        get_data[0] = ((float)ushTmp / 65535.0F * 32F - 16F);
                        ushTmp = (ushort)(((idata2[5] << 8) & 0xff00) | (idata2[6] & 0x00ff));
                        get_data[1] = ((float)ushTmp / 65535.0F * 32F - 16F);
                        ushTmp = (ushort)(((idata2[7] << 8) & 0xff00) | (idata2[8] & 0x00ff));
                        get_data[2] = ((float)ushTmp / 65535.0F * 32F - 16F);

                        //gyro_data
                        ushTmp = (ushort)(((idata2[9] << 8) & 0xff00) | (idata2[10] & 0x00ff));
                        get_data[3] = ((float)ushTmp / 65535.0F * 6 * (float)Math.PI - 3 * (float)Math.PI);
                        ushTmp = (ushort)(((idata2[11] << 8) & 0xff00) | (idata2[12] & 0x00ff));
                        get_data[4] = ((float)ushTmp / 65535.0F * 6 * (float)Math.PI - 3 * (float)Math.PI);
                        ushTmp = (ushort)(((idata2[13] << 8) & 0xff00) | (idata2[14] & 0x00ff));
                        get_data[5] = ((float)ushTmp / 65535.0F * 6 * (float)Math.PI - 3 * (float)Math.PI);

                        //euler_data
                        ushTmp = (ushort)(((idata2[15] << 8) & 0xff00) | (idata2[16] & 0x00ff));
                        get_data[6] = ((float)ushTmp / 65535.0F * 2 * (float)Math.PI - (float)Math.PI);
                        ushTmp = (ushort)(((idata2[17] << 8) & 0xff00) | (idata2[18] & 0x00ff));
                        get_data[7] = ((float)ushTmp / 65535.0F * 2 * (float)Math.PI - (float)Math.PI);
                        ushTmp = (ushort)(((idata2[19] << 8) & 0xff00) | (idata2[20] & 0x00ff));
                        get_data[8] = ((float)ushTmp / 65535.0F * 2 * (float)Math.PI - (float)Math.PI);

                        data = mpu_t.ToString() + "\r\n";
                        State[0] = statusmpu;
                        State[1] = mpu_t;
                        for (i = 2; i < get_data_size_init+2; i++) State[i] = get_data[i - 2];
                        //! 受信したデータをテキストボックスに書き込む.
                        Invoke(new Delegate_RcvDataToTextBox(RcvDataToTextBox), new Object[] { data });
                        //data_save();

                        //send_outputdata();
                    }
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /****************************************************************************/
        /*!
		 *	@brief	受信データをテキストボックスに書き込む.
		 *
		 *	@param	[in]	data	受信した文字列.
		 *
		 *	@retval	なし.
		 */
        private void RcvDataToTextBox(string data)
        {
            //! 受信データをテキストボックスの最後に追記する.
            if (data != null)
            {
                RECEVED_DATA_TEXTBOX.AppendText(data);
            }
        }
        /****************************************************************************/
        /*!
		 *	@brief	[送信]ボタンを押して、データ送信を行う.
		 *
		 *	@param	[in]	sender	イベントの送信元のオブジェクト.
		 *	@param	[in]	e		イベント情報.
		 *
		 *	@retval	なし.
		 */
        private void SEND_DATA_LABEL_Click(object sender, EventArgs e)
        {
            //! シリアルポートをオープンしていない場合、処理を行わない.
            if (GETDATA1_SERIALPORT.IsOpen == false)
            {
                return;
            }
            //! テキストボックスから、送信するテキストを取り出す.
            String data = SEND_DATA_TEXTBOX.Text;

            //! 送信するテキストがない場合、データ送信は行わない.
            if (string.IsNullOrEmpty(data) == true)
            {
                return;
            }

            try
            {
                //! シリアルポートからテキストを送信する.
                GETDATA1_SERIALPORT.Write(data);

                //! 送信データを入力するテキストボックスをクリアする.
                SEND_DATA_TEXTBOX.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Sim//***************************************************************************************

        public int timer_cnt1 = 0;//制御測更新周期カウンタ
        public int timer_cnt2 = 0;//データ保存更新周期カウンタ
        public int timer_cnt3 = 0;//データ表示更新周期カウンタ
        public int timer_cnt4 = 0;//データ送信周期カウンタ
        public double dt = 0.001;//計算刻み幅
        public double time = 0;//計算時間
        public double[] State = new double[get_data_size_init+2];//二種マイコンステータス・時間計2データ追加

        /*
            State[0] = statusmpu;
            State[1] = mpu_t;
            State[2] = acc_data[0];
            State[3] = acc_data[1];
            State[4] = acc_data[2];
            State[5] = gyro_data[0];
            State[6] = gyro_data[1];
            State[7] = gyro_data[2];
            State[8] = euler_data[0];
            State[9] = euler_data[1];
            State[10] = euler_data[2];
        */

        double RTD = 57.295779513082320876798154814105;
        double DTR = 0.01745329251994329576923690768489;

        string[] save_data = new string[10];

        System.Text.StringBuilder save_data_sb = new System.Text.StringBuilder();//一度に追加
  
        
        private void Sim_Initialize()
        {
            Initialize_text();
            Initialize_phase();
            Initialize_state();
            Initialize_graph();
            set_gate_param();
            //send_outputdata();
        }

        private void Initialize_text()
        {
            for (int i = 0; i < 9; i++) save_data[i] = "";

            save_data[0] = "PCTime,statusmpu,time_mpu,acc x,acc y,acc z,gyro x,gyro y,gyro z,euler x,euler y,euler z\r\n";
            for (int i = 0; i < 100; i++) textbox_val[i] = 0.0f;

            
        }

        private void Initialize_phase()
        {
            time = 0.0;
            timer_cnt1 = 0;
            timer_cnt2 = 0;
            timer_cnt3 = 0;
            timer_cnt4 = 0;
        }

        private void Initialize_state()
        {
            for (int i = 0; i < State.Length; i++) State[i] = 0;
            for (int i = 0; i < limb_angle.Length; i++) limb_angle[i] = 0.0;
            double track = trackBar_limb1.Value / 180.0 * 180.0;
            limb_angle[0] = track * DTR;
            label_limb1.Text = string.Format("Limb1:{0:0.0}deg", track);

            track = trackBar_limb2.Value / 180.0 * 180.0;
            limb_angle[1] = track * DTR;
            label_limb2.Text = string.Format("Limb2:{0:0.0}deg", track);

            track = trackBar_limb3.Value / 180.0 * 180.0;
            limb_angle[2] = track * DTR;
            label_limb3.Text = string.Format("Limb3:{0:0.0}deg", track);

            track = trackBar_limb5.Value / 180.0 * 180.0;
            limb_angle[4] = track * DTR;
            label_limb5.Text = string.Format("Limb5:{0:0.0}deg", track);

            track = trackBar_limb6.Value / 180.0 * 180.0;
            limb_angle[5] = track * DTR;
            label_limb6.Text = string.Format("Limb6:{0:0.0}deg", track);

            track = trackBar_limb7.Value / 180.0 * 180.0;
            limb_angle[6] = track * DTR;
            label_limb7.Text = string.Format("Limb7:{0:0.0}deg", track);

            track = trackBar_limb9.Value / 180.0 * 180.0;
            limb_angle[8] = track * DTR;
            label_limb9.Text = string.Format("Limb9:{0:0.0}deg", track);

            track = trackBar_limb10.Value / 180.0 * 180.0;
            limb_angle[9] = track * DTR;
            label_limb10.Text = string.Format("Limb10:{0:0.0}deg", track);

            track = trackBar_limb11.Value / 180.0 * 180.0;
            limb_angle[10] = track * DTR;
            label_limb11.Text = string.Format("Limb11:{0:0.0}deg", track);

            track = trackBar_limb13.Value / 180.0 * 180.0;
            limb_angle[12] = track * DTR;
            label_limb13.Text = string.Format("Limb13:{0:0.0}deg", track);

            track = trackBar_limb14.Value / 180.0 * 180.0;
            limb_angle[13] = track * DTR;
            label_limb14.Text = string.Format("Limb14:{0:0.0}deg", track);

            track = trackBar_limb15.Value / 180.0 * 180.0;
            limb_angle[14] = track * DTR;
            label_limb15.Text = string.Format("Limb15:{0:0.0}deg", track);

            double trackpos = (trackBar_limbpos1.Value - 50.0) / 50.0;
            limb_pos[0,0] = trackpos * 0.05;
            label_limbpos1.Text = string.Format("Leg1_X:{0:0.000}m", limb_pos[0, 0]);

            trackpos = (trackBar_limbpos2.Value - 50.0) / 50.0;
            limb_pos[0,1] = trackpos * 0.05;
            label_limbpos2.Text = string.Format("Leg1_Y:{0:0.000}m", limb_pos[0, 1]);

            trackpos = (trackBar_limbpos3.Value - 50.0) / 50.0;
            limb_pos[0,2] = trackpos * 0.05;
            label_limbpos3.Text = string.Format("Leg1_Z:{0:0.000}m", limb_pos[0, 2]);


            trackpos = (trackBar_limbpos5.Value - 50.0) / 50.0;
            limb_pos[1, 0] = trackpos * 0.05;
            label_limbpos5.Text = string.Format("Leg2_X:{0:0.000}m", limb_pos[1, 0]);

            trackpos = (trackBar_limbpos6.Value - 50.0) / 50.0;
            limb_pos[1, 1] = trackpos * 0.05;
            label_limbpos6.Text = string.Format("Leg2_Y:{0:0.000}m", limb_pos[1, 1]);

            trackpos = (trackBar_limbpos7.Value - 50.0) / 50.0;
            limb_pos[1, 2] = trackpos * 0.05;
            label_limbpos7.Text = string.Format("Leg2_Z:{0:0.000}m", limb_pos[1, 2]);


            trackpos = (trackBar_limbpos9.Value - 50.0) / 50.0;
            limb_pos[2, 0] = trackpos * 0.05;
            label_limbpos9.Text = string.Format("Leg3_X:{0:0.000}m", limb_pos[2, 0]);

            trackpos = (trackBar_limbpos10.Value - 50.0) / 50.0;
            limb_pos[2, 1] = trackpos * 0.05;
            label_limbpos10.Text = string.Format("Leg3_Y:{0:0.000}m", limb_pos[2, 1]);

            trackpos = (trackBar_limbpos11.Value - 50.0) / 50.0;
            limb_pos[2, 2] = trackpos * 0.05;
            label_limbpos11.Text = string.Format("Leg3_Z:{0:0.000}m", limb_pos[2, 2]);


            trackpos = (trackBar_limbpos13.Value - 50.0) / 50.0;
            limb_pos[3, 0] = trackpos * 0.05;
            label_limbpos13.Text = string.Format("Leg4_X:{0:0.000}m", limb_pos[3, 0]);

            trackpos = (trackBar_limbpos14.Value - 50.0) / 50.0;
            limb_pos[3, 1] = trackpos * 0.05;
            label_limbpos14.Text = string.Format("Leg4_Y:{0:0.000}m", limb_pos[3, 1]);

            trackpos = (trackBar_limbpos15.Value - 50.0) / 50.0;
            limb_pos[3, 2] = trackpos * 0.05;
            label_limbpos15.Text = string.Format("Leg4_Z:{0:0.000}m", limb_pos[3, 2]);

            dt = 0.001;
        }



        private void Initialize_graph()
        {
 
        }

        private double[] gate_cycle(double t,double phi,double[] tp, double[] _dir_legvel_raise, double[] _dir_legvel_return, double[] _dir_legvel_down, double[] _dir_legvel_drive)//
        {
            //tp[0] = TP.T
            //tp[1] = TP.T_dr1
            //tp[2] = TP.T_dr2
            //tp[3] = TP.T_dd

            //mp[0,:] = MP.dir_legvel_raise
            //mp[1,:] = MP.dir_legvel_return
            //mp[2,:] = MP.dir_legvel_down
            //mp[3,:] = MP.dir_legvel_drive

            double wait_time = 0.0;
            double t_err = (tp[0] + wait_time * 4) * phi;
            t = t + (tp[0] - t_err);
            double t_c = t%(tp[0] + wait_time * 4);
            double[] _vel_direction = new double[3];
            int flag = 0;
            if (t_c <= (tp[1] * 0.5))
            {//脚上昇期
                _vel_direction = _dir_legvel_raise;
                flag = 0;
            }
            else if (t_c <= (tp[1] * 0.5 + tp[2]))
            {//脚復帰期
                _vel_direction = _dir_legvel_return;
                flag = 0;
            }
            else if (t_c <= (tp[1] * 0.5 + tp[2] + tp[1] * 0.5))
            {//脚下降期
                _vel_direction = _dir_legvel_down;
                flag = 0;
            }
            else if (t_c <= (tp[1] * 0.5 + tp[2] + tp[1] * 0.5 + tp[3]))
            {// 脚推進期
                _vel_direction = _dir_legvel_drive;
                flag = 1;
            }
            return _vel_direction;
        }

        private double[] get_tra_of_end(double[] dir_vel ,double[] Current_POS_e) {

            double[] tra_e = new double[3];
            tra_e[0] = dir_vel[0] * cycle_dt + Current_POS_e[0];
            tra_e[1] = dir_vel[1] * cycle_dt + Current_POS_e[1];
            tra_e[2] = dir_vel[2] * cycle_dt + Current_POS_e[2];
            return tra_e;
        }

        private int cycle_state = 0;//歩容の動作ステータス
                                    //0:cycle modeではない
                                    //1:cycle modes指示あり、初期化未完了
                                    //2:cycle modes指示あり、初期化完了

        private double cycle_time = 0.0;
        private double cycle_dt = 0.02;

        private double[,] init_limb_pos = new double[4, 3];
        private double st_cycle;//基準周期[s]
        private double duty_cycle;//duty比[0.75~0.99]
        private double t_d;//復帰時間[s]
        private double t_dr1;//脚上昇下降合計時間[s]
        private double t_dr2;//脚復帰時間[s]
        private double t_dd;//推進時間[s]
        private double t_ddd;//4脚推進時間[s]

        private double[] tp = new double[4];

        private double r_asta;//脚水平方向スライド距離[m]
        private double h_asta;//脚垂直方向スライド距離[m]
        private double d_r;

        private double vel_body;//胴体進行速度[m/s]
        private double vel_leg_drive;//脚推進速度[m/s]
        private double vel_leg_raise;//脚上昇速度[m/s]
        private double vel_leg_return;//脚復帰速度[m/s]

        private double vel_alpha;//[rad]胴体推進方向
        private double[] dir_bodyxy = new double[3];
        private double[] dir_bodyz = new double[3];
        private double[] dir_legvel_drive = new double[3];
        private double[] dir_legvel_return = new double[3];
        private double[] dir_legvel_raise = new double[3];
        private double[] dir_legvel_down = new double[3];

        private double[] center_limb_pos = new double[3];
        private double[] min_limb_pos = new double[3];
        private double[] max_limb_pos = new double[3];

        private void set_gate_param()
        {
            st_cycle = 1.0;//基準周期[s]
            duty_cycle = 0.5;//duty比[0.75~0.99]
            t_d =(1.0 - duty_cycle) * st_cycle;//復帰時間[s]
            t_dr1 = 0.5 * t_d;//脚上昇下降合計時間[s]
            t_dr2 = t_d - t_dr1;//脚復帰時間[s]
            t_dd = duty_cycle * st_cycle;//推進時間[s]
            t_ddd = (2.0 * duty_cycle - 3.0 / 2.0) * st_cycle;//4脚推進時間[s]

            //tp[0] = TP.T
            //tp[1] = TP.T_dr1
            //tp[2] = TP.T_dr2
            //tp[3] = TP.T_dd
            tp[0] = st_cycle;
            tp[1] = t_dr1;
            tp[2] = t_dr2;
            tp[3] = t_dd;

            r_asta = 0.015;//脚水平方向スライド距離[m]
            h_asta = 0.01;//脚垂直方向スライド距離[m]
            d_r = (t_dr1 * r_asta) / (t_dr1 + t_dd);

            vel_body = (r_asta - d_r) * 2.0 / t_dd;//胴体進行速度[m/s]
            vel_leg_drive = vel_body;//脚推進速度[m/s]
            vel_leg_raise = h_asta * 2.0 / t_dr1;//脚上昇速度[m/s]
            vel_leg_return = r_asta * 2.0 / t_dr2;//脚復帰速度[m/s]

            vel_alpha = 0.0 * Math.PI / 180.0;//[rad]胴体推進方向
            dir_bodyxy[0] = Math.Cos(vel_alpha);
            dir_bodyxy[1] = Math.Sin(vel_alpha);
            dir_bodyxy[2] = 0.0;
            dir_bodyz[0] = 0.0;
            dir_bodyz[1] = 0.0;
            dir_bodyz[2] = 1.0;
            dir_legvel_drive[0] = -dir_bodyxy[0] * vel_leg_drive;
            dir_legvel_drive[1] = -dir_bodyxy[1] * vel_leg_drive;
            dir_legvel_drive[2] = -dir_bodyxy[2] * vel_leg_drive;
            dir_legvel_return[0] = dir_bodyxy[0] * vel_leg_return;
            dir_legvel_return[1] = dir_bodyxy[1] * vel_leg_return;
            dir_legvel_return[2] = dir_bodyxy[2] * vel_leg_return;
            dir_legvel_raise[0] = -dir_bodyxy[0] * vel_leg_drive + dir_bodyz[0] * vel_leg_raise;
            dir_legvel_raise[1] = -dir_bodyxy[1] * vel_leg_drive + dir_bodyz[1] * vel_leg_raise;
            dir_legvel_raise[2] = -dir_bodyxy[2] * vel_leg_drive + dir_bodyz[2] * vel_leg_raise;
            dir_legvel_down[0] = -dir_bodyxy[0] * vel_leg_drive - dir_bodyz[0] * vel_leg_raise;
            dir_legvel_down[1] = -dir_bodyxy[1] * vel_leg_drive - dir_bodyz[1] * vel_leg_raise;
            dir_legvel_down[2] = -dir_bodyxy[2] * vel_leg_drive - dir_bodyz[2] * vel_leg_raise;

            
            center_limb_pos[0] = 0.0;
            center_limb_pos[1] = 0.0;
            center_limb_pos[2] = 0.0;

            
            min_limb_pos[0] = center_limb_pos[0] - (r_asta + d_r) * dir_bodyxy[0];
            min_limb_pos[1] = center_limb_pos[1] - (r_asta + d_r) * dir_bodyxy[1];
            min_limb_pos[2] = center_limb_pos[2] - (r_asta + d_r) * dir_bodyxy[2];

            
            max_limb_pos[0] = center_limb_pos[0] + (r_asta + d_r) * dir_bodyxy[0];
            max_limb_pos[1] = center_limb_pos[1] + (r_asta + d_r) * dir_bodyxy[1];
            max_limb_pos[2] = center_limb_pos[2] + (r_asta + d_r) * dir_bodyxy[2];

            
            double[] init_limb_pos2 = new double[3];
            double[] init_limb_pos3 = new double[3];
            double[] init_limb_pos4 = new double[3];

            //2脚目の初期位置算出
            double err_lenght = 2.0 * (r_asta - d_r);
            init_limb_pos2[0] = min_limb_pos[0] + err_lenght * dir_bodyxy[0];
            init_limb_pos2[1] = min_limb_pos[1] + err_lenght * dir_bodyxy[1];
            init_limb_pos2[2] = min_limb_pos[2] + err_lenght * dir_bodyxy[2];

            double over_lenght = Norm((center_limb_pos[0] - init_limb_pos2[0]), (center_limb_pos[1] - init_limb_pos2[1]), (center_limb_pos[2] - init_limb_pos2[2]));
            if (over_lenght > err_lenght) {
                init_limb_pos2[0] = min_limb_pos[0] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[0];
                init_limb_pos2[1] = min_limb_pos[1] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[1];
                init_limb_pos2[2] = min_limb_pos[2] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[2];
            }

            //3脚目の初期位置算出
            err_lenght = 2.0 * (r_asta - d_r) - (r_asta - d_r)/duty_cycle;
            init_limb_pos3[0] = min_limb_pos[0] + err_lenght * dir_bodyxy[0];
            init_limb_pos3[1] = min_limb_pos[1] + err_lenght * dir_bodyxy[1];
            init_limb_pos3[2] = min_limb_pos[2] + err_lenght * dir_bodyxy[2];

            over_lenght = Norm((center_limb_pos[0] - init_limb_pos3[0]), (center_limb_pos[1] - init_limb_pos3[1]), (center_limb_pos[2] - init_limb_pos3[2]));
            if (over_lenght > err_lenght)
            {
                init_limb_pos3[0] = min_limb_pos[0] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[0];
                init_limb_pos3[1] = min_limb_pos[1] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[1];
                init_limb_pos3[2] = min_limb_pos[2] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[2];
            }

            //4脚目の初期位置算出
            err_lenght = (r_asta - d_r) / duty_cycle;
            init_limb_pos4[0] = min_limb_pos[0] + err_lenght * dir_bodyxy[0];
            init_limb_pos4[1] = min_limb_pos[1] + err_lenght * dir_bodyxy[1];
            init_limb_pos4[2] = min_limb_pos[2] + err_lenght * dir_bodyxy[2];

            over_lenght = Norm((center_limb_pos[0] - init_limb_pos4[0]), (center_limb_pos[1] - init_limb_pos4[1]), (center_limb_pos[2] - init_limb_pos4[2]));
            if (over_lenght > err_lenght)
            {
                init_limb_pos4[0] = min_limb_pos[0] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[0];
                init_limb_pos4[1] = min_limb_pos[1] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[1];
                init_limb_pos4[2] = min_limb_pos[2] + Math.Abs(over_lenght - err_lenght) * dir_bodyxy[2];
            }


            init_limb_pos[0, 0] = min_limb_pos[0];
            init_limb_pos[0, 1] = min_limb_pos[1];
            init_limb_pos[0, 2] = min_limb_pos[2];

            init_limb_pos[1, 0] = init_limb_pos2[0];
            init_limb_pos[1, 1] = init_limb_pos2[1];
            init_limb_pos[1, 2] = init_limb_pos2[2];

            init_limb_pos[2, 0] = init_limb_pos3[0];
            init_limb_pos[2, 1] = init_limb_pos3[1];
            init_limb_pos[2, 2] = init_limb_pos3[2];

            init_limb_pos[3, 0] = init_limb_pos4[0];
            init_limb_pos[3, 1] = init_limb_pos4[1];
            init_limb_pos[3, 2] = init_limb_pos4[2];

        }

        double Norm(double x, double y, double z)
        {
            // ノルムの計算
            return x * x + y * y + z * z;
        }

        private void control_law()//制御則
        {

            if (posmode_select == 1)
            {
                //
                if (cycle_state == 1)
                {
                    cycle_state = 2;
                    cycle_time = 0.0;
                }
                else
                {
                    cycle_time = cycle_time + cycle_dt;
                }

                double[] _vel_direction = new double[3];
                double[] _limb_pos = new double[3];
                //1脚目
                _vel_direction = gate_cycle(cycle_time, 0.0, tp, dir_legvel_raise, dir_legvel_return, dir_legvel_down, dir_legvel_drive);
                _limb_pos[0] = cycle_limb_pos[0, 0];
                _limb_pos[1] = cycle_limb_pos[0, 1];
                _limb_pos[2] = cycle_limb_pos[0, 2];
                _limb_pos = get_tra_of_end(_vel_direction, _limb_pos);
                cycle_limb_pos[0, 0] = _limb_pos[0];
                cycle_limb_pos[0, 1] = _limb_pos[1];
                cycle_limb_pos[0, 2] = _limb_pos[2];

                //2脚目
                _vel_direction = gate_cycle(cycle_time, (3.0 * t_d + 2.0 * t_ddd) / st_cycle, tp, dir_legvel_raise, dir_legvel_return, dir_legvel_down, dir_legvel_drive);
                _limb_pos[0] = cycle_limb_pos[1, 0];
                _limb_pos[1] = cycle_limb_pos[1, 1];
                _limb_pos[2] = cycle_limb_pos[1, 2];
                _limb_pos = get_tra_of_end(_vel_direction, _limb_pos);
                cycle_limb_pos[1, 0] = _limb_pos[0];
                cycle_limb_pos[1, 1] = _limb_pos[1];
                cycle_limb_pos[1, 2] = _limb_pos[2];

                //3脚目
                _vel_direction = gate_cycle(cycle_time, (1.0 * t_d + 1.0 * t_ddd) / st_cycle, tp, dir_legvel_raise, dir_legvel_return, dir_legvel_down, dir_legvel_drive);
                _limb_pos[0] = cycle_limb_pos[2, 0];
                _limb_pos[1] = cycle_limb_pos[2, 1];
                _limb_pos[2] = cycle_limb_pos[2, 2];
                _limb_pos = get_tra_of_end(_vel_direction, _limb_pos);
                cycle_limb_pos[2, 0] = _limb_pos[0];
                cycle_limb_pos[2, 1] = _limb_pos[1];
                cycle_limb_pos[2, 2] = _limb_pos[2];

                //4脚目
                _vel_direction = gate_cycle(cycle_time, (2.0 * t_d + 1.0 * t_ddd) / st_cycle, tp, dir_legvel_raise, dir_legvel_return, dir_legvel_down, dir_legvel_drive);
                _limb_pos[0] = cycle_limb_pos[3, 0];
                _limb_pos[1] = cycle_limb_pos[3, 1];
                _limb_pos[2] = cycle_limb_pos[3, 2];
                _limb_pos = get_tra_of_end(_vel_direction, _limb_pos);
                cycle_limb_pos[3, 0] = _limb_pos[0];
                cycle_limb_pos[3, 1] = _limb_pos[1];
                cycle_limb_pos[3, 2] = _limb_pos[2];

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 3; j++) limb_pos[i, j] = cycle_limb_pos[i, j];
                }

                trackBar_limbpos1.Value = (int)((limb_pos[0,0] / 0.05 * 50.0 + 50.0));
                label_limbpos1.Text = string.Format("Leg1_X:{0:0.000}m", limb_pos[0, 0]);

                trackBar_limbpos2.Value = (int)((limb_pos[0, 1] / 0.05 * 50.0 + 50.0));
                label_limbpos2.Text = string.Format("Leg1_Y:{0:0.000}m", limb_pos[0, 1]);

                trackBar_limbpos3.Value = (int)((limb_pos[0, 2] / 0.05 * 50.0 + 50.0));
                label_limbpos3.Text = string.Format("Leg1_Z:{0:0.000}m", limb_pos[0, 2]);


                trackBar_limbpos5.Value = (int)((limb_pos[1, 0] / 0.05 * 50.0 + 50.0));
                label_limbpos5.Text = string.Format("Leg2_X:{0:0.000}m", limb_pos[1, 0]);

                trackBar_limbpos6.Value = (int)((limb_pos[1, 1] / 0.05 * 50.0 + 50.0));
                label_limbpos6.Text = string.Format("Leg2_Y:{0:0.000}m", limb_pos[1, 1]);

                trackBar_limbpos7.Value = (int)((limb_pos[1, 2] / 0.05 * 50.0 + 50.0));
                label_limbpos7.Text = string.Format("Leg2_Z:{0:0.000}m", limb_pos[1, 2]);


                trackBar_limbpos9.Value = (int)((limb_pos[2, 0] / 0.05 * 50.0 + 50.0));
                label_limbpos9.Text = string.Format("Leg3_X:{0:0.000}m", limb_pos[2, 0]);

                trackBar_limbpos10.Value = (int)((limb_pos[2, 1] / 0.05 * 50.0 + 50.0));
                label_limbpos10.Text = string.Format("Leg3_Y:{0:0.000}m", limb_pos[2, 1]);

                trackBar_limbpos11.Value = (int)((limb_pos[2, 2] / 0.05 * 50.0 + 50.0));
                label_limbpos11.Text = string.Format("Leg3_Z:{0:0.000}m", limb_pos[2, 2]);


                trackBar_limbpos13.Value = (int)((limb_pos[3, 0] / 0.05 * 50.0 + 50.0));
                label_limbpos13.Text = string.Format("Leg4_X:{0:0.000}m", limb_pos[3, 0]);

                trackBar_limbpos14.Value = (int)((limb_pos[3, 1] / 0.05 * 50.0 + 50.0));
                label_limbpos14.Text = string.Format("Leg4_Y:{0:0.000}m", limb_pos[3, 1]);

                trackBar_limbpos15.Value = (int)((limb_pos[3, 2] / 0.05 * 50.0 + 50.0));
                label_limbpos15.Text = string.Format("Leg4_Z:{0:0.000}m", limb_pos[3, 2]);
            }

            double[] leg1_angle = new double[3];
            leg1_angle = ik_leg1();
            limb_angle_IK[0] =  leg1_angle[0] + 89.0 * DTR;
            limb_angle_IK[1] = -leg1_angle[1] + 142.0 * DTR;
            limb_angle_IK[2] =  leg1_angle[2] + 21.0 * DTR;

            double[] leg2_angle = new double[3];
            leg2_angle = ik_leg2();
            limb_angle_IK[4] =  leg2_angle[0] + 89.0 * DTR;
            limb_angle_IK[5] =  leg2_angle[1] + 34.0 * DTR;
            limb_angle_IK[6] = -leg2_angle[2] + 154.0 * DTR;

            double[] leg3_angle = new double[3];
            leg3_angle = ik_leg3();
            limb_angle_IK[8] =   leg3_angle[0] + 81.0 * DTR;
            limb_angle_IK[9] =   leg3_angle[1] + 18.0 * DTR;
            limb_angle_IK[10] = -leg3_angle[2] + 160.0 * DTR;

            double[] leg4_angle = new double[3];
            leg4_angle = ik_leg4();
            limb_angle_IK[12] =  leg4_angle[0] + 72.0 * DTR;
            limb_angle_IK[13] = -leg4_angle[1] + 175.0 * DTR;
            limb_angle_IK[14] =  leg4_angle[2] + 4.0 * DTR;

            timer_cnt1 = 0;
        }

        private double[] ik_leg1()//Leg1の逆運動学を解く
        {
            double lxo = 0.01255 / 2.0;
            double lyo = 0.027425;
            double lzo = 0.009775;

            double l1 = 0.03;
            double l2 = 0.03;
            double l3 = 0.055;
            double l4 = 0.055;

            double[] leg_pos = new double[3];
            leg_pos[0] = limb_pos[0, 0] - cg_pos[0];
            leg_pos[1] = limb_pos[0, 1] - lyo - cg_pos[1];
            leg_pos[2] = limb_pos[0, 2] - lzo - 0.05 - cg_pos[2];

            double leyz = Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2));
            double l0 = Math.Sqrt(Math.Pow(leyz, 2) - Math.Pow(lyo, 2));

            double theta0 = -Math.Acos(lyo / leyz) + Math.Acos(-leg_pos[1] / Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2)));

            double[] leg_posd = new double[2];
            leg_posd[0] = leg_pos[0] + lxo;
            leg_posd[1] = l0 - lzo;
            double[] leg_posd2 = new double[2];
            leg_posd2[0] = leg_posd[0] - 2 * lxo;
            leg_posd2[1] = leg_posd[1];

            double theta1 = Math.Acos((Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2) + Math.Pow(l1, 2) - Math.Pow(l3, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2)))) + Math.Atan2(leg_posd[1], leg_posd[0]) - Math.PI / 2.0;

            double theta2 = Math.Acos((Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2) + Math.Pow(l2, 2) - Math.Pow(l4, 2)) / (2 * l2 * Math.Sqrt(Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2)))) - Math.Atan2(leg_posd2[1], leg_posd2[0]) + Math.PI / 2.0;

            double[] ans = new double[3];
            ans[0] = theta0;
            ans[1] = theta1;
            ans[2] = theta2;

            return ans;
        }

        private double[] ik_leg2()//Leg2の逆運動学を解く
        {
            double lxo = 0.01255 / 2.0;
            double lyo = 0.027425;
            double lzo = 0.009775;

            double l1 = 0.03;
            double l2 = 0.03;
            double l3 = 0.055;
            double l4 = 0.055;

            double[] leg_pos = new double[3];
            leg_pos[0] = limb_pos[1, 0] - cg_pos[0];
            leg_pos[1] = -limb_pos[1, 1] - lyo + cg_pos[1];
            leg_pos[2] = limb_pos[1, 2] - lzo - 0.05 - cg_pos[2];

            double leyz = Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2));
            double l0 = Math.Sqrt(Math.Pow(leyz, 2) - Math.Pow(lyo, 2));

            double theta0 = Math.Acos(lyo / leyz) - Math.Acos(-leg_pos[1] / Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2)));

            double[] leg_posd = new double[2];
            leg_posd[0] = leg_pos[0] + lxo;
            leg_posd[1] = l0 - lzo;
            double[] leg_posd2 = new double[2];
            leg_posd2[0] = leg_posd[0] - 2 * lxo;
            leg_posd2[1] = leg_posd[1];

            double theta1 = Math.Acos((Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2) + Math.Pow(l1, 2) - Math.Pow(l3, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2)))) + Math.Atan2(leg_posd[1], leg_posd[0]) - Math.PI / 2.0;

            double theta2 = Math.Acos((Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2) + Math.Pow(l2, 2) - Math.Pow(l4, 2)) / (2 * l2 * Math.Sqrt(Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2)))) - Math.Atan2(leg_posd2[1], leg_posd2[0]) + Math.PI / 2.0;

            double[] ans = new double[3];
            ans[0] = theta0;
            ans[1] = theta1;
            ans[2] = theta2;

            return ans;
        }

        private double[] ik_leg3()//Leg3の逆運動学を解く
        {
            double lxo = 0.01255 / 2.0;
            double lyo = 0.027425;
            double lzo = 0.009775;

            double l1 = 0.03;
            double l2 = 0.03;
            double l3 = 0.055;
            double l4 = 0.055;

            double[] leg_pos = new double[3];
            leg_pos[0] = limb_pos[2, 0] - cg_pos[0];
            leg_pos[1] = -limb_pos[2, 1] - lyo + cg_pos[1];
            leg_pos[2] = limb_pos[2, 2] - lzo - 0.05 - cg_pos[2];

            double leyz = Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2));
            double l0 = Math.Sqrt(Math.Pow(leyz, 2) - Math.Pow(lyo, 2));

            double theta0 = Math.Acos(lyo / leyz) - Math.Acos(-leg_pos[1] / Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2)));

            double[] leg_posd = new double[2];
            leg_posd[0] = leg_pos[0] + lxo;
            leg_posd[1] = l0 - lzo;
            double[] leg_posd2 = new double[2];
            leg_posd2[0] = leg_posd[0] - 2 * lxo;
            leg_posd2[1] = leg_posd[1];

            double theta1 = Math.Acos((Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2) + Math.Pow(l1, 2) - Math.Pow(l3, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2)))) + Math.Atan2(leg_posd[1], leg_posd[0]) - Math.PI / 2.0;

            double theta2 = Math.Acos((Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2) + Math.Pow(l2, 2) - Math.Pow(l4, 2)) / (2 * l2 * Math.Sqrt(Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2)))) - Math.Atan2(leg_posd2[1], leg_posd2[0]) + Math.PI / 2.0;

            double[] ans = new double[3];
            ans[0] = theta0;
            ans[1] = theta1;
            ans[2] = theta2;

            return ans;
        }

        private double[] ik_leg4()//Leg4の逆運動学を解く
        {
            double lxo = 0.01255 / 2.0;
            double lyo = 0.027425;
            double lzo = 0.009775;

            double l1 = 0.03;
            double l2 = 0.03;
            double l3 = 0.055;
            double l4 = 0.055;

            double[] leg_pos = new double[3];
            leg_pos[0] = limb_pos[3, 0] - cg_pos[0];
            leg_pos[1] = limb_pos[3, 1] - lyo - cg_pos[1];
            leg_pos[2] = limb_pos[3, 2] - lzo - 0.05 - cg_pos[2];

            double leyz = Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2));
            double l0 = Math.Sqrt(Math.Pow(leyz, 2) - Math.Pow(lyo, 2));

            double theta0 = -Math.Acos(lyo / leyz) + Math.Acos(-leg_pos[1] / Math.Sqrt(Math.Pow(leg_pos[1], 2) + Math.Pow(leg_pos[2], 2)));

            double[] leg_posd = new double[2];
            leg_posd[0] = leg_pos[0] + lxo;
            leg_posd[1] = l0 - lzo;
            double[] leg_posd2 = new double[2];
            leg_posd2[0] = leg_posd[0] - 2 * lxo;
            leg_posd2[1] = leg_posd[1];

            double theta1 = Math.Acos((Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2) + Math.Pow(l1, 2) - Math.Pow(l3, 2)) / (2 * l1 * Math.Sqrt(Math.Pow(leg_posd[0], 2) + Math.Pow(leg_posd[1], 2)))) + Math.Atan2(leg_posd[1], leg_posd[0]) - Math.PI / 2.0;

            double theta2 = Math.Acos((Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2) + Math.Pow(l2, 2) - Math.Pow(l4, 2)) / (2 * l2 * Math.Sqrt(Math.Pow(leg_posd2[0], 2) + Math.Pow(leg_posd2[1], 2)))) - Math.Atan2(leg_posd2[1], leg_posd2[0]) + Math.PI / 2.0;

            double[] ans = new double[3];
            ans[0] = theta0;
            ans[1] = theta1;
            ans[2] = theta2;

            return ans;
        }

        private void calculation()//
        {

        }
 



        //運動方程式演算部終了//**************************************************************************************

        private void data_save()//データの保存
        {

            int j;
            if (time < 5) j = 0;
            else if (time < 10) j = 1;
            else if (time < 15) j = 2;
            else if (time < 20) j = 3;
            else if (time < 25) j = 4;
            else if (time < 30) j = 5;
            else if (time < 35) j = 6;
            else if (time < 40) j = 7;
            else if (time < 45) j = 8;
            else j = 9;


            save_data_sb.Clear();//添付用変数のクリア

            //Time
            save_data_sb.Append(time.ToString());
            save_data_sb.Append(",");
            //data
            for (int i = 0; i < State.Length; i++) save_data_sb.Append(State[i].ToString() + ",");      //data

            save_data_sb.Append("\r\n");

            //添付用変数から正規に代入
            save_data[j] += save_data_sb.ToString();
            save_data_sb.Clear();//添付用変数クリア
            timer_cnt2 = 0;
        }

        private void display()//表示
        {
            /*
                State[0] = statusmpu;
                State[1] = mpu_t;
                State[2] = acc_data[0];
                State[3] = acc_data[1];
                State[4] = acc_data[2];
                State[5] = gyro_data[0];
                State[6] = gyro_data[1];
                State[7] = gyro_data[2];
                State[8] = euler_data[0];
                State[9] = euler_data[1];
                State[10] = euler_data[2];
            */

            //TIME_LABEL.Text = string.Format("TIME:{0:0.0}sec",time);

            TIME_LABEL.BeginInvoke((MethodInvoker)delegate ()
            {
                TIME_LABEL.Text = string.Format("TIME:{0:0.0}sec", time);
            });

            //mpu ステータス
            MPUSTATUS_LABEL.BeginInvoke((MethodInvoker)delegate ()
            {
                MPUSTATUS_LABEL.Text = string.Format("MPU Status:{0:0}", State[0]);
            });
            //mpu 時間
            MPUTIME_LABEL.BeginInvoke((MethodInvoker)delegate ()
            {
                MPUTIME_LABEL.Text = string.Format("MPU Time:{0:0.00}sec", State[1]);
            });


            plot_data.BeginInvoke((MethodInvoker)delegate ()
            {
                // 軸の最大値・最小値、主目盛の間隔を設定します。
                plot_data.ChartAreas[0].AxisY.Maximum = 180;
                plot_data.ChartAreas[0].AxisY.Minimum = -180;

                if (plot_data.Series[0].Points.Count <= 500)
                {
                    plot_data.Series[0].Points.AddXY(time, State[8] * 180.0 / Math.PI);
                    plot_data.Series[1].Points.AddXY(time, State[9] * 180.0 / Math.PI);
                    plot_data.Series[2].Points.AddXY(time, State[10] * 180.0 / Math.PI);
                }
                else
                {
                    for (int i = 1; i <= 500; i++)
                    {
                        plot_data.Series[0].Points[i - 1].YValues = plot_data.Series[0].Points[i].YValues;
                        plot_data.Series[1].Points[i - 1].YValues = plot_data.Series[1].Points[i].YValues;
                        plot_data.Series[2].Points[i - 1].YValues = plot_data.Series[2].Points[i].YValues;
                    }
                    plot_data.Series[0].Points.RemoveAt(500);
                    plot_data.Series[1].Points.RemoveAt(500);
                    plot_data.Series[2].Points.RemoveAt(500);
                    plot_data.Series[0].Points.AddXY(time, State[8] * 180.0 / Math.PI);
                    plot_data.Series[1].Points.AddXY(time, State[9] * 180.0 / Math.PI);
                    plot_data.Series[2].Points.AddXY(time, State[10] * 180.0 / Math.PI);
                }
                
                plot_data.Invalidate();
            });

            timer_cnt3 = 0;
        }

        private void SAVE_BUTTON_Click(object sender, EventArgs e)
        {
            string textdata = "";
            for (int i = 0; i < 10; i++) textdata += save_data[i];       //stateデータの保存
            textdata += "\r\n";
            data_save(textdata, "log_data");
        }
        private void data_save(string data, string title)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = title + ".csv";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"C:\Users\H_M\Desktop";
            sfd.Filter =
                "csvファイル(*.csv)|*.csv|textファイル(*.text)|*.text|nmeaファイル(*.nmea)|*.nmea|すべてのファイル(*.*)|*.*";
            sfd.FilterIndex = 1;
            sfd.Title = "保存先のファイルを選択してください";
            sfd.RestoreDirectory = true;
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(
                    sfd.FileName,
                    false,
                    System.Text.Encoding.GetEncoding("shift_jis"));
                sw.Write(data);
                sw.Close();
            }
        }

        public int statuspc = 0;
        float[] textbox_val = new float[100];
        double[] limb_angle_IK = new double[16];
        double[,] cycle_limb_pos = new double[4,3];

        private void set_outputdata()
        {

            if (mode_select == 1) {
                for (int i = 0; i < limb_angle_IK.Length; i++) limb_angle[i] = limb_angle_IK[i];
                trackBar_limb1.Value = (int)((limb_angle_IK[0] * 180.0 / Math.PI));
                label_limb1.Text = string.Format("Limb1:{0:0.0}deg", limb_angle_IK[0] * 180.0 / Math.PI);

                trackBar_limb2.Value = (int)((limb_angle_IK[1] * 180.0 / Math.PI));
                label_limb2.Text = string.Format("Limb2:{0:0.0}deg", limb_angle_IK[1] * 180.0 / Math.PI);

                trackBar_limb3.Value = (int)((limb_angle_IK[2] * 180.0 / Math.PI));
                label_limb3.Text = string.Format("Limb3:{0:0.0}deg", limb_angle_IK[2] * 180.0 / Math.PI);


                trackBar_limb5.Value = (int)((limb_angle_IK[4] * 180.0 / Math.PI));
                label_limb5.Text = string.Format("Limb5:{0:0.0}deg", limb_angle_IK[4] * 180.0 / Math.PI);

                trackBar_limb6.Value = (int)((limb_angle_IK[5] * 180.0 / Math.PI));
                label_limb6.Text = string.Format("Limb6:{0:0.0}deg", limb_angle_IK[5] * 180.0 / Math.PI);

                trackBar_limb7.Value = (int)((limb_angle_IK[6] * 180.0 / Math.PI));
                label_limb7.Text = string.Format("Limb7:{0:0.0}deg", limb_angle_IK[6] * 180.0 / Math.PI);


                trackBar_limb9.Value = (int)((limb_angle_IK[8] * 180.0 / Math.PI));
                label_limb9.Text = string.Format("Limb9:{0:0.0}deg", limb_angle_IK[8] * 180.0 / Math.PI);

                trackBar_limb10.Value = (int)((limb_angle_IK[9] * 180.0 / Math.PI));
                label_limb10.Text = string.Format("Limb10:{0:0.0}deg", limb_angle_IK[9] * 180.0 / Math.PI);

                trackBar_limb11.Value = (int)((limb_angle_IK[10] * 180.0 / Math.PI));
                label_limb11.Text = string.Format("Limb11:{0:0.0}deg", limb_angle_IK[10] * 180.0 / Math.PI);


                trackBar_limb13.Value = (int)((limb_angle_IK[12] * 180.0 / Math.PI));
                label_limb13.Text = string.Format("Limb12:{0:0.0}deg", limb_angle_IK[11] * 180.0 / Math.PI);

                trackBar_limb14.Value = (int)((limb_angle_IK[13] * 180.0 / Math.PI));
                label_limb14.Text = string.Format("Limb13:{0:0.0}deg", limb_angle_IK[12] * 180.0 / Math.PI);

                trackBar_limb15.Value = (int)((limb_angle_IK[14] * 180.0 / Math.PI));
                label_limb15.Text = string.Format("Limb14:{0:0.0}deg", limb_angle_IK[13] * 180.0 / Math.PI);
            }
        }

        private void send_outputdata()
        {
            set_outputdata();
            ushort ushTmp;
            byte[] s_uchMsg = new byte[39];
            string text_tmp = "";
            ushort k = 0;
            s_uchMsg[0] = 0xa5;
            s_uchMsg[1] = 0x5a;

            //ステータス
            text_tmp = PCSTATUS_TEXTBOX.Text;
            if (ushort.TryParse(text_tmp, out k)) textbox_val[0] = ushort.Parse(text_tmp);
            statuspc = (int)textbox_val[0];
            s_uchMsg[2] = (byte)(statuspc);

            //時間
            ushTmp = (ushort)(time / 600.0 * 65535.0);
            s_uchMsg[3] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[4] = (byte)(ushTmp & 0x00ff);

            //limb1_angle
            ushTmp = (ushort)( (double)(limb_angle[0] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[5] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[6] = (byte)(ushTmp & 0x00ff);

            //limb2_angle
            ushTmp = (ushort)((double)(limb_angle[1] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[7] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[8] = (byte)(ushTmp & 0x00ff);

            //limb3_angle
            ushTmp = (ushort)((double)(limb_angle[2] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[9] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[10] = (byte)(ushTmp & 0x00ff);

            //limb4_angle
            ushTmp = (ushort)((double)(limb_angle[3] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[11] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[12] = (byte)(ushTmp & 0x00ff);

            //limb5_angle
            ushTmp = (ushort)((double)(limb_angle[4] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[13] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[14] = (byte)(ushTmp & 0x00ff);

            //limb6_angle
            ushTmp = (ushort)((double)(limb_angle[5] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[15] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[16] = (byte)(ushTmp & 0x00ff);

            //limb7_angle
            ushTmp = (ushort)((double)(limb_angle[6] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[17] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[18] = (byte)(ushTmp & 0x00ff);

            //limb8_angle
            ushTmp = (ushort)((double)(limb_angle[7] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[19] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[20] = (byte)(ushTmp & 0x00ff);

            //limb9_angle
            ushTmp = (ushort)((double)(limb_angle[8] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[21] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[22] = (byte)(ushTmp & 0x00ff);

            //limb10_angle
            ushTmp = (ushort)((double)(limb_angle[9] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[23] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[24] = (byte)(ushTmp & 0x00ff);

            //limb11_angle
            ushTmp = (ushort)((double)(limb_angle[10] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[25] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[26] = (byte)(ushTmp & 0x00ff);

            //limb12_angle
            ushTmp = (ushort)((double)(limb_angle[11] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[27] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[28] = (byte)(ushTmp & 0x00ff);

            //limb13_angle
            ushTmp = (ushort)((double)(limb_angle[12] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[29] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[30] = (byte)(ushTmp & 0x00ff);

            //limb14_angle
            ushTmp = (ushort)((double)(limb_angle[13] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[31] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[32] = (byte)(ushTmp & 0x00ff);

            //limb15_angle
            ushTmp = (ushort)((double)(limb_angle[14] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[33] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[34] = (byte)(ushTmp & 0x00ff);

            //limb16_angle
            ushTmp = (ushort)((double)(limb_angle[15] + 0.0) / (2.0 * Math.PI) * 65535.0);
            s_uchMsg[35] = (byte)(ushTmp >> 8 & 0x00ff);
            s_uchMsg[36] = (byte)(ushTmp & 0x00ff);

            s_uchMsg[37] = 0x0d;
            s_uchMsg[38] = 0x0a;

            //! シリアルポートからテキストを送信する.
            GETDATA1_SERIALPORT.Write(s_uchMsg,0,39);

            timer_cnt4 = 0;
        }



            private void soft_sim()//シミュレーションの制御ルーチン
        {
            
            if (timer_cnt1 == (int)(0.02 / dt))
            {
                calculation();
                control_law();
            }
            if (timer_cnt2 == (int)(0.02 / dt)) data_save();
            if (timer_cnt3 == (int)(0.02  / dt)) display();
            if (timer_cnt4 == (int)(0.02 / dt)) send_outputdata();
        }

        private void timer_cnt()
        {
            timer_cnt1++;
            timer_cnt2++;
            timer_cnt3++;
            timer_cnt4++;
            time = time + dt;
        }

        private void timer1()
        {
            timer_cnt();
            soft_sim();              
        }

        private void START_BUTTON_Click(object sender, EventArgs e)
        {
            STATUS_LABEL.Text = string.Format("Plot Now");
            Sim_Initialize();
            timer4.Enabled = true;
            START_BUTTON.Enabled = false; //無効にする
            STOP_BUTTON.Enabled = true; //有効にする
            COMPORT_SET_BUTTON.Enabled = false; //無効にする
        }

        private void timer4_OnTimer(object sender)
        {
            //timer1();
            this.Invoke(new timer1Delegate(timer1), null);
        }

        private void STOP_BUTTON_Click(object sender, EventArgs e)
        {
            STATUS_LABEL.Text = string.Format("Plot Stoped");
            timer4.Enabled = false;
            START_BUTTON.Enabled = true; //有効にする
            STOP_BUTTON.Enabled = false; //無効にする
            COMPORT_SET_BUTTON.Enabled = true; //有効にする
        }
        private double[] limb_angle = new double[16];//rad
        private double[,] limb_pos = new double[4,3];//m

        private void trackBar_limb1_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb1.Value/180.0*180.0;
            limb_angle[0] = track * DTR;
            label_limb1.Text = string.Format("Limb1:{0:0.0}deg", track);
        }

        private void trackBar_limb2_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb2.Value / 180.0 * 180.0;
            limb_angle[1] = track * DTR;
            label_limb2.Text = string.Format("Limb2:{0:0.0}deg", track);
        }

        private void trackBar_limb3_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb3.Value / 180.0 * 180.0;
            limb_angle[2] = track * DTR;
            label_limb3.Text = string.Format("Limb3:{0:0.0}deg", track);
        }

        private void trackBar_limb5_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb5.Value / 180.0 * 180.0;
            limb_angle[4] = track * DTR;
            label_limb5.Text = string.Format("Limb5:{0:0.0}deg", track);
        }

        private void trackBar_limb6_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb6.Value / 180.0 * 180.0;
            limb_angle[5] = track * DTR;
            label_limb6.Text = string.Format("Limb6:{0:0.0}deg", track);
        }

        private void trackBar_limb7_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb7.Value / 180.0 * 180.0;
            limb_angle[6] = track * DTR;
            label_limb7.Text = string.Format("Limb7:{0:0.0}deg", track);
        }

        private void trackBar_limb9_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb9.Value / 180.0 * 180.0;
            limb_angle[8] = track * DTR;
            label_limb9.Text = string.Format("Limb9:{0:0.0}deg", track);
        }

        private void trackBar_limb10_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb10.Value / 180.0 * 180.0;
            limb_angle[9] = track * DTR;
            label_limb10.Text = string.Format("Limb10:{0:0.0}deg", track);
        }

        private void trackBar_limb11_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb11.Value / 180.0 * 180.0;
            limb_angle[10] = track * DTR;
            label_limb11.Text = string.Format("Limb11:{0:0.0}deg", track);
        }

        private void trackBar_limb13_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb13.Value / 180.0 * 180.0;
            limb_angle[12] = track * DTR;
            label_limb13.Text = string.Format("Limb13:{0:0.0}deg", track);
        }

        private void trackBar_limb14_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb14.Value / 180.0 * 180.0;
            limb_angle[13] = track * DTR;
            label_limb14.Text = string.Format("Limb14:{0:0.0}deg", track);
        }

        private void trackBar_limb15_Scroll(object sender, EventArgs e)
        {
            double track = trackBar_limb15.Value / 180.0 * 180.0;
            limb_angle[14] = track * DTR;
            label_limb15.Text = string.Format("Limb15:{0:0.0}deg", track);
        }


        private void trackBar_limbpos1_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos1.Value - 50.0) / 50.0;
            limb_pos[0,0] = track * 0.05;
            label_limbpos1.Text = string.Format("Leg1_X:{0:0.0000}m", limb_pos[0, 0]);
        }

        private void trackBar_limbpos2_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos2.Value - 50.0) / 50.0;
            limb_pos[0,1] = track * 0.05;
            label_limbpos2.Text = string.Format("Leg1_Y:{0:0.0000}m", limb_pos[0, 1]);
        }

        private void trackBar_limbpos3_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos3.Value - 50.0) / 50.0;
            limb_pos[0,2] = track * 0.05;
            label_limbpos3.Text = string.Format("Leg1_Z:{0:0.0000}m", limb_pos[0, 2]);
        }
        

        private void trackBar_limbpos5_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos5.Value - 50.0) / 50.0;
            limb_pos[1, 0] = track * 0.05;
            label_limbpos5.Text = string.Format("Leg2_X:{0:0.0000}m", limb_pos[1, 0]);
        }

        private void trackBar_limbpos6_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos6.Value - 50.0) / 50.0;
            limb_pos[1, 1] = track * 0.05;
            label_limbpos6.Text = string.Format("Leg2_Y:{0:0.0000}m", limb_pos[1, 1]);
        }

        private void trackBar_limbpos7_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos7.Value - 50.0) / 50.0;
            limb_pos[1, 2] = track * 0.05;
            label_limbpos7.Text = string.Format("Leg2_Z:{0:0.0000}m", limb_pos[1, 2]);
        }

        private void trackBar_limbpos9_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos9.Value - 50.0) / 50.0;
            limb_pos[2, 0] = track * 0.05;
            label_limbpos9.Text = string.Format("Leg3_X:{0:0.0000}m", limb_pos[2, 0]);
        }

        private void trackBar_limbpos10_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos10.Value - 50.0) / 50.0;
            limb_pos[2, 1] = track * 0.05;
            label_limbpos10.Text = string.Format("Leg3_Y:{0:0.0000}m", limb_pos[2, 1]);
        }

        private void trackBar_limbpos11_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos11.Value - 50.0) / 50.0;
            limb_pos[2, 2] = track * 0.05;
            label_limbpos11.Text = string.Format("Leg3_Z:{0:0.0000}m", limb_pos[2, 2]);
        }

        private void trackBar_limbpos13_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos13.Value - 50.0) / 50.0;
            limb_pos[3, 0] = track * 0.05;
            label_limbpos13.Text = string.Format("Leg4_X:{0:0.0000}m", limb_pos[3, 0]);
        }

        private void trackBar_limbpos14_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos14.Value - 50.0) / 50.0;
            limb_pos[3, 1] = track * 0.05;
            label_limbpos14.Text = string.Format("Leg4_Y:{0:0.0000}m", limb_pos[3, 1]);
        }

        private void trackBar_limbpos15_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_limbpos15.Value - 50.0) / 50.0;
            limb_pos[3, 2] = track * 0.05;
            label_limbpos15.Text = string.Format("Leg4_Z:{0:0.0000}m", limb_pos[3, 2]);
        }

        private int mode_select = 0;

        private void radioButton_mode1_CheckedChanged(object sender, EventArgs e)
        {
            mode_select = 0;
        }

        private void radioButton_mode2_CheckedChanged(object sender, EventArgs e)
        {
            mode_select = 1;
        }

        private int posmode_select = 0;

        private void radioButton_manual_CheckedChanged(object sender, EventArgs e)
        {
            posmode_select = 0;
            cycle_state = 0;
        }

        private void radioButton_cycle_CheckedChanged(object sender, EventArgs e)
        {
            posmode_select = 1;
            cycle_state = 1;
        }

        private double[] cg_pos = new double[3];//m
        private void trackBar_cgposx_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_cgposx.Value - 50.0) / 50.0;
            cg_pos[0] = track * 0.05;
            label_cgposx.Text = string.Format("CG_X:{0:0.0000}m", cg_pos[0]);
        }

        private void trackBar_cgposy_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_cgposy.Value - 50.0) / 50.0;
            cg_pos[1] = track * 0.05;
            label_cgposy.Text = string.Format("CG_Y:{0:0.0000}m", cg_pos[1]);
        }

        private void trackBar_cgposz_Scroll(object sender, EventArgs e)
        {
            double track = (trackBar_cgposz.Value - 50.0) / 50.0;
            cg_pos[2] = track * 0.05;
            label_cgposz.Text = string.Format("CG_Z:{0:0.0000}m", cg_pos[2]);
        }
    }
}
