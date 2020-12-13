using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelCrawler.Classes.Chapter
{
    class ChapterComparer : IEqualityComparer<Chapter>
    {
        bool IEqualityComparer<Chapter>.Equals(Chapter x, Chapter y)
        {
            if (x is null || y is null) return false;
            return x.Url == y.Url;
        }

        int IEqualityComparer<Chapter>.GetHashCode(Chapter obj)
        {
            return obj.Url.GetHashCode();
        }
    }
}
