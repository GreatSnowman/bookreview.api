namespace bookreview.infrastructure.DataModel
{
    public class Tag
    {
        public int Id { get; set; }

        public string? TagDescription { get; set; }  

        public int BookId { get; set; }
    }
}