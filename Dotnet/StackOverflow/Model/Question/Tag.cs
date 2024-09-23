using System.Security.AccessControl;

namespace StackOverflow.Model.Question;

public class Tag
{
    public Tag()
    {
        QuestionIds = new List<int>();
    }
    public int Id { get; set; }
    public string Name { get; set; }

    public List<int> QuestionIds { get; set; }
}