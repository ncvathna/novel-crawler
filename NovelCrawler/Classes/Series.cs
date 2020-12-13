using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelCrawler.Classes
{
    [Serializable]
    class Series
    {
        public string Url { private set; get; }
        public string Title { set; get; }
        public string Cover { set; get; }
        public List<Chapter.Chapter> Chapters { set; get; }
        public int Connections { set; get; }
        public int Delay { set; get; }
        public Series(string url, string title, string cover, List<Chapter.Chapter> chapters, int connections, int delay = 0)
        {
            Url = url;
            Title = title;
            Cover = cover;
            Chapters = chapters;
            Connections = connections;
            Delay = delay;
        }
    }
}
