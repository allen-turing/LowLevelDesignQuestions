using System.Text.Json;
using System.Text.Json.Serialization;
using StackOverflow.Model.Question;

namespace StackOverflow.Services;

public class StackOverflow
{
    public StackOverflow()
    {
        var userService = new UserService();

        var user1 = userService.CreateUserAsync("praty", "praty@gmail.com");
        var user2 = userService.CreateUserAsync("alan", "alan@yahoo.com");
        var user3 = userService.CreateUserAsync("blake", "blake@outlook.com");
        var user4 = userService.CreateUserAsync("rayan", "rayan@proton.com");

        var allUsers = userService.GetAllUsers();
        Print(allUsers, "--- All users ---  ");
        var questionService = new QuestionService();
        var question1 = questionService.CreateQuestion("Git Rebase vs Git Merge",
            "How is git rebase different from git merge?",
            user1,
            ["Git", "Rebase", "Merge"]
        );

        var question2 = questionService.CreateQuestion("Abstraction vs Interface",
            "What is the difference between Abstract class in Interface?",
            user1,
            ["OOPS", "AbstractClass", "Interface"]
        );

        Print(questionService.GetAllQuestions(), "--- All Question ---  ");
        var answer1 = new Answer
        {
            Id = 1,
            Descrition = "Git Rebase keeps the history clean and merge creates a new additonal merge commit",
            AnswereBy = user2,
            AnswerOn = DateTime.Now,
            Question = question1
        };

        var answer2 = new Answer
        {
            Id = 2,
            Descrition = "An abstract class** can contain both abstract methods (without implementation) " +
                         "and concrete methods (with implementation). An **interface** only contains method " +
                         "declarations, and any class implementing it must provide implementations for all its methods",
            AnswereBy = user3,
            AnswerOn = DateTime.Now,
            Question = question2
        };
        question1 = questionService.AnswerQuestion(question1, answer1);
        question1 = questionService.VoteAnswer(answer1, user1);
        question1 = questionService.VoteAnswer(answer1, user2);

        question2 = questionService.AnswerQuestion(question2, answer2);
        question2 = questionService.VoteAnswer(answer2, user1);
        question2 = questionService.VoteAnswer(answer2, user2);
        question2 = questionService.VoteAnswer(answer2, user3);
        question2 = questionService.VoteAnswer(answer2, user4);

        var comment = new Comment
        {
            Description = "Git has awesome documentation have you checke that?",
            PostedBy = user4
        };

        var comment2 = new Comment
        {
            Description = "Try to use any object oriented programing language and explore your own?",
            PostedBy = user4
        };

        question1 = questionService.AddComments(question1, comment);
        question2 = questionService.AddComments(question2, comment2);

        var user1Reputation = userService.GetReputation(user2, questionService);
        var user3Reputation = userService.GetReputation(user3, questionService);

        Print(questionService.GetAllQuestions(), "--- All questions After Comment and Reputation ---  ");

        var searchQuestionWithTag = questionService.SearchQuestion("GIT");
        var searchQuestionWithTag2 = questionService.SearchQuestion("Oops");

        Print(searchQuestionWithTag, "--- Search Question With Tag : GIT---  ");
        Print(searchQuestionWithTag2, "--- Search Question With Tag : Oops---  ");
    }

    private void Print<T>(T input, string description)
    {
        Console.WriteLine(description);
        var jsonOption = new JsonSerializerOptions
        {
            WriteIndented = true,
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        };
        var jsonString = JsonSerializer.Serialize(input, jsonOption);
        Console.WriteLine(jsonString);
        Console.WriteLine("\n\n");
    }
}