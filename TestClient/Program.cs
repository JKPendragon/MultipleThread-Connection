/*using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            while (true)
            {

                TcpClient client = new TcpClient("127.0.0.1", 1308);

                NetworkStream stream = client.GetStream();

                // read data receive from server
                byte[] buffer = new byte[1024];
                int received = await stream.ReadAsync(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, received);


                if(response == "changed")
                Console.WriteLine(response);
                else if(response== "not")
            Console.WriteLine("static");
                else Console.WriteLine(response);
                client.Close();
                stream.Close();
            }
        }

    }
    }

*/
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 1308);

            NetworkStream stream = client.GetStream();
            while (true)
            {
                // read data received from the server
                byte[] buffer = new byte[1024];
                int received =  stream.Read(buffer, 0, buffer.Length);
                string response = Encoding.UTF8.GetString(buffer, 0, received);
                if (response !=null)
                    Console.WriteLine("Server: " + response);
            }
        }
    }
}
