using StackOverflow.Model.Question;
using StackOverflow.Model.User;

namespace StackOverflow.Question;

public class Question
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<Tag> Tag { get; set; }
    public User Author { get; set; }
    
    public List<Answer>? Answer { get; set; }
    public int TotalVotes { get; private set; }
    private HashSet<int>? UserVotes { get; set; }
    public List<Comment>? Comments { get; set; }
    public DateTime CreatedOn { get; set; }

    public void Vote(User user, VoteType voteType)
    {
        if (UserVotes is null)
        {
            this.UserVotes = new HashSet<int>();
        }
        if (!UserVotes.Contains(user.Id))
        {
            if(voteType == VoteType.Upvote)
            {
                TotalVotes++;
            }
            else if (voteType == VoteType.Downvote)
            {
                TotalVotes--;
            }
        }
    }
}