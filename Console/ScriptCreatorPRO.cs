using System;
using System.IO;
using System.Collections.Generic;

namespace ScriptCreatorPRO
{
    public static class ScriptCreator
    {
        public const string DEFAULT_UID = "0123456789abcdef0123456789abcdef";

        private static Random random = new Random();

        public static void CreateAudio(Part[] parts, string script, int framerate, bool bigEndian, bool signed, int bps, int sample, int channels, bool aac, int aacRate)
        {
            StreamWriter writer = new StreamWriter(Path.GetDirectoryName(script) + "\\audio.bat");
            string endian = bigEndian ? "big" : "little";

            writer.WriteLine("flac --fast --endian=" + endian + " --sign=" + (signed ? "signed" : "unsigned") + " --bps=" + bps + " --sample-rate=" + sample + " --channels=" + channels + " -f -o temp.flac audio.pcm");
            writer.Write("mkvmerge -o audio.mka --split parts:");

            int startTime;
            bool first = true;
            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i].Enabled)
                {
                    startTime = parts[i].StartFrame;
                    while (i < parts.Length - 1 && parts[i + 1].Enabled && parts[i].EndFrame == parts[i + 1].StartFrame - 1)
                        i++;

                    if (!first)
                        writer.Write(",+");
                    else
                        first = false;

                    writer.Write(FrameToTimeStamp(startTime, framerate) + "-" + FrameToTimeStamp(parts[i].EndFrame + 1, framerate));
                }
            }

            writer.WriteLine(" temp.flac");
            writer.WriteLine("eac3to audio.mka temp.pcm");

            writer.WriteLine("flac --best --endian=" + endian + " --sign=" + (signed ? "signed" : "unsigned") + " --bps=" + bps + " --sample-rate=" + sample + " --channels=" + channels + " -f -o audio.flac temp.pcm");

            if (aac)
            {
                writer.WriteLine("eac3to audio.flac audio.wav");
                writer.WriteLine("neroaacenc -br " + aacRate + " -lc -if audio.wav -of audio.aac");
                writer.WriteLine("del \"audio - Log.txt\"");
                writer.WriteLine("del \"audio.wav\"");
            }

            writer.WriteLine("del \"temp - Log.txt\"");
            writer.WriteLine("del \"temp.pcm\"");
            writer.WriteLine("del \"temp.flac\"");
            writer.WriteLine("del \"audio.mka\"");
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
            writer.WriteLine("    <EditionUID>" + RandomUID() + "</EditionUID>");

            int current = 0;
            foreach (Part p in parts)
            {
                writer.WriteLine("    <ChapterAtom>");
                writer.WriteLine("      <ChapterFlagHidden>0</ChapterFlagHidden>");
                writer.WriteLine("      <ChapterFlagEnabled>1</ChapterFlagEnabled>");

                if (!p.Enabled)
                    writer.WriteLine("      <ChapterSegmentUID format=\"hex\">" + p.SUID + "</ChapterSegmentUID>");
                else
                    writer.WriteLine("      <ChapterUID>" + RandomUID() + "</ChapterUID>");

                writer.WriteLine("      <ChapterDisplay>");
                writer.WriteLine("        <ChapterString>" + p.Name + "</ChapterString>");
                writer.WriteLine("        <ChapterLanguage>jpn</ChapterLanguage>");
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
            int trim, chapterCount = 0;
            while ((line = reader.ReadLine()) != null)
            {
                string l = line.ToLowerInvariant();
                if ((trim = l.IndexOf("trim")) != -1)
                {
                    int open = line.IndexOf('(', trim);
                    int close = line.IndexOf(')', open);
                    string se = line.Substring(open + 1, close - open - 1);
                    string[] startEnd = se.Split(',');
                    
                    string comment, name = "Chapter" + ++chapterCount, suid = DEFAULT_UID;
                    if (line.IndexOf('#') != -1)
                    {
                        comment = line.Split('#')[1].Trim();
                        if (comment.IndexOf('|') != -1)
                        {
                            string[] split = comment.Split('|');
                            name = split[0].Trim();
                            suid = split[1].Trim();
                        }
                        else
                            name = comment;
                    }

                    parts.Add(new Part(line.Split('=')[0].Trim(), name, int.Parse(startEnd[0]), int.Parse(startEnd[1]), suid));
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

            int hours = (int)Math.Truncate(totalSeconds / 3600);
            int minutes = (int)Math.Truncate(totalSeconds / 60);
            int seconds = (int)Math.Truncate(totalSeconds % 60);
            int nanoseconds = (int)Math.Truncate((totalSeconds % 1) * 1000000000);

            return hours.ToString("00") + ":" + minutes.ToString("00") + ":" + seconds.ToString("00") + "." + nanoseconds.ToString("000000000");
        }

        private static string RandomUID() { return random.Next(1, 10000).ToString() + random.Next(1, 10000).ToString() + random.Next(1, 10000).ToString() + random.Next(1, 10000).ToString(); }
    }

    public class Part
    {
        public Part(string scriptName, string name, int start, int end, string suid)
        {
            this.ScriptDesignation = scriptName;
            this.Name = name;
            this.StartFrame = start;
            this.EndFrame = end;
            this.Enabled = false;
            this.SUID = suid;
        }

        public string ScriptDesignation { get; private set; }
        public string Name { get; private set; }
        public int StartFrame { get; private set; }
        public int EndFrame { get; private set; }
        public bool Enabled { get; set; }
        public string SUID { get; private set; }
    }
}