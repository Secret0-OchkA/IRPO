using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ConsoleAppServer
{
    class Server : IDisposable
    {
        TcpListener listener;

        LinkedList<Client> clients = new LinkedList<Client>();

        public Server(int Port)
        {
            listener = new TcpListener(IPAddress.Any, Port); 
        }


        public void Start()
        {
            Console.WriteLine("Start Server");
            listener.Start();

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();

                var newClient = new Client(client);
                foreach(var c in clients)
                {
                    c.GetMessageHandler += newClient.Send;
                    newClient.GetMessageHandler += c.Send;
                }

                clients.AddFirst(newClient);

                Thread Thread = new Thread(() => newClient.Start());

                Thread.Start();
            }
        }

        public void Dispose()
        {
            if (listener != null)
            {
                // Остановим его
                listener.Stop();

                foreach(var c in clients)
                    c.Dispose();
            }
        }
    }

    class Client : IDisposable
    {
        TcpClient client;
        StreamWriter writer;
        StreamReader reader;

        public event GetMessageEvent GetMessageHandler;
        public delegate void GetMessageEvent(string message);

        public Client(TcpClient client)
        {
            this.client = client;
            NetworkStream stream = client.GetStream();

            writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            reader = new StreamReader(stream, Encoding.ASCII);

            GetMessageHandler += this.Send;
        }

        public void Start()
        {
            while (true)
            {
                string? inputLine = "";
                while (inputLine != null)
                {
                    try
                    {

                        inputLine = reader.ReadLine();
                        if (inputLine == null) break;

                        Console.WriteLine(client.GetHashCode().ToString() + ": \t" + inputLine);

                        this.GetMessageHandler?.Invoke(inputLine);
                    } catch { }
                }

                this.Dispose();
                Console.WriteLine("Server saw disconnect from client.");
            }
        }

        public void Send(string msg)
        {
            writer.WriteLine(msg);
        }

        public void Dispose()
        {
            writer.Dispose();
            reader.Dispose();
            client.Dispose();
        }
    }


}
