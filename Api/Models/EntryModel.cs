namespace Api.Models
{
    public class EntryModel
    {
        public string Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Published { get; set; }

        public string Updated { get; set; }

        public string Link { get; set; }

        public string Diggs { get; set; }

        public string Views { get; set; }

        public string Comments { get; set; }

        public string TopicIcon { get; set; }

        public string SourceName { get; set; }

        public string Content { get; set; }
    }

    public class Author
    {
        public string Name { get; set; }

        public string Uri { get; set; }
    }
}