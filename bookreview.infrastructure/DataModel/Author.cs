using atomic.chicken.common.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace atomic.chicken.infrastructure.DataModel
{
    public class Author : BaseEntity
    {
        public int AuthorId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Forename { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Middlename { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Surname { get; set; }

        public AuthorType AuthorType { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}