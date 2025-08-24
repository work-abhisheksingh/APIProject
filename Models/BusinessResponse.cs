namespace MyMvcApiProject.Models
{
    public class BusinessResponse
    {
        public int BusinessId { get; set; }
        public Dictionary<string, object?> Data { get; set; } = new();
    }
}