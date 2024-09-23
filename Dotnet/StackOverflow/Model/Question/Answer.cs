namespace StackOverflow.Model.Question;

public class Answer
{
    public int Id { get; set; }
    public string Descrition { get; set; }
    public User.User AnswereBy { get; set; }
    public DateTime AnswerOn { get; set; }

    public StackOverflow.Question.Question Question { get; set; }
}