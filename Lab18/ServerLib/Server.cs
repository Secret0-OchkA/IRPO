using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace ServerLib
{
    public class Server : IDisposable
    {
        TcpListener listener;

        LinkedList<Client> clients = new LinkedList<Client>();

        public event GetMessageEvent GetMessageServerHandler;

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
                    c.GetMessageClientHandler += newClient.Send;
                    newClient.GetMessageClientHandler += c.Send;
                }

                newClient.GetMessageClientHandler += this.GetMessage;

                clients.AddFirst(newClient);

                Thread Thread = new Thread(() => newClient.Start());

                Thread.Start();
            }
        }

        public void GetMessage(object sender,string msg)
        {
            Console.WriteLine($"{sender.GetHashCode()} get message: " + msg);
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

        public event GetMessageEvent GetMessageClientHandler;

        public Client(TcpClient client)
        {
            this.client = client;
            NetworkStream stream = client.GetStream();

            writer = new StreamWriter(stream, Encoding.ASCII) { AutoFlush = true };
            reader = new StreamReader(stream, Encoding.ASCII);

            GetMessageClientHandler += this.Send;
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

                        this.GetMessageClientHandler?.Invoke(this, inputLine);
                    } catch { }
                }

                this.Dispose();
                Console.WriteLine("Server saw disconnect from client.");
            }
        }

        public void Send(object sender, string msg)
        {
            writer.WriteLine(sender.GetHashCode().ToString() + ":\t" + msg);
        }

        public void Dispose()
        {
            writer.Dispose();
            reader.Dispose();
            client.Dispose();
        }
    }

    public delegate void GetMessageEvent(object sender, string message);
}
