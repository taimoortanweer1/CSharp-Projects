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
using System.Data.OleDb;
using System.Data.Sql;
using System.Data.SqlClient;
using System.IO.Ports;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Management;
using System.Diagnostics;
using System.Data.Common; 
//using System.Security.AccessControl.DirectorySecurity;

namespace serversocket
{
    public partial class Form1 : Form
    {
        int[] CARD_ID = new int[3];
        int[] DEVICE_ID = new int[4];
        int count_client = 0; //(no of clients which are connected - 1)
        int count_client_check = 0;
        //******************************************************************************
        byte[] data1 = new byte[60];  //data receiving from client 1
        string output1 = "0";
        int rcv1;

        byte[] data2 = new byte[60];  //data receiving from client 2
        string output2 = "0";
        int rcv2;
        //*****************************************************************************    
        string MSG_STR = null; //message string to be sent
        string com; // com tellling which comport is accessed
        string ENT_NAME; // GUI showing name using invoke function
        string ENT_ID;// GUI showing CARD using invoke function

        OleDbConnection dbConn_SMS; //db connection for SMS sending
        OleDbConnection dbConn_LOG; //db connection for log maintainence

        //***************************************************************************************8
        Socket sockfd = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 5010);
        Socket[] clients = new Socket[10];
        int check_SMS = 0;
        int check_LOG = 0;
        int listening_sockets = 1;
        //******************** variables for message sending *******************************

        public Thread SMSThread;
        public Thread ReadThread;
        public static bool _Continue = false;
        public static bool _ContSMS = false;
        public bool _Wait = false;
        public static bool _ReadPort = false;
        public delegate void SendingEventHandler(bool Done);
        public event SendingEventHandler Sending;
        public delegate void DataReceivedEventHandler(string Message);
        public event DataReceivedEventHandler DataReceived;
        string signal;
        int signal_strength = 0;
        int signal_threshold = 9;
        Thread SMS_SENDING_THREAD; //separate thread for retrieving PENDING SMS and sending SMS
        int msg_send_check = 0;

        //********************** variables for security ********************************************* 
        string mac = null;
        private static byte[] salt = Encoding.ASCII.GetBytes("salt");
        //**************** character count **************************************
        int char_count = 0;
        int sms_count = 1;
        //**********************************************************8

