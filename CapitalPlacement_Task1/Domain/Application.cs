namespace CapitalPlacement_Task1.Domain;

public class Application
{
    [Newtonsoft.Json.JsonProperty(propertyName: "fields")]
    public List<Field> Fields { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "customQuestions")]
    public List<CustomQuestion> CustomQuestions { get; set; }
}
