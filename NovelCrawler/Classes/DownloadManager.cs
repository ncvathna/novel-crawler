using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NovelCrawler.Classes
{
    
    class DownloadManager
    {
        public delegate void DownloadCompletedDelegate();
        public static event DownloadCompletedDelegate DownloadCompleted;

        private static Queue<Chapter.Chapter> queue = new Queue<Chapter.Chapter>();
        private static int count = 0;

        public static void DownloadContent(Series series)
        {
            if (queue.Count > 0)
                {
                    System.Windows.Forms.MessageBox.Show("Please wait for current downloads to be finished.");
                    return;
                }
            count = 0;

            // Add to Queue
            for (int i = 0; i < series.Chapters.Count; i++)
                if (series.Chapters[i].Status == Chapter.Status.WAITING)
                    queue.Enqueue(series.Chapters[i]);

            // Use a different thread to avoid stopping the main thread which leads to UI not being updated
            new Thread(() => {
                // Call each Client to download Chapters
                for (int i = 0; i < series.Connections; i++)
                {
                    new Thread(() => {
                        DownloadCallback(series.Connections, series.Delay);
                    }).Start();
                    Thread.Sleep(250);
                }
            }).Start();
        }

        private static void DownloadCallback(int concurrentConnections, int delay)
        {
            if (queue.Count > 0)
            {
                queue.Dequeue().Parse();
                if (delay > 0) Thread.Sleep(delay);
                DownloadCallback(concurrentConnections, delay);
            }
            else
            {
                count++;
                if (count == concurrentConnections) DownloadCompleted.Invoke();
            }
        }
    }
}
