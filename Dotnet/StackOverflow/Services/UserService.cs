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
        Console.WriteLine($"Created user {username} with email {email}.");
        return user;
    }

    public UserReputation GetReputation(User user, QuestionService questionService)
    {
        int reputationCount = questionService.GetAllQuestionsAnsweredByAUser(user).Count();

        if (reputationCount >= 0 && reputationCount < 2)
        {
            user.Reputation = UserReputation.Beginer;
        }
        if (reputationCount >= 2 && reputationCount < 4)
        {
            user.Reputation = UserReputation.Intermediate;
        }
        if (reputationCount >= 4 && reputationCount < 6)
        {
            user.Reputation = UserReputation.Master;
        }
        if (reputationCount >= 6 && reputationCount < 8)
        {
            user.Reputation = UserReputation.SubjectMatterExpert;
        }
        
        return user.Reputation;
    }

    public List<User> GetAllUsers()
    {
        return _users;
    }
}