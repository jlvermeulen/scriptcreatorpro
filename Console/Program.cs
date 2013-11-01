using System;
using System.Collections.Generic;

namespace ScriptCreatorPRO
{
    class Program
    {
        private static readonly Dictionary<string, string> arguments = new Dictionary<string, string>()
        {
            {"input", null},
            {"bps", null},
            {"sample-rate", null},
            {"channels", null},
            {"framerate", null},
            {"delay", "0"},
            {"aac-rate", "192000"}
        };

        static void Main(string[] args)
        {
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("--"))
                {
                    string arg = args[i].Substring(2);
                    if (i < args.Length - 1 && !args[i + 1].StartsWith("--"))
                        arguments[arg] = args[++i];
                    else
                        arguments[arg] = "";
                }
            }

            if (arguments["input"] == null ||
                ((arguments.ContainsKey("audio") || arguments.ContainsKey("all")) && arguments.ContainsValue(null)) ||
                (arguments.ContainsKey("chapters") && arguments ["framerate"] == null))
                throw new ArgumentException("Not all necessary commandline arguments were provided.");

            Console.WriteLine("Parsing " + arguments["input"] + "\n");
            Part[] parts = ScriptCreator.ParseScript(arguments["input"]);
            Console.WriteLine("Detected the following segments:");
            foreach (Part p in parts)
            {
                Console.WriteLine("\n" + p.Name);
                Console.WriteLine("Script designation: " + p.ScriptDesignation);
                Console.WriteLine("Start frame: " + p.StartFrame);
                Console.WriteLine("End frame: " + p.EndFrame);
                Console.WriteLine("Enabled: " + p.Enabled);
            }

            Console.WriteLine();

            if (arguments.ContainsKey("audio") || arguments.ContainsKey("all"))
            {
                Console.WriteLine("Generating audio.bat...");
                ScriptCreator.CreateAudio(parts, arguments["input"], int.Parse(arguments["framerate"]), arguments.ContainsKey("big"), arguments.ContainsKey("signed"),
                    int.Parse(arguments["bps"]), int.Parse(arguments["sample-rate"]), int.Parse(arguments["channels"]), int.Parse(arguments["delay"]),
                    arguments.ContainsKey("aac"), int.Parse(arguments["aac-rate"]));
            }

            if (arguments.ContainsKey("qpfile") || arguments.ContainsKey("all"))
            {
                Console.WriteLine("Generating qpfile.txt...");
                ScriptCreator.CreateQP(parts, arguments["input"]);
            }

            if (arguments.ContainsKey("chapters") || arguments.ContainsKey("all"))
            {
                Console.WriteLine("Generating chapters.xml...");
                ScriptCreator.CreateChapters(parts, arguments["input"], int.Parse(arguments["framerate"]));
            }

            Console.WriteLine("\nDone!");
        }
    }
}
