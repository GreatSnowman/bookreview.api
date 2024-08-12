namespace atomic.chicken.infrastructure.DataModel
{
    public class Book : BaseEntity
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public string? Synoposis { get; set; }

        public string? ISBNThirteen { get; set; }

        public string? ISBNNine { get; set; }

        public string? Year { get;set; }

        public int? PublisherId { get; set; }

        public Publisher? Publisher { get; set; }
    }
}
