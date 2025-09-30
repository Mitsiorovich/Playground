using System.Net;
using ChatComponent;

class Program
{
    static void Main(string[] args)
    {
        // Create server instance (listening on localhost:9000)
        ChatServer server = new ChatServer(IPAddress.Loopback, 9000);

        // Start server
        server.TryStartAsync();

        Console.WriteLine("Chat server is running. Press Enter to exit...");
        Console.ReadLine();

        // Stop server
        server.Close();
    }
}
