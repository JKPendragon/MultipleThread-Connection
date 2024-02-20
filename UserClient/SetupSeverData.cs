using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserClient
{
    public partial class SetupSeverData : Form
    {
        public SetupSeverData()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, EventArgs e)
        {
            SQLiteConnection sqlite_conn;
            sqlite_conn = CreateConnection();
            InsertData1(sqlite_conn);
            InsertData2(sqlite_conn);
            InsertData3(sqlite_conn);
            this.Close();
        }
        static void InsertData1(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"REPLACE INTO AddressSaved (ID, IpAddress, Port) 
                                                VALUES (@id, @ipaddress, @port);";
            sqlite_cmd.Parameters.AddWithValue("@id",1);
            string ip = ip1.Text;
            sqlite_cmd.Parameters.AddWithValue("@ipaddress",ip);
            int port = int.Parse(port1.Text);
            sqlite_cmd.Parameters.AddWithValue("@port",port);
            sqlite_cmd.ExecuteNonQuery();
        }
        static void InsertData2(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"REPLACE INTO AddressSaved (ID, IpAddress, Port) 
                                                VALUES (@id, @ipaddress, @port);";
            sqlite_cmd.Parameters.AddWithValue("@id", 2);
            string ip = ip2.Text;
            sqlite_cmd.Parameters.AddWithValue("@ipaddress", ip);
            int port = int.Parse(port2.Text);
            sqlite_cmd.Parameters.AddWithValue("@port", port);
            sqlite_cmd.ExecuteNonQuery();
        }
        static void InsertData3(SQLiteConnection conn)
        {
            SQLiteCommand sqlite_cmd;
            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = @"REPLACE INTO AddressSaved (ID, IpAddress, Port) 
                                                VALUES (@id, @ipaddress, @port);";
            sqlite_cmd.Parameters.AddWithValue("@id", 3);
            string ip = ip3.Text;
            sqlite_cmd.Parameters.AddWithValue("@ipaddress", ip);
            int port = int.Parse(port3.Text);
            sqlite_cmd.Parameters.AddWithValue("@port", port);
            sqlite_cmd.ExecuteNonQuery();
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

        private void connect_Click(object sender, EventArgs e)
        {
            save.Enabled = true;
        }
    }
}
