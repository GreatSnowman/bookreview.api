namespace bookreview.infrastructure.DataModel
{
    public class BookReview
    {
        public int Id { get; set; }

        public int AuthorId { get; set; }

        public string? ReviewContent { get; set; }

        public bool IsLive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public Author? Author { get; set; }

        public Book? Book { get; set; }
    }
}