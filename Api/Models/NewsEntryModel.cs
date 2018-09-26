namespace Api.Models
{
    public class NewsEntryModel: EntryModel
    {
        public string TopicIcon { get; set; }

        public string SourceName { get; set; }

        public string Content { get; set; }
    }
}