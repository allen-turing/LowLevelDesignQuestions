namespace StackOverflow.Model.Question;

public class Comment
{
    public int Id { get; set; }
    public string Description { get; set; }
    public User.User PostedBy { get; set; }
}