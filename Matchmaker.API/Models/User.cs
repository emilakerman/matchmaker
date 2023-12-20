namespace Matchmaker.API.Models;

public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ProfileText { get; set; }
    public List<int>? Likes { get; set; } = new List<int>();
    public List<int>? Dislikes { get; set; } = new List<int>();
    public List<Message> SentMessages {get; set; } = new List<Message>();
     public List<Message> RecievedMessages {get; set; } = new List<Message>();

    public User(string name, string profileText)
    {
        Name = name;
        ProfileText = profileText;
    }
}