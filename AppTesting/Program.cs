﻿using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace AppTesting
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            IPEndPoint p;
            p = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1308);
            Socket s = new Socket(SocketType.Stream, ProtocolType.Tcp);
            s.Connect(p);
            NetworkStream stream = new NetworkStream(s);
            var reader = new StreamReader(stream);
            var writer = new StreamWriter(stream);
            int i = 0;
            while (true)
            {
                writer.WriteLine("checkFile");// request sever check file
                i++;
                writer.Flush();// send request to server;
                //read response form server
                string response = reader.ReadLine();
                if (response.Equals("CHANGED")) Console.WriteLine(response);
            }
            stream.Close();
            writer.Close();
            reader.Close();
            s.Close();


            /*            IPEndPoint p;
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
                            await Task.Delay(4000);*/

        }

        }
    }


