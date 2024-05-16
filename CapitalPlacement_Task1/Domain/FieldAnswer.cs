namespace CapitalPlacement_Task1.Domain;

public class FieldAnswer
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "_field_id")]
    public string FieldId { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "answer")]
    public string Answer { get; set; }
}
