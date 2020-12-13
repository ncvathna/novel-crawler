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
    class NovelFull : Chapter
    {
        public NovelFull(int id, string name, string url) : base(id, name, url) { }
        public override void Parse()
        {
            Status = Status.PARSING;
            
            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(Url);

            // Get Content
            HtmlNode contentNode = doc.DocumentNode.SelectSingleNode("//div[@id='chapter-content']");
            contentNode.InnerHtml = Regex.Replace(contentNode.InnerHtml, @"</p>|</li>", "\n\n", RegexOptions.Multiline);
            contentNode.InnerHtml = Regex.Replace(contentNode.InnerHtml, @"<li>", "<li> - ", RegexOptions.Multiline);
            
            Content = System.Net.WebUtility.HtmlDecode(contentNode.InnerText).Trim();
            Content = Regex.Replace(Content, @"[\r\n]+", "\n\n", RegexOptions.Multiline);

            Status = Status.PARSED;
        }
    }
}
