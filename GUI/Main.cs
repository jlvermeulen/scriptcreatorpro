using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using ScriptCreatorPRO;
using System.Diagnostics;

namespace GUI
{
    public partial class Main : Form
    {
        private Part[] parts;

        public Main() { InitializeComponent(); }

        private void scriptButton_Click(object sender, EventArgs e) { this.openFileDialog.ShowDialog(); }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e) { this.scriptPath.Text = this.openFileDialog.FileName; this.scriptPath.Modified = true; }

        private void scriptPath_ModifiedChanged(object sender, EventArgs e)
        {
            if (File.Exists(this.scriptPath.Text) && Path.GetExtension(this.scriptPath.Text) == ".avs")
            {
                this.openFileDialog.InitialDirectory = Path.GetDirectoryName(this.scriptPath.Text);
                this.parts = ScriptCreator.ParseScript(this.scriptPath.Text);
                this.partsList.Items.Clear();

                foreach (Part p in this.parts)
                    this.partsList.Items.Add(p.Name + " (" + p.StartFrame + "," + p.EndFrame + ")", p.Enabled);

                this.scriptPath.Modified = false;
            }
        }

        private void aac_CheckedChanged(object sender, EventArgs e) { this.aacRate.Enabled = this.aacRateLabel.Enabled = this.aac.Checked; }

        private void all_Click(object sender, EventArgs e)
        {
            if (this.parts == null)
            {
                MessageBox.Show("Please select a script file.");
                return;
            }

            Process p = new Process();
            p.StartInfo.FileName = "ScriptCreatorPRO.exe";
            p.StartInfo.Arguments = "--all --input " + this.scriptPath.Text + " --framerate " + (int)this.framerate.Value + " --bps " + (int)this.bps.Value + " --sample-rate " + (int)this.sampleRate.Value +
                " --channels " + (int)this.channels.Value + (this.bigEndian.Checked ? " --big " : "") + (this.signed.Checked ? " --signed " : "") +
                (this.aac.Checked ? " --aac --aac-rate " + (int)this.aacRate.Value : "");
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            MessageBox.Show("Created all files.");
        }

        private void audio_Click(object sender, EventArgs e)
        {
            if (this.parts == null)
            {
                MessageBox.Show("Please select a script file.");
                return;
            }

            Process p = new Process();
            p.StartInfo.FileName = "ScriptCreatorPRO.exe";
            p.StartInfo.Arguments = "--audio --input " + this.scriptPath.Text + " --framerate " + (int)this.framerate.Value + " --bps " + (int)this.bps.Value + " --sample-rate " + (int)this.sampleRate.Value +
                " --channels " + (int)this.channels.Value + (this.bigEndian.Checked ? " --big " : "") + (this.signed.Checked ? " --signed " : "") +
                (this.aac.Checked ? " --aac --aac-rate " + (int)this.aacRate.Value : "");
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            MessageBox.Show("Created audio.bat");
        }

        private void qpfile_Click(object sender, EventArgs e)
        {
            if (this.parts == null)
            {
                MessageBox.Show("Please select a script file.");
                return;
            }

            Process p = new Process();
            p.StartInfo.FileName = "ScriptCreatorPRO.exe";
            p.StartInfo.Arguments = "--qpfile --input " + this.scriptPath.Text + " --framerate " + (int)this.framerate.Value;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            MessageBox.Show("Created qpfile.txt");
        }

        private void chapters_Click(object sender, EventArgs e)
        {
            if (this.parts == null)
            {
                MessageBox.Show("Please select a script file.");
                return;
            }

            Process p = new Process();
            p.StartInfo.FileName = "ScriptCreatorPRO.exe";
            p.StartInfo.Arguments = "--chapters --input " + this.scriptPath.Text + " --framerate " + (int)this.framerate.Value;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false;
            p.Start();
            p.WaitForExit();

            MessageBox.Show("Created chapters.xml");
        }
    }
}