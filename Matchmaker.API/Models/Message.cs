namespace Matchmaker.API.Models;

public class Message {
    public int Id { get; set; }
    public string Content { get; set; }
    public int SenderId { get; set; }
    public int RecieverId { get; set; }
    public DateTime TimeStamp { get; set; }

    public Message(string content, int senderId, int recieverId )
    {
        Content = content;
        SenderId = senderId;
        RecieverId = recieverId;
        TimeStamp = DateTime.UtcNow;
    }
}