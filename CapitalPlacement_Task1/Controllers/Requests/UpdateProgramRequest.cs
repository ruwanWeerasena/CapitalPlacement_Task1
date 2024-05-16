
using CapitalPlacement_Task1.Domain;

namespace CapitalPlacement_Task1.Controllers.Requests;
public class UpdateProgramRequest
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ApplicationUpdateRequest ApplicationRequest { get; set; }
}

public class ApplicationUpdateRequest
{
    public List<FieldUpdateRequest> FieldRequests { get; set; }
    public List<CustomQuestionUpdateRequest> CustomQuestionRequests { get; set; }
}
public class FieldUpdateRequest
{
    public string Id { get; set; }
    public string Text { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerType AnswerType { get; set; }
}
public class CustomQuestionUpdateRequest
{
    public string Id { get; set; }
    public string Text { get; set; }
    public QuestionType QuestionType { get; set; }
    public List<string>? Choices  { get; set; }
    public AnswerType AnswerType { get; set; }
}

