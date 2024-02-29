using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices.ComTypes;

namespace Server2
{
    internal class Program
    {
        static bool isFileChanged = false;
        static TcpClient client;
        static byte[] buffer = new byte[1024];

        static void Main(string[] args)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 1309);
            TcpListener server = new TcpListener(ip);
            server.Start();

            // Giám sát file thay đổi   
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "File2.txt";
            watcher.EnableRaisingEvents = true;
            watcher.Changed += OnChanged;
            Console.WriteLine("Server2 is running...");
            client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            string filePath = "C:\\Users\\khang\\source\\repos\\MultipleThread Connection\\File2.txt";
            string text = File.ReadAllText(filePath, Encoding.UTF8);
            buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
            while (true)
            {
                /*
                                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                                string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                                if (response == "data")
                                {
                                    string filePath = "C:\\Users\\khang\\source\\repos\\MultipleThread Connection\\File1.txt";
                                    string text = File.ReadAllText(filePath, Encoding.UTF8);
                                    Console.WriteLine(text);
                                    buffer = Encoding.UTF8.GetBytes("dataclient");
                                    stream.Write(buffer, 0, buffer.Length);
                                }*/

            }

        }
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File2 has been changed.");
            NetworkStream stream = client.GetStream();
            string k = "";
            k = "File2 was changed";
            isFileChanged = false;
            buffer = Encoding.UTF8.GetBytes(k);
            stream.Write(buffer, 0, buffer.Length);
            string filePath = "C:\\Users\\khang\\source\\repos\\MultipleThread Connection\\File2.txt";
            string text = File.ReadAllText(filePath, Encoding.UTF8);
            buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
        }
    }
}
