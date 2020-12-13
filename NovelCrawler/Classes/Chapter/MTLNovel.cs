using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace NovelCrawler.Classes.Chapter
{
    [Serializable]
    class MTLNovel : Chapter
    {
        public MTLNovel(int id, string name, string url) : base(id, name, url) { }
        public override void Parse()
        {
            Status = Status.PARSING;
            
            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(Url);

            // Get Content
            HtmlNode contentNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'par')]");

            Content = System.Net.WebUtility.HtmlDecode(contentNode.InnerText).Trim();
            Content = Regex.Replace(Content, @"[\r\n]+", "\n\n", RegexOptions.Multiline);

            Status = Status.PARSED;
        }
    }
}
