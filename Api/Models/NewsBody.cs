namespace Api.Models
{
    public class NewsBody
    {
        public string Title { get; set; }

        public string SourceName { get; set; }

        public string SubmitDate { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string PrevNews { get; set; }

        public string NextNews { get; set; }

        public string CommentCount { get; set; }
    }
}