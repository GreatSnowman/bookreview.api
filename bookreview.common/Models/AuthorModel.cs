using bookreview.common.Enum;

namespace bookreview.common.Models
{
    public class AuthorModel : BaseModel
    {
         public AuthorModel()
         {
            Error = new ErrorModel();
         }

        public string? Forename { get; set; }

        public string? Surname { get; set; }

        public AuthorType AuthorType { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}