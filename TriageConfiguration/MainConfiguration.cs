using System.Text.Json;
using System.Text.Json.Serialization;
using TriageConfiguration.TriageElements;
using TriageConfiguration.TrieageDrawer;

namespace TriageConfiguration
{
    public class MainConfiguration
    {
        public static async Task Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please give the path of .json in the command line arguments!");
                return;
            }
            using FileStream openStream = File.OpenRead(args[0]);
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            options.Converters.Add(new JsonStringEnumConverter());

            TriageConfig? triageConfig = await JsonSerializer.DeserializeAsync<TriageConfig>(openStream, options);

            TriageDrawer.Draw(triageConfig, new TextTriageDrawer());
            TriageDrawer.Draw(triageConfig, new HtmlTextTriageDrawer());
            TriageDrawer.Draw(triageConfig, new HtmlImageTriageDrawer());
            TriageDrawer.Draw(triageConfig, new ConsoleTriageDrawer());
        }
    }
}
