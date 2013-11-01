namespace GUI
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.scriptPath = new System.Windows.Forms.TextBox();
            this.scriptLabel = new System.Windows.Forms.Label();
            this.scriptButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.partsList = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.audio = new System.Windows.Forms.Button();
            this.qpfile = new System.Windows.Forms.Button();
            this.chapters = new System.Windows.Forms.Button();
            this.aac = new System.Windows.Forms.CheckBox();
            this.bps = new System.Windows.Forms.NumericUpDown();
            this.sampleRate = new System.Windows.Forms.NumericUpDown();
            this.channels = new System.Windows.Forms.NumericUpDown();
            this.framerate = new System.Windows.Forms.NumericUpDown();
            this.sampleRateLabel = new System.Windows.Forms.Label();
            this.bpsLabel = new System.Windows.Forms.Label();
            this.framerateLabel = new System.Windows.Forms.Label();
            this.channelsLabel = new System.Windows.Forms.Label();
            this.aacRateLabel = new System.Windows.Forms.Label();
            this.aacRate = new System.Windows.Forms.NumericUpDown();
            this.all = new System.Windows.Forms.Button();
            this.bigEndian = new System.Windows.Forms.CheckBox();
            this.signed = new System.Windows.Forms.CheckBox();
            this.audioDelayLabel = new System.Windows.Forms.Label();
            this.audioDelay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.bps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.channels)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aacRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioDelay)).BeginInit();
            this.SuspendLayout();
            // 
            // scriptPath
            // 
            this.scriptPath.Enabled = false;
            this.scriptPath.Location = new System.Drawing.Point(102, 11);
            this.scriptPath.Name = "scriptPath";
            this.scriptPath.Size = new System.Drawing.Size(377, 20);
            this.scriptPath.TabIndex = 0;
            this.scriptPath.ModifiedChanged += new System.EventHandler(this.scriptPath_ModifiedChanged);
            // 
            // scriptLabel
            // 
            this.scriptLabel.AutoSize = true;
            this.scriptLabel.Location = new System.Drawing.Point(12, 14);
            this.scriptLabel.Name = "scriptLabel";
            this.scriptLabel.Size = new System.Drawing.Size(37, 13);
            this.scriptLabel.TabIndex = 1;
            this.scriptLabel.Text = "Script:";
            // 
            // scriptButton
            // 
            this.scriptButton.Location = new System.Drawing.Point(485, 11);
            this.scriptButton.Name = "scriptButton";
            this.scriptButton.Size = new System.Drawing.Size(26, 19);
            this.scriptButton.TabIndex = 2;
            this.scriptButton.Text = "...";
            this.scriptButton.UseVisualStyleBackColor = true;
            this.scriptButton.Click += new System.EventHandler(this.scriptButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.DefaultExt = "avs";
            this.openFileDialog.Filter = "AviSynth Script|*.avs";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // partsList
            // 
            this.partsList.FormattingEnabled = true;
            this.partsList.Location = new System.Drawing.Point(103, 37);
            this.partsList.Name = "partsList";
            this.partsList.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.partsList.Size = new System.Drawing.Size(376, 214);
            this.partsList.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Detected parts:";
            // 
            // audio
            // 
            this.audio.Location = new System.Drawing.Point(357, 257);
            this.audio.Name = "audio";
            this.audio.Size = new System.Drawing.Size(122, 48);
            this.audio.TabIndex = 5;
            this.audio.Text = "Generate audio";
            this.audio.UseVisualStyleBackColor = true;
            this.audio.Click += new System.EventHandler(this.audio_Click);
            // 
            // qpfile
            // 
            this.qpfile.Location = new System.Drawing.Point(357, 311);
            this.qpfile.Name = "qpfile";
            this.qpfile.Size = new System.Drawing.Size(122, 48);
            this.qpfile.TabIndex = 6;
            this.qpfile.Text = "Generate qpfile";
            this.qpfile.UseVisualStyleBackColor = true;
            this.qpfile.Click += new System.EventHandler(this.qpfile_Click);
            // 
            // chapters
            // 
            this.chapters.Location = new System.Drawing.Point(357, 365);
            this.chapters.Name = "chapters";
            this.chapters.Size = new System.Drawing.Size(122, 47);
            this.chapters.TabIndex = 7;
            this.chapters.Text = "Generate chapters";
            this.chapters.UseVisualStyleBackColor = true;
            this.chapters.Click += new System.EventHandler(this.chapters_Click);
            // 
            // aac
            // 
            this.aac.AutoSize = true;
            this.aac.Location = new System.Drawing.Point(102, 422);
            this.aac.Name = "aac";
            this.aac.Size = new System.Drawing.Size(94, 17);
            this.aac.TabIndex = 8;
            this.aac.Text = "Generate AAC";
            this.aac.UseVisualStyleBackColor = true;
            this.aac.CheckedChanged += new System.EventHandler(this.aac_CheckedChanged);
            // 
            // bps
            // 
            this.bps.Location = new System.Drawing.Point(174, 283);
            this.bps.Maximum = new decimal(new int[] {
            128,
            0,
            0,
            0});
            this.bps.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.bps.Name = "bps";
            this.bps.Size = new System.Drawing.Size(177, 20);
            this.bps.TabIndex = 9;
            this.bps.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // sampleRate
            // 
            this.sampleRate.Location = new System.Drawing.Point(174, 335);
            this.sampleRate.Maximum = new decimal(new int[] {
            192000,
            0,
            0,
            0});
            this.sampleRate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.sampleRate.Name = "sampleRate";
            this.sampleRate.Size = new System.Drawing.Size(177, 20);
            this.sampleRate.TabIndex = 10;
            this.sampleRate.Value = new decimal(new int[] {
            48000,
            0,
            0,
            0});
            // 
            // channels
            // 
            this.channels.Location = new System.Drawing.Point(174, 257);
            this.channels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.channels.Name = "channels";
            this.channels.Size = new System.Drawing.Size(177, 20);
            this.channels.TabIndex = 11;
            this.channels.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // framerate
            // 
            this.framerate.Location = new System.Drawing.Point(174, 309);
            this.framerate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.framerate.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.framerate.Name = "framerate";
            this.framerate.Size = new System.Drawing.Size(177, 20);
            this.framerate.TabIndex = 12;
            this.framerate.Value = new decimal(new int[] {
            24000,
            0,
            0,
            0});
            // 
            // sampleRateLabel
            // 
            this.sampleRateLabel.AutoSize = true;
            this.sampleRateLabel.Location = new System.Drawing.Point(99, 337);
            this.sampleRateLabel.Name = "sampleRateLabel";
            this.sampleRateLabel.Size = new System.Drawing.Size(69, 13);
            this.sampleRateLabel.TabIndex = 13;
            this.sampleRateLabel.Text = "Sample  rate:";
            // 
            // bpsLabel
            // 
            this.bpsLabel.AutoSize = true;
            this.bpsLabel.Location = new System.Drawing.Point(99, 285);
            this.bpsLabel.Name = "bpsLabel";
            this.bpsLabel.Size = new System.Drawing.Size(52, 13);
            this.bpsLabel.TabIndex = 14;
            this.bpsLabel.Text = "Bit-depth:";
            // 
            // framerateLabel
            // 
            this.framerateLabel.AutoSize = true;
            this.framerateLabel.Location = new System.Drawing.Point(99, 311);
            this.framerateLabel.Name = "framerateLabel";
            this.framerateLabel.Size = new System.Drawing.Size(57, 13);
            this.framerateLabel.TabIndex = 15;
            this.framerateLabel.Text = "Framerate:";
            // 
            // channelsLabel
            // 
            this.channelsLabel.AutoSize = true;
            this.channelsLabel.Location = new System.Drawing.Point(99, 259);
            this.channelsLabel.Name = "channelsLabel";
            this.channelsLabel.Size = new System.Drawing.Size(54, 13);
            this.channelsLabel.TabIndex = 16;
            this.channelsLabel.Text = "Channels:";
            // 
            // aacRateLabel
            // 
            this.aacRateLabel.AutoSize = true;
            this.aacRateLabel.Enabled = false;
            this.aacRateLabel.Location = new System.Drawing.Point(99, 447);
            this.aacRateLabel.Name = "aacRateLabel";
            this.aacRateLabel.Size = new System.Drawing.Size(40, 13);
            this.aacRateLabel.TabIndex = 17;
            this.aacRateLabel.Text = "Bitrate:";
            // 
            // aacRate
            // 
            this.aacRate.Enabled = false;
            this.aacRate.Location = new System.Drawing.Point(174, 445);
            this.aacRate.Maximum = new decimal(new int[] {
            512000,
            0,
            0,
            0});
            this.aacRate.Name = "aacRate";
            this.aacRate.Size = new System.Drawing.Size(177, 20);
            this.aacRate.TabIndex = 18;
            this.aacRate.Value = new decimal(new int[] {
            192000,
            0,
            0,
            0});
            // 
            // all
            // 
            this.all.Location = new System.Drawing.Point(357, 418);
            this.all.Name = "all";
            this.all.Size = new System.Drawing.Size(122, 47);
            this.all.TabIndex = 19;
            this.all.Text = "Generate all";
            this.all.UseVisualStyleBackColor = true;
            this.all.Click += new System.EventHandler(this.all_Click);
            // 
            // bigEndian
            // 
            this.bigEndian.AutoSize = true;
            this.bigEndian.Checked = true;
            this.bigEndian.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bigEndian.Location = new System.Drawing.Point(174, 387);
            this.bigEndian.Name = "bigEndian";
            this.bigEndian.Size = new System.Drawing.Size(76, 17);
            this.bigEndian.TabIndex = 20;
            this.bigEndian.Text = "Big endian";
            this.bigEndian.UseVisualStyleBackColor = true;
            // 
            // signed
            // 
            this.signed.AutoSize = true;
            this.signed.Checked = true;
            this.signed.CheckState = System.Windows.Forms.CheckState.Checked;
            this.signed.Location = new System.Drawing.Point(256, 387);
            this.signed.Name = "signed";
            this.signed.Size = new System.Drawing.Size(59, 17);
            this.signed.TabIndex = 21;
            this.signed.Text = "Signed";
            this.signed.UseVisualStyleBackColor = true;
            // 
            // audioDelayLabel
            // 
            this.audioDelayLabel.AutoSize = true;
            this.audioDelayLabel.Location = new System.Drawing.Point(99, 363);
            this.audioDelayLabel.Name = "audioDelayLabel";
            this.audioDelayLabel.Size = new System.Drawing.Size(65, 13);
            this.audioDelayLabel.TabIndex = 23;
            this.audioDelayLabel.Text = "Audio delay:";
            // 
            // audioDelay
            // 
            this.audioDelay.Location = new System.Drawing.Point(174, 361);
            this.audioDelay.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.audioDelay.Minimum = new decimal(new int[] {
            5000,
            0,
            0,
            -2147483648});
            this.audioDelay.Name = "audioDelay";
            this.audioDelay.Size = new System.Drawing.Size(177, 20);
            this.audioDelay.TabIndex = 22;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 477);
            this.Controls.Add(this.audioDelayLabel);
            this.Controls.Add(this.audioDelay);
            this.Controls.Add(this.signed);
            this.Controls.Add(this.bigEndian);
            this.Controls.Add(this.all);
            this.Controls.Add(this.aacRate);
            this.Controls.Add(this.aacRateLabel);
            this.Controls.Add(this.channelsLabel);
            this.Controls.Add(this.framerateLabel);
            this.Controls.Add(this.bpsLabel);
            this.Controls.Add(this.sampleRateLabel);
            this.Controls.Add(this.framerate);
            this.Controls.Add(this.channels);
            this.Controls.Add(this.sampleRate);
            this.Controls.Add(this.bps);
            this.Controls.Add(this.aac);
            this.Controls.Add(this.chapters);
            this.Controls.Add(this.qpfile);
            this.Controls.Add(this.audio);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.partsList);
            this.Controls.Add(this.scriptButton);
            this.Controls.Add(this.scriptLabel);
            this.Controls.Add(this.scriptPath);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ScriptCreatorPRO";
            ((System.ComponentModel.ISupportInitialize)(this.bps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sampleRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.channels)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.framerate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aacRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.audioDelay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox scriptPath;
        private System.Windows.Forms.Label scriptLabel;
        private System.Windows.Forms.Button scriptButton;
        private System.Windows.Forms.CheckedListBox partsList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button audio;
        private System.Windows.Forms.Button qpfile;
        private System.Windows.Forms.Button chapters;
        private System.Windows.Forms.CheckBox aac;
        private System.Windows.Forms.NumericUpDown bps;
        private System.Windows.Forms.NumericUpDown sampleRate;
        private System.Windows.Forms.NumericUpDown channels;
        private System.Windows.Forms.NumericUpDown framerate;
        private System.Windows.Forms.Label sampleRateLabel;
        private System.Windows.Forms.Label bpsLabel;
        private System.Windows.Forms.Label framerateLabel;
        private System.Windows.Forms.Label channelsLabel;
        private System.Windows.Forms.Label aacRateLabel;
        private System.Windows.Forms.NumericUpDown aacRate;
        private System.Windows.Forms.Button all;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.CheckBox bigEndian;
        private System.Windows.Forms.CheckBox signed;
        private System.Windows.Forms.Label audioDelayLabel;
        private System.Windows.Forms.NumericUpDown audioDelay;
    }
}

