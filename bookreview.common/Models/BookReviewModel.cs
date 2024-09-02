namespace bookreview.common.Models
{
    public class BookReviewModel
    {
        public int Id { get; set; }

        public AuthorModel? BookAuthor { get; set; }

        public string? ReviewContent { get; set; }

        public List<TagModel>? Tags { get; set; }

        public AuthorModel? ReviewAuthor { get; set; }

        public BookModel? Book { get; set; }
    }
}
