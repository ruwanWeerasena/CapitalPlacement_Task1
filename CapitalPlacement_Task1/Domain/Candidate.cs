namespace CapitalPlacement_Task1.Domain;

public class Candidate
{
    public string Id { get; set; }
    public string ProgramId { get; set; }
    public List<FieldAnswer> FieldAnswers { get; set; }
    public List<CustomQuestionAnswer> CustomQuestionAnswers { get; set; }
}
