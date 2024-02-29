using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data;
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
        string dataServer1;
        string dataServer2;
        string dataServer3;
        public getData()
        {
            InitializeComponent();
        }

        /// <summary>
        /// show the setup server form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            SetupSeverData s = new SetupSeverData();
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            ReadData(sqlite_conn);
            s.Show();
            check.Enabled = true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
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
            read.Enabled = true;
            try
            {
                log.ForeColor = Color.Green;
                log.Text = "START CHECKING FILE";
                log.AppendText(Environment.NewLine);
                backgroundWorker1.RunWorkerAsync();
                backgroundWorker2.RunWorkerAsync();
                backgroundWorker3.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                log.Text=("error from server, please try again");
            }

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
            try
            {
                List<IPEndPoint> ip = iPEndPoints();
                //Connect to server 1 :

                client1.Connect(ip[0]);
                NetworkStream stream = client1.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    // read data received from the server
                    int received = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, received);
                    if (response.Equals("File1 was changed"))
                    {
                        AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine);
                    }
                    else
                    {
                        dataServer1 = response;
                    }
                }
            }catch (Exception ex)
            {
                AppendToLog("can't Connect to server 1,please try again (port is 1308 and ip is any)");
            }


        }
        private void AppendToLog(string text)
        {
            if (log.InvokeRequired)
            {
                log.Invoke(new Action<string>(AppendToLog), new object[] { text });
            }
            else
            {
                log.Text += text;
                // Thiết lập màu cho văn bản đã chọn
            }
        }
        private static void AppendToGet(string text)
        {
            if (get.InvokeRequired)
            {
                get.Invoke(new Action<string>(AppendToGet), new object[] { text });
            }
            else
            {
                get.Text = text;
            }
        }

        private void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                List<IPEndPoint> ip = iPEndPoints();
                //Connect to server 1 :

                client2.Connect(ip[1]);
                NetworkStream stream = client2.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    // read data received from the server
                    int received = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, received);
                    if (response.Equals("File2 was changed"))
                    {
                        AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine);
                    }
                    else
                    {
                        dataServer2 = response;
                    }
                }
            }catch(Exception ex)
            {
                AppendToLog("can't Connect to server 2,please try again (port is 1309 and ip is any)");
            }
            
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            try
            {
                List<IPEndPoint> ip = iPEndPoints();
                //Connect to server 1 :

                client3.Connect(ip[2]);
                NetworkStream stream = client3.GetStream();
                byte[] buffer = new byte[1024];
                while (true)
                {
                    // read data received from the server
                    int received = stream.Read(buffer, 0, buffer.Length);
                    string response = Encoding.UTF8.GetString(buffer, 0, received);
                    if (response.Equals("File3 was changed"))
                    {
                        AppendToLog("detect " + response + " at " + DateTime.Now + Environment.NewLine);
                    }
                    else
                    {
                        dataServer3 = response;
                    }
                }
            }
            catch(Exception ex)
            {
                AppendToLog("can't Connect to server 3,please try again (port is 1310 and ip is any)");

            }

        }
        /// <summary>
        /// display json string get from server
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void read_Click(object sender, EventArgs e)
        {
            submit.Enabled = true;
            get.Text = dataServer1 + " " + dataServer2 + "" + dataServer3;
        }
        /// <summary>
        /// return list product when input the string json
        /// </summary>
        /// <returns></returns>
        static List<Product> Loading(string text)
        {
            var products = JsonConvert.DeserializeObject<List<Product>>(text);
            return products;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTable ConvertToDataTable()
        {
            DataTable table = new DataTable("Products");

            // Check if columns exists
            if (!table.Columns.Contains("PART_NO"))
            {
                table.Columns.Add("PART_NO", typeof(string));
            }

            if (!table.Columns.Contains("LOT"))
            {
                table.Columns.Add("LOT", typeof(string));
            }

            if (!table.Columns.Contains("PART_NAME"))
            {
                table.Columns.Add("PART_NAME", typeof(string));
            }

            if (!table.Columns.Contains("PARA_NAME"))
            {
                table.Columns.Add("PARA_NAME", typeof(string));
            }

            if (!table.Columns.Contains("VALUE"))
            {
                table.Columns.Add("VALUE", typeof(string));
            }

            if (!table.Columns.Contains("WO_QTY"))
            {
                table.Columns.Add("WO_QTY", typeof(string));
            }

            if (!table.Columns.Contains("PER_REEL_QTY"))
            {
                table.Columns.Add("PER_REEL_QTY", typeof(string));
            }
            return table;
        }

        private void submit_Click(object sender, EventArgs e)
        { 
            string userLot = lot.Text;
            DataTable data = new DataTable();
            data = ConvertToDataTable();
            var lisProduct1 = Loading(dataServer1);
            var lisProduct2 = Loading(dataServer2);
            var lisProduct3 = Loading(dataServer3);
            List<Product> listAllProduct = lisProduct1.Concat(lisProduct2).Concat(lisProduct3).ToList();
            var listOfProductOrder = from product in listAllProduct
                                     where product.LOT == userLot
                                     select product;
            foreach (var product in listOfProductOrder)
            {
                data.Rows.Add(product.PART_NO,
                       product.LOT,
                       product.PART_NAME,
                       product.PARA_NAME,
                       product.VALUE,
                       product.WO_QTY,
                       product.PER_REEL_QTY);
            }
            table.DataSource = data;
        }
    }
}
