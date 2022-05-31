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
                    Console.WriteLine(o.Source);

                });
        }
    }
}
