namespace CapitalPlacement_Task1.Domain;

public class Field
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "text")]
    public string Text { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "isMandatory")]
    public bool IsMandatory { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "answerType")]
    public AnswerType AnswerType { get; set; }
}
