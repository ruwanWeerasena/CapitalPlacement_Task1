namespace CapitalPlacement_Task1.Domain;

public class CustomQuestion
{
    public string Id { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }
    public List<string>? Choices { get; set; }
    public AnswerType AnswerType { get; set; }
}
