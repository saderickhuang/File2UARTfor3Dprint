using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SerialTransmit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SerialPort comm = new SerialPort();
        string[] ports;
        String Filepath = "";
        Thread _sendThread;
        bool _keepSend;
        int delayInterval = 0;
        public MainWindow()
        {
            InitializeComponent();
            ports = SerialPort.GetPortNames();
            Array.Sort(ports);
            if (ports.Length == 0)
            {
                textBox_Output.AppendText("Unable to find COM ports\r\n");
            }
           
            this.comboBox_SerialSelect.SelectedIndex=0;
          
        }

        private void comboBox_SerialSelect_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                comm.BaudRate = int.Parse(((sender as ComboBox).SelectedItem as ComboBoxItem).Content as String);
            }
            catch (Exception err)
            {

            }
            textBox_Output.AppendText("COM Baudrate set to: " + comm.BaudRate+ "\r\n");
        }
    

        private void button_SelectFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                // Open document 
                Filepath = dlg.FileName;
                this.textBox_InputFile.Text = Filepath;
                textBox_Output.AppendText("Open File: " + Filepath+ "\r\n");
            }
        }

        private void textBox_InputFile_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void textBox_InputFile_LostFocus(object sender, RoutedEventArgs e)
        {
            Filepath = (sender as TextBox).Text;
            textBox_Output.AppendText("Open File: " + Filepath + "\r\n");
        }

        private void textBox_COMs_LostFocus(object sender, RoutedEventArgs e)
        {
            if ((sender as TextBox).Text.Length != 0) { 
            comm.PortName = (sender as TextBox).Text;
            textBox_Output.AppendText("COM Port Set to: " + comm.PortName + "\r\n");
            }
        }

        private void Button_Start_Stop_Click(object sender, RoutedEventArgs e)
        {
            if (textBox_COMs.Text.Length == 0)
            {
                textBox_Output.AppendText("Input COM Port\r\n");
                return;
            }
            if (textBox_InputFile.Text.Length == 0)
            {
                textBox_Output.AppendText("Input Filepath\r\n");
                return;
            }
            
            
            if (!comm.IsOpen)
            {
                try {
                    comm.Parity = 0;
                    comm.StopBits = System.IO.Ports.StopBits.One;
                    comm.NewLine = "\r\n";
                    comm.Open();
                    _keepSend = true;
                    delayInterval = int.Parse(this.textBox_Interval.Text);
                    textBox_Interval.IsEnabled = false;
                    textBox_COMs.IsEnabled = false;
                    textBox_InputFile.IsEnabled = false;
                    _keepSend = true;
                    _sendThread = new Thread(SendPort);
                    _sendThread.Start();
                    textBox_Output.AppendText(comm.PortName + "Opened\r\n");
                }
                catch (Exception exc)
                {
                    textBox_Output.AppendText(exc.ToString() + "\r\n");
                }
            }
            else if (comm.IsOpen)
            {
                try {
                    _keepSend = false;
                    textBox_Interval.IsEnabled = true;
                    textBox_COMs.IsEnabled = true;
                    textBox_InputFile.IsEnabled = true;
                    textBox_Output.AppendText(comm.PortName + "Closed\r\n");
                }
                catch (Exception exc)
                {
                    textBox_Output.AppendText(exc.ToString() + "\r\n");
                }
            }


        }

        private void SendPort()
        {
            StreamReader sr;
            String line = "";

            if (File.Exists(Filepath))
                sr = new System.IO.StreamReader(this.Filepath);
            else {
                this.Dispatcher.Invoke((Action)(() =>
                {
                    comm.Close();
                    textBox_Output.AppendText("\r\nCannot open "+Filepath+"\r\n");
                    textBox_Interval.IsEnabled = true;
                    textBox_COMs.IsEnabled = true;
                    textBox_InputFile.IsEnabled = true;
                }));


                return;
            }
                
            line = sr.ReadLine();

            while (_keepSend)
            {
                if (line == null)
                    break;
                comm.WriteLine(line);
                try
                {
                    textBox_Output.Dispatcher.BeginInvoke((Action)(() =>
                    {
                        textBox_Output.AppendText("\r\nSending: " + line);
                    }));
                    UsDelay(delayInterval);
                    //Thread.SLEEP(delayInterval);
                }
                catch (Exception e)
                { }

                while (comm.BytesToRead > 0)
                    comm.DiscardInBuffer();
                line = sr.ReadLine();
            }
            this.Dispatcher.Invoke((Action)(() =>
            {
                if(_keepSend)
                    textBox_Output.AppendText("\r\nSending Complete\r\n");
                else
                    textBox_Output.AppendText("\r\nSending Aborted\r\n");
                textBox_Interval.IsEnabled = true;
                textBox_COMs.IsEnabled = true;
                textBox_InputFile.IsEnabled = true;
            }));
            sr.Dispose();
            sr.Close();
            comm.Close();
            _sendThread.Abort();
            
        }

        private void textBox_Output_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*  var oldFocusedElement = FocusManager.GetFocusedElement(this);

              this.textBox_Output.Focus();
              this.textBox_Output.CaretIndex = this.textBox_Output.Text.Length;
              this.textBox_Output.ScrollToEnd();
              FocusManager.SetFocusedElement(this, oldFocusedElement);
          */
            if (this.textBox_Output.LineCount > 100)
                this.textBox_Output.Clear();
            this.textBox_Output.ScrollToEnd();
        }
        public static void UsDelay(int us)
        {
            long duetime = -10 * us;
            int hWaitTimer = CreateWaitableTimer(NULL, true, NULL);
            SetWaitableTimer(hWaitTimer, ref duetime, 0, NULL, NULL, false);
            while (MsgWaitForMultipleObjects(1, ref hWaitTimer, false, Timeout.Infinite, QS_TIMER)) ;
            CloseHandle(hWaitTimer);
        }
        [DllImport("kernel32.dll")]
        public static extern int CreateWaitableTimer(int lpTimerAttributes, bool bManualReset, int lpTimerName);


        [DllImport("kernel32.dll")]
        public static extern bool SetWaitableTimer(int hTimer, ref long pDueTime,
            int lPeriod, int pfnCompletionRoutine, // TimerCompleteDelegate
            int lpArgToCompletionRoutine, bool fResume);


        [DllImport("user32.dll")]
        public static extern bool MsgWaitForMultipleObjects(uint nCount, ref int pHandles,
            bool bWaitAll, int dwMilliseconds, uint dwWakeMask);


        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(int hObject);


        public const int NULL = 0;
        public const int QS_TIMER = 0x10;
    }
}
