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
    class WordExcerpt : Chapter
    {
        public WordExcerpt(int id, string name, string url) : base(id, name, url) { }
        public override void Parse()
        {
            Status = Status.PARSING;
            
            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(Url);

            // Get Content
            HtmlNode contentNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'text-left')]");
            HtmlNodeCollection advertisements = contentNode.SelectNodes("center");
            if (advertisements != null)
                foreach (HtmlNode advertisement in advertisements)
                    advertisement.Remove();
            
            Content = System.Net.WebUtility.HtmlDecode(contentNode.InnerText).Trim();
            try
            {
                Content = Content.Substring(0, Content.IndexOf("Want to read the Advanced Chapters Below"));
            }
            catch (Exception) { }
            Content = Regex.Replace(Content, @" \n", "", RegexOptions.Multiline);
            Content = Regex.Replace(Content, @"[\r\n]+", "\n\n", RegexOptions.Multiline);

            Status = Status.PARSED;
        }
    }
}
