using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.infrastructure.DataModel
{
    public class Review
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public DateTimeOffset CreatedDate { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }
    }
}
 