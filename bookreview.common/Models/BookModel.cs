namespace bookreview.common.Models
{
    public class BookModel : BaseModel
    {
        public string Title { get; set; }

        public List<int> AuthorIds { get; set; }

        public string Synoposis { get; set; }

        public List<string> Tags { get; set; }

        /// <summary>
        /// Preferabbly ISBN 13 as this is more recent version, but will accept ISBN 10
        /// </summary>
        public string ISBN { get; set; }

        public string YearPublished { get; set; }

        public int PublisherId { get; set; }
    }
}
