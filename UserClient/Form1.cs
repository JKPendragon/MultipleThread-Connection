using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UserClient.Model;

namespace UserClient
{
    public partial class getData : Form
    {
        private TcpClient client1 = new();
        private TcpClient client2 = new();
        private TcpClient client3 = new();
        public getData()
        {
            InitializeComponent();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetupSeverData s = new SetupSeverData();
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            ReadData(sqlite_conn);
            s.Show();
        }

        static SQLiteConnection CreateConnection()
        {
            SQLiteConnection sqlite_conn;
            // Create a new database connection:
            sqlite_conn = new SQLiteConnection("Data Source= C:\\Users\\khang\\OneDrive\\Desktop\\Database\\tcpConnection.db; Version = 3; New = True; Compress = True; ");
            // Open the connection:
            try
            {
                sqlite_conn.Open();
            }
            catch (Exception ex)
            {

            }
            return sqlite_conn;
        }
        static void ReadData(SQLiteConnection conn)
        {
            List<Address> addresses = new List<Address>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM AddressSaved";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Address address = new Address();
                address.ID = sqlite_datareader.GetInt32(0);
                address.IP = sqlite_datareader.GetString(1);
                address.Port = sqlite_datareader.GetInt32(2);
                addresses.Add(address);
            }
            SetupSeverData.ip1.Text = addresses[0].IP;
            SetupSeverData.ip2.Text = addresses[1].IP;
            SetupSeverData.ip3.Text = addresses[2].IP;
            SetupSeverData.port1.Text = addresses[0].Port.ToString();
            SetupSeverData.port2.Text = addresses[1].Port.ToString();
            SetupSeverData.port3.Text = addresses[2].Port.ToString();
            conn.Close();
        }
        /// <summary>
        /// start receive from server, if server send a data about check file to client, display to log.text.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_Click(object sender, EventArgs e)
        {
            log.Text = "START CHECKING FILE CHANGED";
            backgroundWorker1.RunWorkerAsync();
            backgroundWorker2.RunWorkerAsync();
            backgroundWorker3.RunWorkerAsync();
        }
        /*private void StartClient(IPEndPoint address)
        {

            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }*/

        private static List<IPEndPoint> iPEndPoints()
        {

            List<Address> addresses = new List<Address>();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = CreateConnection().CreateCommand();
            sqlite_cmd.CommandText = "SELECT * FROM AddressSaved";
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                Address address = new Address();
                address.ID = sqlite_datareader.GetInt32(0);
                address.IP = sqlite_datareader.GetString(1);
                address.Port = sqlite_datareader.GetInt32(2);
                addresses.Add(address);// address include 3 ip endpoint
            }

            IPEndPoint ip1 = new IPEndPoint(IPAddress.Parse(addresses[0].IP), addresses[0].Port);
            IPEndPoint ip2 = new IPEndPoint(IPAddress.Parse(addresses[1].IP), addresses[1].Port);
            IPEndPoint ip3 = new IPEndPoint(IPAddress.Parse(addresses[2].IP), addresses[2].Port);
            List<IPEndPoint> iPEndPoints = new List<IPEndPoint>();
            iPEndPoints.Add(ip1);
            iPEndPoints.Add(ip2);
            iPEndPoints.Add(ip3);
            return iPEndPoints;
        }
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<IPEndPoint> ip = iPEndPoints();
            client1.Connect(ip[0]);
            NetworkStream stream = client1.GetStream();
            byte[] buffer = new byte[1024];
            while (true)
            {
                // read data received from the server

                int received = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response != null)
                {
                    AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine, Color.Chartreuse);
                }
            }

        }
        private void AppendToLog(string text, Color color)
        {
            if (log.InvokeRequired)
            {
                log.Invoke(new Action<string, Color>(AppendToLog), new object[] { text, color });
            }
            else
            {
                log.Text += text;
                // Thiết lập màu cho văn bản đã chọn
                log.SelectionColor = color;
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<IPEndPoint> ip = iPEndPoints();
            client2.Connect(ip[1]);
            NetworkStream stream = client2.GetStream();
            byte[] buffer = new byte[1024];
            string k = "connect success to server";
            buffer = Encoding.UTF8.GetBytes(k);
            stream.Write(buffer, 0, buffer.Length);
            while (true)
            {
                // read data received from the server

                int received = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response != null)
                {
                    AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine, Color.Teal);
                }
            }
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            List<IPEndPoint> ip = iPEndPoints();
            client3.Connect(ip[2]);
            NetworkStream stream = client3.GetStream();
            byte[] buffer = new byte[1024];
            string k = "connect success to server";
            buffer = Encoding.UTF8.GetBytes(k);
            stream.Write(buffer, 0, buffer.Length);
            while (true)
            {
                // read data received from the server

                int received = stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response != null)
                {
                    AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine, Color.Magenta);
                }
            }
        }

        private void read_Click(object sender, EventArgs e)
        {
            var stream1 = client1.GetStream();
            byte[] buffer = new byte[1024];
            string request = "data";
            buffer = Encoding.UTF8.GetBytes(request);
            stream1.Write(buffer, 0, buffer.Length);

            //receive data and display
            int received = stream1.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, received);
            get.Text = response;
        }
    }
}
