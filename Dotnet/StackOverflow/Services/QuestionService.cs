using StackOverflow.Model.Question;
using StackOverflow.Model.User;

namespace StackOverflow.Services;

public class QuestionService
{
    private readonly Dictionary<int,Question.Question> _questions;
    private readonly List<Tag> _tags;
    public QuestionService()
    {
        _questions = new Dictionary<int, Question.Question>();
        _tags = new List<Tag>();
    }

    public Question.Question CreateQuestion(string title, string description, User author, List<string> tagNames)
    {
        var question = new Question.Question
        {
            Id = _questions.Count + 1,
            Title = title,
            Description = description,
            Tag = SetTags(tagNames),
            Author = author,
            Answer = new List<Answer>(),
            Comments = new List<Comment>(),
            CreatedOn = DateTime.Now,
        };
        
        _questions.Add(question.Id, question);
        return question;
    }

    private List<Tag> SetTags(List<string> tagNames)
    {
        int totalTags = _tags.Count;
        var tags = tagNames.Select((tagName,index) => new Tag {Id = ++totalTags, Name = tagName}).ToList();
        _tags.AddRange(tags);
        return tags;
    }

    public List<Question.Question> GetAllQuestions() => _questions.Values.ToList();

    public Question.Question AnswerQuestion(Question.Question question,Answer answer)
    {
        if (!_questions.TryGetValue(question.Id, out Question.Question questionToAnswer))
        {
            throw new Exception("Question not found for Answering");
        }

        questionToAnswer.Answer?.Add(answer);
        return questionToAnswer;
    }

    public Question.Question VoteAnswer(Answer question, User voter, VoteType voteType)
    {
        if (!_questions.TryGetValue(question.Question.Id, out Question.Question questionToAnswer))
        {
            throw new Exception("Question not found Against the Answer for Upvote");
        }

        question.Vote(voter,voteType);
        var ansNumber = questionToAnswer.Answer?.FindIndex(_ => _.Id == question.Id);
        if (questionToAnswer.Answer != null)
            if (ansNumber != null)
                questionToAnswer.Answer[ansNumber.Value] = question;
        return questionToAnswer;
    }
    
    public Question.Question VoteQuestion(Question.Question question, User voter, VoteType voteType)
    {
        if (!_questions.TryGetValue(question.Id, out Question.Question questionToAnswer))
        {
            throw new Exception("Question not found for Upvote");
        }

        questionToAnswer.Vote(voter,voteType);
        
        return questionToAnswer;
    }
    
    public Question.Question AddComments(Question.Question question, Comment comment)
    {
        if (!_questions.TryGetValue(question.Id, out Question.Question questionToAnswer))
        {
            throw new Exception("Question not found for Upvote");
        }

        questionToAnswer.Comments?.Add(comment);
        return questionToAnswer;
    }

    public IEnumerable<Answer> GetAllQuestionsAnsweredByAUser(User user)
    {
       return _questions.Values.SelectMany(question => question.Answer)
            .Where(_ => _.AnswereBy.Id == user.Id);
    }


    public List<Question.Question> SearchQuestion(string tagName)
    {
        var tagQuestions = new List<Question.Question>();
        foreach (var question in _questions)
        {
            var questionId = question.Key;
            if (question.Value.Tag.Any(_ => string.Equals(_.Name, tagName,StringComparison.CurrentCultureIgnoreCase))
                || question.Value.Description.Contains(tagName))
            {
                tagQuestions.Add(question.Value);
            }
        }
        return tagQuestions;
    }
}