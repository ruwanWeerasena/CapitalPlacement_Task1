using static System.Net.Mime.MediaTypeNames;

namespace CapitalPlacement_Task1.Domain;

public class Program
{
    [Newtonsoft.Json.JsonProperty(propertyName: "id")]
    public string Id { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "title")]
    public string Title { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "description")]
    public string Description { get; set; }
    [Newtonsoft.Json.JsonProperty(propertyName: "application")]
    public Application Application { get; set; }

}
