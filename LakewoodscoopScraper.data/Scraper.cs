using AngleSharp.Parser.Html;
using AngleSharp.Dom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace LakewoodscoopScraper.data
{
    public class Scraper
    {
        public IEnumerable<Lakewoodscoop> GetNews()
        {
            string url = $"http://thelakewoodscoop.com";
            var client = new WebClient();
            var html = client.DownloadString(url);
            var parser = new HtmlParser();
            var document = parser.Parse(html);
            IEnumerable<IElement> title = document.QuerySelectorAll(".post");
            return title.Select(Parsetitle).Where(t => t != null);
        }
        private Lakewoodscoop Parsetitle(IElement t)
        {
            var h2 = t.QuerySelector("h2");
            if (h2 == null)
            {
                return null;
            }
            var result = new Lakewoodscoop();
            result.Title = h2.TextContent;
            var a = t.QuerySelector("a");
            if (a != null)
            {
                result.TitleURL = (a.Attributes["href"].Value);
            }
            var img = t.QuerySelector("img");
            if (img != null)
            {
                result.ImageURL = (img.Attributes["src"].Value);
            }
            var blog = t.QuerySelector("p");
            {
                if (blog != null)
                {
                    result.Blog = blog.TextContent;
                }
            }
            return result;
        }

    }
}
