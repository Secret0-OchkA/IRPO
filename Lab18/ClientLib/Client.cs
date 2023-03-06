using System.Net.Sockets;

namespace ClientLib
{
    public class Client : IDisposable
    {
        TcpClient tcpClient;
        StreamReader reader;
        StreamWriter writer;
        public Client(int port)
        {
            tcpClient = new TcpClient("localhost", port);
            NetworkStream stream = tcpClient.GetStream();
            reader = new StreamReader(stream);
            writer = new StreamWriter(stream) { AutoFlush = true };
        }

        public void Start()
        {
            new Thread(GetMessage).Start();
            //new Thread(SendMessage).Start();
        }
        public void Stop()
        {
            tcpClient.Close();
            this.Dispose();
        }

        void GetMessage()
        {
            while (true)
            {
                try
                {
                    string lineReceived = reader.ReadLine();
                    Console.WriteLine("from server: " + lineReceived);
                }
                catch { }
            }
        }

        public void SendString(string msg)
        {

        }

        void SendMessage()
        {
            while (true)
            {
                string lineToSend = Console.ReadLine();
                writer.WriteLine(lineToSend);
            }
        }
        public void Dispose()
        {
            writer.Dispose();
            reader.Dispose();
            tcpClient.Dispose();
        }
    }
}