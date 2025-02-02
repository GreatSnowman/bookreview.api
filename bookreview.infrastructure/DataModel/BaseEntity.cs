namespace bookreview.infrastructure.DataModel
{
    public class BaseEntity
    {
        public DateTimeOffset CreatedDate { get; set; }

        public int CreatedId { get; set; }

        public DateTimeOffset UpdatedDate { get; set; }

        public int UpdatedId { get; set; }
    }
}