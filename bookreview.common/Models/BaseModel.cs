namespace bookreview.common.Models
{
    public class BaseModel
    {
        public int Id { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public int CreatedId { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public int UpdatedId { get; set; }

        public ErrorModel Error { get; set; }
    }
}
