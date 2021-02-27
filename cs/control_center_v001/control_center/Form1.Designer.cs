namespace control_center
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series13 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series14 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series15 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.GETDATA1_SERIALPORT = new System.IO.Ports.SerialPort(this.components);
            this.COMPORT_BOX = new System.Windows.Forms.ComboBox();
            this.COMPORT_SET_BUTTON = new System.Windows.Forms.Button();
            this.TIME_LABEL = new System.Windows.Forms.Label();
            this.START_BUTTON = new System.Windows.Forms.Button();
            this.BAUDRATE_BOX = new System.Windows.Forms.ComboBox();
            this.CON_BOX = new System.Windows.Forms.ComboBox();
            this.SEND_DATA_TEXTBOX = new System.Windows.Forms.TextBox();
            this.RECEVED_DATA_TEXTBOX = new System.Windows.Forms.TextBox();
            this.SEND_DATA_LABEL = new System.Windows.Forms.Label();
            this.RECEVED_DATA_LABEL = new System.Windows.Forms.Label();
            this.STOP_BUTTON = new System.Windows.Forms.Button();
            this.SAVE_BUTTON = new System.Windows.Forms.Button();
            this.STATUS_LABEL = new System.Windows.Forms.Label();
            this.plot_data = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.trackBar_limb1 = new System.Windows.Forms.TrackBar();
            this.MPUTIME_LABEL = new System.Windows.Forms.Label();
            this.MPUSTATUS_LABEL = new System.Windows.Forms.Label();
            this.label_limb1 = new System.Windows.Forms.Label();
            this.label_limb2 = new System.Windows.Forms.Label();
            this.trackBar_limb2 = new System.Windows.Forms.TrackBar();
            this.label_limb3 = new System.Windows.Forms.Label();
            this.trackBar_limb3 = new System.Windows.Forms.TrackBar();
            this.label_limb7 = new System.Windows.Forms.Label();
            this.trackBar_limb7 = new System.Windows.Forms.TrackBar();
            this.label_limb6 = new System.Windows.Forms.Label();
            this.trackBar_limb6 = new System.Windows.Forms.TrackBar();
            this.label_limb5 = new System.Windows.Forms.Label();
            this.trackBar_limb5 = new System.Windows.Forms.TrackBar();
            this.label_limb11 = new System.Windows.Forms.Label();
            this.trackBar_limb11 = new System.Windows.Forms.TrackBar();
            this.label_limb10 = new System.Windows.Forms.Label();
            this.trackBar_limb10 = new System.Windows.Forms.TrackBar();
            this.label_limb9 = new System.Windows.Forms.Label();
            this.trackBar_limb9 = new System.Windows.Forms.TrackBar();
            this.label_limb15 = new System.Windows.Forms.Label();
            this.trackBar_limb15 = new System.Windows.Forms.TrackBar();
            this.label_limb14 = new System.Windows.Forms.Label();
            this.trackBar_limb14 = new System.Windows.Forms.TrackBar();
            this.label_limb13 = new System.Windows.Forms.Label();
            this.trackBar_limb13 = new System.Windows.Forms.TrackBar();
            this.PCSTATUS_LABEL = new System.Windows.Forms.Label();
            this.PCSTATUS_TEXTBOX = new System.Windows.Forms.TextBox();
            this.label_limbpos3 = new System.Windows.Forms.Label();
            this.trackBar_limbpos3 = new System.Windows.Forms.TrackBar();
            this.label_limbpos2 = new System.Windows.Forms.Label();
            this.trackBar_limbpos2 = new System.Windows.Forms.TrackBar();
            this.label_limbpos1 = new System.Windows.Forms.Label();
            this.trackBar_limbpos1 = new System.Windows.Forms.TrackBar();
            this.radioButton_mode1 = new System.Windows.Forms.RadioButton();
            this.radioButton_mode2 = new System.Windows.Forms.RadioButton();
            this.groupBox_modeselect1 = new System.Windows.Forms.GroupBox();
            this.groupBox_angle = new System.Windows.Forms.GroupBox();
            this.groupBox_pos = new System.Windows.Forms.GroupBox();
            this.trackBar_limbpos13 = new System.Windows.Forms.TrackBar();
            this.label_limbpos13 = new System.Windows.Forms.Label();
            this.trackBar_limbpos14 = new System.Windows.Forms.TrackBar();
            this.label_limbpos15 = new System.Windows.Forms.Label();
            this.label_limbpos14 = new System.Windows.Forms.Label();
            this.trackBar_limbpos15 = new System.Windows.Forms.TrackBar();
            this.trackBar_limbpos9 = new System.Windows.Forms.TrackBar();
            this.label_limbpos9 = new System.Windows.Forms.Label();
            this.trackBar_limbpos10 = new System.Windows.Forms.TrackBar();
            this.label_limbpos11 = new System.Windows.Forms.Label();
            this.label_limbpos10 = new System.Windows.Forms.Label();
            this.trackBar_limbpos11 = new System.Windows.Forms.TrackBar();
            this.trackBar_limbpos5 = new System.Windows.Forms.TrackBar();
            this.label_limbpos5 = new System.Windows.Forms.Label();
            this.trackBar_limbpos6 = new System.Windows.Forms.TrackBar();
            this.label_limbpos7 = new System.Windows.Forms.Label();
            this.label_limbpos6 = new System.Windows.Forms.Label();
            this.trackBar_limbpos7 = new System.Windows.Forms.TrackBar();
            this.radioButton_manual = new System.Windows.Forms.RadioButton();
            this.radioButton_cycle = new System.Windows.Forms.RadioButton();
            this.label_dutycycle = new System.Windows.Forms.Label();
            this.trackBar_cgposx = new System.Windows.Forms.TrackBar();
            this.label_cgposx = new System.Windows.Forms.Label();
            this.trackBar_cgposy = new System.Windows.Forms.TrackBar();
            this.label_cgposz = new System.Windows.Forms.Label();
            this.label_cgposy = new System.Windows.Forms.Label();
            this.trackBar_cgposz = new System.Windows.Forms.TrackBar();
            this.trackBar_dutycycle = new System.Windows.Forms.TrackBar();
            this.timer4 = new control_center.MultiMediaTimerComponent(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.plot_data)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos1)).BeginInit();
            this.groupBox_modeselect1.SuspendLayout();
            this.groupBox_angle.SuspendLayout();
            this.groupBox_pos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_dutycycle)).BeginInit();
            this.SuspendLayout();
            // 
            // GETDATA1_SERIALPORT
            // 
            this.GETDATA1_SERIALPORT.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.GETDATA1_SERIALPORT_DataReceived);
            // 
            // COMPORT_BOX
            // 
            this.COMPORT_BOX.FormattingEnabled = true;
            this.COMPORT_BOX.Location = new System.Drawing.Point(7, 11);
            this.COMPORT_BOX.Name = "COMPORT_BOX";
            this.COMPORT_BOX.Size = new System.Drawing.Size(70, 20);
            this.COMPORT_BOX.TabIndex = 1;
            // 
            // COMPORT_SET_BUTTON
            // 
            this.COMPORT_SET_BUTTON.Location = new System.Drawing.Point(160, 37);
            this.COMPORT_SET_BUTTON.Name = "COMPORT_SET_BUTTON";
            this.COMPORT_SET_BUTTON.Size = new System.Drawing.Size(98, 23);
            this.COMPORT_SET_BUTTON.TabIndex = 2;
            this.COMPORT_SET_BUTTON.Text = "CONNECT";
            this.COMPORT_SET_BUTTON.UseVisualStyleBackColor = true;
            this.COMPORT_SET_BUTTON.Click += new System.EventHandler(this.COMPORT_SET_BUTTON_Click);
            // 
            // TIME_LABEL
            // 
            this.TIME_LABEL.AutoSize = true;
            this.TIME_LABEL.Location = new System.Drawing.Point(12, 63);
            this.TIME_LABEL.Name = "TIME_LABEL";
            this.TIME_LABEL.Size = new System.Drawing.Size(33, 12);
            this.TIME_LABEL.TabIndex = 4;
            this.TIME_LABEL.Text = "TIME:";
            // 
            // START_BUTTON
            // 
            this.START_BUTTON.Location = new System.Drawing.Point(7, 37);
            this.START_BUTTON.Name = "START_BUTTON";
            this.START_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.START_BUTTON.TabIndex = 5;
            this.START_BUTTON.Text = "START";
            this.START_BUTTON.UseVisualStyleBackColor = true;
            this.START_BUTTON.Click += new System.EventHandler(this.START_BUTTON_Click);
            // 
            // BAUDRATE_BOX
            // 
            this.BAUDRATE_BOX.FormattingEnabled = true;
            this.BAUDRATE_BOX.Location = new System.Drawing.Point(83, 11);
            this.BAUDRATE_BOX.Name = "BAUDRATE_BOX";
            this.BAUDRATE_BOX.Size = new System.Drawing.Size(97, 20);
            this.BAUDRATE_BOX.TabIndex = 6;
            // 
            // CON_BOX
            // 
            this.CON_BOX.FormattingEnabled = true;
            this.CON_BOX.Location = new System.Drawing.Point(191, 11);
            this.CON_BOX.Name = "CON_BOX";
            this.CON_BOX.Size = new System.Drawing.Size(122, 20);
            this.CON_BOX.TabIndex = 7;
            // 
            // SEND_DATA_TEXTBOX
            // 
            this.SEND_DATA_TEXTBOX.Location = new System.Drawing.Point(12, 165);
            this.SEND_DATA_TEXTBOX.Multiline = true;
            this.SEND_DATA_TEXTBOX.Name = "SEND_DATA_TEXTBOX";
            this.SEND_DATA_TEXTBOX.Size = new System.Drawing.Size(160, 160);
            this.SEND_DATA_TEXTBOX.TabIndex = 8;
            // 
            // RECEVED_DATA_TEXTBOX
            // 
            this.RECEVED_DATA_TEXTBOX.Location = new System.Drawing.Point(181, 165);
            this.RECEVED_DATA_TEXTBOX.Multiline = true;
            this.RECEVED_DATA_TEXTBOX.Name = "RECEVED_DATA_TEXTBOX";
            this.RECEVED_DATA_TEXTBOX.Size = new System.Drawing.Size(160, 160);
            this.RECEVED_DATA_TEXTBOX.TabIndex = 9;
            // 
            // SEND_DATA_LABEL
            // 
            this.SEND_DATA_LABEL.AutoSize = true;
            this.SEND_DATA_LABEL.Location = new System.Drawing.Point(12, 150);
            this.SEND_DATA_LABEL.Name = "SEND_DATA_LABEL";
            this.SEND_DATA_LABEL.Size = new System.Drawing.Size(70, 12);
            this.SEND_DATA_LABEL.TabIndex = 10;
            this.SEND_DATA_LABEL.Text = "SEND DATA";
            this.SEND_DATA_LABEL.Click += new System.EventHandler(this.SEND_DATA_LABEL_Click);
            // 
            // RECEVED_DATA_LABEL
            // 
            this.RECEVED_DATA_LABEL.AutoSize = true;
            this.RECEVED_DATA_LABEL.Location = new System.Drawing.Point(179, 150);
            this.RECEVED_DATA_LABEL.Name = "RECEVED_DATA_LABEL";
            this.RECEVED_DATA_LABEL.Size = new System.Drawing.Size(93, 12);
            this.RECEVED_DATA_LABEL.TabIndex = 11;
            this.RECEVED_DATA_LABEL.Text = "RECEVED DATA";
            // 
            // STOP_BUTTON
            // 
            this.STOP_BUTTON.Location = new System.Drawing.Point(83, 37);
            this.STOP_BUTTON.Name = "STOP_BUTTON";
            this.STOP_BUTTON.Size = new System.Drawing.Size(75, 23);
            this.STOP_BUTTON.TabIndex = 12;
            this.STOP_BUTTON.Text = "STOP";
            this.STOP_BUTTON.UseVisualStyleBackColor = true;
            this.STOP_BUTTON.Click += new System.EventHandler(this.STOP_BUTTON_Click);
            // 
            // SAVE_BUTTON
            // 
            this.SAVE_BUTTON.Location = new System.Drawing.Point(260, 37);
            this.SAVE_BUTTON.Name = "SAVE_BUTTON";
            this.SAVE_BUTTON.Size = new System.Drawing.Size(81, 23);
            this.SAVE_BUTTON.TabIndex = 13;
            this.SAVE_BUTTON.Text = "SAVE";
            this.SAVE_BUTTON.UseVisualStyleBackColor = true;
            this.SAVE_BUTTON.Click += new System.EventHandler(this.SAVE_BUTTON_Click);
            // 
            // STATUS_LABEL
            // 
            this.STATUS_LABEL.AutoSize = true;
            this.STATUS_LABEL.Location = new System.Drawing.Point(14, 79);
            this.STATUS_LABEL.Name = "STATUS_LABEL";
            this.STATUS_LABEL.Size = new System.Drawing.Size(49, 12);
            this.STATUS_LABEL.TabIndex = 14;
            this.STATUS_LABEL.Text = "STATUS";
            // 
            // plot_data
            // 
            chartArea5.AxisY.LabelStyle.Format = "{0:F0}";
            chartArea5.Name = "ChartArea1";
            this.plot_data.ChartAreas.Add(chartArea5);
            legend5.Name = "Legend1";
            this.plot_data.Legends.Add(legend5);
            this.plot_data.Location = new System.Drawing.Point(347, 5);
            this.plot_data.Name = "plot_data";
            series13.ChartArea = "ChartArea1";
            series13.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series13.Legend = "Legend1";
            series13.Name = "data1";
            series14.ChartArea = "ChartArea1";
            series14.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series14.Legend = "Legend1";
            series14.Name = "data2";
            series15.ChartArea = "ChartArea1";
            series15.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastPoint;
            series15.Legend = "Legend1";
            series15.Name = "data3";
            this.plot_data.Series.Add(series13);
            this.plot_data.Series.Add(series14);
            this.plot_data.Series.Add(series15);
            this.plot_data.Size = new System.Drawing.Size(956, 320);
            this.plot_data.TabIndex = 38;
            this.plot_data.Text = "XI ETA";
            // 
            // trackBar_limb1
            // 
            this.trackBar_limb1.LargeChange = 1;
            this.trackBar_limb1.Location = new System.Drawing.Point(23, 28);
            this.trackBar_limb1.Maximum = 180;
            this.trackBar_limb1.Name = "trackBar_limb1";
            this.trackBar_limb1.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb1.TabIndex = 1;
            this.trackBar_limb1.Value = 90;
            this.trackBar_limb1.Scroll += new System.EventHandler(this.trackBar_limb1_Scroll);
            // 
            // MPUTIME_LABEL
            // 
            this.MPUTIME_LABEL.AutoSize = true;
            this.MPUTIME_LABEL.Location = new System.Drawing.Point(14, 350);
            this.MPUTIME_LABEL.Name = "MPUTIME_LABEL";
            this.MPUTIME_LABEL.Size = new System.Drawing.Size(58, 12);
            this.MPUTIME_LABEL.TabIndex = 67;
            this.MPUTIME_LABEL.Text = "MPU Time";
            // 
            // MPUSTATUS_LABEL
            // 
            this.MPUSTATUS_LABEL.AutoSize = true;
            this.MPUSTATUS_LABEL.Location = new System.Drawing.Point(14, 338);
            this.MPUSTATUS_LABEL.Name = "MPUSTATUS_LABEL";
            this.MPUSTATUS_LABEL.Size = new System.Drawing.Size(66, 12);
            this.MPUSTATUS_LABEL.TabIndex = 45;
            this.MPUSTATUS_LABEL.Text = "MPU Status";
            // 
            // label_limb1
            // 
            this.label_limb1.AutoSize = true;
            this.label_limb1.Location = new System.Drawing.Point(59, 13);
            this.label_limb1.Name = "label_limb1";
            this.label_limb1.Size = new System.Drawing.Size(35, 12);
            this.label_limb1.TabIndex = 101;
            this.label_limb1.Text = "Limb1";
            // 
            // label_limb2
            // 
            this.label_limb2.AutoSize = true;
            this.label_limb2.Location = new System.Drawing.Point(59, 73);
            this.label_limb2.Name = "label_limb2";
            this.label_limb2.Size = new System.Drawing.Size(35, 12);
            this.label_limb2.TabIndex = 103;
            this.label_limb2.Text = "Limb2";
            // 
            // trackBar_limb2
            // 
            this.trackBar_limb2.LargeChange = 1;
            this.trackBar_limb2.Location = new System.Drawing.Point(23, 88);
            this.trackBar_limb2.Maximum = 180;
            this.trackBar_limb2.Name = "trackBar_limb2";
            this.trackBar_limb2.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb2.TabIndex = 2;
            this.trackBar_limb2.Value = 90;
            this.trackBar_limb2.Scroll += new System.EventHandler(this.trackBar_limb2_Scroll);
            // 
            // label_limb3
            // 
            this.label_limb3.AutoSize = true;
            this.label_limb3.Location = new System.Drawing.Point(59, 137);
            this.label_limb3.Name = "label_limb3";
            this.label_limb3.Size = new System.Drawing.Size(35, 12);
            this.label_limb3.TabIndex = 105;
            this.label_limb3.Text = "Limb3";
            // 
            // trackBar_limb3
            // 
            this.trackBar_limb3.LargeChange = 1;
            this.trackBar_limb3.Location = new System.Drawing.Point(23, 152);
            this.trackBar_limb3.Maximum = 180;
            this.trackBar_limb3.Name = "trackBar_limb3";
            this.trackBar_limb3.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb3.TabIndex = 3;
            this.trackBar_limb3.Value = 90;
            this.trackBar_limb3.Scroll += new System.EventHandler(this.trackBar_limb3_Scroll);
            // 
            // label_limb7
            // 
            this.label_limb7.AutoSize = true;
            this.label_limb7.Location = new System.Drawing.Point(196, 137);
            this.label_limb7.Name = "label_limb7";
            this.label_limb7.Size = new System.Drawing.Size(35, 12);
            this.label_limb7.TabIndex = 111;
            this.label_limb7.Text = "Limb7";
            // 
            // trackBar_limb7
            // 
            this.trackBar_limb7.LargeChange = 1;
            this.trackBar_limb7.Location = new System.Drawing.Point(160, 152);
            this.trackBar_limb7.Maximum = 180;
            this.trackBar_limb7.Name = "trackBar_limb7";
            this.trackBar_limb7.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb7.TabIndex = 7;
            this.trackBar_limb7.Value = 90;
            this.trackBar_limb7.Scroll += new System.EventHandler(this.trackBar_limb7_Scroll);
            // 
            // label_limb6
            // 
            this.label_limb6.AutoSize = true;
            this.label_limb6.Location = new System.Drawing.Point(196, 73);
            this.label_limb6.Name = "label_limb6";
            this.label_limb6.Size = new System.Drawing.Size(35, 12);
            this.label_limb6.TabIndex = 109;
            this.label_limb6.Text = "Limb6";
            // 
            // trackBar_limb6
            // 
            this.trackBar_limb6.LargeChange = 1;
            this.trackBar_limb6.Location = new System.Drawing.Point(160, 88);
            this.trackBar_limb6.Maximum = 180;
            this.trackBar_limb6.Name = "trackBar_limb6";
            this.trackBar_limb6.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb6.TabIndex = 6;
            this.trackBar_limb6.Value = 90;
            this.trackBar_limb6.Scroll += new System.EventHandler(this.trackBar_limb6_Scroll);
            // 
            // label_limb5
            // 
            this.label_limb5.AutoSize = true;
            this.label_limb5.Location = new System.Drawing.Point(196, 13);
            this.label_limb5.Name = "label_limb5";
            this.label_limb5.Size = new System.Drawing.Size(35, 12);
            this.label_limb5.TabIndex = 107;
            this.label_limb5.Text = "Limb5";
            // 
            // trackBar_limb5
            // 
            this.trackBar_limb5.LargeChange = 1;
            this.trackBar_limb5.Location = new System.Drawing.Point(160, 28);
            this.trackBar_limb5.Maximum = 180;
            this.trackBar_limb5.Name = "trackBar_limb5";
            this.trackBar_limb5.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb5.TabIndex = 5;
            this.trackBar_limb5.Value = 90;
            this.trackBar_limb5.Scroll += new System.EventHandler(this.trackBar_limb5_Scroll);
            // 
            // label_limb11
            // 
            this.label_limb11.AutoSize = true;
            this.label_limb11.Location = new System.Drawing.Point(334, 137);
            this.label_limb11.Name = "label_limb11";
            this.label_limb11.Size = new System.Drawing.Size(41, 12);
            this.label_limb11.TabIndex = 117;
            this.label_limb11.Text = "Limb11";
            // 
            // trackBar_limb11
            // 
            this.trackBar_limb11.LargeChange = 1;
            this.trackBar_limb11.Location = new System.Drawing.Point(298, 152);
            this.trackBar_limb11.Maximum = 180;
            this.trackBar_limb11.Name = "trackBar_limb11";
            this.trackBar_limb11.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb11.TabIndex = 11;
            this.trackBar_limb11.Value = 90;
            this.trackBar_limb11.Scroll += new System.EventHandler(this.trackBar_limb11_Scroll);
            // 
            // label_limb10
            // 
            this.label_limb10.AutoSize = true;
            this.label_limb10.Location = new System.Drawing.Point(334, 73);
            this.label_limb10.Name = "label_limb10";
            this.label_limb10.Size = new System.Drawing.Size(41, 12);
            this.label_limb10.TabIndex = 115;
            this.label_limb10.Text = "Limb10";
            // 
            // trackBar_limb10
            // 
            this.trackBar_limb10.LargeChange = 1;
            this.trackBar_limb10.Location = new System.Drawing.Point(298, 88);
            this.trackBar_limb10.Maximum = 180;
            this.trackBar_limb10.Name = "trackBar_limb10";
            this.trackBar_limb10.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb10.TabIndex = 10;
            this.trackBar_limb10.Value = 90;
            this.trackBar_limb10.Scroll += new System.EventHandler(this.trackBar_limb10_Scroll);
            // 
            // label_limb9
            // 
            this.label_limb9.AutoSize = true;
            this.label_limb9.Location = new System.Drawing.Point(334, 13);
            this.label_limb9.Name = "label_limb9";
            this.label_limb9.Size = new System.Drawing.Size(35, 12);
            this.label_limb9.TabIndex = 113;
            this.label_limb9.Text = "Limb9";
            // 
            // trackBar_limb9
            // 
            this.trackBar_limb9.LargeChange = 1;
            this.trackBar_limb9.Location = new System.Drawing.Point(298, 28);
            this.trackBar_limb9.Maximum = 180;
            this.trackBar_limb9.Name = "trackBar_limb9";
            this.trackBar_limb9.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb9.TabIndex = 9;
            this.trackBar_limb9.Value = 90;
            this.trackBar_limb9.Scroll += new System.EventHandler(this.trackBar_limb9_Scroll);
            // 
            // label_limb15
            // 
            this.label_limb15.AutoSize = true;
            this.label_limb15.Location = new System.Drawing.Point(471, 137);
            this.label_limb15.Name = "label_limb15";
            this.label_limb15.Size = new System.Drawing.Size(41, 12);
            this.label_limb15.TabIndex = 123;
            this.label_limb15.Text = "Limb15";
            // 
            // trackBar_limb15
            // 
            this.trackBar_limb15.LargeChange = 1;
            this.trackBar_limb15.Location = new System.Drawing.Point(435, 152);
            this.trackBar_limb15.Maximum = 180;
            this.trackBar_limb15.Name = "trackBar_limb15";
            this.trackBar_limb15.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb15.TabIndex = 15;
            this.trackBar_limb15.Value = 90;
            this.trackBar_limb15.Scroll += new System.EventHandler(this.trackBar_limb15_Scroll);
            // 
            // label_limb14
            // 
            this.label_limb14.AutoSize = true;
            this.label_limb14.Location = new System.Drawing.Point(471, 73);
            this.label_limb14.Name = "label_limb14";
            this.label_limb14.Size = new System.Drawing.Size(41, 12);
            this.label_limb14.TabIndex = 121;
            this.label_limb14.Text = "Limb14";
            // 
            // trackBar_limb14
            // 
            this.trackBar_limb14.LargeChange = 1;
            this.trackBar_limb14.Location = new System.Drawing.Point(435, 88);
            this.trackBar_limb14.Maximum = 180;
            this.trackBar_limb14.Name = "trackBar_limb14";
            this.trackBar_limb14.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb14.TabIndex = 14;
            this.trackBar_limb14.Value = 90;
            this.trackBar_limb14.Scroll += new System.EventHandler(this.trackBar_limb14_Scroll);
            // 
            // label_limb13
            // 
            this.label_limb13.AutoSize = true;
            this.label_limb13.Location = new System.Drawing.Point(471, 13);
            this.label_limb13.Name = "label_limb13";
            this.label_limb13.Size = new System.Drawing.Size(41, 12);
            this.label_limb13.TabIndex = 119;
            this.label_limb13.Text = "Limb13";
            // 
            // trackBar_limb13
            // 
            this.trackBar_limb13.LargeChange = 1;
            this.trackBar_limb13.Location = new System.Drawing.Point(435, 28);
            this.trackBar_limb13.Maximum = 180;
            this.trackBar_limb13.Name = "trackBar_limb13";
            this.trackBar_limb13.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limb13.TabIndex = 13;
            this.trackBar_limb13.Value = 90;
            this.trackBar_limb13.Scroll += new System.EventHandler(this.trackBar_limb13_Scroll);
            // 
            // PCSTATUS_LABEL
            // 
            this.PCSTATUS_LABEL.AutoSize = true;
            this.PCSTATUS_LABEL.Location = new System.Drawing.Point(179, 338);
            this.PCSTATUS_LABEL.Name = "PCSTATUS_LABEL";
            this.PCSTATUS_LABEL.Size = new System.Drawing.Size(66, 12);
            this.PCSTATUS_LABEL.TabIndex = 124;
            this.PCSTATUS_LABEL.Text = "MPU Status";
            // 
            // PCSTATUS_TEXTBOX
            // 
            this.PCSTATUS_TEXTBOX.Location = new System.Drawing.Point(251, 335);
            this.PCSTATUS_TEXTBOX.Multiline = true;
            this.PCSTATUS_TEXTBOX.Name = "PCSTATUS_TEXTBOX";
            this.PCSTATUS_TEXTBOX.Size = new System.Drawing.Size(53, 19);
            this.PCSTATUS_TEXTBOX.TabIndex = 125;
            // 
            // label_limbpos3
            // 
            this.label_limbpos3.AutoSize = true;
            this.label_limbpos3.Location = new System.Drawing.Point(42, 193);
            this.label_limbpos3.Name = "label_limbpos3";
            this.label_limbpos3.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos3.TabIndex = 131;
            this.label_limbpos3.Text = "Leg1_Z";
            // 
            // trackBar_limbpos3
            // 
            this.trackBar_limbpos3.LargeChange = 1;
            this.trackBar_limbpos3.Location = new System.Drawing.Point(6, 208);
            this.trackBar_limbpos3.Maximum = 100;
            this.trackBar_limbpos3.Name = "trackBar_limbpos3";
            this.trackBar_limbpos3.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos3.TabIndex = 128;
            this.trackBar_limbpos3.Value = 50;
            this.trackBar_limbpos3.Scroll += new System.EventHandler(this.trackBar_limbpos3_Scroll);
            // 
            // label_limbpos2
            // 
            this.label_limbpos2.AutoSize = true;
            this.label_limbpos2.Location = new System.Drawing.Point(42, 129);
            this.label_limbpos2.Name = "label_limbpos2";
            this.label_limbpos2.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos2.TabIndex = 130;
            this.label_limbpos2.Text = "Leg1_Y";
            // 
            // trackBar_limbpos2
            // 
            this.trackBar_limbpos2.LargeChange = 1;
            this.trackBar_limbpos2.Location = new System.Drawing.Point(6, 144);
            this.trackBar_limbpos2.Maximum = 100;
            this.trackBar_limbpos2.Name = "trackBar_limbpos2";
            this.trackBar_limbpos2.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos2.TabIndex = 127;
            this.trackBar_limbpos2.Value = 50;
            this.trackBar_limbpos2.Scroll += new System.EventHandler(this.trackBar_limbpos2_Scroll);
            // 
            // label_limbpos1
            // 
            this.label_limbpos1.AutoSize = true;
            this.label_limbpos1.Location = new System.Drawing.Point(42, 69);
            this.label_limbpos1.Name = "label_limbpos1";
            this.label_limbpos1.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos1.TabIndex = 129;
            this.label_limbpos1.Text = "Leg1_X";
            // 
            // trackBar_limbpos1
            // 
            this.trackBar_limbpos1.LargeChange = 1;
            this.trackBar_limbpos1.Location = new System.Drawing.Point(6, 84);
            this.trackBar_limbpos1.Maximum = 100;
            this.trackBar_limbpos1.Name = "trackBar_limbpos1";
            this.trackBar_limbpos1.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos1.TabIndex = 126;
            this.trackBar_limbpos1.Value = 50;
            this.trackBar_limbpos1.Scroll += new System.EventHandler(this.trackBar_limbpos1_Scroll);
            // 
            // radioButton_mode1
            // 
            this.radioButton_mode1.AutoSize = true;
            this.radioButton_mode1.Location = new System.Drawing.Point(19, 18);
            this.radioButton_mode1.Name = "radioButton_mode1";
            this.radioButton_mode1.Size = new System.Drawing.Size(83, 16);
            this.radioButton_mode1.TabIndex = 132;
            this.radioButton_mode1.TabStop = true;
            this.radioButton_mode1.Text = "Angle mode";
            this.radioButton_mode1.UseVisualStyleBackColor = true;
            this.radioButton_mode1.CheckedChanged += new System.EventHandler(this.radioButton_mode1_CheckedChanged);
            // 
            // radioButton_mode2
            // 
            this.radioButton_mode2.AutoSize = true;
            this.radioButton_mode2.Location = new System.Drawing.Point(19, 43);
            this.radioButton_mode2.Name = "radioButton_mode2";
            this.radioButton_mode2.Size = new System.Drawing.Size(95, 16);
            this.radioButton_mode2.TabIndex = 133;
            this.radioButton_mode2.TabStop = true;
            this.radioButton_mode2.Text = "Position mode";
            this.radioButton_mode2.UseVisualStyleBackColor = true;
            this.radioButton_mode2.CheckedChanged += new System.EventHandler(this.radioButton_mode2_CheckedChanged);
            // 
            // groupBox_modeselect1
            // 
            this.groupBox_modeselect1.Controls.Add(this.radioButton_mode1);
            this.groupBox_modeselect1.Controls.Add(this.radioButton_mode2);
            this.groupBox_modeselect1.Location = new System.Drawing.Point(191, 66);
            this.groupBox_modeselect1.Name = "groupBox_modeselect1";
            this.groupBox_modeselect1.Size = new System.Drawing.Size(134, 69);
            this.groupBox_modeselect1.TabIndex = 134;
            this.groupBox_modeselect1.TabStop = false;
            this.groupBox_modeselect1.Text = "Mode select";
            // 
            // groupBox_angle
            // 
            this.groupBox_angle.Controls.Add(this.trackBar_limb3);
            this.groupBox_angle.Controls.Add(this.trackBar_limb1);
            this.groupBox_angle.Controls.Add(this.label_limb1);
            this.groupBox_angle.Controls.Add(this.trackBar_limb2);
            this.groupBox_angle.Controls.Add(this.label_limb2);
            this.groupBox_angle.Controls.Add(this.label_limb3);
            this.groupBox_angle.Controls.Add(this.trackBar_limb5);
            this.groupBox_angle.Controls.Add(this.label_limb5);
            this.groupBox_angle.Controls.Add(this.trackBar_limb6);
            this.groupBox_angle.Controls.Add(this.label_limb6);
            this.groupBox_angle.Controls.Add(this.label_limb15);
            this.groupBox_angle.Controls.Add(this.trackBar_limb7);
            this.groupBox_angle.Controls.Add(this.trackBar_limb15);
            this.groupBox_angle.Controls.Add(this.label_limb7);
            this.groupBox_angle.Controls.Add(this.label_limb14);
            this.groupBox_angle.Controls.Add(this.trackBar_limb9);
            this.groupBox_angle.Controls.Add(this.trackBar_limb14);
            this.groupBox_angle.Controls.Add(this.label_limb9);
            this.groupBox_angle.Controls.Add(this.label_limb13);
            this.groupBox_angle.Controls.Add(this.trackBar_limb10);
            this.groupBox_angle.Controls.Add(this.trackBar_limb13);
            this.groupBox_angle.Controls.Add(this.label_limb10);
            this.groupBox_angle.Controls.Add(this.label_limb11);
            this.groupBox_angle.Controls.Add(this.trackBar_limb11);
            this.groupBox_angle.Location = new System.Drawing.Point(16, 376);
            this.groupBox_angle.Name = "groupBox_angle";
            this.groupBox_angle.Size = new System.Drawing.Size(582, 211);
            this.groupBox_angle.TabIndex = 135;
            this.groupBox_angle.TabStop = false;
            this.groupBox_angle.Text = "angle";
            // 
            // groupBox_pos
            // 
            this.groupBox_pos.Controls.Add(this.trackBar_dutycycle);
            this.groupBox_pos.Controls.Add(this.trackBar_cgposx);
            this.groupBox_pos.Controls.Add(this.label_cgposx);
            this.groupBox_pos.Controls.Add(this.trackBar_cgposy);
            this.groupBox_pos.Controls.Add(this.label_cgposz);
            this.groupBox_pos.Controls.Add(this.label_cgposy);
            this.groupBox_pos.Controls.Add(this.trackBar_cgposz);
            this.groupBox_pos.Controls.Add(this.label_dutycycle);
            this.groupBox_pos.Controls.Add(this.radioButton_manual);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos13);
            this.groupBox_pos.Controls.Add(this.label_limbpos13);
            this.groupBox_pos.Controls.Add(this.radioButton_cycle);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos14);
            this.groupBox_pos.Controls.Add(this.label_limbpos15);
            this.groupBox_pos.Controls.Add(this.label_limbpos14);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos15);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos9);
            this.groupBox_pos.Controls.Add(this.label_limbpos9);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos10);
            this.groupBox_pos.Controls.Add(this.label_limbpos11);
            this.groupBox_pos.Controls.Add(this.label_limbpos10);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos11);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos5);
            this.groupBox_pos.Controls.Add(this.label_limbpos5);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos6);
            this.groupBox_pos.Controls.Add(this.label_limbpos7);
            this.groupBox_pos.Controls.Add(this.label_limbpos6);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos7);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos1);
            this.groupBox_pos.Controls.Add(this.label_limbpos1);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos2);
            this.groupBox_pos.Controls.Add(this.label_limbpos3);
            this.groupBox_pos.Controls.Add(this.label_limbpos2);
            this.groupBox_pos.Controls.Add(this.trackBar_limbpos3);
            this.groupBox_pos.Location = new System.Drawing.Point(605, 320);
            this.groupBox_pos.Name = "groupBox_pos";
            this.groupBox_pos.Size = new System.Drawing.Size(698, 267);
            this.groupBox_pos.TabIndex = 136;
            this.groupBox_pos.TabStop = false;
            this.groupBox_pos.Text = "position";
            // 
            // trackBar_limbpos13
            // 
            this.trackBar_limbpos13.LargeChange = 1;
            this.trackBar_limbpos13.Location = new System.Drawing.Point(413, 84);
            this.trackBar_limbpos13.Maximum = 100;
            this.trackBar_limbpos13.Name = "trackBar_limbpos13";
            this.trackBar_limbpos13.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos13.TabIndex = 144;
            this.trackBar_limbpos13.Value = 50;
            this.trackBar_limbpos13.Scroll += new System.EventHandler(this.trackBar_limbpos13_Scroll);
            // 
            // label_limbpos13
            // 
            this.label_limbpos13.AutoSize = true;
            this.label_limbpos13.Location = new System.Drawing.Point(449, 69);
            this.label_limbpos13.Name = "label_limbpos13";
            this.label_limbpos13.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos13.TabIndex = 147;
            this.label_limbpos13.Text = "Leg4_X";
            // 
            // trackBar_limbpos14
            // 
            this.trackBar_limbpos14.LargeChange = 1;
            this.trackBar_limbpos14.Location = new System.Drawing.Point(413, 144);
            this.trackBar_limbpos14.Maximum = 100;
            this.trackBar_limbpos14.Name = "trackBar_limbpos14";
            this.trackBar_limbpos14.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos14.TabIndex = 145;
            this.trackBar_limbpos14.Value = 50;
            this.trackBar_limbpos14.Scroll += new System.EventHandler(this.trackBar_limbpos14_Scroll);
            // 
            // label_limbpos15
            // 
            this.label_limbpos15.AutoSize = true;
            this.label_limbpos15.Location = new System.Drawing.Point(449, 193);
            this.label_limbpos15.Name = "label_limbpos15";
            this.label_limbpos15.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos15.TabIndex = 149;
            this.label_limbpos15.Text = "Leg4_Z";
            // 
            // label_limbpos14
            // 
            this.label_limbpos14.AutoSize = true;
            this.label_limbpos14.Location = new System.Drawing.Point(449, 129);
            this.label_limbpos14.Name = "label_limbpos14";
            this.label_limbpos14.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos14.TabIndex = 148;
            this.label_limbpos14.Text = "Leg4_Y";
            // 
            // trackBar_limbpos15
            // 
            this.trackBar_limbpos15.LargeChange = 1;
            this.trackBar_limbpos15.Location = new System.Drawing.Point(413, 208);
            this.trackBar_limbpos15.Maximum = 100;
            this.trackBar_limbpos15.Name = "trackBar_limbpos15";
            this.trackBar_limbpos15.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos15.TabIndex = 146;
            this.trackBar_limbpos15.Value = 50;
            this.trackBar_limbpos15.Scroll += new System.EventHandler(this.trackBar_limbpos15_Scroll);
            // 
            // trackBar_limbpos9
            // 
            this.trackBar_limbpos9.LargeChange = 1;
            this.trackBar_limbpos9.Location = new System.Drawing.Point(281, 84);
            this.trackBar_limbpos9.Maximum = 100;
            this.trackBar_limbpos9.Name = "trackBar_limbpos9";
            this.trackBar_limbpos9.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos9.TabIndex = 138;
            this.trackBar_limbpos9.Value = 50;
            this.trackBar_limbpos9.Scroll += new System.EventHandler(this.trackBar_limbpos9_Scroll);
            // 
            // label_limbpos9
            // 
            this.label_limbpos9.AutoSize = true;
            this.label_limbpos9.Location = new System.Drawing.Point(317, 69);
            this.label_limbpos9.Name = "label_limbpos9";
            this.label_limbpos9.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos9.TabIndex = 141;
            this.label_limbpos9.Text = "Leg3_X";
            // 
            // trackBar_limbpos10
            // 
            this.trackBar_limbpos10.LargeChange = 1;
            this.trackBar_limbpos10.Location = new System.Drawing.Point(281, 144);
            this.trackBar_limbpos10.Maximum = 100;
            this.trackBar_limbpos10.Name = "trackBar_limbpos10";
            this.trackBar_limbpos10.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos10.TabIndex = 139;
            this.trackBar_limbpos10.Value = 50;
            this.trackBar_limbpos10.Scroll += new System.EventHandler(this.trackBar_limbpos10_Scroll);
            // 
            // label_limbpos11
            // 
            this.label_limbpos11.AutoSize = true;
            this.label_limbpos11.Location = new System.Drawing.Point(317, 193);
            this.label_limbpos11.Name = "label_limbpos11";
            this.label_limbpos11.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos11.TabIndex = 143;
            this.label_limbpos11.Text = "Leg3_Z";
            // 
            // label_limbpos10
            // 
            this.label_limbpos10.AutoSize = true;
            this.label_limbpos10.Location = new System.Drawing.Point(317, 129);
            this.label_limbpos10.Name = "label_limbpos10";
            this.label_limbpos10.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos10.TabIndex = 142;
            this.label_limbpos10.Text = "Leg3_Y";
            // 
            // trackBar_limbpos11
            // 
            this.trackBar_limbpos11.LargeChange = 1;
            this.trackBar_limbpos11.Location = new System.Drawing.Point(281, 208);
            this.trackBar_limbpos11.Maximum = 100;
            this.trackBar_limbpos11.Name = "trackBar_limbpos11";
            this.trackBar_limbpos11.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos11.TabIndex = 140;
            this.trackBar_limbpos11.Value = 50;
            this.trackBar_limbpos11.Scroll += new System.EventHandler(this.trackBar_limbpos11_Scroll);
            // 
            // trackBar_limbpos5
            // 
            this.trackBar_limbpos5.LargeChange = 1;
            this.trackBar_limbpos5.Location = new System.Drawing.Point(143, 84);
            this.trackBar_limbpos5.Maximum = 100;
            this.trackBar_limbpos5.Name = "trackBar_limbpos5";
            this.trackBar_limbpos5.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos5.TabIndex = 132;
            this.trackBar_limbpos5.Value = 50;
            this.trackBar_limbpos5.Scroll += new System.EventHandler(this.trackBar_limbpos5_Scroll);
            // 
            // label_limbpos5
            // 
            this.label_limbpos5.AutoSize = true;
            this.label_limbpos5.Location = new System.Drawing.Point(179, 69);
            this.label_limbpos5.Name = "label_limbpos5";
            this.label_limbpos5.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos5.TabIndex = 135;
            this.label_limbpos5.Text = "Leg2_X";
            // 
            // trackBar_limbpos6
            // 
            this.trackBar_limbpos6.LargeChange = 1;
            this.trackBar_limbpos6.Location = new System.Drawing.Point(143, 144);
            this.trackBar_limbpos6.Maximum = 100;
            this.trackBar_limbpos6.Name = "trackBar_limbpos6";
            this.trackBar_limbpos6.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos6.TabIndex = 133;
            this.trackBar_limbpos6.Value = 50;
            this.trackBar_limbpos6.Scroll += new System.EventHandler(this.trackBar_limbpos6_Scroll);
            // 
            // label_limbpos7
            // 
            this.label_limbpos7.AutoSize = true;
            this.label_limbpos7.Location = new System.Drawing.Point(179, 193);
            this.label_limbpos7.Name = "label_limbpos7";
            this.label_limbpos7.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos7.TabIndex = 137;
            this.label_limbpos7.Text = "Leg2_Z";
            // 
            // label_limbpos6
            // 
            this.label_limbpos6.AutoSize = true;
            this.label_limbpos6.Location = new System.Drawing.Point(179, 129);
            this.label_limbpos6.Name = "label_limbpos6";
            this.label_limbpos6.Size = new System.Drawing.Size(40, 12);
            this.label_limbpos6.TabIndex = 136;
            this.label_limbpos6.Text = "Leg2_Y";
            // 
            // trackBar_limbpos7
            // 
            this.trackBar_limbpos7.LargeChange = 1;
            this.trackBar_limbpos7.Location = new System.Drawing.Point(143, 208);
            this.trackBar_limbpos7.Maximum = 100;
            this.trackBar_limbpos7.Name = "trackBar_limbpos7";
            this.trackBar_limbpos7.Size = new System.Drawing.Size(142, 45);
            this.trackBar_limbpos7.TabIndex = 134;
            this.trackBar_limbpos7.Value = 50;
            this.trackBar_limbpos7.Scroll += new System.EventHandler(this.trackBar_limbpos7_Scroll);
            // 
            // radioButton_manual
            // 
            this.radioButton_manual.AutoSize = true;
            this.radioButton_manual.Location = new System.Drawing.Point(17, 28);
            this.radioButton_manual.Name = "radioButton_manual";
            this.radioButton_manual.Size = new System.Drawing.Size(90, 16);
            this.radioButton_manual.TabIndex = 134;
            this.radioButton_manual.TabStop = true;
            this.radioButton_manual.Text = "Manual mode";
            this.radioButton_manual.UseVisualStyleBackColor = true;
            this.radioButton_manual.CheckedChanged += new System.EventHandler(this.radioButton_manual_CheckedChanged);
            // 
            // radioButton_cycle
            // 
            this.radioButton_cycle.AutoSize = true;
            this.radioButton_cycle.Location = new System.Drawing.Point(125, 28);
            this.radioButton_cycle.Name = "radioButton_cycle";
            this.radioButton_cycle.Size = new System.Drawing.Size(83, 16);
            this.radioButton_cycle.TabIndex = 135;
            this.radioButton_cycle.TabStop = true;
            this.radioButton_cycle.Text = "Cycle mode";
            this.radioButton_cycle.UseVisualStyleBackColor = true;
            this.radioButton_cycle.CheckedChanged += new System.EventHandler(this.radioButton_cycle_CheckedChanged);
            // 
            // label_dutycycle
            // 
            this.label_dutycycle.AutoSize = true;
            this.label_dutycycle.Location = new System.Drawing.Point(259, 32);
            this.label_dutycycle.Name = "label_dutycycle";
            this.label_dutycycle.Size = new System.Drawing.Size(62, 12);
            this.label_dutycycle.TabIndex = 137;
            this.label_dutycycle.Text = "Duty Cycle";
            // 
            // trackBar_cgposx
            // 
            this.trackBar_cgposx.LargeChange = 1;
            this.trackBar_cgposx.Location = new System.Drawing.Point(556, 84);
            this.trackBar_cgposx.Maximum = 100;
            this.trackBar_cgposx.Name = "trackBar_cgposx";
            this.trackBar_cgposx.Size = new System.Drawing.Size(142, 45);
            this.trackBar_cgposx.TabIndex = 150;
            this.trackBar_cgposx.Value = 50;
            this.trackBar_cgposx.Scroll += new System.EventHandler(this.trackBar_cgposx_Scroll);
            // 
            // label_cgposx
            // 
            this.label_cgposx.AutoSize = true;
            this.label_cgposx.Location = new System.Drawing.Point(592, 69);
            this.label_cgposx.Name = "label_cgposx";
            this.label_cgposx.Size = new System.Drawing.Size(32, 12);
            this.label_cgposx.TabIndex = 153;
            this.label_cgposx.Text = "CG_X";
            // 
            // trackBar_cgposy
            // 
            this.trackBar_cgposy.LargeChange = 1;
            this.trackBar_cgposy.Location = new System.Drawing.Point(556, 144);
            this.trackBar_cgposy.Maximum = 100;
            this.trackBar_cgposy.Name = "trackBar_cgposy";
            this.trackBar_cgposy.Size = new System.Drawing.Size(142, 45);
            this.trackBar_cgposy.TabIndex = 151;
            this.trackBar_cgposy.Value = 50;
            this.trackBar_cgposy.Scroll += new System.EventHandler(this.trackBar_cgposy_Scroll);
            // 
            // label_cgposz
            // 
            this.label_cgposz.AutoSize = true;
            this.label_cgposz.Location = new System.Drawing.Point(592, 193);
            this.label_cgposz.Name = "label_cgposz";
            this.label_cgposz.Size = new System.Drawing.Size(32, 12);
            this.label_cgposz.TabIndex = 155;
            this.label_cgposz.Text = "CG_Z";
            // 
            // label_cgposy
            // 
            this.label_cgposy.AutoSize = true;
            this.label_cgposy.Location = new System.Drawing.Point(592, 129);
            this.label_cgposy.Name = "label_cgposy";
            this.label_cgposy.Size = new System.Drawing.Size(32, 12);
            this.label_cgposy.TabIndex = 154;
            this.label_cgposy.Text = "CG_Y";
            // 
            // trackBar_cgposz
            // 
            this.trackBar_cgposz.LargeChange = 1;
            this.trackBar_cgposz.Location = new System.Drawing.Point(556, 208);
            this.trackBar_cgposz.Maximum = 100;
            this.trackBar_cgposz.Name = "trackBar_cgposz";
            this.trackBar_cgposz.Size = new System.Drawing.Size(142, 45);
            this.trackBar_cgposz.TabIndex = 152;
            this.trackBar_cgposz.Value = 50;
            this.trackBar_cgposz.Scroll += new System.EventHandler(this.trackBar_cgposz_Scroll);
            // 
            // trackBar_dutycycle
            // 
            this.trackBar_dutycycle.LargeChange = 1;
            this.trackBar_dutycycle.Location = new System.Drawing.Point(359, 21);
            this.trackBar_dutycycle.Maximum = 100;
            this.trackBar_dutycycle.Name = "trackBar_dutycycle";
            this.trackBar_dutycycle.Size = new System.Drawing.Size(142, 45);
            this.trackBar_dutycycle.TabIndex = 156;
            this.trackBar_dutycycle.Value = 50;
            // 
            // timer4
            // 
            this.timer4.Enabled = false;
            this.timer4.Interval = ((uint)(1u));
            this.timer4.Resolution = ((uint)(1u));
            this.timer4.OnTimer += new control_center.MultiMediaTimerComponent.TimerDelegate(this.timer4_OnTimer);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 589);
            this.Controls.Add(this.groupBox_pos);
            this.Controls.Add(this.groupBox_angle);
            this.Controls.Add(this.groupBox_modeselect1);
            this.Controls.Add(this.PCSTATUS_TEXTBOX);
            this.Controls.Add(this.PCSTATUS_LABEL);
            this.Controls.Add(this.MPUTIME_LABEL);
            this.Controls.Add(this.MPUSTATUS_LABEL);
            this.Controls.Add(this.plot_data);
            this.Controls.Add(this.STATUS_LABEL);
            this.Controls.Add(this.SAVE_BUTTON);
            this.Controls.Add(this.STOP_BUTTON);
            this.Controls.Add(this.RECEVED_DATA_LABEL);
            this.Controls.Add(this.SEND_DATA_LABEL);
            this.Controls.Add(this.RECEVED_DATA_TEXTBOX);
            this.Controls.Add(this.SEND_DATA_TEXTBOX);
            this.Controls.Add(this.CON_BOX);
            this.Controls.Add(this.BAUDRATE_BOX);
            this.Controls.Add(this.START_BUTTON);
            this.Controls.Add(this.TIME_LABEL);
            this.Controls.Add(this.COMPORT_SET_BUTTON);
            this.Controls.Add(this.COMPORT_BOX);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.plot_data)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limb13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos1)).EndInit();
            this.groupBox_modeselect1.ResumeLayout(false);
            this.groupBox_modeselect1.PerformLayout();
            this.groupBox_angle.ResumeLayout(false);
            this.groupBox_angle.PerformLayout();
            this.groupBox_pos.ResumeLayout(false);
            this.groupBox_pos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_limbpos7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_cgposz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_dutycycle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort GETDATA1_SERIALPORT;
        private System.Windows.Forms.ComboBox COMPORT_BOX;
        private System.Windows.Forms.Button COMPORT_SET_BUTTON;
        private System.Windows.Forms.Label TIME_LABEL;
        private System.Windows.Forms.Button START_BUTTON;
        private System.Windows.Forms.ComboBox BAUDRATE_BOX;
        private System.Windows.Forms.ComboBox CON_BOX;
        private System.Windows.Forms.TextBox SEND_DATA_TEXTBOX;
        private System.Windows.Forms.TextBox RECEVED_DATA_TEXTBOX;
        private System.Windows.Forms.Label SEND_DATA_LABEL;
        private System.Windows.Forms.Label RECEVED_DATA_LABEL;
        private control_center.MultiMediaTimerComponent timer4;
        private System.Windows.Forms.Button STOP_BUTTON;
        private System.Windows.Forms.Button SAVE_BUTTON;
        private System.Windows.Forms.Label STATUS_LABEL;
        private System.Windows.Forms.DataVisualization.Charting.Chart plot_data;
        private System.Windows.Forms.TrackBar trackBar_limb1;
        private System.Windows.Forms.Label MPUTIME_LABEL;
        private System.Windows.Forms.Label MPUSTATUS_LABEL;
        private System.Windows.Forms.Label label_limb1;
        private System.Windows.Forms.Label label_limb2;
        private System.Windows.Forms.TrackBar trackBar_limb2;
        private System.Windows.Forms.Label label_limb3;
        private System.Windows.Forms.TrackBar trackBar_limb3;
        private System.Windows.Forms.Label label_limb7;
        private System.Windows.Forms.TrackBar trackBar_limb7;
        private System.Windows.Forms.Label label_limb6;
        private System.Windows.Forms.TrackBar trackBar_limb6;
        private System.Windows.Forms.Label label_limb5;
        private System.Windows.Forms.TrackBar trackBar_limb5;
        private System.Windows.Forms.Label label_limb11;
        private System.Windows.Forms.TrackBar trackBar_limb11;
        private System.Windows.Forms.Label label_limb10;
        private System.Windows.Forms.TrackBar trackBar_limb10;
        private System.Windows.Forms.Label label_limb9;
        private System.Windows.Forms.TrackBar trackBar_limb9;
        private System.Windows.Forms.Label label_limb15;
        private System.Windows.Forms.TrackBar trackBar_limb15;
        private System.Windows.Forms.Label label_limb14;
        private System.Windows.Forms.TrackBar trackBar_limb14;
        private System.Windows.Forms.Label label_limb13;
        private System.Windows.Forms.TrackBar trackBar_limb13;
        private System.Windows.Forms.Label PCSTATUS_LABEL;
        private System.Windows.Forms.TextBox PCSTATUS_TEXTBOX;
        private System.Windows.Forms.Label label_limbpos3;
        private System.Windows.Forms.TrackBar trackBar_limbpos3;
        private System.Windows.Forms.Label label_limbpos2;
        private System.Windows.Forms.TrackBar trackBar_limbpos2;
        private System.Windows.Forms.Label label_limbpos1;
        private System.Windows.Forms.TrackBar trackBar_limbpos1;
        private System.Windows.Forms.RadioButton radioButton_mode1;
        private System.Windows.Forms.RadioButton radioButton_mode2;
        private System.Windows.Forms.GroupBox groupBox_modeselect1;
        private System.Windows.Forms.GroupBox groupBox_angle;
        private System.Windows.Forms.GroupBox groupBox_pos;
        private System.Windows.Forms.TrackBar trackBar_limbpos13;
        private System.Windows.Forms.Label label_limbpos13;
        private System.Windows.Forms.TrackBar trackBar_limbpos14;
        private System.Windows.Forms.Label label_limbpos15;
        private System.Windows.Forms.Label label_limbpos14;
        private System.Windows.Forms.TrackBar trackBar_limbpos15;
        private System.Windows.Forms.TrackBar trackBar_limbpos9;
        private System.Windows.Forms.Label label_limbpos9;
        private System.Windows.Forms.TrackBar trackBar_limbpos10;
        private System.Windows.Forms.Label label_limbpos11;
        private System.Windows.Forms.Label label_limbpos10;
        private System.Windows.Forms.TrackBar trackBar_limbpos11;
        private System.Windows.Forms.TrackBar trackBar_limbpos5;
        private System.Windows.Forms.Label label_limbpos5;
        private System.Windows.Forms.TrackBar trackBar_limbpos6;
        private System.Windows.Forms.Label label_limbpos7;
        private System.Windows.Forms.Label label_limbpos6;
        private System.Windows.Forms.TrackBar trackBar_limbpos7;
        private System.Windows.Forms.TrackBar trackBar_dutycycle;
        private System.Windows.Forms.TrackBar trackBar_cgposx;
        private System.Windows.Forms.Label label_cgposx;
        private System.Windows.Forms.TrackBar trackBar_cgposy;
        private System.Windows.Forms.Label label_cgposz;
        private System.Windows.Forms.Label label_cgposy;
        private System.Windows.Forms.TrackBar trackBar_cgposz;
        private System.Windows.Forms.Label label_dutycycle;
        private System.Windows.Forms.RadioButton radioButton_manual;
        private System.Windows.Forms.RadioButton radioButton_cycle;
    }
}

