using ClientLib;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Starting echo client...");
Client cls = new Client(48901);
cls.Start();

Thread.Sleep(5000);

//cls.Stop();
Console.WriteLine("colse coonect");
while (true) ;


