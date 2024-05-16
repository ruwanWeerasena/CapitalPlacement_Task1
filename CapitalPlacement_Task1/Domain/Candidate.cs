namespace CapitalPlacement_Task1.Domain;

public class Candidate
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "_program_id")]
    public string ProgramId { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "fieldAnswers")]
    public List<FieldAnswer> FieldAnswers { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "customQuestionAnswers")]
    public List<CustomQuestionAnswer> CustomQuestionAnswers { get; set; }
}
