using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Server1
{
    internal class Program
    {
        static bool isFileChanged = false;
        static TcpClient client;
        static byte[] buffer = new byte[1024];

        static void Main(string[] args)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 1308);
            TcpListener server = new TcpListener(ip);
            server.Start();

            // Giám sát file thay đổi   
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "File1.txt";
            watcher.EnableRaisingEvents = true;
            watcher.Changed += OnChanged;
            Console.WriteLine("Server1 is running...");
            client = server.AcceptTcpClient();
            NetworkStream stream = client.GetStream();
            string filePath = "C:\\Users\\khang\\source\\repos\\MultipleThread Connection\\File1.txt";
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
            Console.WriteLine("File1 has been changed.");
            NetworkStream stream = client.GetStream();
            string k = "";
            k = "File1 was changed";
            isFileChanged = false;
            buffer = Encoding.UTF8.GetBytes(k);
            stream.Write(buffer, 0, buffer.Length);
            string filePath = "C:\\Users\\khang\\source\\repos\\MultipleThread Connection\\File1.txt";
            string text = File.ReadAllText(filePath, Encoding.UTF8);
            buffer = Encoding.UTF8.GetBytes(text);
            stream.Write(buffer, 0, buffer.Length);
        }


    }
    }

