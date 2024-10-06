using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bookreview.common.Models
{
    public class BookReviewViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public List<string> Paragraphs { get; set; }

        public List<string> Tags { get; set; }

        public BookModel Book { get; set; }

        public AuthorModel BookAuthor { get; set; }

        public AuthorModel ReviewAuthor { get; set; }
    }
}
