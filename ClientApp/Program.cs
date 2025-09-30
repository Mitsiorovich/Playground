using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatClientTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Choose user
            Console.WriteLine("Choose user (A/B):");
            string choice = Console.ReadLine() ?? "A";

            Guid myId = choice.ToUpper() == "A"
                ? Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa")
                : Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb");

            Guid otherId = choice.ToUpper() == "A"
                ? Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb")
                : Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa");

            using TcpClient client = new TcpClient();
            await client.ConnectAsync("127.0.0.1", 9000); // connect to server
            NetworkStream stream = client.GetStream();

            // Task to listen for incoming messages
            _ = Task.Run(async () =>
            {
                byte[] buffer = new byte[1024];
                while (true)
                {
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) continue;

                    string msgJson = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    var msg = JsonSerializer.Deserialize<Message>(msgJson);
                    Console.WriteLine($"Received from {msg?.SenderId}: {msg?.MessageStr}");
                }
            });

            // Loop to send messages
            while (true)
            {
                string text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) continue;

                var message = new Message
                {
                    SenderId = myId,
                    ReceiverId = otherId,
                    MessageStr = text,
                    Timestamp = DateTime.UtcNow,
                    Delivered = false
                };

                byte[] data = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
                await stream.WriteAsync(data, 0, data.Length);
            }
        }
    }

    public class Message
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageStr { get; set; } = "";
        public DateTime Timestamp { get; set; }
        public bool Delivered { get; set; }
    }
}
