using System.Data;
using System.Data.Entity;
using System.Data.SQLite;

namespace UserClient
{
    public class Address
    {
        public int ID { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
    }

    public partial class getData : Form
    {
        public getData()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SetupSeverData s = new SetupSeverData();
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

            conn.Close();
        }



    }
}
