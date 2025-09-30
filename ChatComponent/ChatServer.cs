using System.Collections.Concurrent;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace ChatComponent
{
    public class ChatServer
    {
        private readonly TcpListener listener;
        private readonly ConcurrentDictionary<Guid, TcpClient> connectedClients = new ConcurrentDictionary<Guid, TcpClient>();
        private readonly MessageRepository messageRepo;

        public ChatServer(IPAddress address, int port, string storageFile = "messages.json")
        {
            listener = new TcpListener(address, port);
            messageRepo = new MessageRepository(storageFile);
        }

        public async void TryStartAsync()
        {
            try
            {
                listener.Start();
                Console.WriteLine("Server started...");

                while (true)
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("New client connected");

                    _ = HandleClientAsync(client);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            Guid? senderId = null;

            try
            {
                using NetworkStream stream = client.GetStream();

                while (client.Connected)
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    if (bytesRead == 0) break;

                    string json = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Message? msg = JsonSerializer.Deserialize<Message>(json);

                    if (msg == null) continue;

                    // First message from client → register sender
                    if (!senderId.HasValue)
                    {
                        senderId = msg.SenderId;
                        connectedClients.TryAdd(senderId.Value, client);
                        Console.WriteLine($"Registered new client: {senderId}");

                        // Send any undelivered messages
                        var pendingMessages = messageRepo.GetUndeliveredMessages(senderId.Value);
                        foreach (var pending in pendingMessages)
                        {
                            byte[] msgBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(pending));
                            await stream.WriteAsync(msgBytes, 0, msgBytes.Length);
                        }
                        if (pendingMessages.Any())
                        {
                            messageRepo.MarkAsDelivered(senderId.Value);
                            Console.WriteLine($"Delivered {pendingMessages.Count} pending messages to {senderId}");
                        }
                    }

                    // Handle new incoming messages
                    if (connectedClients.TryGetValue(msg.ReceiverId, out TcpClient? receiverClient))
                    {
                        NetworkStream receiverStream = receiverClient.GetStream();
                        byte[] msgBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(msg));
                        await receiverStream.WriteAsync(msgBytes, 0, msgBytes.Length);
                        Console.WriteLine($"Forwarded message from {msg.SenderId} to {msg.ReceiverId}");
                    }
                    else
                    {
                        // Save to repo if recipient is offline
                        messageRepo.SaveMessage(msg);
                        Console.WriteLine($"Stored message for {msg.ReceiverId}, they are offline");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Client error: {ex.Message}");
            }
            finally
            {
                if (senderId.HasValue)
                {
                    connectedClients.TryRemove(senderId.Value, out _);
                    Console.WriteLine($"Client {senderId} disconnected and removed");
                }
                client.Close();
            }
        }

        public void Close()
        {
            listener.Stop();
            Console.WriteLine("Server stopped");
        }
    }
}
