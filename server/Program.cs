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

    internal class Program
    {
        static bool isFileChanged = false;
       public static void Main(string[] args)
        {

            var listener  = new Socket(SocketType.Stream, ProtocolType.Tcp);
            var ipEndPoint = new IPEndPoint(IPAddress.Any, 1308);
            listener.Bind(ipEndPoint);
            listener.Listen(1000);
            while (true) {
                

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
                    isFileChanged = false;
                }
                worker.Close();
               // Thread.Sleep(4000);
            }

        }
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        private static void Watcher()
        {

            using (FileSystemWatcher watcher = new FileSystemWatcher())
            {
                watcher.Path = @"C:\Users\khang\source\repos\MultipleThread Connection";
                watcher.NotifyFilter = NotifyFilters.LastWrite;
                watcher.Filter = "data.txt";
                watcher.Changed += OnChanged;
                watcher.EnableRaisingEvents = true;
                //Console.ReadKey();
            }
        }
        

        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            isFileChanged = true;
        }
    }
}
