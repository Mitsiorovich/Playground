namespace ChatComponent
{
    public class Message
    {
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageStr { get; set; } = string.Empty;
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;
        public bool Delivered { get; set; } = false;
    }
}
