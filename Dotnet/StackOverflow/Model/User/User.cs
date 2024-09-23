namespace StackOverflow.Model.User;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public UserReputation Reputation { get; set; }
}