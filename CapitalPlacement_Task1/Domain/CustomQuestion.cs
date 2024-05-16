namespace CapitalPlacement_Task1.Domain;

public class CustomQuestion
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "text")]
    public string Text { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "type")]
    public QuestionType Type { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "choices")]
    public List<string>? Choices { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "answerType")]
    public AnswerType AnswerType { get; set; }
}
