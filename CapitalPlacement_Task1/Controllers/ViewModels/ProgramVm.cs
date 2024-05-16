namespace CapitalPlacement_Task1.Controllers.ViewModels;

public class ProgramVm
{
    public string Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public ApplicationVm Application { get; set; }
}



public class ApplicationVm
{
    public List<FieldVm> Fields { get; set; }
    public List<CustomQuestionVm> CustomQuestions { get; set; }
}
public class FieldVm
{
    public string Id { get; set; }
    public string Text { get; set; }
    public bool IsMandatory { get; set; }
    public string AnswerType { get; set; }
}
public class CustomQuestionVm
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string QuestionType { get; set; }
    public List<string>? Choices { get; set; }
    public string AnswerType { get; set; }
}
