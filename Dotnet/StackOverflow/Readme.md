# Overview
Stack-overflow is a website for developers over which they can post their questions and other developers can answers those question.

# Functional Requirement
1. User should be able to post questions
2. User should be able to answer other posted questions
3. User can add comments to the questions
4. User should be able to search question by
    1. By Question Keywords
    2. By Tag
    3. By Username
5. User should be able to upvote the question
6. User reputation should be assigned based on number of upvotes they receive on questions

# Non Functional Requirement
1. System should be able to handle current users



```mermaid
classDiagram
    class QuestionService {
        -Dictionary&lt;int, Question&gt; _questions
        -List&lt;Tag&gt; _tags
        -Dictionary&lt;string, List&lt;int&gt;&gt; _tagQuestionMapping
        +QuestionService()
        +CreateQuestion(string title, string description, User author, List&lt;string&gt; tagNames) : Question
        +GetAllQuestions() : List&lt;Question&gt;
        +AnswerQuestion(Question question, Answer answer) : Question
        +VoteAnswer(Answer answer, User voter, VoteType voteType) : Question
        +VoteQuestion(Question question, User voter, VoteType voteType) : Question
        +AddComments(Question question, Comment comment) : Question
        +GetAllQuestionsAnsweredByAUser(User user) : IEnumerable&lt;Answer&gt;
        +SearchQuestion(string tagName) : List&lt;Question&gt;
        -SetTags(List&lt;string&gt; tagNames, int questionId) : List&lt;Tag&gt;
    }

    class Answer {
        +int Id
        +string Description
        +User AnswereBy
        +DateTime AnswerOn
        +int TotalVotes
        +void Vote(User user, VoteType voteType)
        -HashSet&lt;int&gt; UserVotes
        +Question Question
    }

    class Comment {
        +int Id
        +string Description
        +User PostedBy
    }

    class Tag {
        +int Id
        +string Name
        +List&lt;int&gt; QuestionIds
    }

    class Question {
        +int Id
        +string Title
        +string Description
        +List&lt;Tag&gt; Tags
        +User Author
        +List&lt;Answer&gt; Answers
        +List&lt;Comment&gt; Comments
        +DateTime CreatedOn
        +int TotalVotes
        +void Vote(User user, VoteType voteType)
        -HashSet&lt;int&gt; UserVotes
    }

    class UserService {
        -List&lt;User&gt; _users
        +UserService()
        +CreateUserAsync(string username, string email) : User
        +GetReputation(User user, QuestionService questionService) : UserReputation
        +GetAllUsers() : List&lt;User&gt;
    }

    class User {
        +int Id
        +string Name
        +string Email
        +UserReputation Reputation
    }

    class UserReputation {
    }

    class StackOverflow {
        +StackOverflow()
        +Print&lt;T&gt;(T input, string description)
    }

    class StackOverflowInitializer {
        +Main(string[] args)
    }

    class VoteType {
        Upvote
        Downvote
    }

    %% Relationships
    QuestionService --> Question
    QuestionService --> Answer
    QuestionService --> Tag
    QuestionService --> Comment
    QuestionService --> User

    Question --> Answer
    Question --> Tag
    Question --> Comment
    Question --> User

    Answer --> User
    Answer --> Question
    Answer --> VoteType

    Comment --> User

    Tag --> Question

    User --> UserReputation
```

