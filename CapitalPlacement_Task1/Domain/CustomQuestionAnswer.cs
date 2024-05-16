namespace CapitalPlacement_Task1.Domain;

public class CustomQuestionAnswer
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "_customQuestion_id")]
    public string CustomQuestionId { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "answer")]
    public object Answer { get; set; }
}
