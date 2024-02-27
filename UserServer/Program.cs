using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace UserServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener listener1 = getConnection1(getAddress1());
            TcpListener listener2 = getConnection2(getAddress2());
            TcpListener listener3 = getConnection3(getAddress3());
            listener1.Start();
            listener2.Start();
            listener3.Start();


            

            Socket worker2 = listener2.AcceptSocket();
            NetworkStream stream2 = new NetworkStream(worker2);
            var reader2 = new StreamReader(stream2);
            var writer2 = new StreamWriter(stream2);

            Socket worker3 = listener3.AcceptSocket();
            NetworkStream stream3 = new NetworkStream(worker3);
            var reader3 = new StreamReader(stream3);
            var writer3 = new StreamWriter(stream3);
            try
            {
                while (true)
                {
                    Socket worker1 = listener1.AcceptSocket();
                    NetworkStream stream1 = new NetworkStream(worker1);
                    var reader1 = new StreamReader(stream1);
                    var writer1 = new StreamWriter(stream1);
                    writer1.AutoFlush = true;

                    string request = reader1.ReadLine();//doc du request tu nguoi dung
                    Console.WriteLine($"request : {request} from  {worker1.RemoteEndPoint}");//display what is request
                    if (request.Equals("checkFile"))//user yeu cau filePath
                    {
                        writer1.WriteLine("hi");//put to stream the file path
                        writer1.Flush();// gooooooo

                    }

                    stream1.Close();
                    writer1.Close();
                    reader1.Close();

                }

                

                stream2.Close();
                writer2.Close();
                reader2.Close();

                stream3.Close();
                writer3.Close();
                reader3.Close();
            }
            catch (Exception ex)
            {

            }
            
        }
        private static IPEndPoint getAddress1()
        {
            IPEndPoint add1 = new IPEndPoint(IPAddress.Any, 1308);
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
