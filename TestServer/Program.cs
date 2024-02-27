/*using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TestServer
{
    internal class Program
    {
        
        static bool isFileChanged = false;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1308);
            server.Start();
            // Giám sát file thay đổi   
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "data.txt";
            watcher.EnableRaisingEvents = true;
            while (true)
            {
                isFileChanged = false;
                string k = Console.ReadLine();
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream;
                stream = client.GetStream();

                byte[] buffer = new byte[1024];
                watcher.Changed += OnChanged;
                Console.WriteLine(isFileChanged);
                if (isFileChanged == true) {
                    k = "changed";
                    buffer = Encoding.UTF8.GetBytes(k);
                    stream.Write(buffer, 0, buffer.Length);}
                buffer = Encoding.UTF8.GetBytes(k);
                stream.Write(buffer, 0, buffer.Length);
                client.Close();
            }

        }
        static void isC()
        {
            Console.WriteLine("file hasbeen changed");
        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            isC();
            isFileChanged = true;
        }

    }
}

*/
using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace TestServer
{
    internal class Program
    {
        static bool isFileChanged = false;

        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 1308);
            server.Start();

            // Giám sát file thay đổi   
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "data.txt";
            watcher.EnableRaisingEvents = true;
            watcher.Changed += OnChanged;

            
            Console.WriteLine("Server is running...");
            TcpClient client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            while (true)
            {
                string k = "";
                if (isFileChanged)
                {
                    k = "changed";
                    isFileChanged = false;
                }


                byte[] buffer = Encoding.UTF8.GetBytes(k);
                stream.Write(buffer, 0, buffer.Length);

            }
          
        }

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            isFileChanged = true;
            Console.WriteLine("File has been changed.");
        }
    }
}
