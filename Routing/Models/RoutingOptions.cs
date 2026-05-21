namespace TgWsProxy.Routing.Models
{
    public class RoutingOptions
    {
        public int ZapretPort { get; set; } = 1081;

        public List<string> ZapretDomains { get; set; } = new()
        {
            "youtube.com",
            "youtu.be",
            "googleapis.com",
            "discord.com",
        };
    }
}
