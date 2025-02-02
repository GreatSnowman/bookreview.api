namespace bookreview.infrastructure.DataModel.LinkingTables
{
    public class BookReview : BaseEntity
    {
        public int BookId { get; set; }

        public int AuthorId { get; set; }

        public bool IsLive { get; set; }

        public Author Author { get; set; }

        public Book Book { get; set; }
    }
}