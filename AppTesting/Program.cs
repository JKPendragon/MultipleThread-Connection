using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Timers;
using System.Threading;
using System.Threading.Tasks;

namespace AppTesting
{
    internal class Program
    {
       public static async Task Main(string[] args)
        {


            IPEndPoint p;
            p = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1308);
            while (true)
            {
                
                Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);
                await s.ConnectAsync(p);
               // s.Connect(p);
                NetworkStream stream = new NetworkStream(s);
                var reader = new StreamReader(stream);
                var writer = new StreamWriter(stream);


                writer.WriteLine("checkFile");// request sever check file
                writer.Flush();// send request to server;

                //read response form server
                string response = reader.ReadLine();
                Console.WriteLine(response);
                s.Close();
                //Thread.Sleep(4000);
                await Task.Delay(4000);

            }

        }
    }
}
