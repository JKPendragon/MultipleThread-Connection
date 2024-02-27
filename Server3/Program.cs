using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Server3
{
    internal class Program
    {
        static bool isFileChanged = false;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1310);
            server.Start();

            // Giám sát file thay đổi   
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "File3.txt";
            watcher.EnableRaisingEvents = true;
            watcher.Changed += OnChanged;


            Console.WriteLine("Server3 is running...");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int received = stream.Read(buffer, 0, buffer.Length);
            string response = Encoding.UTF8.GetString(buffer, 0, received);


            while (true)
            {
                string k = "";
                if (isFileChanged)
                {
                    k = "File3 was changed";
                    isFileChanged = false;
                }

                buffer = Encoding.UTF8.GetBytes(k);
                stream.Write(buffer, 0, buffer.Length);

            }

        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            isFileChanged = true;
            Console.WriteLine("File3 has been changed.");
        }
    }
}
