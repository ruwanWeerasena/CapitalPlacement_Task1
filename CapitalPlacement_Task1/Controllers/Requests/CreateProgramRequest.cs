

using CapitalPlacement_Task1.Domain;

namespace CapitalPlacement_Task1.Controllers.Requests;

public class CreateProgramRequest
{
    public string Title { get; set; }
    public string Description { get; set; }
    public ApplicationRequest ApplicationRequest { get; set; }
}

public class ApplicationRequest
{
    public List<FieldRequest> FieldRequests { get; set; }
    public List<CustomQuestionRequest> CustomQuestionRequests { get; set; }
}
public class FieldRequest
{
    public string Text { get; set; }
    public bool IsMandatory { get; set; }
    public AnswerType AnswerType { get; set; }
}
public class CustomQuestionRequest
{
    public string Text { get; set; }
    public QuestionType QuestionType { get; set; }
    public List<string>? Choices  { get; set; }
    public AnswerType AnswerType { get; set; }
}

