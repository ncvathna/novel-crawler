using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace NovelCrawler.Classes.Chapter
{
    enum Status { WAITING, PARSING, PARSED}

    [Serializable]
    abstract class Chapter
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Url { set; get; }
        public Status Status { set; get; }
        public string Content { set; get; }

        public Chapter(int id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
            Status = Status.WAITING;
        }

        public abstract void Parse();
    }
}
