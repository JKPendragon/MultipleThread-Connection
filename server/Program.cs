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
            //while (true)
            {

                //           timer = new System.Threading.Timer(state => {

                Socket worker = listener.Accept();
                NetworkStream stream = new NetworkStream(worker);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);
                while (true)
                {

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
                        else
                        {
                            writer.Write("no"); writer.Flush();
                        }
                        isFileChanged = false;
                        

                    }
                    
                }
                stream.Close();
                writer.Close();
                reader.Close();

                worker.Close();

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
                /*ManualResetEvent waitHandle = new ManualResetEvent(false);
                waitHandle.WaitOne();
                waitHandle.Set();*/
                //watcher.Changed += (sender, e) =>
                //{

                //    Console.WriteLine("File changed detected");

                //};

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

    }
}
