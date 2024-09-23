namespace StackOverflow.Model.Question;

public class Answer
{
    public int Id { get; set; }
    public string Descrition { get; set; }
    public User.User AnswereBy { get; set; }
    public DateTime AnswerOn { get; set; }
    
    public int TotalVotes { get; private set; }
    private HashSet<int>? UserVotes { get; set; }

    public StackOverflow.Question.Question Question { get; set; }
    public void Vote(User.User user, VoteType voteType)
    {
        if (UserVotes is null)
        {
            this.UserVotes = new HashSet<int>();
        }
        if (!UserVotes.Contains(user.Id))
        {
            switch (voteType)
            {
                case VoteType.Upvote:
                    TotalVotes++;
                    break;
                case VoteType.Downvote:
                    TotalVotes--;
                    break;
            }
        }
    }
}