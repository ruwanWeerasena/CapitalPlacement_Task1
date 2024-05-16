namespace CapitalPlacement_Task1.Controllers.Requests;

public class CreateCandidateRequest
{
    public string ProgramId { get; set; }
    public List<FieldAnswerRequest> FieldAnswers { get; set; }
    public List<CustomQuestionAnswerRequest> CustomQuestionAnswers { get; set; }
}
public class FieldAnswerRequest
{
    public string FieldId { get; set; } 
    public string Answer { get; set; }
}

public class CustomQuestionAnswerRequest
{
    public string CustomQuestionId { get; set; }
    public Object Answer { get; set; }
}
