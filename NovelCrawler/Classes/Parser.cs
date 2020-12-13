using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace NovelCrawler.Classes
{
    class Parser
    {
        public static Series Parse(string link)
        {
            if (Regex.Match(link, @"https://www.mtlnovel.com/[^/]*/$").Success) return ParseMTLNovel(link);
            else if (Regex.Match(link, @"https://wordexcerpt.com/series/[^/]*/$").Success) return ParseWordExcerpt(link);
            else if (Regex.Match(link, @"https://novelfull.com/[^\.]*\.html$").Success) return ParseNovelFull(link);
            else if (Regex.Match(link, @"https://www.wuxiaworld.com/novel/[^/]*$").Success) return ParseWuxiaWorld(link);
            else if (Regex.Match(link, @"https://www.volarenovels.com/novel/[^/]*$").Success) return ParseVolareNovels(link);
            else if (Regex.Match(link, @"https://creativenovels.com/novel/[^/]*/$").Success) return ParseCreativeNovels(link);
            else throw new Exception("Unsupported link.");
        }

        private static Series ParseMTLNovel(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(link + "chapter-list/");

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//div[@class='list-right']/h1");
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//div[@class='post-content']/amp-img/amp-img");
            cover = coverNode.Attributes["src"].Value;

            // Get Chapters
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//a[@class='ch-link']").ToArray();
            int chId = 1;
            for (int i = nodes.Length-1; i >= 0; i--)
            {
                string chapterTitle = System.Net.WebUtility.HtmlDecode(nodes[i].InnerText.Trim());
                chapters.Add(new Chapter.MTLNovel(chId++, chapterTitle, nodes[i].Attributes["href"].Value));
            }

            Series series = new Series(link, title, cover, chapters, 3);
            return series;
        }

        private static Series ParseWordExcerpt(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(link);

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//div[@class='c-manga-title']/h1");
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//div[@class='c-manga-thumbnail-bg']");
            cover = Regex.Match(coverNode.Attributes["style"].Value, @"http[^']*").Value;

            // Get Chapters
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'wp-manga-chapter')]/a").ToArray();
            int chId = 1;
            for (int i = nodes.Length - 1; i >= 0; i--)
            {
                string chapterTitle = System.Net.WebUtility.HtmlDecode(nodes[i].InnerText.Trim());
                chapters.Add(new Chapter.WordExcerpt(chId++, chapterTitle, nodes[i].Attributes["href"].Value));
            }
            Series series = new Series(link, title, cover, chapters, 1, 1000);
            return series;
        }

        private static Series ParseNovelFull(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(link);

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//h3[@class='title']");
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//div[@class='book']/img");
            cover = "https://novelfull.com" + coverNode.Attributes["src"].Value;

            // Get All Pages
            // Check pagination: null means only 1 page
            // https://novelfull.com/goddess-medical-doctor.html
            // https://novelfull.com/overlord-ln.html
            // https://novelfull.com/venerated-venomous-consort.html
            List<string> pages = new List<string>();
            HtmlNode pagination = doc.DocumentNode.SelectSingleNode("//ul[contains(@class, 'pagination')]");
            if (pagination != null)
            {
                HtmlNode lastNode = pagination.SelectSingleNode("//li[contains(@class, 'last')]/a");
                int lastPage = int.Parse(lastNode.Attributes["data-page"].Value)+1;
                Console.WriteLine(lastPage);
                for (int i = 1; i <= lastPage; i++) pages.Add(link + "?page=" + i);
            }
            else pages.Add(link);

            int chId = 1;
            foreach (string page in pages)
            {
                // Scrape each page for chapter
                HtmlDocument pageDoc = web.Load(page);
                HtmlNode[] nodes = pageDoc.DocumentNode.SelectNodes("//ul[contains(@class, 'list-chapter')]//a").ToArray();
                foreach (HtmlNode node in nodes)
                {
                    string chapterTitle = System.Net.WebUtility.HtmlDecode(node.InnerText.Trim());
                    chapters.Add(new Chapter.NovelFull(chId++, chapterTitle, "https://novelfull.com" + node.Attributes["href"].Value));
                }
            }

            Series series = new Series(link, title, cover, chapters, 3);
            return series;
        }

        private static Series ParseWuxiaWorld(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(link);

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//div[@class='novel-body']/h2");
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//div[@class='novel-left']//img");
            cover = coverNode.Attributes["src"].Value;

            // Get Chapters
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'chapter-item')]/a").ToArray();
            int chId = 1;
            for (int i = 0; i < nodes.Length; i++)
            {
                string chapterTitle = System.Net.WebUtility.HtmlDecode(nodes[i].InnerText.Trim());
                chapters.Add(new Chapter.WuxiaWorld(chId++, chapterTitle, "https://www.wuxiaworld.com" + nodes[i].Attributes["href"].Value));
            }

            Series series = new Series(link, title, cover, chapters, 3);
            return series;
        }

        private static Series ParseVolareNovels(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(link);

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//h3[contains(@class, 'title')]");
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//div[@id='content-container']//img");
            cover = coverNode.Attributes["src"].Value;

            // Get Chapters
            HtmlNode[] nodes = doc.DocumentNode.SelectNodes("//li[contains(@class, 'chapter-item')]/a").ToArray();
            int chId = 1;
            for (int i = 0; i < nodes.Length; i++)
            {
                string chapterTitle = System.Net.WebUtility.HtmlDecode(nodes[i].InnerText.Trim());
                chapters.Add(new Chapter.VolareNovels(chId++, chapterTitle, "https://www.volarenovels.com" + nodes[i].Attributes["href"].Value));
            }

            Series series = new Series(link, title, cover, chapters, 3);
            return series;
        }

        private static Series ParseCreativeNovels(string link)
        {
            // Variables to be retrieved
            string title = null;
            string cover = null;
            List<Chapter.Chapter> chapters = new List<Chapter.Chapter>();

            // Necessary variables
            HtmlWeb web = new HtmlWeb();
            web.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/83.0.4103.97 Safari/537.36";
            HtmlDocument doc = web.Load(link);

            // Get Title
            HtmlNode titleNode = doc.DocumentNode.SelectSingleNode("//div[contains(@class, 'x-text-headline')]").PreviousSibling;
            title = System.Net.WebUtility.HtmlDecode(titleNode.InnerText.Trim());
            foreach (char ch in System.IO.Path.GetInvalidFileNameChars()) title = title.Replace(ch, '_');

            // Get Cover
            HtmlNode coverNode = doc.DocumentNode.SelectSingleNode("//img[@class='book_cover']");
            cover = coverNode.Attributes["src"].Value;


            // Get Chapters
            // Get Novel ID
            HtmlNode idNode = doc.DocumentNode.SelectSingleNode("//div[@id='chapter_list_novel_page']");
            string novelId = idNode.Attributes["class"].Value;
            // Get Security Code
            string securityCode = "bf72be1c0d";
            HtmlNodeCollection scripts = doc.DocumentNode.SelectNodes("//body/script");
            for (int i = scripts.Count-1; i >= 0; i--)
                if (scripts[i].InnerText.Contains("chapter_list_summon"))
                {
                    securityCode = Regex.Match(scripts[i].InnerText, "\"security\":\"([^\"]*)\"").Groups[1].Value;
                    break;
                }
            // POST to https://creativenovels.com/wp-admin/admin-ajax.php to get Chapter List
            //Dictionary<string, string> postValues = new Dictionary<string, string>
            //{
            //    { "action", "crn_chapter_list"},
            //    { "view_id", novelId},
            //    { "s", securityCode},
            //};
            //FormUrlEncodedContent postContent = new FormUrlEncodedContent(postValues);
            string postValues = "action=crn_chapter_list&view_id=" + novelId + "&s=" + securityCode;
            byte[] postContent = Encoding.UTF8.GetBytes(postValues);
            System.Net.HttpWebRequest postRequest = System.Net.WebRequest.CreateHttp("https://creativenovels.com/wp-admin/admin-ajax.php");
            postRequest.Method = "POST";
            postRequest.ContentType = "application/x-www-form-urlencoded";
            System.IO.Stream postStream = postRequest.GetRequestStream();
            postStream.Write(postContent, 0, postContent.Length);
            System.Net.WebResponse response = postRequest.GetResponse();
            System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());
            string responseContent = reader.ReadToEnd();

            int chId = 1;
            MatchCollection chapterMatches = Regex.Matches(responseContent, @"(https.*?)\.data\.(.*?)\.data\.(.*?)\.data\.available\.end_data\.");
            foreach (Match chapterMatch in chapterMatches)
            {
                string chapterTitle = System.Net.WebUtility.HtmlDecode(chapterMatch.Groups[2].Value);
                chapters.Add(new Chapter.CreativeNovels(chId++, chapterTitle, chapterMatch.Groups[1].Value));
            }

            Series series = new Series(link, title, cover, chapters, 3);
            return series;
        }
    }
}
