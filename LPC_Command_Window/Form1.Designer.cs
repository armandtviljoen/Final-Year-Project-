
namespace SerialCOMMS
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btn_TestConnection = new System.Windows.Forms.Button();
            this.btn_Disconnect = new System.Windows.Forms.Button();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.lblCOMPort = new System.Windows.Forms.Label();
            this.cb_COMPort = new System.Windows.Forms.ComboBox();
            this.tb_MessageOut = new System.Windows.Forms.TextBox();
            this.tb_MessageIn = new System.Windows.Forms.TextBox();
            this._serialPort = new System.IO.Ports.SerialPort(this.components);
            this.gb_CalSet = new System.Windows.Forms.GroupBox();
            this.btn_FinCal = new System.Windows.Forms.Button();
            this.btn_StartCal = new System.Windows.Forms.Button();
            this.lbl_Coordinates = new System.Windows.Forms.Label();
            this.lbl_CrankCal = new System.Windows.Forms.Label();
            this.lbl_PlanarCal = new System.Windows.Forms.Label();
            this.btn_RotateCrank = new System.Windows.Forms.Button();
            this.btn_ZeroPlane = new System.Windows.Forms.Button();
            this.btn_decrease_y = new System.Windows.Forms.Button();
            this.btn_decrease_x = new System.Windows.Forms.Button();
            this.btn_increase_y = new System.Windows.Forms.Button();
            this.btn_increase_x = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_MessageIn = new System.Windows.Forms.Label();
            this.lbl_MessageOut = new System.Windows.Forms.Label();
            this.gb_CalProc = new System.Windows.Forms.GroupBox();
            this.btn_RunCalProc = new System.Windows.Forms.Button();
            this.lbl_FilePath = new System.Windows.Forms.Label();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_RunPerfProc = new System.Windows.Forms.Button();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.btn_LoadFile = new System.Windows.Forms.Button();
            this.btn_Continue = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gb_CalSet.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gb_CalProc.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btn_TestConnection);
            this.groupBox1.Controls.Add(this.btn_Disconnect);
            this.groupBox1.Controls.Add(this.btn_Connect);
            this.groupBox1.Controls.Add(this.lblCOMPort);
            this.groupBox1.Controls.Add(this.cb_COMPort);
            this.groupBox1.Location = new System.Drawing.Point(13, 12);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox1.Size = new System.Drawing.Size(268, 165);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communications Channel";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 50);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(63, 10);
            this.progressBar1.TabIndex = 12;
            // 
            // btn_TestConnection
            // 
            this.btn_TestConnection.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_TestConnection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_TestConnection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_TestConnection.Location = new System.Drawing.Point(71, 122);
            this.btn_TestConnection.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_TestConnection.Name = "btn_TestConnection";
            this.btn_TestConnection.Size = new System.Drawing.Size(140, 27);
            this.btn_TestConnection.TabIndex = 11;
            this.btn_TestConnection.Text = "Test Connection";
            this.btn_TestConnection.UseVisualStyleBackColor = false;
            this.btn_TestConnection.Click += new System.EventHandler(this.btn_TestConnection_Click);
            // 
            // btn_Disconnect
            // 
            this.btn_Disconnect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Disconnect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Disconnect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Disconnect.Location = new System.Drawing.Point(143, 89);
            this.btn_Disconnect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Disconnect.Name = "btn_Disconnect";
            this.btn_Disconnect.Size = new System.Drawing.Size(100, 27);
            this.btn_Disconnect.TabIndex = 10;
            this.btn_Disconnect.Text = "Disconnect";
            this.btn_Disconnect.UseVisualStyleBackColor = false;
            this.btn_Disconnect.Click += new System.EventHandler(this.btn_Disconnect_Click);
            // 
            // btn_Connect
            // 
            this.btn_Connect.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Connect.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Connect.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Connect.Location = new System.Drawing.Point(31, 89);
            this.btn_Connect.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(100, 27);
            this.btn_Connect.TabIndex = 9;
            this.btn_Connect.Text = "Connect";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Open_Click);
            // 
            // lblCOMPort
            // 
            this.lblCOMPort.AutoSize = true;
            this.lblCOMPort.Location = new System.Drawing.Point(27, 32);
            this.lblCOMPort.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCOMPort.Name = "lblCOMPort";
            this.lblCOMPort.Size = new System.Drawing.Size(69, 15);
            this.lblCOMPort.TabIndex = 1;
            this.lblCOMPort.Text = "COM Port";
            // 
            // cb_COMPort
            // 
            this.cb_COMPort.BackColor = System.Drawing.Color.LightGray;
            this.cb_COMPort.FormattingEnabled = true;
            this.cb_COMPort.Location = new System.Drawing.Point(105, 35);
            this.cb_COMPort.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cb_COMPort.Name = "cb_COMPort";
            this.cb_COMPort.Size = new System.Drawing.Size(136, 23);
            this.cb_COMPort.TabIndex = 0;
            // 
            // tb_MessageOut
            // 
            this.tb_MessageOut.BackColor = System.Drawing.Color.LightGray;
            this.tb_MessageOut.Location = new System.Drawing.Point(21, 46);
            this.tb_MessageOut.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_MessageOut.Multiline = true;
            this.tb_MessageOut.Name = "tb_MessageOut";
            this.tb_MessageOut.Size = new System.Drawing.Size(423, 32);
            this.tb_MessageOut.TabIndex = 1;
            // 
            // tb_MessageIn
            // 
            this.tb_MessageIn.BackColor = System.Drawing.Color.LightGray;
            this.tb_MessageIn.Location = new System.Drawing.Point(21, 105);
            this.tb_MessageIn.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tb_MessageIn.Multiline = true;
            this.tb_MessageIn.Name = "tb_MessageIn";
            this.tb_MessageIn.Size = new System.Drawing.Size(423, 32);
            this.tb_MessageIn.TabIndex = 2;
            // 
            // gb_CalSet
            // 
            this.gb_CalSet.Controls.Add(this.btn_FinCal);
            this.gb_CalSet.Controls.Add(this.btn_StartCal);
            this.gb_CalSet.Controls.Add(this.lbl_Coordinates);
            this.gb_CalSet.Controls.Add(this.lbl_CrankCal);
            this.gb_CalSet.Controls.Add(this.lbl_PlanarCal);
            this.gb_CalSet.Controls.Add(this.btn_RotateCrank);
            this.gb_CalSet.Controls.Add(this.btn_ZeroPlane);
            this.gb_CalSet.Controls.Add(this.btn_decrease_y);
            this.gb_CalSet.Controls.Add(this.btn_decrease_x);
            this.gb_CalSet.Controls.Add(this.btn_increase_y);
            this.gb_CalSet.Controls.Add(this.btn_increase_x);
            this.gb_CalSet.Location = new System.Drawing.Point(16, 183);
            this.gb_CalSet.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb_CalSet.Name = "gb_CalSet";
            this.gb_CalSet.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb_CalSet.Size = new System.Drawing.Size(424, 263);
            this.gb_CalSet.TabIndex = 3;
            this.gb_CalSet.TabStop = false;
            this.gb_CalSet.Text = "Calibration Settings";
            // 
            // btn_FinCal
            // 
            this.btn_FinCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_FinCal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_FinCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_FinCal.Location = new System.Drawing.Point(235, 25);
            this.btn_FinCal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_FinCal.Name = "btn_FinCal";
            this.btn_FinCal.Size = new System.Drawing.Size(145, 27);
            this.btn_FinCal.TabIndex = 20;
            this.btn_FinCal.Text = "Finish_Calibration";
            this.btn_FinCal.UseVisualStyleBackColor = false;
            this.btn_FinCal.Click += new System.EventHandler(this.btn_FinCal_Click);
            // 
            // btn_StartCal
            // 
            this.btn_StartCal.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_StartCal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_StartCal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_StartCal.Location = new System.Drawing.Point(49, 25);
            this.btn_StartCal.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_StartCal.Name = "btn_StartCal";
            this.btn_StartCal.Size = new System.Drawing.Size(145, 27);
            this.btn_StartCal.TabIndex = 19;
            this.btn_StartCal.Text = "Start_Calibration";
            this.btn_StartCal.UseVisualStyleBackColor = false;
            this.btn_StartCal.Click += new System.EventHandler(this.btn_StartCal_Click);
            // 
            // lbl_Coordinates
            // 
            this.lbl_Coordinates.AutoSize = true;
            this.lbl_Coordinates.ForeColor = System.Drawing.Color.Black;
            this.lbl_Coordinates.Location = new System.Drawing.Point(316, 87);
            this.lbl_Coordinates.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Coordinates.Name = "lbl_Coordinates";
            this.lbl_Coordinates.Size = new System.Drawing.Size(69, 15);
            this.lbl_Coordinates.TabIndex = 16;
            this.lbl_Coordinates.Text = "(*ref,*ref)";
            // 
            // lbl_CrankCal
            // 
            this.lbl_CrankCal.AutoSize = true;
            this.lbl_CrankCal.Location = new System.Drawing.Point(13, 194);
            this.lbl_CrankCal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_CrankCal.Name = "lbl_CrankCal";
            this.lbl_CrankCal.Size = new System.Drawing.Size(132, 15);
            this.lbl_CrankCal.TabIndex = 14;
            this.lbl_CrankCal.Text = "Rotate Crank (10%)";
            // 
            // lbl_PlanarCal
            // 
            this.lbl_PlanarCal.AutoSize = true;
            this.lbl_PlanarCal.Location = new System.Drawing.Point(11, 65);
            this.lbl_PlanarCal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_PlanarCal.Name = "lbl_PlanarCal";
            this.lbl_PlanarCal.Size = new System.Drawing.Size(108, 15);
            this.lbl_PlanarCal.TabIndex = 13;
            this.lbl_PlanarCal.Text = "Calibrate Plane";
            // 
            // btn_RotateCrank
            // 
            this.btn_RotateCrank.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_RotateCrank.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RotateCrank.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_RotateCrank.Location = new System.Drawing.Point(49, 218);
            this.btn_RotateCrank.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_RotateCrank.Name = "btn_RotateCrank";
            this.btn_RotateCrank.Size = new System.Drawing.Size(145, 27);
            this.btn_RotateCrank.TabIndex = 9;
            this.btn_RotateCrank.Text = "Rotate Crank";
            this.btn_RotateCrank.UseVisualStyleBackColor = false;
            this.btn_RotateCrank.Click += new System.EventHandler(this.btn_RotateCrank_Click);
            // 
            // btn_ZeroPlane
            // 
            this.btn_ZeroPlane.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_ZeroPlane.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_ZeroPlane.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_ZeroPlane.Location = new System.Drawing.Point(259, 218);
            this.btn_ZeroPlane.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_ZeroPlane.Name = "btn_ZeroPlane";
            this.btn_ZeroPlane.Size = new System.Drawing.Size(145, 27);
            this.btn_ZeroPlane.TabIndex = 10;
            this.btn_ZeroPlane.Text = "Zero Plane";
            this.btn_ZeroPlane.UseVisualStyleBackColor = false;
            this.btn_ZeroPlane.Click += new System.EventHandler(this.btn_ZeroPlane_Click);
            // 
            // btn_decrease_y
            // 
            this.btn_decrease_y.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_decrease_y.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_decrease_y.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_decrease_y.Location = new System.Drawing.Point(155, 87);
            this.btn_decrease_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_decrease_y.Name = "btn_decrease_y";
            this.btn_decrease_y.Size = new System.Drawing.Size(100, 27);
            this.btn_decrease_y.TabIndex = 5;
            this.btn_decrease_y.Text = "Decrease Y";
            this.btn_decrease_y.UseVisualStyleBackColor = false;
            this.btn_decrease_y.Click += new System.EventHandler(this.btn_decrease_y_Click);
            // 
            // btn_decrease_x
            // 
            this.btn_decrease_x.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_decrease_x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_decrease_x.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_decrease_x.Location = new System.Drawing.Point(99, 118);
            this.btn_decrease_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_decrease_x.Name = "btn_decrease_x";
            this.btn_decrease_x.Size = new System.Drawing.Size(100, 27);
            this.btn_decrease_x.TabIndex = 6;
            this.btn_decrease_x.Text = "Decrease X";
            this.btn_decrease_x.UseVisualStyleBackColor = false;
            this.btn_decrease_x.Click += new System.EventHandler(this.btn_decrease_x_Click);
            // 
            // btn_increase_y
            // 
            this.btn_increase_y.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_increase_y.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_increase_y.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_increase_y.Location = new System.Drawing.Point(155, 151);
            this.btn_increase_y.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_increase_y.Name = "btn_increase_y";
            this.btn_increase_y.Size = new System.Drawing.Size(100, 27);
            this.btn_increase_y.TabIndex = 8;
            this.btn_increase_y.Text = "Increase Y";
            this.btn_increase_y.UseVisualStyleBackColor = false;
            this.btn_increase_y.Click += new System.EventHandler(this.btn_increase_y_Click);
            // 
            // btn_increase_x
            // 
            this.btn_increase_x.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_increase_x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_increase_x.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_increase_x.Location = new System.Drawing.Point(211, 118);
            this.btn_increase_x.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_increase_x.Name = "btn_increase_x";
            this.btn_increase_x.Size = new System.Drawing.Size(100, 27);
            this.btn_increase_x.TabIndex = 7;
            this.btn_increase_x.Text = "Increase X";
            this.btn_increase_x.UseVisualStyleBackColor = false;
            this.btn_increase_x.Click += new System.EventHandler(this.btn_increase_x_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_MessageIn);
            this.groupBox3.Controls.Add(this.lbl_MessageOut);
            this.groupBox3.Controls.Add(this.tb_MessageIn);
            this.groupBox3.Controls.Add(this.tb_MessageOut);
            this.groupBox3.Location = new System.Drawing.Point(289, 12);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.groupBox3.Size = new System.Drawing.Size(475, 165);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Comms";
            // 
            // lbl_MessageIn
            // 
            this.lbl_MessageIn.AutoSize = true;
            this.lbl_MessageIn.Location = new System.Drawing.Point(17, 87);
            this.lbl_MessageIn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MessageIn.Name = "lbl_MessageIn";
            this.lbl_MessageIn.Size = new System.Drawing.Size(130, 15);
            this.lbl_MessageIn.TabIndex = 20;
            this.lbl_MessageIn.Text = "Incoming from LPC";
            // 
            // lbl_MessageOut
            // 
            this.lbl_MessageOut.AutoSize = true;
            this.lbl_MessageOut.Location = new System.Drawing.Point(17, 28);
            this.lbl_MessageOut.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_MessageOut.Name = "lbl_MessageOut";
            this.lbl_MessageOut.Size = new System.Drawing.Size(112, 15);
            this.lbl_MessageOut.TabIndex = 19;
            this.lbl_MessageOut.Text = "Outgoing to LPC";
            // 
            // gb_CalProc
            // 
            this.gb_CalProc.Controls.Add(this.btn_RunCalProc);
            this.gb_CalProc.Controls.Add(this.lbl_FilePath);
            this.gb_CalProc.Controls.Add(this.btn_Stop);
            this.gb_CalProc.Controls.Add(this.btn_RunPerfProc);
            this.gb_CalProc.Controls.Add(this.btn_Pause);
            this.gb_CalProc.Controls.Add(this.btn_LoadFile);
            this.gb_CalProc.Controls.Add(this.btn_Continue);
            this.gb_CalProc.Location = new System.Drawing.Point(448, 183);
            this.gb_CalProc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb_CalProc.Name = "gb_CalProc";
            this.gb_CalProc.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.gb_CalProc.Size = new System.Drawing.Size(316, 263);
            this.gb_CalProc.TabIndex = 5;
            this.gb_CalProc.TabStop = false;
            this.gb_CalProc.Text = "Perforation Procedure";
            // 
            // btn_RunCalProc
            // 
            this.btn_RunCalProc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_RunCalProc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RunCalProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_RunCalProc.Location = new System.Drawing.Point(47, 28);
            this.btn_RunCalProc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_RunCalProc.Name = "btn_RunCalProc";
            this.btn_RunCalProc.Size = new System.Drawing.Size(229, 27);
            this.btn_RunCalProc.TabIndex = 26;
            this.btn_RunCalProc.Text = "Run Calibration Procedure";
            this.btn_RunCalProc.UseVisualStyleBackColor = false;
            this.btn_RunCalProc.Click += new System.EventHandler(this.btn_RunCalProc_Click);
            // 
            // lbl_FilePath
            // 
            this.lbl_FilePath.AutoSize = true;
            this.lbl_FilePath.Location = new System.Drawing.Point(19, 139);
            this.lbl_FilePath.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_FilePath.Name = "lbl_FilePath";
            this.lbl_FilePath.Size = new System.Drawing.Size(83, 15);
            this.lbl_FilePath.TabIndex = 21;
            this.lbl_FilePath.Text = ".../Filename";
            // 
            // btn_Stop
            // 
            this.btn_Stop.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Stop.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Stop.Location = new System.Drawing.Point(91, 218);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(128, 27);
            this.btn_Stop.TabIndex = 25;
            this.btn_Stop.Text = "Stop Procedure";
            this.btn_Stop.UseVisualStyleBackColor = false;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_RunPerfProc
            // 
            this.btn_RunPerfProc.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_RunPerfProc.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_RunPerfProc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_RunPerfProc.Location = new System.Drawing.Point(47, 59);
            this.btn_RunPerfProc.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_RunPerfProc.Name = "btn_RunPerfProc";
            this.btn_RunPerfProc.Size = new System.Drawing.Size(229, 27);
            this.btn_RunPerfProc.TabIndex = 21;
            this.btn_RunPerfProc.Text = "Run Perforation Procedure";
            this.btn_RunPerfProc.UseVisualStyleBackColor = false;
            this.btn_RunPerfProc.Click += new System.EventHandler(this.btn_RunPerfProc_Click);
            // 
            // btn_Pause
            // 
            this.btn_Pause.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Pause.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Pause.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Pause.Location = new System.Drawing.Point(8, 182);
            this.btn_Pause.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(143, 27);
            this.btn_Pause.TabIndex = 22;
            this.btn_Pause.Text = "Pause Procedure";
            this.btn_Pause.UseVisualStyleBackColor = false;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_LoadFile
            // 
            this.btn_LoadFile.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_LoadFile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_LoadFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_LoadFile.Location = new System.Drawing.Point(47, 109);
            this.btn_LoadFile.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_LoadFile.Name = "btn_LoadFile";
            this.btn_LoadFile.Size = new System.Drawing.Size(229, 27);
            this.btn_LoadFile.TabIndex = 21;
            this.btn_LoadFile.Text = "Load File";
            this.btn_LoadFile.UseVisualStyleBackColor = false;
            this.btn_LoadFile.Click += new System.EventHandler(this.btn_LoadFile_Click);
            // 
            // btn_Continue
            // 
            this.btn_Continue.BackColor = System.Drawing.Color.Gainsboro;
            this.btn_Continue.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_Continue.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Continue.Location = new System.Drawing.Point(165, 182);
            this.btn_Continue.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btn_Continue.Name = "btn_Continue";
            this.btn_Continue.Size = new System.Drawing.Size(143, 27);
            this.btn_Continue.TabIndex = 23;
            this.btn_Continue.Text = "Continue";
            this.btn_Continue.UseVisualStyleBackColor = false;
            this.btn_Continue.Click += new System.EventHandler(this.btn_Continue_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(772, 465);
            this.Controls.Add(this.gb_CalProc);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gb_CalSet);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "LPC Command Window";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gb_CalSet.ResumeLayout(false);
            this.gb_CalSet.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gb_CalProc.ResumeLayout(false);
            this.gb_CalProc.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblCOMPort;
        private System.Windows.Forms.ComboBox cb_COMPort;
        private System.Windows.Forms.Button btn_Disconnect;
        private System.Windows.Forms.Button btn_Connect;
        private System.Windows.Forms.TextBox tb_MessageOut;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox tb_MessageIn;
        private System.IO.Ports.SerialPort _serialPort;
        private System.Windows.Forms.Button btn_TestConnection;
        private System.Windows.Forms.GroupBox gb_CalSet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lbl_CrankCal;
        private System.Windows.Forms.Label lbl_PlanarCal;
        private System.Windows.Forms.Button btn_RotateCrank;
        private System.Windows.Forms.Button btn_ZeroPlane;
        private System.Windows.Forms.Button btn_decrease_y;
        private System.Windows.Forms.Button btn_decrease_x;
        private System.Windows.Forms.Button btn_increase_y;
        private System.Windows.Forms.Button btn_increase_x;
        private System.Windows.Forms.Label lbl_Coordinates;
        private System.Windows.Forms.GroupBox gb_CalProc;
        private System.Windows.Forms.Label lbl_MessageIn;
        private System.Windows.Forms.Label lbl_MessageOut;
        private System.Windows.Forms.Button btn_FinCal;
        private System.Windows.Forms.Button btn_StartCal;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.Button btn_RunPerfProc;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Button btn_LoadFile;
        private System.Windows.Forms.Button btn_Continue;
        private System.Windows.Forms.Label lbl_FilePath;
        private System.Windows.Forms.Button btn_RunCalProc;
    }
}

