using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelCrawler
{
    public partial class Main : Form
    {
        private Classes.Series series;
        private string defaultLocation = Environment.CurrentDirectory;
        //private string defaultLocation = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public Main()
        {
            InitializeComponent();

            // Button Go
            btnGo.Click += (o, e) => {
                try
                {
                    series = Classes.Parser.Parse(txtLink.Text);
                    RefreshView();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message, "Error");
                }
            };

            // Button Refresh
            btnRefresh.Click += (o, e) =>
            {
                try
                {
                    Classes.Series refreshed = Classes.Parser.Parse(series.Url);
                    series.Title = refreshed.Title;
                    series.Cover = refreshed.Cover;

                    IEnumerable<Classes.Chapter.Chapter> newChapters = refreshed.Chapters.Except(series.Chapters, new Classes.Chapter.ChapterComparer());
                    series.Chapters.AddRange(newChapters);
                    series.Chapters = series.Chapters.OrderBy((chapter) => chapter.Id).ToList();
                    RefreshView();
                }
                catch (Exception) { }
            };

            // Button Parse
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            Classes.DownloadManager.DownloadCompleted += () => {
                timer.Stop();
                System.Windows.Forms.MessageBox.Show("Parse Completed! Time elapsed: " + timer.Elapsed, "Success");
                timer.Reset();
                // Re-enable Buttons
                this.Invoke((MethodInvoker)delegate {
                    btnGo.Enabled = true;
                    btnSave.Enabled = true;
                    btnLoad.Enabled = true;
                    btnRefresh.Enabled = true;
                    btnGenerate.Enabled = true;
                    numConnections.Enabled = true;
                    numDelay.Enabled = true;
                });
            };
            btnParse.Click += (o, e) =>
            {
                // Disable Buttons
                btnGo.Enabled = false;
                btnSave.Enabled = false;
                btnLoad.Enabled = false;
                btnRefresh.Enabled = false;
                btnGenerate.Enabled = false;
                numConnections.Enabled = false;
                numDelay.Enabled = false;

                timer.Start();
                Classes.DownloadManager.DownloadContent(series);
            };

            // Button Generate
            btnGenerate.Click += (o, e) =>
            {
                System.IO.Stream stream;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text File (*.txt)|*.txt";
                dialog.InitialDirectory = defaultLocation;
                dialog.FileName = series.Title;
                if (dialog.ShowDialog() == DialogResult.OK)
                    if ((stream = dialog.OpenFile()) != null)
                    {
                        System.IO.StreamWriter writer = new System.IO.StreamWriter(stream);
                        writer.WriteLine("#====================#");
                        writer.WriteLine(series.Title);
                        writer.WriteLine("#====================#");
                        for (int i = 0; i < series.Chapters.Count; i++)
                        {
                            writer.WriteLine(series.Chapters[i].Name + Environment.NewLine);
                            writer.WriteLine(series.Chapters[i].Content);
                            writer.WriteLine("-====================-" + Environment.NewLine + Environment.NewLine + Environment.NewLine);
                        }
                        writer.Close();
                    }
            };

            // File Serialization
            btnSave.Click += (o, e) => {
                System.IO.Stream stream;
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Novel Crawler File (*.ncf)|*.ncf";
                dialog.InitialDirectory = defaultLocation;
                dialog.FileName = series.Title;
                if (dialog.ShowDialog() == DialogResult.OK)
                    if ((stream = dialog.OpenFile()) != null)
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        formatter.Serialize(stream, series);
                        stream.Flush();
                        stream.Close();
                        stream.Dispose();
                    }
            };
            btnLoad.Click += (o, e) =>
            {
                System.IO.Stream stream;
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Novel Crawler File (*.ncf)|*.ncf";
                dialog.InitialDirectory = defaultLocation;
                if (dialog.ShowDialog() == DialogResult.OK)
                    if ((stream = dialog.OpenFile()) != null)
                    {
                        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                        series = formatter.Deserialize(stream) as Classes.Series;
                        stream.Close();
                        stream.Dispose();

                        //foreach (Classes.Chapter.Chapter chapter in series.Chapters) chapter.Content = System.Text.RegularExpressions.Regex.Replace(chapter.Content, @"[ ]+\n", "", System.Text.RegularExpressions.RegexOptions.Multiline);
                        RefreshView();
                    }
            };

            // Concurrent Connections
            numConnections.ValueChanged += (o, e) => {
                if (series !=null) series.Connections = Convert.ToInt32(numConnections.Value);
            };

            // Delay
            numDelay.ValueChanged += (o, e) => {
                if (series != null) series.Delay = Convert.ToInt32(numDelay.Value);
            };
        }

        private void RefreshView()
        {
            txtLink.Text = series.Url;
            pbCover.LoadAsync(series.Cover);
            lblTitle.Text = series.Title;
            BindingSource bsChapters = new BindingSource();
            bsChapters.DataSource = series.Chapters;
            dgvChapters.DataSource = bsChapters;
            dgvChapters.Columns[dgvChapters.Columns.Count - 1].Visible = false;

            txtChapter.DataBindings.Clear();
            txtChapter.DataBindings.Add("Text", bsChapters, "Content");

            if (series.Connections < 1) series.Connections = 1;
            numConnections.Value = series.Connections;

            if (series.Delay < 0) series.Delay = 0;
            numDelay.Value = series.Delay;

            btnSave.Enabled = true;
            btnRefresh.Enabled = true;
            btnParse.Enabled = true;
            btnGenerate.Enabled = true;
            numConnections.Enabled = true;
            numDelay.Enabled = true;
        }
    }
}
