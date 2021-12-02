using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;

namespace SerialCOMMS
{

    public partial class Form1 : Form
    {
        static Thread calproc; static Thread perfproc; static Thread returnzero;
        int My_X = 0; int My_Y = 0; int C_Dir = 0;
        int CalisRunning = 0; int PerfisRunning = 0;
        int BurnTimeSteps = 300; int BurnTimeCrank = 800;

        int strt_x, strt_y, ln_x, ln_y;

        string messageOut; string[,] matrix;

        string DialogueMessage, DialogueCaption;

        public Form1()
        {
            InitializeComponent();
        }


        // Communications Channel Group.
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            cb_COMPort.Items.AddRange(ports);

            // Update Coordinates;
            lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")";

            // Communications Buttons.
            btn_Disconnect.Enabled = false;
            btn_TestConnection.Enabled = false;
            btn_Connect.Enabled = true;
            // Calibration Buttons.
            btn_StartCal.Enabled = false;
            btn_FinCal.Enabled = false;
            btn_decrease_y.Enabled = false;
            btn_decrease_x.Enabled = false;
            btn_increase_x.Enabled = false;
            btn_increase_y.Enabled = false;
            btn_ZeroPlane.Enabled = false;
            btn_RotateCrank.Enabled = false;
            // Perforation buttons
            btn_RunCalProc.Enabled = false;
            btn_LoadFile.Enabled = false;
            btn_RunPerfProc.Enabled = false;
            btn_Pause.Enabled = false;
            btn_Continue.Enabled = false;
            btn_Stop.Enabled = false;

        }

