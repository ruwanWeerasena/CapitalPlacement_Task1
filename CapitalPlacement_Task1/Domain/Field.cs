namespace CapitalPlacement_Task1.Domain;

public class Field
{
    public string Id { get; set; }
    public string Text { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerType AnswerType { get; set; }
}
