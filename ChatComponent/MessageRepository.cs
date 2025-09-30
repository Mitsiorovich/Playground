using System.Text.Json;

namespace ChatComponent
{
    public class MessageRepository
    {
        private readonly string _filePath;
        private readonly object _lock = new object();
        private const int MaxMessages = 200;

        public MessageRepository(string filePath = "messages.json")
        {
            _filePath = filePath;

            // Create the file if it doesn’t exist
            if (!File.Exists(_filePath))
            {
                File.WriteAllText(_filePath, "[]");
            }
        }

        private List<Message> LoadMessages()
        {
            lock (_lock)
            {
                string json = File.ReadAllText(_filePath);
                return JsonSerializer.Deserialize<List<Message>>(json) ?? new List<Message>();
            }
        }

        private void SaveMessages(List<Message> messages)
        {
            lock (_lock)
            {
                string json = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(_filePath, json);
            }
        }

        public void SaveMessage(Message message)
        {
            lock (_lock)
            {
                var messages = LoadMessages();
                messages.Add(message);

                // Trim to last 200 messages
                if (messages.Count > MaxMessages)
                {
                    messages = messages.Skip(messages.Count - MaxMessages).ToList();
                }

                SaveMessages(messages);
            }
        }

        public List<Message> GetUndeliveredMessages(Guid receiverId)
        {
            lock (_lock)
            {
                var messages = LoadMessages();
                return messages
                    .Where(m => m.ReceiverId == receiverId && !m.Delivered)
                    .ToList();
            }
        }

        public void MarkAsDelivered(Guid receiverId)
        {
            lock (_lock)
            {
                var messages = LoadMessages();
                foreach (var msg in messages.Where(m => m.ReceiverId == receiverId))
                {
                    msg.Delivered = true;
                }
                SaveMessages(messages);
            }
        }
    }
}
