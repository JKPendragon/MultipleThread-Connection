using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace server
{
    /// <summary>
    /// 
    /// </summary>
    internal class Program
    {

        static bool isFileChanged = false;
        public static void Main(string[] args)
        {

            var listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 1308);
            listener.Bind(ipEndPoint);
            listener.Listen(10);
            
                while (true)
                {
                    Socket worker = listener.Accept();
                    NetworkStream stream = new NetworkStream(worker);
                    var reader = new StreamReader(stream);
                    var writer = new StreamWriter(stream);
                    string request = reader.ReadLine();
                    Console.WriteLine($"request : {request} from {worker.RemoteEndPoint}");
                    if (request.Equals("checkFile"))
                    {
                        
                        Watcher();
                        if (isFileChanged)
                        {
                            writer.WriteLine("CHANGED");
                            writer.Flush();
                        }
                        else writer.WriteLine("not");
                        isFileChanged = false;
                        

                    }

                stream.Close();
                writer.Close();
                reader.Close();

            }
                

            

        }
        static FileSystemWatcher watcher = new FileSystemWatcher();
        /// <summary>
        /// 
        /// </summary>
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Watcher()
        {

            //using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection\";
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Filter = "data.txt";
                watcher.Changed += OnChanged;
                watcher.EnableRaisingEvents = true;
                Console.ReadKey();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            isFileChanged = true;
        }
        private static IPEndPoint getAddress1()
        {
            IPEndPoint add1 = new  IPEndPoint(IPAddress.Any, 1308);
            return add1;
        }
        private static TcpListener getConnection1(IPEndPoint ad)
        {
            var listener = new TcpListener(ad);
            return listener;
        }
        private static IPEndPoint getAddress2()
        {
            IPEndPoint add1 = new IPEndPoint(IPAddress.Any, 1309);
            return add1;
        }
        private static TcpListener getConnection2(IPEndPoint ad)
        {
            var listener = new TcpListener(ad);
            return listener;
        }
        private static IPEndPoint getAddress3()
        {
            IPEndPoint add1 = new IPEndPoint(IPAddress.Any, 1310);
            return add1;
        }
        private static TcpListener getConnection3(IPEndPoint ad)
        {
            var listener = new TcpListener(ad);
            return listener;
        }
        private static Socket sk1()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(getAddress1());//connect socket to ip in the winform screen
            return socket;
        }
        private static Socket sk2()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(getAddress2());//connect socket to ip in the winform screen
            return socket;
        }
        private static Socket sk3()
        {
            var socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(getAddress3());//connect socket to ip in the winform screen
            return socket;
        }
    }
}
