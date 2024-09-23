using StackOverflow.Model.User;

namespace StackOverflow.Services;

public class UserService
{
    private readonly List<User> _users;
    public UserService()
    {
        _users = new List<User>(); 
    }
    public User CreateUserAsync(string username, string email)
    {
        var user = new User
        {
            Id = _users.Count + 1,
            Name = username,
            Email = email,
            Reputation = 0
        };
        _users.Add(user);
        return user;
    }

    public UserReputation GetReputation(User user, QuestionService questionService)
    {
        int reputationCount = questionService.GetAllQuestionsAnsweredByAUser(user).Count();

        user.Reputation = reputationCount switch
        {
            >= 0 and < 2 => UserReputation.Beginer,
            >= 2 and < 4 => UserReputation.Intermediate,
            >= 4 and < 6 => UserReputation.Master,
            >= 6 and < 8 => UserReputation.SubjectMatterExpert,
            _ => user.Reputation
        };

        return user.Reputation;
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}