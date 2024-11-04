using YamlDotNet.Serialization;

namespace Tfl.JourneyPlanner.Config
{
    public class TestConfiguration
    {
        public const string FileName = "settings.yml";

        [YamlMember(Alias = "url")] public string? Url { get; set; }

        [YamlMember(Alias = "browserOptions")] public BrowserOptions BrowserOptions { get; set; } = new();
    }
}