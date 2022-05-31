// See https://aka.ms/new-console-template for more information

using CommandLine;

namespace nugeted
{
    class Options
    {
        [Option('s', "source", Required = true, HelpText = "Source path")]
        public string Source { get; set; }
    }

    class Program
    {
        public static void Main(string[] args)
        {
            CommandLine.Parser.Default.ParseArguments<Options>(args)
                .WithParsed<Options>(o =>
                {
                    var path = Path.GetDirectoryName(o.Source);
                    var watcher = new FileSystemWatcher(path);
                    watcher.Filter = "*.dll";
                    watcher.NotifyFilter = NotifyFilters.LastWrite;
                    watcher.Changed += Watcher_Changed;
                    watcher.Created += Watcher_Changed;
                    watcher.Renamed += Watcher_Changed;
                    watcher.Deleted += Watcher_Changed;
                    watcher.EnableRaisingEvents = true;

                    Console.ReadLine();
                });
        }

        private static void Watcher_Changed(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.ChangeType} {e.Name} {File.GetLastWriteTime(e.FullPath)} {File.GetAttributes(e.FullPath)}");
        }
    }
}