        private void btn_Open_Click(object sender, EventArgs e)
        {
            _serialPort = new SerialPort();
            try
            {// Allow the user to set the appropriate properties.
                _serialPort.PortName = cb_COMPort.Text;
                _serialPort.BaudRate = 9600;
                _serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), "Even");
                _serialPort.DataBits = 8;
                _serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), "One");
                _serialPort.Handshake = Handshake.None;

                _serialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                _serialPort.Open();
                progressBar1.Value = 100;

                btn_Connect.Enabled = false;
                btn_Disconnect.Enabled = true;
                btn_TestConnection.Enabled = true;
                tb_MessageOut.Text = "You can now test the connection to the LPC.";

            }
            catch (Exception error) {
            DialogueMessage =   "There was a problem selecting your chosen port. Please try again. ";
            DialogueCaption =   "Dear User";

                var result = MessageBox.Show(DialogueMessage, DialogueCaption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);


                // If the yes button was pressed...
                if (result == DialogResult.OK)
                {
                    
                }
            }
        }

        private void btn_Disconnect_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {

                _serialPort.Close();

                tb_MessageIn.Text = " ";
                tb_MessageOut.Text = " ";
                progressBar1.Value = 0;

                // Communications Buttons.
                btn_Disconnect.Enabled = false;
                btn_TestConnection.Enabled = false;
                btn_Connect.Enabled = true;
                // Calibration Buttons.
                btn_StartCal.Enabled = false;
                btn_FinCal.Enabled = false;
                btn_decrease_y.Enabled = false;
                btn_decrease_y.Enabled = false;
                btn_increase_x.Enabled = false;
                btn_increase_x.Enabled = false;
                btn_ZeroPlane.Enabled = false;
                btn_RotateCrank.Enabled = false;
                // Perforation buttons
                btn_RunCalProc.Enabled = false;
                btn_LoadFile.Enabled = false;
                btn_RunPerfProc.Enabled = false;
                btn_Pause.Enabled = false;
                btn_Continue.Enabled = false;
                btn_Stop.Enabled = false;

            }
        }

        private void btn_TestConnection_Click(object sender, EventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                tb_MessageOut.Text = "Are you there LPC?";
                messageOut = "Yes. You may continue to calibration.";
                _serialPort.WriteLine(messageOut);
                btn_StartCal.Enabled = true;
                btn_RunCalProc.Enabled = true;
                btn_TestConnection.Enabled = false;
            }
        }


        // Data Receivced from LPC Controller.
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            string messageIn = _serialPort.ReadLine();
            tb_MessageIn.Invoke((MethodInvoker)(() => tb_MessageIn.Text = messageIn));
        }


        // Calibration Settings Group.
        private void btn_StartCal_Click(object sender, EventArgs e)
        {
            DialogueMessage =
            "You will now be able to move the motors freely. " +
            "Be aware of the limits of the rig as to not damadge the rig by moving out of bounds. " +
            "You will also be able to set the new (0,0) coordinates for the motors for perforation purposes." +
            "Do you wish to proceed?";
            DialogueCaption =
            "Attention";

            var result = MessageBox.Show(DialogueMessage, DialogueCaption,
                                         MessageBoxButtons.OKCancel,
                                         MessageBoxIcon.Question);


            // If the yes button was pressed...
            if (result == DialogResult.OK)
            {

                // Communications Buttons.
                btn_Disconnect.Enabled      = false;
                btn_TestConnection.Enabled  = false;
                btn_Disconnect.Enabled      = false;
                // Calibration Buttons.
                btn_FinCal.Enabled          = true;
                btn_decrease_y.Enabled      = true;
                btn_decrease_x.Enabled      = true;
                btn_increase_x.Enabled      = true;
                btn_increase_y.Enabled      = true;
                btn_ZeroPlane.Enabled       = true;
                btn_RotateCrank.Enabled     = true;

                btn_RunCalProc.Enabled = false;

                messageOut = "Calibrating.";
                _serialPort.WriteLine(messageOut);
                tb_MessageOut.Text = "Calibrating.";
            }
        }

        private void btn_FinCal_Click(object sender, EventArgs e)
        {
            DialogueMessage =
            "You may have changed the relative starting coordinates. " +
            "We recommend that you run the calibration sequence. " +
            "The motors wil actuate from the specified starting coordinates to the outer bounds in a square pattern " +
            "You may interrupt or abort the procedure. " +
            "After the calibration sequence have been performed, feel free to use the perforator.";
            DialogueCaption =
            "Attention";

            var result = MessageBox.Show(DialogueMessage, DialogueCaption,
                                         MessageBoxButtons.OK,
                                         MessageBoxIcon.Information);


            // If the yes button was pressed ...
            if (result == DialogResult.OK)
            {
                btn_Disconnect.Enabled  = true;
                // Calibration Buttons.
                btn_FinCal.Enabled      = false;
                btn_decrease_y.Enabled  = false;
                btn_decrease_y.Enabled  = false;
                btn_decrease_x.Enabled  = false;
                btn_increase_x.Enabled  = false;
                btn_increase_y.Enabled  = false;
                btn_ZeroPlane.Enabled   = false;
                btn_RotateCrank.Enabled = false;
                // Perforation Buttons.
                btn_RunCalProc.Enabled  = true;
                btn_LoadFile.Enabled    = false;

                btn_RunCalProc.Enabled = true;
                messageOut = "Calibration Finished.";
                _serialPort.WriteLine(messageOut);
                tb_MessageOut.Text = "Calibration Finished.";
                
            }
        }

        private void btn_ZeroPlane_Click(object sender, EventArgs e)
        {
            tb_MessageOut.Text = "Zero plane coordinates.";
            My_X = 0;
            My_Y = 0;
            lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")";
        }

        private void btn_increase_x_Click(object sender, EventArgs e)
        {
            inc_X();
        }

        private void btn_increase_y_Click(object sender, EventArgs e)
        {
            inc_Y();
        }

        private void btn_decrease_x_Click(object sender, EventArgs e)
        {
            dec_X();
        }

        private void btn_decrease_y_Click(object sender, EventArgs e)
        {
            dec_Y();
        }

        private void btn_RotateCrank_Click(object sender, EventArgs e)
        {
            messageOut = "5";
            _serialPort.WriteLine(messageOut);

            tb_MessageOut.Text = "Command 5: Rotate Crank (Partial).";
        }


        // Perforation Procedure Group.
        public void btn_RunCalProc_Click(object sender, EventArgs e)
        {
            DialogueMessage = "You are about to start the Calibration Proceduere. You may interrupt or abort the procedure at any time. You may skip this step by pressing no. Do you wish to continue?";
            DialogueCaption = "Attention";

            var result = MessageBox.Show(DialogueMessage, DialogueCaption, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            // If the yes button was pressed ...
            if (result == DialogResult.Yes)
            {
                btn_RunPerfProc.Enabled = false;
                btn_Disconnect.Enabled = false;
                btn_RunCalProc.Enabled = false;
                btn_LoadFile.Enabled = false;
                CalisRunning = 1;
                calproc = new Thread(CalibrationProcedure);
                calproc.Start();

                // Control Buttons.
                btn_StartCal.Enabled    = false;
                btn_Pause.Enabled       = true;
                btn_Continue.Enabled    = true;               
            }
            // If the no button was pressed ...
            if (result == DialogResult.No)
            {
                // Control Buttons.
                btn_LoadFile.Enabled    = true;
            }
        }

        private void btn_LoadFile_Click(object sender, EventArgs e)
        {
            string filename = " ";

            OpenFileDialog findfile = new OpenFileDialog();
            if (findfile.ShowDialog() == DialogResult.OK)
            {
                filename = findfile.FileName;
            }

            if (filename.Substring(filename.Length - 3, 3) == "txt")
            {

                lbl_FilePath.Text = filename;

                StreamReader filereader = new StreamReader(filename);

                // Starting coordinates;
                string line = filereader.ReadLine();

                string[] bounds = line.Split(',');
                strt_x = int.Parse(bounds[0]);
                strt_y = int.Parse(bounds[1]);
                ln_x = int.Parse(bounds[2]);
                ln_y = int.Parse(bounds[3]);
                matrix = new string[ln_y, ln_x];

                int i, j = 0;

                string filetext = filereader.ReadToEnd();
                string[] filerows = filetext.Split('\n');

                for (j = 0; j < ln_y; j++)
                {
                    for (i = 0; i < ln_x; i++)
                    {
                        matrix[j, i] = filerows[j].Substring(i, 1);
                    }
                }
                btn_RunPerfProc.Enabled = true;
            }
            else
            {
                DialogueMessage = "There was a problem selecting your chosen port. Please try again. ";
                DialogueCaption = "Dear User";

                var result = MessageBox.Show(DialogueMessage, DialogueCaption,
                                             MessageBoxButtons.OK,
                                             MessageBoxIcon.Information);

                // If the yes button was pressed...
                if (result == DialogResult.OK)
                {

                }
            }
        }

        private void btn_RunPerfProc_Click(object sender, EventArgs e)
        {
            DialogueMessage = "You are about to start the Perforation Proceduere. You may interrupt or abort the procedure at any time. Do you wish to continue?";
            DialogueCaption = "Attention";

            var result = MessageBox.Show(DialogueMessage, DialogueCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the yes button was pressed ...
            if (result == DialogResult.Yes)
            {
                btn_RunCalProc.Enabled = false;
                btn_Disconnect.Enabled = false;
                btn_RunPerfProc.Enabled = false;
                btn_LoadFile.Enabled = false;
                PerfisRunning = 1;
                perfproc = new Thread(PerforationProcedure);
                perfproc.Start();
                // Control Buttons.
                btn_StartCal.Enabled = false;
                btn_Pause.Enabled = true;
                btn_Continue.Enabled = true;
            }
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (CalisRunning == 1) {
                calproc.Suspend();
            }
            if (PerfisRunning == 1)
            {
                perfproc.Suspend();
            }
            btn_Stop.Enabled = true;
        }

        private void btn_Continue_Click(object sender, EventArgs e)
        {
            if (CalisRunning == 1)
            {
                calproc.Resume();
            }
            if (PerfisRunning == 1)
            {
                perfproc.Resume();
            }
            btn_Stop.Enabled = false;
        }

        private void btn_Stop_Click(object sender, EventArgs e)
        {
            DialogueMessage = "You are about to abort the running Procedure. Do you wish to continue?";
            DialogueCaption = "Attention";

            var result = MessageBox.Show(DialogueMessage, DialogueCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the yes button was pressed ...
            if (result == DialogResult.Yes)
            {
                btn_Stop.Enabled = false;
                btn_RunCalProc.Enabled = false;
                btn_Continue.Enabled = false;
                btn_Pause.Enabled = false;

                if (CalisRunning == 1)
                {
                    calproc.Resume();
                    calproc.Abort();
                    CalisRunning = 0;
                }
                if (PerfisRunning == 1)
                {
                    perfproc.Resume();
                    perfproc.Abort();
                    PerfisRunning = 0;
                }
                returnzero = new Thread(return2zero);
                returnzero.Start();
            }

        }

        // Background Threads.
        public void CalibrationProcedure() {
            int i = 0;
            
            // Increase X Direction
            for (i = 0; i < 1200; i++)
            {
                inc_X();
            }
             
            // Rotate Crank
            Perforate();

            // Increase Y Direction
            for (i = 0; i < 800; i++ ) {
                inc_Y();
            }
            
            // Rotate Crank
            Perforate();

            // Decrease X Direction
            for (i = 0; i < 1200; i++)
            {
                dec_X();
            }

            // Rotate Crank
            Perforate();

            // Decrease Y Direction
            for (i = 0; i < 800; i++)
            {
                dec_Y();
            }

            // Rotate Crank
            Perforate();
            CalisRunning = 0;
            btn_RunCalProc.Invoke((MethodInvoker)(() => btn_RunCalProc.Enabled = true));
            btn_LoadFile.Invoke((MethodInvoker)(() => btn_LoadFile.Enabled = true));
            btn_Disconnect.Invoke((MethodInvoker)(() => btn_Disconnect.Enabled = true));
        }

        public void PerforationProcedure() {
            int col, row = 0;
            // Move to starting coordinates.
            for (row = 0; row < strt_y; row++)
            {
                inc_Y();
            }
            for (col = 0; col < strt_x; col++)
            {
                inc_X();
            }
            // Iterate through matrices.
            for (row = 0; row < ln_y; row++)
            {
                if (row % 2 == 0) {
                    for (col = 0; col <= ln_x-1; col++)
                    {
                        if (matrix[row, col] == "1")
                        {
                            Perforate();
                            inc_X();
                        }
                        else {
                            inc_X();  
                        }
                    }
                    inc_Y();
                }
                else {
                    for (col = ln_x-1; col >= 0; col--)
                    {
                        if (matrix[row, col] == "1")
                        {
                            dec_X();
                            Perforate();
                        }
                        else
                        {
                            dec_X();
                        }
                    }
                    inc_Y();
                }

            }
            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Perforation Complete."));
            tb_MessageIn.Invoke((MethodInvoker)(() => tb_MessageIn.Text = "Perforation Complete."));
  
            PerfisRunning = 0;
            // Control buttons. 
            btn_Disconnect.Invoke((MethodInvoker)(() => btn_Disconnect.Enabled = true));
            btn_LoadFile.Invoke((MethodInvoker)(() => btn_LoadFile.Enabled = true));
            btn_StartCal.Invoke((MethodInvoker)(() => btn_StartCal.Enabled = true));
            btn_RunPerfProc.Invoke((MethodInvoker)(() => btn_RunPerfProc.Enabled = true));

            return2zero();
        }

        public void return2zero()
        {
            if (My_X > 0) {
                // Decrease X Direction
                while(My_X > 0)
                {
                    dec_X();
                }

            }
            if (My_Y > 0)
            {
                // Decrease X Direction
                while (My_Y > 0)
                {
                    dec_Y();
                }
            }
            btn_StartCal.Invoke((MethodInvoker)(() => btn_StartCal.Enabled = true));
            btn_RunCalProc.Invoke((MethodInvoker)(() => btn_RunCalProc.Enabled = true));
            btn_Disconnect.Invoke((MethodInvoker)(() => btn_Disconnect.Enabled = true));
            
            btn_Stop.Invoke((MethodInvoker)(() => btn_Stop.Enabled = false));
            btn_Pause.Invoke((MethodInvoker)(() => btn_Pause.Enabled = false));
            btn_Continue.Invoke((MethodInvoker)(() => btn_Continue.Enabled = false));

            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Procedure Ended."));
            tb_MessageIn.Invoke((MethodInvoker)(() => tb_MessageIn.Text = "Procedure Ended."));
        }

        // LPC Commands.
        public void Perforate() {
            int c = 0;
            if (C_Dir == 0) {
                // Send instruction.
                messageOut = "6";
                _serialPort.WriteLine(messageOut);

                // Update Display.
                tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 6: Rotate Crank (Full Rotation-F)."));

                // Update UI.
                Application.DoEvents();

                // Burn some time.                             
                Task.Delay(BurnTimeCrank).Wait();
                C_Dir = 1;
            }
            else
            {
                // Send instruction.
                messageOut = "7";
                _serialPort.WriteLine(messageOut);

                // Update Display.
                tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 7: Rotate Crank (Full Rotation-R)."));

                // Update UI.
                Application.DoEvents();

                // Burn some time.                             
                Task.Delay(BurnTimeCrank).Wait();
                C_Dir = 0;
            }

        }

        public void inc_X(){
            
            int c = 0; int i = 0;

            // Send instruction.
            messageOut = "1";
            _serialPort.WriteLine(messageOut);

            // Update Display. 
            My_X = My_X + 1;
            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 1: Increase X."));
            lbl_Coordinates.Invoke((MethodInvoker)(() => lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")"));

            // Update UI.
            Application.DoEvents();

            // Burn some time.
            Thread.Sleep(BurnTimeSteps);
        }

        public void dec_X()
        {
            int c = 0; int i;
           
            // Send instruction.
            messageOut = "3";
            _serialPort.WriteLine(messageOut);

            // Update Display.
            My_X = My_X - 1;
            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 3: Decrease X."));
            lbl_Coordinates.Invoke((MethodInvoker)(() => lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")"));

            // Update UI.
            Application.DoEvents();

            // Burn some time.
            Thread.Sleep(BurnTimeSteps);
        }

        public void inc_Y()
        {
            int c = 0; int i;
            // Send instruction.
            messageOut = "2";
            _serialPort.WriteLine(messageOut);

            // Update Display.
            My_Y = My_Y + 1;
            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 2: Increase Y."));
            lbl_Coordinates.Invoke((MethodInvoker)(() => lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")"));

            // Update UI.
            Application.DoEvents();

            // Burn some time.
            Thread.Sleep(BurnTimeSteps);
        }

        public void dec_Y()
        {
            int c = 0; int i;
            // Send instruction.
            messageOut = "4";
            _serialPort.WriteLine(messageOut);

            // Update Display.
            My_Y = My_Y - 1;
            tb_MessageOut.Invoke((MethodInvoker)(() => tb_MessageOut.Text = "Command 4: Decrease Y."));
            lbl_Coordinates.Invoke((MethodInvoker)(() => lbl_Coordinates.Text = "(" + My_X.ToString() + "," + My_Y.ToString() + ")"));

            // Update UI.
            Application.DoEvents();

            // Burn some time.
            Thread.Sleep(BurnTimeSteps);
        }

    }
}