        public Form1()
        {
            //initializing block of objects used in project
            InitializeComponent();
            load_message();
            load_IP();
            SMS_SENDING_THREAD = new Thread(new ThreadStart(SMS_SENDING));
            timer1.Start();

        }
        private void button1_Click(object sender, EventArgs e)
        {

            //*********** starting and creating waiting thread for client ******************
            byte[] data = new byte[40];
            try
            {
                sockfd.Bind(ipep);
                sockfd.Listen(listening_sockets);
                Thread waiting = new Thread(new ThreadStart(waitingforclient));
                waiting.Start();
            }
            catch (Exception ex)
            {
                if (toolStripStatusLabel2.Text == "0")
                {
                    MessageBox.Show("Waiting for response.......!! \n Check if device is properly connected !! \r\n" + ex.Message);
                }
                else
                {
                    MessageBox.Show("Devices already connected !! \r\n" + ex.Message);
                }
            }
            //*********** END OF starting and creating waiting thread for client ******************
        }
        void waitingforclient()
        {
            //*********** starting and creating receiver thread for client ******************
            byte[] data = new byte[40];
            while (true)
            {
                count_client_check = 1;
                this.Invoke(new EventHandler(UI_update));
                count_client = count_client + 1;
                count_client_check = 0;
                clients[count_client] = sockfd.Accept();

                if (count_client == 1)
                {
                    Thread receiver1 = new Thread(new ThreadStart(myreceive1));
                    receiver1.Start();
                }
                /*
                if (count_client == 2)
                {
                    Thread receiver2 = new Thread(new ThreadStart(myreceive2));
                    receiver2.Start();
                }
                 */

            }
            //*********** END OF starting and creating waiting thread for client ******************

        }
        void myreceive1()
        {
            //Application.ExecutablePath + "log1.txt"
            string[] INFO_FROM_EX = new string[4];
            bool con = false;
            while (true)
            {
                data1 = new byte[30];
                try
                {
                    rcv1 = clients[1].Receive(data1, data1.Length, SocketFlags.None);
                }
                catch
                {
                    MessageBox.Show("Connection Lost");
                }
                output1 = Encoding.ASCII.GetString(data1);

                string s = clients[1].RemoteEndPoint.ToString();
                s = s.Remove(s.Length - 5);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (s.Equals(listBox1.Items[i]))
                    {
                        con = true;
                        break;
                    }

                }

                //con = listBox1.
                if (rcv1 == 25 && con)
                {
                    // Storing new DATA in Big endian format
                    CARD_ID[0] = (data1[11] << 16);
                    CARD_ID[1] = (data1[12] << 8);
                    CARD_ID[2] = (data1[13]);

                    DEVICE_ID[0] = (data1[1] << 24);
                    DEVICE_ID[1] = (data1[2] << 16);
                    DEVICE_ID[2] = (data1[3] << 8);
                    DEVICE_ID[3] = (data1[4]);
                    string DevID = (DEVICE_ID[0] + DEVICE_ID[1] + DEVICE_ID[2] + DEVICE_ID[3]).ToString();
                    string ID = (CARD_ID[0] + CARD_ID[1] + CARD_ID[2]).ToString();

                    INFO_FROM_EX = ACQUIRING_DATA(ID);
                    maintain_log(INFO_FROM_EX, ID, DevID);
                }
            }
        }
        /*
        void myreceive2()
        {
            string[] INFO_FROM_EX = new string[4];
            bool con = false;
            while (true)
            {
                data2 = new byte[30];
                try
                {
                    rcv2 = clients[2].Receive(data2, data2.Length, SocketFlags.None);
                }
                catch
                {
                    MessageBox.Show("Connection Lost");
                }
                output2 = Encoding.ASCII.GetString(data2);

                string s = clients[1].RemoteEndPoint.ToString();
                s = s.Remove(s.Length - 5);

                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    if (s.Equals(listBox1.Items[i]))
                    {
                        con = true;
                        break;
                    }

                }
                if (rcv2 == 25 && con)
                {
                    // Storing new DATA in Big endian format
                    CARD_ID[0] = (data2[11] << 16);
                    CARD_ID[1] = (data2[12] << 8);
                    CARD_ID[2] = (data2[13]);

                    DEVICE_ID[0] = (data2[1] << 24);
                    DEVICE_ID[1] = (data2[2] << 16);
                    DEVICE_ID[2] = (data2[3] << 8);
                    DEVICE_ID[3] = (data2[4]);
                    string DevID = (DEVICE_ID[0] + DEVICE_ID[1] + DEVICE_ID[2] + DEVICE_ID[3]).ToString();
                    string ID = (CARD_ID[0] + CARD_ID[1] + CARD_ID[2]).ToString();

                    INFO_FROM_EX = ACQUIRING_DATA(ID);
                    maintain_log(INFO_FROM_EX, ID, DevID);
                }
            }

        }
        */
        void maintain_log(string[] INFO, string Cid, string DevID)
        {
            //*********************** creating table dynamically if required ************************
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DataTable userTables = null;
            string dateTable = null;
            using (DbConnection connection = factory.CreateConnection())
            {

                string path = Application.StartupPath + "\\Userfiles\\RFID_TRACKER.mdb";
                string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
                string[] restrictions = new string[4];
                bool found = false;
                connection.ConnectionString = con;
                restrictions[3] = "Table";
                connection.Open();
                userTables = connection.GetSchema("Tables", restrictions);

                dateTable = DateTime.Today.Date.ToShortDateString();
                dateTable = dateTable.Replace("/", "");
                string TableName = null;

                using (OleDbConnection conn = new OleDbConnection())
                {
                    conn.ConnectionString = con;
                    OleDbCommand cmmd = new OleDbCommand("", conn);
                    conn.Open();

                    for (int i = 0; i < userTables.Rows.Count; i++)
                    {
                        TableName = (userTables.Rows[i][2].ToString());
                        if (TableName == dateTable)
                        {
                            found = true;
                            break;
                        }
                        else
                        {
                            found = false;
                        }
                    }

                    if (found == false)
                    {
                        try
                        {
                            cmmd.CommandText = "CREATE TABLE " + dateTable + "( [CARD_ID] int, [DEVICE_ID] int, [NAME] Text, [ENTRY_TIME] DateTime, [DATE] DateTime, [STATUS] Text, [MOBILE] Text, [ENTRY_EXIT] Text)";
                            cmmd.ExecuteNonQuery();
                        }
                        catch
                        { }
                    }
                }
             
            }
            
            //****************** end of creating table ************************************************
            if (!SMS_SENDING_THREAD.IsAlive)
            {
                SMS_SENDING_THREAD = new Thread(SMS_SENDING);
                SMS_SENDING_THREAD.IsBackground = true;
                SMS_SENDING_THREAD.Start();
            }  //*************** START SEARCHING FOR LAST ENTRY STATUS MAINTAINING LOG PART ***************************************
            DateTime prev_time = DateTime.Now.AddYears(-1000);
            DateTime cur_time;
            string ENTRY_EXIT = "ENTRY";
            try
            {
                if (check_LOG != 0)
                {
                    dbConn_LOG.Close(); ;
                    dbConn_LOG.Dispose();
                }
                check_LOG = 1;
                string path = Application.StartupPath + "\\Userfiles\\RFID_TRACKER.mdb";
                string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path;
                using (OleDbConnection excon = new OleDbConnection(con))
                {
                    excon.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM " + dateTable + "  WHERE DATE=#" + DateTime.Now.ToShortDateString() + "# AND CARD_ID=" + Cid, excon))
                    {
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                cur_time = DateTime.Parse(dr[3].ToString());
                                if (cur_time > prev_time)
                                {
                                    prev_time = cur_time;
                                    if (dr[7].ToString() == "ENTRY")
                                    {
                                        ENTRY_EXIT = "EXIT";
                                    }
                                    else
                                    {
                                        ENTRY_EXIT = "ENTRY";
                                    }
                                }
                            }

                        }
                    }
                }
                //*************** END OF SEARCHING FOR LAST ENTRY STATUS MAINTAINING LOG PART ***************************************

                //*************** START MAINTAINING LOG PART ***************************************
                using (dbConn_LOG = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Userfiles\\RFID_TRACKER.mdb"))
                {
                    using (OleDbCommand adcommand = new OleDbCommand())
                    {
                        adcommand.Connection = dbConn_LOG;
                        adcommand.CommandText = "INSERT INTO " + dateTable + " VALUES(" + Cid + ","
                                                                            + DevID + ","
                                                                            + "\'" + INFO[1] + "\',"
                                                                            + "\'" + DateTime.Now.ToShortTimeString() + "\',"
                                                                            + "\'" + DateTime.Now.ToShortDateString() + "\',"
                                                                            + "\'" + "PENDING" + "\',"
                                                                            + "\'" + INFO[3] + "\',"
                                                                            + "\'" + ENTRY_EXIT + "\')";
                        ENT_NAME = INFO[1];
                        ENT_ID = Cid;
                        this.Invoke(new EventHandler(UI_update));
                        dbConn_LOG.Open();
                        adcommand.ExecuteNonQuery();
                    }
                    dbConn_LOG.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            //*************** END OF MAINTAINING LOG PART ***************************************
        }
        public string[] ACQUIRING_DATA(string ID)
        {
            string path = Application.StartupPath + "\\Userfiles\\info.xls";
            //MessageBox.Show(path);
            //string path = @"C:\Users\Taimoor\Desktop\Workshop\Client servercomunication\Client servercomunication\serversocket\serversocket\info.xls";
            string con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;";
            string[] DATA_INFO = new string[4];

            try
            {
                using (OleDbConnection excon = new OleDbConnection(con))
                {
                    excon.Open();

                    using (OleDbCommand command = new OleDbCommand("SELECT * FROM [rfid$]", excon))
                    {
                        using (OleDbDataReader dr = command.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (dr[0].ToString().Equals(ID))
                                {
                                    DATA_INFO[0] = dr[0].ToString(); // card id
                                    DATA_INFO[1] = dr[1].ToString(); //name
                                    DATA_INFO[2] = dr[10].ToString();//rfid no
                                    DATA_INFO[3] = dr[11].ToString();//mobile no

                                    break;
                                }
                            }

                        }
                    }
                }
                return DATA_INFO;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                return null;
            }
        }
        private void UI_update(object sender, EventArgs e)
        {
            label5.Text = "Name : " + ENT_NAME;
            label6.Text = "Card ID : " + ENT_ID;
            if (count_client_check == 1)
                toolStripStatusLabel2.Text = count_client.ToString();

            if (count_client > 0)
                toolStripStatusLabel4.Text = "Connected";

            if (signal_strength < signal_threshold || signal_strength==99)
                label11.Show();
            else
                label11.Hide();


            if (msg_send_check == 1)
                toolStripStatusLabel7.Text = "SENDING";
            else
                toolStripStatusLabel7.Text = "IDLE";

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (SMSPort.IsOpen)
                SMSPort.Close();

            SMS_SENDING_THREAD.Abort();
            Process[] myProcess = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            foreach (Process process in myProcess)
            {
                process.Kill();
                //hence call to Application DoEvents forces the MSG
                Application.DoEvents();
            }


        }
        public void button3_Click(object sender, EventArgs e)
        {
            bool check = false;
            int port;

            if (radioButton2.Checked)
            {
                com = comboBox1.Text;
                try
                {
                    PORT_PROP(com);
                    check = Open1();
                    if (check == false)
                    {
                        label3.ForeColor = Color.Red;
                        label3.Text = "No GSM Modem Found";
                        return;
                    }
                    else
                    {
                        label3.ForeColor = Color.Green;
                        label3.Text = "Connected to PORT : " + com;
                        // Close();
                        if (SMS_SENDING_THREAD.ThreadState.ToString() == "Unstarted")
                            SMS_SENDING_THREAD.Start();
                        return;
                    }
                }
                catch (Exception ex)
                {
                    //  MessageBox.Show(ex.ToString());
                    label3.ForeColor = Color.Red;
                    label3.Text = " GSM Connection Error";
                }
            }
            else
            {

                port = 1;
                com = "COM" + port.ToString();

                while (!check && port < 39)
                {
                    try
                    {
                        PORT_PROP(com);
                        check = Open1();

                        if (check == false)
                        {
                            port = port + 1;
                            com = "COM" + port.ToString();
                        }
                        else
                        {
                            check = true;
                            label3.ForeColor = Color.Green;
                            label3.Text = "Connected to PORT : " + com;
                            //   Close();
                            if (SMS_SENDING_THREAD.ThreadState.ToString() == "Unstarted")
                                SMS_SENDING_THREAD.Start();
                            return;
                        }

                    }
                    catch (Exception ex)
                    {
                        label3.ForeColor = Color.Red;
                        label3.Text = "No GSM Modem Found";
                        return;
                        //   MessageBox.Show(ex.ToString());
                    }
                }

            }

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string lines = "";

            for (int i = 0; i < listBox1.Items.Count; i++)
                lines = lines + listBox1.Items[i] + "\r\n";

            try
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\Userfiles\\IP.txt", FileMode.Create, FileAccess.Write);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fs))
                {
                    file.Write(lines);
                }
                MessageBox.Show("File Saved");
            }
            catch
            {
                MessageBox.Show("File Save Error");
            }

        }
        private void button5_Click(object sender, EventArgs e)
        {

            if (SMSPort.IsOpen)
            {
                SMSPort.Close();
                if (SMS_SENDING_THREAD.ThreadState.ToString() == "Running")
                    SMS_SENDING_THREAD.Abort();
                signal_strength = 0;
                label3.ForeColor = Color.Red;
                label3.Text = "GSM Module Disconnected";
            }

        }
        private void button6_Click(object sender, EventArgs e)
        {
            if (IsValidIP(textBox1.Text))
            {
                listBox1.Items.Add(textBox1.Text);
            }
            else
            {
                MessageBox.Show("Not a valid IP Address");
            }
        }
        public static bool IsValidIP(string ipAddress)
        {
            IPAddress unused;
            return IPAddress.TryParse(ipAddress, out unused)
              &&
              (
                  unused.AddressFamily != AddressFamily.InterNetwork
                  ||
                  ipAddress.Count(c => c == '.') == 3
              );
        }
        void SMS_SENDING()
        {
            string today_date = DateTime.Today.Date.ToShortDateString(); ;

            today_date = today_date.Replace("/", "");
            try
            {
                while (true)
                {
                    if (check_SMS != 0)
                    {
                        dbConn_SMS.Close();
                        dbConn_SMS.Dispose();
                        dbConn_SMS.Close();
                    }
                    check_SMS = 1;
                    msg_send_check = 0;
                    using (dbConn_SMS = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Application.StartupPath + "\\Userfiles\\RFID_TRACKER.mdb"))
                    {
                        // dbConn_SMS = new OleDbConnection(Application.StartupPath + "\\RFID_TRACKER.mdb");
                        //dbConn_SMS = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Taimoor\Desktop\Workshop\Client servercomunication\Client servercomunication\serversocket\serversocket\RFID_TRACKER.mdb");
                        using (OleDbCommand adcommand = new OleDbCommand())
                        {
                            using (OleDbCommand adcommandupdate = new OleDbCommand())
                            {
                                adcommand.CommandText = "SELECT * FROM " + today_date + " WHERE DATE=#" + DateTime.Now.Date.ToShortDateString() + "# and " + " STATUS='PENDING' ";
                                OleDbDataReader read = null;
                                adcommand.Connection = dbConn_SMS;
                                adcommandupdate.Connection = dbConn_SMS;
                                dbConn_SMS.Open();
                                read = adcommand.ExecuteReader();
                                string time = null;
                                if (read.HasRows && ( (signal_strength > signal_threshold) && (signal_strength < 33 )))
                                {
                                    msg_send_check = 1;

                                    this.Invoke(new EventHandler(UI_update));
                                    while (read.Read())
                                    {

                                        if (read[3].ToString().Contains("12/30/1899"))
                                        {
                                            time = read[3].ToString();
                                            time = time.Replace("12/30/1899", " ");
                                        }

                                        if (textBox4.Text == "")
                                        {
                                            textBox4.Text = "Alert";
                                        }
                                      //+ " and Device ID:" + read[1].ToString() //device
                                      //  MSG_STR = "HeadStart Alert\r\n"
                                          MSG_STR = textBox4.Text + ": \n"
                                                    + "Name: "    + read[2].ToString() +"\n" //name
                                                    + "CARD No: " + read[0].ToString() +"\n" //cardid
                                                    + "Status: "+read[7].ToString() +"\n"
                                                    + "Time:"+  time +"\n"
                                                    + textBox2.Text + "\n"
                                                    + "\nPowered By Robotech Engineering"; //time

                                        SendSMS("0" + read[6].ToString(), MSG_STR);

                                        adcommandupdate.CommandText = " UPDATE " + today_date + " SET STATUS='SENT' WHERE CARD_ID=" + read[0].ToString() + "AND DATE= #" + DateTime.Now.ToShortDateString() + "# AND " + "STATUS = 'PENDING'";
                                        adcommandupdate.ExecuteNonQuery();

                                    }
                                    msg_send_check = 0;
                                }
                                else
                                {
                                    this.Invoke(new EventHandler(UI_update));
                                }
                            }
                        }
                        dbConn_SMS.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
        }
        public void PORT_PROP(string COMMPORT)
        {

            SMSPort.PortName = COMMPORT;
            SMSPort.BaudRate = 9600;
            SMSPort.Parity = Parity.None;
            SMSPort.DataBits = 8;
            SMSPort.StopBits = StopBits.One;
            SMSPort.Handshake = Handshake.RequestToSend;
            SMSPort.DtrEnable = true;
            SMSPort.RtsEnable = true;
            SMSPort.NewLine = System.Environment.NewLine;
            ReadThread = new Thread(new System.Threading.ThreadStart(ReadPort));


        }
        public bool SendSMS(string CellNumber, string SMSMessage)
        {
            string MyMessage = null;
            string s = null; ; ;
            //Check if Message Length <= 160
            if (SMSMessage.Length <= 160)
                MyMessage = SMSMessage;
            else
                MyMessage = SMSMessage.Substring(0, 160);

            if (SMSPort.IsOpen == true)
            {
                SMSPort.Write("AT+CMGF=1\r\n");
                Thread.Sleep(1000);
                SMSPort.Write("AT+CMGS=\"" + CellNumber + "\"\r\n");

                Thread.Sleep(1000);
                SMSPort.Write(SMSMessage + (char)(26) + Environment.NewLine);
                Thread.Sleep(1000);
                s = SMSPort.ReadExisting();
                _Continue = false;
                if (Sending != null)
                    Sending(false);
            }
            return false;
        }
        private void ReadPort()
        {
            string SerialIn = null;
            byte[] RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            while (SMSPort.IsOpen == true)
            {


                try
                {
                    if ((SMSPort.BytesToRead != 0) & (SMSPort.IsOpen == true))
                    {

                        while (SMSPort.BytesToRead != 0)
                        {
                            SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize);
                            SerialIn =
                                SerialIn + System.Text.Encoding.ASCII.GetString(
                                RXBuffer);
                            if (SerialIn.Contains("+CSQ:") == true)
                            {
                                signal = SerialIn;
                            }
                            if (SerialIn.Contains(">") == true)
                            {
                                _ContSMS = true;
                            }
                            if (SerialIn.Contains("+CMGS:") == true)
                            {
                                _Continue = true;
                                if (Sending != null)
                                    Sending(true);
                                _Wait = false;
                                SerialIn = string.Empty;
                                RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Unexpected GSM Module Error");
                }
                if (DataReceived != null)
                    DataReceived(SerialIn);
                SerialIn = string.Empty;
                RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            }
        }
        public void Open()
        {

            if (SMSPort.IsOpen == false)
            {
                try
                {
                    SMSPort.Open();
                    SMSPort.Write("AT+CFUN=1\r\n");
                    ReadThread.Start();
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                }
            }

        }
        public bool Open1()
        {
            string s = null;
            if (SMSPort.IsOpen == false)
            {
                try
                {
                    SMSPort.Open();
                    SMSPort.Write("AT\r\n");
                    Thread.Sleep(100);
                    s = SMSPort.ReadExisting();
                    if (s.Contains("OK"))
                    {
                        SMSPort.Write("AT+CFUN=1\r\n");
                        ReadThread.Start();
                        return true;
                    }
                    else
                    {
                        if (SMSPort.IsOpen)
                            SMSPort.Close();
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    return false;
                }
            }
            return true;
        }
        public void Close()
        {
            if (SMSPort.IsOpen == true)
            {
                SMSPort.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            string sig = null;
            float value = 0;
            if (SMSPort.IsOpen)
            {
                try
                {
                    SMSPort.Write("AT+CSQ\r\n");
                    Thread.Sleep(1000);
                    // signal = SMSPort.ReadExisting();
                    int in1 = signal.IndexOf("CSQ:");
                    string ret = signal.Substring(in1 + 4, 3);
                   
                    ret = ret.Replace(" ", "");

                    signal_strength = int.Parse(ret);
                    toolStripStatusLabel12.Text = signal_strength.ToString();
                    value = (signal_strength / 32.0f) * 100.0f;
                    toolStripProgressBar1.Value = (int)(value);
                }
                catch
                { }


            }
        }
        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("For any query\r\nPlease contact us via email : crg@case.edu.pk ");
        }
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {

            char_count = (textBox2.TextLength + textBox3.TextLength + textBox4.TextLength);
            sms_count = ((textBox2.TextLength + textBox3.TextLength + textBox4.TextLength) / 160) + 1;

            label2.Text = sms_count.ToString();
            label8.Text = char_count.ToString();
        }
        private void button8_Click(object sender, EventArgs e)
        {
            string line = "";

            line = textBox2.Text + "\r\n";

            try
            {
                FileStream fs = new FileStream(Application.StartupPath + "\\Userfiles\\messagetemplate.txt", FileMode.Create, FileAccess.Write);
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(fs))
                {
                    file.WriteLine(line);
                }
                MessageBox.Show("File Saved");
            }
            catch
            {
                MessageBox.Show("File Save Error");
            }
        }
        void load_message()
        {
            //loading of text sms to be loaded in the textbox for sending 
            //loaded at form1 constructor
            string line = "";
            if (File.Exists(Application.StartupPath + "\\Userfiles\\messagetemplate.txt"))
            {
                try
                {

                    using (System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\Userfiles\\messagetemplate.txt", true))
                    {
                        line = file.ReadToEnd();
                        textBox2.Text = line;
                        label8.Text = (textBox3.TextLength + textBox2.TextLength).ToString();
                    }

                }
                catch
                {
                    MessageBox.Show("File Read Error");
                }
            }
            else
            {
                MessageBox.Show("Message file not available \r\n Kindly Go to Message Settings Tab, write Message template and save message");
            }

        }
        void load_IP()
        {
            //loading of IP addres to be loaded in the listbox
            //loaded at form1 constructor
            string line = "";
            if (File.Exists(Application.StartupPath + "\\Userfiles\\IP.txt"))
            {
                try
                {

                    using (System.IO.StreamReader file = new System.IO.StreamReader(Application.StartupPath + "\\Userfiles\\IP.txt", true))
                    {
                        while ((line = file.ReadLine()) != null)

                            listBox1.Items.Add(line);
                    }

                }
                catch
                {
                    MessageBox.Show("IP File Read Error");
                }
            }
            else
            {
                MessageBox.Show("IP file not available \r\n Kindly Go to IP Configuration Tab, Add Client IPs and Click Save");
            }

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            /*
            Microsoft.Win32.RegistryKey m_RegEntry = Microsoft.Win32.Registry.LocalMachine;
            m_RegEntry = m_RegEntry.OpenSubKey(@"SYSTEM\CurrentControlSet\Control\Class\{4D36E96D-E325-11CE-BFC1-08002BE10318}");

            int i = 0;
            string[] m_szModemEntries = m_RegEntry.GetSubKeyNames();
            string[] m_szModem = new string[m_szModemEntries.Length];
            string m_szModemPort = null;
            string m_szModemName = null;
            //System.IO.Ports.SerialPort.GetPortNames();
            foreach (string m_szModemEntry in m_szModemEntries)
            {
                m_RegEntry.Close();
                m_RegEntry = Microsoft.Win32.Registry.LocalMachine;
                string m_szKeyName = @"SYSTEM\CurrentControlSet\Control\Class\{4D36E96D-E325-11CE-BFC1-08002BE10318}\" + m_szModemEntry;
                m_RegEntry = m_RegEntry.OpenSubKey(m_szKeyName);
                m_szModemPort = m_RegEntry.GetValue("AttachedTo").ToString();
                m_szModemName = m_RegEntry.GetValue("Model").ToString();
                MessageBox.Show(m_szModemPort.ToString() + "\r\n" + m_szModemName.ToString());
            }
            */

        }
        private void button9_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItems.Count > 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
        }
        private void button11_Click(object sender, EventArgs e)
        {
            if (tabControl1.Visible == true)
            {
                tabControl1.Hide();
            }
            else
            {
                tabControl1.Show();
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }
    }
}