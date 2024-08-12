using atomic.chicken.common.Enum;

namespace atomic.chicken.common.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }

        public string? Forename { get; set; }

        public string? Surname { get; set; }

        public AuthorType AuthorType { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}