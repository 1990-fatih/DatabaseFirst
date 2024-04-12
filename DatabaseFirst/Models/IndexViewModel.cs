using DatabaseFirst.Models.Database;

namespace DatabaseFirst.Models
{
    public class IndexViewModel
    {
        public Article? TopArticle { get; set; }
        public List<Article>? Articles { get; set; }
    }
}
