using System;
using System.IO;
using System.Collections.Generic;

namespace ScriptCreatorPRO
{
    public static class ScriptCreator
    {
        public static void CreateAudio(Part[] parts, string script, int framerate, bool bigEndian, bool signed, int bps, int sample, int channels, bool aac, int aacRate)
        {
            StreamWriter writer = new StreamWriter(Path.GetDirectoryName(script) + "\\audio.bat");
            string endian = bigEndian ? "big" : "little";
            
            int partCount = 0;
            int startTime;
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Enabled)
                {
                    startTime = parts[i].StartFrame;
                    while (i < parts.Length - 1 && parts[i + 1].Enabled && parts[i].EndFrame == parts[i + 1].StartFrame - 1)
                        i++;

                    writer.WriteLine("flac --fast --skip=" + FrameToTimeStamp(startTime, framerate) + " --until=" + FrameToTimeStamp(parts[i].EndFrame + 1, framerate) +
                        " --endian=" + endian + " --sign=" + (signed ? "signed" : "unsigned") + " --bps=" + bps + " --sample-rate=" + sample + " --channels=" + channels +
                        " -f -o part" + partCount++ + ".flac audio.pcm");
                }
            }

            for (int i = 0; i < partCount; i++)
                writer.WriteLine("eac3to part" + i + ".flac part" + i + ".pcm");

            writer.Write("eac3to ");
            for (int i = 0; i < partCount; i++)
                writer.Write("part"+i+".pcm" + (i == partCount - 1 ? " " : "+"));
            writer.WriteLine("parts.pcm -" + channels + " -" + endian + " -" + sample + " -" + bps);

            writer.WriteLine("flac --best --endian=" + endian + " --sign=" + (signed ? "signed" : "unsigned") + " --bps=" + bps + " --sample-rate=" + sample + " --channels=" + channels + " -f -o audio.flac parts.pcm");

            if (aac)
            {
                writer.WriteLine("eac3to audio.flac audio.wav");
                writer.WriteLine("neroaacenc -br " + aacRate + " -lc -if audio.wav -of audio.aac");
                writer.WriteLine("del \"audio - Log.txt\"");
                writer.WriteLine("del \"audio.wav\"");
            }

            for (int i = 0; i < partCount; i++)
            {
                writer.WriteLine("del \"part" + i + " - Log.txt\"");
                writer.WriteLine("del \"part" + i + ".pcm\"");
                writer.WriteLine("del \"part" + i + ".flac\"");
            }

            writer.WriteLine("del \"parts - Log.txt\"");
            writer.WriteLine("del \"parts.pcm\"");
            writer.WriteLine("pause");

            writer.Close();
        }

        public static void CreateQP(Part[] parts, string script)
        {
            StreamWriter writer = new StreamWriter(Path.GetDirectoryName(script) + "\\qpfile.txt");
            int current = 0;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (!parts[i].Enabled)
                    continue;

                current += parts[i].EndFrame - parts[i].StartFrame + 1;
                writer.WriteLine(current + " I -1");
            }
            writer.Close();
        }

        public static void CreateChapters(Part[] parts, string script, int framerate)
        {
            StreamWriter writer = new StreamWriter(Path.GetDirectoryName(script) + "\\chapters.xml");
            writer.WriteLine("<?xml version=\"1.0\"?>");
            writer.WriteLine("<!-- <!DOCTYPE Chapters SYSTEM \"matroskachapters.dtd\"> -->");
            writer.WriteLine("<Chapters>");
            writer.WriteLine("  <EditionEntry>");
            writer.WriteLine("    <EditionFlagHidden>0</EditionFlagHidden>");
            writer.WriteLine("    <EditionFlagDefault>0</EditionFlagDefault>");

            int current = 0;
            foreach (Part p in parts)
            {
                writer.WriteLine("    <ChapterAtom>");
                writer.WriteLine("      <ChapterFlagHidden>0</ChapterFlagHidden>");
                writer.WriteLine("      <ChapterFlagEnabled>1</ChapterFlagEnabled>");

                if (!p.Enabled)
                    writer.WriteLine("      <ChapterSegmentUID format=\"hex\">00000000000000000000000000000000</ChapterSegmentUID>");

                writer.WriteLine("      <ChapterDisplay>");
                writer.WriteLine("        <ChapterString>" + p.Name + "</ChapterString>");
                writer.WriteLine("        <ChapterLanguage>jap</ChapterLanguage>");
                writer.WriteLine("      </ChapterDisplay>");
                writer.WriteLine("      <ChapterTimeStart>" + FrameToTimeStamp(p.Enabled ? current : 0, framerate) + "</ChapterTimeStart>");
                writer.WriteLine("    </ChapterAtom>");

                if (p.Enabled)
                    current += p.EndFrame - p.StartFrame + 1;
            }

            writer.WriteLine("  </EditionEntry>");
            writer.WriteLine("</Chapters>");

            writer.Close();
        }

        public static Part[] ParseScript(string script)
        {
            StreamReader reader = new StreamReader(script);
            List<Part> parts = new List<Part>();

            string line;
            int trim;
            while ((line = reader.ReadLine()) != null)
            {
                string l = line.ToLowerInvariant();
                if ((trim = l.IndexOf("trim")) != -1)
                {
                    int open = l.IndexOf('(', trim);
                    int close = l.IndexOf(')', open);
                    string se = l.Substring(open + 1, close - open - 1);
                    string[] startEnd = se.Split(',');

                    parts.Add(new Part(line.Split('=')[0].Trim(), line.Split('#')[1].Trim(), int.Parse(startEnd[0]), int.Parse(startEnd[1])));
                }
                else if (line.Contains("+"))
                {
                    string[] enabledParts = line.Split('+');
                    foreach (string s in enabledParts)
                        foreach (Part p in parts)
                            if (!p.Enabled && p.ScriptDesignation == s.Trim())
                                p.Enabled = true;
                }
            }

            reader.Close();
            return parts.ToArray();
        }

        private static string FrameToTimeStamp(int frame, int framerate)
        {
            decimal totalSeconds = (frame * 1001m) / framerate;

            int minutes = (int)Math.Truncate(totalSeconds / 60);
            int seconds = (int)Math.Truncate(totalSeconds % 60);
            int milliseconds = (int)Math.Truncate((totalSeconds % 1) * 1000);

            return minutes.ToString("00") + ":" + seconds.ToString("00") + "." + milliseconds.ToString("000");
        }
    }

    public class Part
    {
        public Part(string scriptName, string name, int start, int end)
        {
            this.ScriptDesignation = scriptName;
            this.Name = name;
            this.StartFrame = start;
            this.EndFrame = end;
            this.Enabled = false;
        }

        public string ScriptDesignation { get; private set; }
        public string Name { get; private set; }
        public int StartFrame { get; private set; }
        public int EndFrame { get; private set; }
        public bool Enabled { get; set; }
    }
}