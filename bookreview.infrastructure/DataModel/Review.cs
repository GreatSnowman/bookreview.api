namespace bookreview.infrastructure.DataModel
{
    public class Review: BaseEntity
    {
        public int ReviewId { get; set; }

        public string ContentAddress { get; set; }

        public string ReviewSynopsis { get; set; }

        public int AuthorId { get; set; }
    }
}
 