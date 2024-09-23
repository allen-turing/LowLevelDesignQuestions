using StackOverflow.Model.Question;
using StackOverflow.Model.User;

namespace StackOverflow.Services;

public class QuestionService
{
    private readonly Dictionary<int,Question.Question> _questions;
    public QuestionService()
    {
        _questions = new Dictionary<int, Question.Question>();
    }

    public Question.Question CreateQuestion(string title, string description, User author, List<string> tagNames)
    {
        var question = new Question.Question
        {
            Id = _questions.Count + 1,
            Title = title,
            Description = description,
            Tag = tagNames.Select(tagName => new Tag {Id = _questions.Count + 1, Name = tagName}).ToList(),
            Author = author,
            Answer = new List<Answer>(),
            TotalVotes = 0,
            Comments = new List<Comment>(),
            CreatedOn = DateTime.Now,
        };
        
        _questions.Add(question.Id, question);
        return question;
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

    public Question.Question VoteAnswer(Answer answer, User voter)
    {
        if (!_questions.TryGetValue(answer.Question.Id, out Question.Question questionToAnswer))
        {
            throw new Exception("Question not found for Upvote");
        }

        questionToAnswer.UpVote(voter);
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