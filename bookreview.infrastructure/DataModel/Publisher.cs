using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.infrastructure.DataModel
{
    public class Publisher : BaseEntity
    {
        public int PublisherId { get; set; }

        [Column(TypeName = "nvarchar(150)")]
        public string? Name { get; set; }

        public IEnumerable<Book> Books { get; set; } = [];
    }
}
